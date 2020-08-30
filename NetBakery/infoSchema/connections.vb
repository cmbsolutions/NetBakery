Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Security.Cryptography
Imports System.Security
Imports System.Xml.Serialization
Imports System.Text.RegularExpressions

Namespace infoSchema
    <Serializable>
    Public Class connections
        Implements IList(Of connection)
        Implements IDisposable

        <System.Xml.Serialization.XmlArray("items")>
        Private _internal As List(Of connection)

        Public Sub New()
            If _internal Is Nothing Then _internal = New List(Of connection)
        End Sub

        Public ReadOnly Property Count As Integer Implements ICollection(Of connection).Count
            Get
                Return _internal.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of connection).IsReadOnly
            Get
                Return False
            End Get
        End Property

        Default Public Property Item(index As Integer) As connection Implements IList(Of connection).Item
            Get
                If index >= 0 AndAlso index < Count Then
                    Return _internal.Item(index)
                Else
                    Return Nothing
                End If
            End Get
            Set(value As connection)
                If index >= 0 AndAlso index < Count Then
                    _internal.Item(index) = value
                Else
                    Add(value)
                End If
            End Set
        End Property

        Public Sub Add(item As connection) Implements ICollection(Of connection).Add
            _internal.Add(item)
        End Sub

        Public Sub Clear() Implements ICollection(Of connection).Clear
            _internal.Clear()
        End Sub

        Public Sub CopyTo(array() As connection, arrayIndex As Integer) Implements ICollection(Of connection).CopyTo
            _internal.CopyTo(array, arrayIndex)
        End Sub

        Public Sub Insert(index As Integer, item As connection) Implements IList(Of connection).Insert
            _internal.Insert(index, item)
        End Sub

        Public Sub RemoveAt(index As Integer) Implements IList(Of connection).RemoveAt
            _internal.RemoveAt(index)
        End Sub

        Public Function Contains(item As connection) As Boolean Implements ICollection(Of connection).Contains
            Return _internal.Contains(item)
        End Function

        Public Function GetEnumerator() As IEnumerator(Of connection) Implements IEnumerable(Of connection).GetEnumerator
            Return _internal.GetEnumerator
        End Function

        Public Function IndexOf(item As connection) As Integer Implements IList(Of connection).IndexOf
            Return _internal.IndexOf(item)
        End Function

        Public Function Remove(item As connection) As Boolean Implements ICollection(Of connection).Remove
            Return _internal.Remove(item)
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return GetEnumerator()
        End Function

        Public Sub SaveToFile(file As IO.FileInfo)
            Try
                Dim formatter As New BinaryFormatter

                If Not file.Directory.Exists Then file.Directory.Create()

                Using data As New FileStream(file.FullName, FileMode.Create, FileAccess.Write, FileShare.None)
                    formatter.Serialize(data, _internal.Where(Function(c) Not c.fromNavicat).ToList)
                End Using

                formatter = Nothing
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub LoadFromFile(file As IO.FileInfo)
            Try
                _internal = New List(Of connection)

                If file.Exists Then
                    Dim formatter As New BinaryFormatter

                    Using data As New FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read)
                        _internal = CType(formatter.Deserialize(data), List(Of connection))
                    End Using
                    formatter = Nothing
                End If
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub LoadFromNavicat()
            Dim registryRoot As String = "Software\PremiumSoft\Navicat\Servers"

            Try
                Using mainReg = My.Computer.Registry.CurrentUser.OpenSubKey(registryRoot, False)
                    Dim RegexObj As New Regex("^(DEV|TST|APP|PRD) - (\w+)$", RegexOptions.IgnoreCase)

                    For Each entry In mainReg.GetSubKeyNames
                        If RegexObj.IsMatch(entry) Then
                            Using subKey = mainReg.OpenSubKey(entry)
                                _internal.Add(New connection With {
                                              .fromNavicat = True,
                                              .host = subKey.GetValue("Host").ToString,
                                              .user = subKey.GetValue("UserName").ToString,
                                              .pass = subKey.GetValue("Pwd").ToString,
                                              .description = entry,
                                              .sslmode = eSslMode.Required
                                              })
                            End Using
                        End If
                    Next

                End Using
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    _internal = Nothing
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class

    <Serializable>
    Public Class connection
        Property host As String
        Property user As String
        Property pass As String
        Property sslmode As eSslMode
        Property description As String

        <XmlIgnore()>
        Property fromNavicat As Boolean

        Public Sub setPass(ByVal p As String)
            Using security As New secure
                pass = security.EncryptData(p)
            End Using
        End Sub
        Public Function decryptedPass() As String
            If fromNavicat Then
                Using navi As New CMBSolutions.NavicatEncrypt
                    Return navi.Decrypt(pass)
                End Using
            Else
                Using security As New secure
                    Return security.DecryptData(pass)
                End Using
            End If
        End Function
        Public Overrides Function ToString() As String
            Return $"server={host};user id={user};password={decryptedPass()};allowuservariables=True;characterset=utf8;interactivesession=True;treattinyasboolean=False;compress=True;persistsecurityinfo=True;sslmode={sslmode.ToString}"
        End Function
    End Class

    <Serializable>
    Public Enum eSslMode
        Prefered
        Required
    End Enum

    Public NotInheritable Class secure
        Implements IDisposable

        Private TripleDes As New TripleDESCryptoServiceProvider

        Public Sub New()
            Try
                Using securePwd As New SecureString()

                    securePwd.AppendChar("k"c)
                    securePwd.AppendChar("8"c)
                    securePwd.AppendChar("H"c)
                    securePwd.AppendChar("E"c)
                    securePwd.AppendChar("s"c)
                    securePwd.AppendChar("!"c)
                    securePwd.AppendChar("U"c)
                    securePwd.AppendChar("p"c)

                    TripleDes.Key = TruncateHash(securePwd.ToString, TripleDes.KeySize \ 8)
                    TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub New(ByVal key As String)
            Try
                ' Initialize the crypto provider.
                TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
                TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
            Try
                Using sha1 As New SHA1CryptoServiceProvider

                    ' Hash the key.
                    Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
                    Dim hash() As Byte = sha1.ComputeHash(keyBytes)

                    ' Truncate or pad the hash.
                    ReDim Preserve hash(length - 1)
                    Return hash
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function EncryptData(ByVal plaintext As String) As String
            Try
                ' Convert the plaintext string to a byte array.
                Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)

                ' Create the stream.
                Using ms As New System.IO.MemoryStream
                    ' Create the encoder to write to the stream.
                    Using encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

                        ' Use the crypto stream to write the byte array to the stream.
                        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
                        encStream.FlushFinalBlock()
                    End Using

                    ' Convert the encrypted stream to a printable string.
                    Return Convert.ToBase64String(ms.ToArray)
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function DecryptData(ByVal encryptedtext As String) As String
            Try
                ' Convert the encrypted text string to a byte array.
                Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

                ' Create the stream.
                Using ms As New System.IO.MemoryStream
                    ' Create the decoder to write to the stream.
                    Using decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

                        ' Use the crypto stream to write the byte array to the stream.
                        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
                        decStream.FlushFinalBlock()
                    End Using
                    ' Convert the plaintext stream to a string.
                    Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean

        Protected Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    TripleDes.Dispose()
                End If
            End If
            disposedValue = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
#End Region
    End Class
End Namespace

Imports MySql.Data.MySqlClient
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Validator
Imports System.ComponentModel

Public Class connection_editor
    Property _conn As infoSchema.connections
    Private _currentConnection As infoSchema.connection = Nothing

    Public Sub loadConnection(_name As String)
        Try
            TitleText = "Edit connection"

            _currentConnection = _conn.Where(Function(c) c.description = _name).First

            txtDescription.Text = _currentConnection.description
            txtHost.Text = _currentConnection.host
            txtUser.Text = _currentConnection.user
            txtPassword.Text = _currentConnection.decryptedPass

            If _currentConnection.sslmode = infoSchema.eSslMode.Prefered Then
                sbSsl.Value = False
            Else
                sbSsl.Value = True
            End If

            btnDelete.Enabled = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtPassword_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtPassword.ButtonCustomClick
        If txtPassword.UseSystemPasswordChar Then
            txtPassword.PasswordChar = Nothing
            txtPassword.UseSystemPasswordChar = False
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
            txtPassword.PasswordChar = "*"c
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            If Not SuperValidator1.Validate() Then Exit Sub

            If _currentConnection IsNot Nothing Then
                _currentConnection.description = txtDescription.Text
                _currentConnection.host = txtHost.Text
                _currentConnection.user = txtUser.Text
                _currentConnection.setPass(txtPassword.Text)
                _currentConnection.sslmode = DirectCast([Enum].Parse(GetType(infoSchema.eSslMode), sbSsl.ValueObject.ToString), infoSchema.eSslMode)
            Else
                Dim c As New infoSchema.connection

                c.description = txtDescription.Text
                c.host = txtHost.Text
                c.user = txtUser.Text
                c.setPass(txtPassword.Text)
                c.sslmode = DirectCast([Enum].Parse(GetType(infoSchema.eSslMode), sbSsl.ValueObject.ToString), infoSchema.eSslMode)

                _conn.Add(c)
            End If

            SuperValidator1.Enabled = False

            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        SuperValidator1.Enabled = False
        DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnTryConnection_Click(sender As Object, e As EventArgs) Handles btnTryConnection.Click
        Try
            If Not SuperValidator1.Validate() Then Exit Sub

            Dim ver As String = ""
            Dim c As New infoSchema.connection

            c.description = txtDescription.Text
            c.host = txtHost.Text
            c.user = txtUser.Text
            c.setPass(txtPassword.Text)
            c.sslmode = DirectCast([Enum].Parse(GetType(infoSchema.eSslMode), sbSsl.ValueObject.ToString), infoSchema.eSslMode)

            Try
                Using conn As New MySqlConnection
                    conn.ConnectionString = c.ToString
                    conn.Open()

                    ver = conn.ServerVersion

                    conn.Close()

                    MessageBoxEx.Show(String.Format("Serverversion {0} found", ver), "Connection OK.", MessageBoxButtons.OK)
                End Using
            Catch mex As MySqlException
                MessageBoxEx.Show(mex.Message, String.Format("MySql error {0} occured.", mex.Number), MessageBoxButtons.OK)
            End Try

            c = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If _currentConnection IsNot Nothing Then
                If MessageBoxEx.Show("Are you sure you want to delete this connection?", "Delete connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    SuperValidator1.Enabled = False
                    _conn.Remove(_currentConnection)

                    DialogResult = System.Windows.Forms.DialogResult.OK
                    Close()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub isUniqueValidator_ValidateValue(sender As Object, e As ValidateValueEventArgs) Handles isUniqueValidator.ValidateValue
        Try
            If _conn.LongCount(Function(c) Not c.Equals(_currentConnection) AndAlso c.description = e.ControlToValidate.Text) <> 0 Then
                e.IsValid = False
            Else
                e.IsValid = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub connection_editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            StyleManager1.ManagerStyle = DirectCast([Enum].Parse(GetType(eStyle), My.Settings.gui_style), eStyle)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Enabled = False

            If Not txtPassword.UseSystemPasswordChar Then
                txtPassword.UseSystemPasswordChar = True
                txtPassword.PasswordChar = "*"c
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub connection_editor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            Dim frx = TryCast(sender, connection_editor)

            If frx.DialogResult = DialogResult.Cancel Then
                SuperValidator1.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class

Imports System.Collections.Specialized
Imports System.Windows.Forms

Public Class customDictionaryEdit

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Dim slist As New StringCollection

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    slist.Add(String.Format("{0}|{1}", row.Cells(0).Value.ToString, row.Cells(1).Value.ToString))
                End If
            Next

            My.Settings.customDictionary = slist
            My.Settings.Save()

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        Finally
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub customDictionaryEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DataGridView1.Rows.Clear()

            For Each dict In My.Settings.customDictionary
                DataGridView1.Rows.Add(dict.Split("|"c))
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
End Class

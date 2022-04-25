Imports System.Data.SqlClient
Public Class FormLogin
    Sub start()
        TextUsername.Text = ""
        TextPassword.Text = ""
        TextUsername.Focus()
        TextPassword.PasswordChar = "*"
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        If TextUsername.Text = "" Or
           TextPassword.Text = "" Then
            If MessageBox.Show("Tolong Masukkan Username dan Password terlebih dahulu", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.OK Then
            End If
        Else
            Call Connection()
            Dim CheckUser As String = "SELECT * FROM pengguna WHERE username = '" & TextUsername.Text & "' AND password = '" & TextPassword.Text & "'"
            cmd = New sqlcommand
        End If
    End Sub
End Class

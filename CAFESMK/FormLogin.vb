Imports System.Data.SqlClient
Public Class FormLogin
    Sub start()
        TextUsername.Text = ""
        TextPassword.Text = ""
        TextUsername.Focus()
        TextPassword.PasswordChar = "*"
    End Sub
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call start()
        TextUsername.Text = ""
        TextPassword.Text = ""
        TextUsername.Focus()
    End Sub
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        If TextUsername.Text = "" Or
           TextPassword.Text = "" Then
            If MessageBox.Show("Tolong Masukkan Username dan Password terlebih dahulu", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.OK Then
            End If
        Else
            Call Connection()
            Dim CheckUser As String = "SELECT * FROM pengguna WHERE username = '" & TextUsername.Text & "' AND password = '" & TextPassword.Text & "'"
            cmd = New SqlCommand(CheckUser, conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                If MessageBox.Show("USERNAME ATAU PASSWORD SALAH", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.OK Then
                End If
            ElseIf rd("jenis").ToString() = "admin" Then
                If MessageBox.Show("Login Berhasil", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                End If
                Me.Hide()
                FormHalamanUtama.Show()
                FormHalamanUtama.Label2.Text = "Selamat Datang, " & rd("nama")
                Call start()
            ElseIf rd("jenis").ToString() = "kasir" Then
                If MessageBox.Show("Login Berhasil", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                End If
                Me.Hide()
                FormHalamanUtamaKasir.Show()
                FormHalamanUtamaKasir.Label2.Text = "Selamat Datang, " & rd("nama")
                Call start()
            End If
            Call start()
        End If
    End Sub

    Private Sub TextPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextUsername.Text = "" Or
           TextPassword.Text = "" Then
                If MessageBox.Show("Tolong Masukkan Username dan Password terlebih dahulu", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.OK Then
                End If
            Else
                Call Connection()
                Dim CheckUser As String = "SELECT * FROM pengguna WHERE username = '" & TextUsername.Text & "' AND password = '" & TextPassword.Text & "'"
                cmd = New SqlCommand(CheckUser, conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If Not rd.HasRows Then
                    If MessageBox.Show("USERNAME ATAU PASSWORD SALAH", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.OK Then
                        Call start()
                    End If

                ElseIf rd("jenis").ToString() = "admin" Then
                    If MessageBox.Show("Login Berhasil", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                    End If
                    Me.Hide()
                    FormHalamanUtama.Show()
                    FormHalamanUtama.Label2.Text = "Selamat Datang, " & rd("nama")
                    Call start()
                ElseIf rd("jenis").ToString() = "kasir" Then
                    If MessageBox.Show("Login Berhasil", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                    End If
                    Me.Hide()
                    FormHalamanUtamaKasir.Show()
                    FormHalamanUtamaKasir.Label2.Text = "Selamat Datang, " & rd("nama")
                    Call start()
                End If
            End If
        End If
    End Sub
    Private Sub TextUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextUsername.KeyPress
        If e.KeyChar = Chr(13) Then
            TextPassword.Focus()
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextPassword.PasswordChar = ""
        Else TextPassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        If MessageBox.Show("Anda Yakin ingin keluar?", "Form Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            End
        End If
    End Sub
End Class

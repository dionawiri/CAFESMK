Imports System.ComponentModel

Public Class FormHalamanUtama
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormDataMenu.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FormDataPengguna.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FormDataMember.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormLaporanAdmin.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormChangePAssword.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Anda yakin ingin keluar?", "Logout Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = ShowDialog.Yes Then
            FormLogin.Show()
            FormLogin.TextUsername.Focus()
            Me.Hide()
        End If
    End Sub

    Private Sub FormHalamanUtama_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MessageBox.Show("Anda yakin ingin keluar?", "Logout Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = ShowDialog.Yes Then
            FormLogin.Show()
            FormLogin.TextUsername.Focus()
            Me.Hide()
        Else
            e.Cancel = True
        End If
    End Sub
End Class
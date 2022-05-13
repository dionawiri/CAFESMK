Imports System.Data.SqlClient
Public Class FormOrder

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FormPembayaran.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormLaporanKasir.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormChangePAssword.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Anda yakin ingin keluar?", "Logout Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            FormLogin.Show()
            FormLogin.TextUsername.Focus()
            Me.Hide()
        End If
    End Sub
    Sub start()
        Call Connection()
        da = New SqlDataAdapter("SELECT menu.id_menu, menu.nama, order_detail.id_detail, order_detail.id_order, order_detail.id_menu, order_detail.qty, order_detail.harga FROM menu INNER JOIN order_detail ON menu.id_menu  =  order_detail.id_menu", conn)
        ds = New DataSet
        dt = New DataTable
        ds.Clear()
        da.Fill(dt)
        DataGridView2.DataSource = (dt)
    End Sub

    Private Sub FormOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call start()
    End Sub
End Class
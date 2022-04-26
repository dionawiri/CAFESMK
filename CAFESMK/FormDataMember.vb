Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class FormDataMember
    Private Sub FormDataMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call start()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormDataMenu.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FormDataPengguna.Show()
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

    Private Sub FormDataMember_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MessageBox.Show("Anda yakin ingin keluar?", "Logout Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = ShowDialog.Yes Then
            FormLogin.Show()
            FormLogin.TextUsername.Focus()
            Me.Hide()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        FormTambahMember.Show()
        Me.Hide()
    End Sub
    Sub start()
        Call Connection()
        da = New SqlDataAdapter("SELECT * FROM member", conn)
        ds = New DataSet
        dt = New DataTable
        ds.Clear()
        da.Fill(dt)
        DataGridView1.DataSource = (dt)

        Button7.Enabled = False
        Button8.Enabled = False
        Button10.Enabled = False

        Button7.Text = "Ubah"
        Button8.Text = "Hapus"
        Button10.Text = "Batal"

        TextBox1.Enabled = False
        ComboBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox2.Enabled = False
    End Sub
    Sub empty()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox4.Text = ""
    End Sub
    Sub ReadyFill()
        TextBox1.Enabled = True
        ComboBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox2.Enabled = True
    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox4.Text = DataGridView1.Item(0, i).Value
        TextBox1.Text = DataGridView1.Item(1, i).Value
        ComboBox1.Text = DataGridView1.Item(2, i).Value
        TextBox2.Text = DataGridView1.Item(3, i).Value
        TextBox3.Text = DataGridView1.Item(4, i).Value
        ComboBox2.Text = DataGridView1.Item(5, i).Value

        Button7.Enabled = True
        Button8.Enabled = True
        Button10.Enabled = True
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Call start()
        Me.start()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If MessageBox.Show("Anda yakin ingin menghapus " & TextBox1.Text & "?", "Hapus data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = ShowDialog.Yes Then
            Call Connection()
            Dim Hapus As String = "DELETE member WHERE  id_member = '" & TextBox4.Text & "'"
            cmd = New SqlCommand(Hapus, conn)
            cmd.ExecuteNonQuery()
            If MessageBox.Show("Data Berhasil dihapus", "Hapus Data", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
            End If
            Call start()
            Call empty()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Button7.Text = "Ubah" Then
            Button7.Text = "Simpan"
            Button8.Enabled = False
            Call ReadyFill()
        Else
            Call Connection()
            Dim Ubah As String = "UPDATE member SET
                                    nama = '" & TextBox1.Text & "',
                                       jenis_kelamin = '" & ComboBox1.Text & "',
                                       email = '" & TextBox2.Text & "',
                                       no_hp = '" & TextBox3.Text & "',
                                       jenis = '" & ComboBox2.Text & "'
                                       WHERE id_member = '" & TextBox4.Text & "'"
            cmd = New SqlCommand(Ubah, conn)
            cmd.ExecuteNonQuery()
            If MessageBox.Show("Data Berhasil dirubah", "Ubah Data", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
            End If
            Call start()
            Call empty()

        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Call empty()
        Call start()
    End Sub
End Class
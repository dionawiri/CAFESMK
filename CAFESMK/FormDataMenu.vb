Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class FormDataMenu

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
    Sub start()
        Call Connection()
        da = New SqlDataAdapter("SELECT id_menu as No, nama, kategori, harga, photo FROM menu", conn)
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

        TextBox1.Enabled = False
        ComboBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False



    End Sub
    Sub empty()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        PictureBox1.ImageLocation = ""

    End Sub
    Sub ReadyFill()
        TextBox1.Enabled = True
        ComboBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.jfif;"
        OpenFileDialog1.ShowDialog()
        TextBox3.Text = OpenFileDialog1.FileName
        PictureBox1.ImageLocation = TextBox3.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub FormDataMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call start()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox4.Text = DataGridView1.Item(0, i).Value
        TextBox1.Text = DataGridView1.Item(1, i).Value
        ComboBox1.Text = DataGridView1.Item(2, i).Value
        TextBox2.Text = DataGridView1.Item(3, i).Value
        TextBox3.Text = DataGridView1.Item(4, i).Value
        PictureBox1.ImageLocation = TextBox3.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom

        Button7.Enabled = True
        Button8.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Button7.Text = "Ubah" Then
            Button7.Text = "Simpan"
            Button8.Enabled = False
            Button11.Enabled = True
            Call ReadyFill()
        Else
            Call Connection()
            Dim UbahData As String = "UPDATE menu SET
                                       nama = '" & TextBox1.Text & "',
                                       kategori = '" & ComboBox1.Text & "',
                                       harga = '" & TextBox2.Text & "',
                                       photo = '" & TextBox3.Text & "'
                                       WHERE id_menu = '" & TextBox4.Text & "'"
            cmd = New SqlCommand(UbahData, conn)
            cmd.ExecuteNonQuery()
            If MessageBox.Show("Data Berhasil dirubah", "Ubah Data", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
            End If
            Call start()
            Call empty()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If MessageBox.Show("Anda yakin ingin menghapus data?", "Ubah Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Call Connection()
            Dim HapusData As String = "Delete menu WHERE id_menu = '" & TextBox4.Text & "'"
            cmd = New SqlCommand(HapusData, conn)
            cmd.ExecuteNonQuery()
            If MessageBox.Show("Data Berhasil dihapus", "Hapus Data", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
            End If
            Call start()
            Call empty()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        FormTambahMenu.Show()
        Me.Hide()
    End Sub

    Private Sub FormDataMenu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FormHalamanUtama.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Call start()
        Call empty()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Call start()
    End Sub
End Class
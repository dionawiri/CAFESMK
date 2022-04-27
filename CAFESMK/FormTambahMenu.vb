Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class FormTambahMenu
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

    Sub start()
        Call Connection()
    End Sub
    Sub empty()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
    End Sub
    Sub readyfill()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True
    End Sub
    Private Sub FormTambahMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call start()
        Dim GID As String = "SELECT * FROM menu WHERE id_menu IN (select max (id_menu) FROM menu)"
        Dim AutoId As String
        Dim Count As Long
        cmd = New SqlCommand(GID, conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            AutoId = "1"
        Else
            Count = Microsoft.VisualBasic.Right(rd.GetInt32(0), 2) + 1
            AutoId = Microsoft.VisualBasic.Right("0" + Count, 2)

        End If
        TextBox4.Text = AutoId
        TextBox1.Focus()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.jfif;"
        OpenFileDialog1.ShowDialog()
        TextBox3.Text = OpenFileDialog1.FileName
        PictureBox1.ImageLocation = TextBox3.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call Connection()
        Dim InputData As String = "INSERT INTO menu VAlUES
                                       ('" & TextBox4.Text & "',
                                       '" & TextBox1.Text & "',
                                       '" & ComboBox1.Text & "',
                                       '" & TextBox2.Text & "',
                                       '" & TextBox3.Text & "'
                                       )"
        cmd = New SqlCommand(InputData, conn)
        cmd.ExecuteNonQuery()
        If MessageBox.Show("Data Berhasil ditambah", "tambah Data", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
        End If
        Call start()
        Me.Hide()
        FormDataMenu.Show()
        FormDataMenu.Activate()
    End Sub

    Private Sub FormTambahMenu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        FormDataMenu.Show()

    End Sub
End Class
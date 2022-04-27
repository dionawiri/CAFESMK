Imports System.Data.SqlClient
Public Class FormTambahPengguna
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormDataMenu.Show()
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
        Button7.Text = "Simpan"
        Button8.Text = "Batal"

        TextBox1.Enabled = True
        ComboBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox2.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
    End Sub
    Sub empty()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox1.Text = "" Or
           ComboBox1.Text = "" Or
           TextBox2.Text = "" Or
           TextBox3.Text = "" Or
           TextBox4.Text = "" Or
           TextBox5.Text = "" Or
           TextBox6.Text = "" Or
           ComboBox2.Text = "" Then
            If MessageBox.Show("isi semua data terlebih dahulu", "tambah Data", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
            End If
        Else
            Call Connection()
            Dim InputData As String = "INSERT INTO pengguna VALUES
                                       ('" & TextBox6.Text & "',
                                       '" & TextBox1.Text & "',
                                       '" & ComboBox1.Text & "',
                                       '" & TextBox2.Text & "',
                                       '" & TextBox3.Text & "',
                                       '" & TextBox5.Text & "',
                                       '" & TextBox4.Text & "',
                                       '" & ComboBox2.Text & "'
                                       )"
            cmd = New SqlCommand(InputData, conn)
            cmd.ExecuteNonQuery()
            If MessageBox.Show("Data Berhasil ditambah", "tambah Data", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
            End If
            Call start()
            Call empty()
            Me.Hide()
            FormDataPengguna.Show()
            FormDataPengguna.Activate()
        End If
    End Sub

    Private Sub FormTambahPengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call start()
        Dim GID As String = "SELECT * FROM pengguna WHERE id_pengguna IN (SELECT MAX (id_pengguna) FROM pengguna)"
        Dim AutoID As String
        Dim count As Long
        cmd = New SqlCommand(GID, conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            AutoID = Format(Now, "yyyy") + "001"
        Else
            count = Format(Now, "yyyy") + Microsoft.VisualBasic.Right(rd.GetInt32(0), 7) + 1
            AutoID = Microsoft.VisualBasic.Right("000" + count, 7)
        End If
        TextBox6.Text = AutoID
        TextBox1.Focus()
        TextBox5.PasswordChar = "*"
    End Sub
End Class
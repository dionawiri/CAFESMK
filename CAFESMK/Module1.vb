Imports System.Data.SqlClient
Module Module1
    Public conn As SqlConnection
    Public da As SqlDataAdapter
    Public ds As DataSet
    Public dt As DataTable
    Public cmd As SqlCommand
    Public rd As SqlDataReader
    Public mydb As String
    Sub Connection()
        mydb = "Data source=DESKTOP-IF7V1AR\SQLEXPRESS; initial catalog=CAFESMK; integrated security=true"
        conn = New SqlConnection(mydb)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
End Module


Imports MySql.Data.MySqlClient
Module connection
    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public ds As New DataSet
    Public dt As New DataTable
    Public dr As MySqlDataReader

    Public Sub conOpen()
        If conn.State = System.Data.ConnectionState.Open Then conn.Close()

        Try
            conn.ConnectionString = "server=localhost;username=root;password=;database=ffposis.db"
            conn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: Can't Connect to the database. Program will close", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Module

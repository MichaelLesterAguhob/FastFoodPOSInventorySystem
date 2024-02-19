
Imports MySql.Data.MySqlClient

Public Class operationRecord
    Private Sub operationRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Dim cmdOpr As New MySqlCommand
    Dim daOpr As New MySqlDataAdapter
    Dim dtOpr As New DataTable

    Sub loadData()
        Try
            conOpen()
            cmdOpr.Connection = conn
            cmdOpr.CommandText = "SELECT * FROM started_ended ORDER BY dayNum ASC"
            daOpr.SelectCommand = cmdOpr
            dtOpr.Clear()
            daOpr.Fill(dtOpr)
            DataGridView1.DataSource = dtOpr

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on loading data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

End Class
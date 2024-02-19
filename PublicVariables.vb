Module PublicVariables
    Public accountLoggedInStat As String
    Public accountLoggedIn As String
    Public programStarted As String = "FALSE"
    Public accountID As Integer
    Public dayStarted As Integer = 0
    Public started_ended As String = "FALSE"

    Public Sub refresher()
        SalesRecord.LoadTodaySalesData()
        TransactionsRecords.loadTransData()
        Modify_Food_Menu.loadData()
        InventoryForm.loadInventory()
    End Sub



End Module

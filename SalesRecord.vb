Imports MySql.Data.MySqlClient
Public Class SalesRecord

    Private Sub SalesRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        dateLbl.Text = DateTime.Now.ToLongDateString
        LoadTodaySalesData()
    End Sub

    ' ///////////////////////////          MY MAIN CODES         /////////////////////////
    Dim cmdSales As New MySqlCommand
    Dim dtSales As New DataTable
    Dim daSales As New MySqlDataAdapter

    ' LOADING ALL DATA FROM DATABASE INTO DATAGRID VEIW WHERE DATE IS TODAY
    Public Sub LoadTodaySalesData()

        Try
            conOpen()
            cmdSales.Connection = conn
            cmdSales.CommandText = "SELECT * FROM soldtbl WHERE dateOrdered = '" & dateLbl.Text & "'order by soldNo asc"
            daSales.SelectCommand = cmdSales
            dtSales.Clear()
            daSales.Fill(dtSales)
            dgv1.DataSource = dtSales
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Loading Sales Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Sub loadRefundedRec()
        Dim cmdSale As New MySqlCommand
        Dim dtSale As New DataTable
        Dim daSale As New MySqlDataAdapter
        Try
            conOpen()
            cmdSale.Connection = conn
            cmdSale.CommandText = "SELECT * FROM refunditem_table ORDER BY soldNum ASC"

            daSale.SelectCommand = cmdSale
            dtSale.Clear()
            daSale.Fill(dtSale)
            dgv2.DataSource = dtSale

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading data from refunditem table", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    ' LOADING ALL DATA FROM DATABASE INTO DATAGRIDVIEW
    Public Sub LoadSalesData()

        Try
            conOpen()
            cmdSales.Connection = conn
            cmdSales.CommandText = "SELECT * FROM soldtbl order by soldNo asc"
            daSales.SelectCommand = cmdSales
            dtSales.Clear()
            daSales.Fill(dtSales)
            dgv1.DataSource = dtSales
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Loading Sales Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub viewAllBtn_Click(sender As Object, e As EventArgs) Handles viewAllBtn.Click
        LoadSalesData()
    End Sub

    ' BUTTON TO SHOW CRYSTAL REPORTS
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim reprts As New Reports
        reprts.Show()

        Dim reports As New CrystalReport1
        reports.SetDataSource(dtSales)
        reprts.CrystalReportViewer1.ReportSource = reports

    End Sub

    Private Sub searchtxt_TextChanged(sender As Object, e As EventArgs) Handles searchtxt.TextChanged
        If searchtxt.Text <> "" Then
            If cBox1.Text = "SOLD#" Then
                Try
                    conOpen()
                    cmdSales.Connection = conn
                    cmdSales.CommandText = "SELECT * FROM soldtbl WHERE soldNo LIKE '%" & searchtxt.Text.Trim & "%' ORDER BY soldNo ASC"
                    daSales.SelectCommand = cmdSales
                    dtSales.Clear()
                    daSales.Fill(dtSales)
                    dgv1.DataSource = dtSales

                    conn.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR : Searching By Sold#", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try

            ElseIf cBox1.Text = "TRANS#" Then
                Try
                    conOpen()
                    cmdSales.Connection = conn
                    cmdSales.CommandText = "SELECT * FROM soldtbl WHERE transNo LIKE '%" & searchtxt.Text & "%' ORDER BY soldNo ASC"
                    daSales.SelectCommand = cmdSales
                    dtSales.Clear()
                    daSales.Fill(dtSales)
                    dgv1.DataSource = dtSales

                    conn.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR : Searching By Trans#", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try

            ElseIf cBox1.Text = "DATE" Then
                Try
                    conOpen()
                    cmdSales.Connection = conn
                    cmdSales.CommandText = "SELECT * FROM soldtbl WHERE dateOrdered LIKE '%" & searchtxt.Text & "%' ORDER BY soldNo ASC"
                    daSales.SelectCommand = cmdSales
                    dtSales.Clear()
                    daSales.Fill(dtSales)
                    dgv1.DataSource = dtSales

                    conn.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR : Searching By Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try

            ElseIf cBox1.Text = "TIME" Then
                Try
                    conOpen()
                    cmdSales.Connection = conn
                    cmdSales.CommandText = "SELECT * FROM soldtbl WHERE timeOrdered LIKE '%" & searchtxt.Text & "%'  ORDER BY soldNo ASC"
                    daSales.SelectCommand = cmdSales
                    dtSales.Clear()
                    daSales.Fill(dtSales)
                    dgv1.DataSource = dtSales

                    conn.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR : Searching By Time", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try
            End If
        Else
            LoadSalesData()
        End If

    End Sub


    ' /////////////////       BASIC CODES            //////////////////////////

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timeLbl.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Private Sub todayRecordsBtn_Click(sender As Object, e As EventArgs) Handles todayRecordsBtn.Click
        LoadTodaySalesData()

    End Sub

    Private Sub cBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBox1.SelectedIndexChanged
        searchtxt.Clear()
        searchtxt.Focus()
    End Sub

    Private Sub refund_Click(sender As Object, e As EventArgs) Handles refund.Click
        If soldNoTxt.Text = "" Then
            MessageBox.Show("No Selected Row", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                Dim ordrName As String
                Dim takeOut As String
                Dim dateOrder As String
                Dim timeOrder As String
                Dim transNum As Integer
                Dim tableNo As Integer
                Dim soldNum As Integer
                Dim orderPrice As Integer
                Dim orderQnty As Integer
                Dim subTotal As Integer

                conOpen()

                cmdSales.Connection = conn
                cmdSales.CommandText = "SELECT soldNo FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                soldNum = cmdSales.ExecuteScalar

                cmdSales.Connection = conn
                cmdSales.CommandText = "SELECT transNo FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                transNum = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT orderName FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                ordrName = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT orderQuantity FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                orderQnty = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT orderPrice FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                orderPrice = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT subTotal FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                subTotal = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT takeOut FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                takeOut = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT tableNo FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                tableNo = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT dateOrdered FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                dateOrder = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT timeOrdered FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "' "
                timeOrder = cmdSales.ExecuteScalar

                conn.Close()

                ' UPDATING THE INVENTORY - ADDING THE REFUNDED QUANTITY TO INVENTORY
                conOpen()
                cmdSales.Connection = conn
                cmdSales.CommandText = "SELECT quantity FROM foodmenu WHERE name = '" & ordrName & "'"
                Dim qntyInv As Integer = cmdSales.ExecuteScalar
                qntyInv += orderQnty

                cmdSales.CommandText = "UPDATE foodmenu SET `quantity`='" & qntyInv & "' WHERE name = '" & ordrName & "'"
                cmdSales.ExecuteNonQuery()

                ' INSERTING THE SOLD ITEM FROM SOLDTBL TABLE INTO REFUNDED TABLE
                cmdSales.CommandText = "INSERT INTO refunditem_table (`soldNum`,`transNo`,`orderName`,`orderQuantity`,`orderPrice`,`subTotal`,`takeOut`,`tableNo`,`dateOrdered`,`timeOrdered`)
                            VALUES ('" & soldNoTxt.Text & "', '" & transNum & "','" & ordrName & "','" & orderQnty & "',
                            '" & orderPrice & "','" & subTotal & "','" & takeOut & "','" & tableNo & "','" & dateOrder & "',
                            '" & timeOrder & "')"
                cmdSales.ExecuteNonQuery()

                ' DELETING SOLD ITEM FROM SOLD TABLE IN DATABASE ONCE IT IS REFUNDED
                cmdSales.CommandText = "DELETE FROM soldtbl WHERE soldNo = '" & soldNoTxt.Text & "'"
                cmdSales.ExecuteNonQuery()

                conn.Close()

                refresher()
                refund.Enabled = False
                soldNoTxt.Clear()
                loadRefundedRec()
                LoadSalesData()
                MessageBox.Show("Successfully Refunded", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Refund", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub undoRefundBtn_Click(sender As Object, e As EventArgs) Handles undoRefundBtn.Click

        If soldNumRefTxt.Text = "" Then
            MessageBox.Show("No Record Selected", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                Dim ordrName As String
                Dim takeOut As String
                Dim dateOrder As String
                Dim timeOrder As String
                Dim transNum As Integer
                Dim tableNo As Integer
                Dim soldNum As Integer
                Dim orderPrice As Integer
                Dim orderQnty As Integer
                Dim subTotal As Integer

                conOpen()

                cmdSales.Connection = conn
                cmdSales.CommandText = "SELECT soldNum FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                soldNum = cmdSales.ExecuteScalar

                cmdSales.Connection = conn
                cmdSales.CommandText = "SELECT transNo FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                transNum = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT orderName FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                ordrName = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT orderQuantity FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                orderQnty = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT orderPrice FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                orderPrice = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT subTotal FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                subTotal = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT takeOut FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                takeOut = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT tableNo FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                tableNo = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT dateOrdered FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                dateOrder = cmdSales.ExecuteScalar

                cmdSales.CommandText = "SELECT timeOrdered FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "' "
                timeOrder = cmdSales.ExecuteScalar

                conn.Close()

                ' UPDATING THE INVENTORY - SUBTRACTING THE UNDO REFUND ITEM'S QUANTITY TO INVENTORY
                conOpen()
                cmdSales.Connection = conn
                cmdSales.CommandText = "SELECT quantity FROM foodmenu WHERE name = '" & ordrName & "'"
                Dim qntyInv As Integer = cmdSales.ExecuteScalar
                qntyInv -= orderQnty

                cmdSales.CommandText = "UPDATE foodmenu SET `quantity`='" & qntyInv & "' WHERE name = '" & ordrName & "'"
                cmdSales.ExecuteNonQuery()

                ' INSERTING THE SOLD ITEM FROM refunditem_table BACK INTO soldtbl TABLE
                cmdSales.CommandText = "INSERT INTO soldtbl (`soldNo`,`transNo`,`orderName`,`orderQuantity`,`orderPrice`,`subTotal`,`takeOut`,`tableNo`,`dateOrdered`,`timeOrdered`)
                            VALUES ('" & soldNum & "', '" & transNum & "','" & ordrName & "','" & orderQnty & "',
                            '" & orderPrice & "','" & subTotal & "','" & takeOut & "','" & tableNo & "','" & dateOrder & "',
                            '" & timeOrder & "')"
                cmdSales.ExecuteNonQuery()

                ' DELETING SOLD ITEM FROM refunditem_table IN DATABASE ONCE IT IS undo refund
                cmdSales.CommandText = "DELETE FROM refunditem_table WHERE soldNum = '" & soldNumRefTxt.Text & "'"
                cmdSales.ExecuteNonQuery()

                conn.Close()

                refresher()
                undoRefundBtn.Visible = False
                soldNumRefTxt.Clear()
                loadRefundedRec()
                LoadSalesData()
                MessageBox.Show("Successfully Undo Refund", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Refund", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Dim i As Integer = dgv1.CurrentRow.Index
        soldNoTxt.Text = dgv1.Item(0, i).Value

    End Sub
    Private Sub dgv2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentClick
        Dim i As Integer = dgv2.CurrentRow.Index
        soldNumRefTxt.Text = dgv2.Item(0, i).Value
    End Sub

    Private Sub soldNoTxt_TextChanged(sender As Object, e As EventArgs) Handles soldNoTxt.TextChanged
        If soldNoTxt.Text <> "" Then
            refund.Enabled = True
        Else
            refund.Enabled = False
        End If
    End Sub

    Dim close_open As String = "Close"
    Private Sub refundedBtn_Click(sender As Object, e As EventArgs) Handles refundedBtn.Click
        loadRefundedRec()
        If close_open = "Close" Then
            Panel5.Width = 1022
            close_open = "Open"
            refundedBtn.Text = "CLOSE"

        ElseIf close_open = "Open" Then
            soldNumRefTxt.Clear()
            Panel5.Width = 0
            close_open = "Close"
            refundedBtn.Text = "VIEW REFUNDED"

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel5.Width = 0
        soldNumRefTxt.Clear()
        close_open = "Close"
        refundedBtn.Text = "VIEW REFUNDED"
    End Sub

    Private Sub soldNumRefTxt_TextChanged(sender As Object, e As EventArgs) Handles soldNumRefTxt.TextChanged

        If soldNumRefTxt.Text = "" Then
            undoRefundBtn.Visible = False
        Else
            undoRefundBtn.Visible = True

        End If
    End Sub


End Class
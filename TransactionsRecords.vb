
Imports MySql.Data.MySqlClient


Public Class TransactionsRecords
    Private Sub TransactionsRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTransData()
        Timer1.Start()
        dateLbl.Text = DateTime.Now.ToLongDateString
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timeLbl.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Dim cmdTrans As New MySqlCommand
    Dim daTrans As New MySqlDataAdapter
    Dim dtTrans As New DataTable


    ' ////////// MY FUNCTIONS SECTION ///////////////
    Public Sub loadTransData()
        Try
            conOpen()
            cmdTrans.Connection = conn
            cmdTrans.CommandText = "SELECT * FROM transactions ORDER BY transNO ASC"
            daTrans.SelectCommand = cmdTrans
            dtTrans.Clear()
            daTrans.Fill(dtTrans)
            dgv1.DataSource = dtTrans

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Loading Sales Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try

    End Sub

    Private Sub refundedBtn_Click(sender As Object, e As EventArgs) Handles refundedBtn.Click
        Try
            conOpen()
            cmdTrans.Connection = conn
            cmdTrans.CommandText = "SELECT * FROM transactions WHERE refundStat = '" & "Refunded" & "' ORDER BY transNO ASC"
            daTrans.SelectCommand = cmdTrans
            dtTrans.Clear()
            daTrans.Fill(dtTrans)
            dgv1.DataSource = dtTrans

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on viewing refunded")
            conn.Close()
        End Try
    End Sub

    Private Sub todayTransBtn_Click(sender As Object, e As EventArgs) Handles todayTransBtn.Click
        Try
            conOpen()
            cmdTrans.Connection = conn
            cmdTrans.CommandText = "SELECT * FROM transactions WHERE dateOrdered = '" & dateLbl.Text & "' ORDER BY transNO ASC"
            daTrans.SelectCommand = cmdTrans
            dtTrans.Clear()
            daTrans.Fill(dtTrans)
            dgv1.DataSource = dtTrans

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on viewing refunded")
            conn.Close()
        End Try
    End Sub

    Private Sub viewAllRecBtn_Click(sender As Object, e As EventArgs) Handles viewAllRecBtn.Click
        loadTransData()
    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Dim i As Integer = dgv1.CurrentRow.Index
        transNoLbl.Text = dgv1.Item(0, i).Value.ToString
        orderDetailLbl.Text = dgv1.Item(2, i).Value.ToString
        orderTotalLbl.Text = dgv1.Item(3, i).Value.ToString

        If Not String.IsNullOrEmpty(dgv1.Item(7, i).Value.ToString) Then
            reasonTxt.Text = dgv1.Item(7, i).Value
        Else
            reasonTxt.Text = "NONE"
        End If

    End Sub

    Dim orderDet As String
    Dim subTot As Integer

    Private Sub refundBtn_Click(sender As Object, e As EventArgs) Handles refundBtn.Click

        If transNoLbl.Text = "0" Then
            MessageBox.Show("Select first the transaction you want to refund", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        ElseIf transNoLbl.Text <> "0" Then
            Try
                conOpen()
                cmdTrans.Connection = conn
                cmdTrans.CommandText = "SELECT refundStat FROM transactions WHERE transNO = '" & transNoLbl.Text & "'"
                Dim refundStatus As String = cmdTrans.ExecuteScalar
                conn.Close()

                If refundStatus = "Refunded" Then
                    MessageBox.Show("This transaction is already refunded", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    refundReasonPanelinput.Width = 457
                    refundReasontxt.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on refund ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try

        End If
    End Sub

    Dim minSoldNum As Integer
    Dim minSoldNumRef As Integer

    Sub selectSoldwMinNum()
        Try
            conOpen()
            cmdTrans.Connection = conn
            cmdTrans.CommandText = "SELECT IFNULL(MIN(soldNo),0) FROM soldtbl WHERE transNo = '" & transNoLbl.Text & "'"
            minSoldNum = cmdTrans.ExecuteScalar
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Selecting Min Sold Num", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Dim maxSoldNum As Integer
    Sub selectSoldwMaxNum()
        Try
            conOpen()
            cmdTrans.Connection = conn
            cmdTrans.CommandText = "SELECT IFNULL(MAX(soldNo),0) FROM soldtbl WHERE transNo = '" & transNoLbl.Text & "'"
            maxSoldNum = cmdTrans.ExecuteScalar
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Selecting MAX Sold Num", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Sub deleteSoldwMinNum()
        Try
            conOpen()
            cmdTrans.Connection = conn
            cmdTrans.CommandText = "DELETE FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "'"
            cmdTrans.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on deleting Min Sold Num", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    ' CODE FOR REFUND NOW BUTTON
    Private Sub refundNowBtn_Click(sender As Object, e As EventArgs) Handles refundNowBtn.Click

        If refundReasontxt.Text = "" Then
            MessageBox.Show("Write a short reason to this refund ", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information)
            refundReasontxt.Focus()
        Else

            Dim confirm As New DialogResult
            confirm = MessageBox.Show("Are you sure you want to refund this selected Transaction? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If confirm = DialogResult.Yes Then
                Try
                    conOpen()
                    cmdTrans.Connection = conn
                    cmdTrans.CommandText = "SELECT orderDetails FROM transactions WHERE transNO = '" & transNoLbl.Text & "'"
                    orderDet = cmdTrans.ExecuteScalar
                    cmdTrans.CommandText = "SELECT ordertotal FROM transactions WHERE transNO = '" & transNoLbl.Text & "'"
                    subTot = cmdTrans.ExecuteScalar
                    conn.Close()

                    conOpen()
                    cmdTrans.Connection = conn
                    cmdTrans.CommandText = "INSERT INTO refunded_table (`transNO`,`orderDetails`,`subTotal`)
                VALUES ('" & transNoLbl.Text & "', '" & orderDet & "','" & subTot & "')"
                    cmdTrans.ExecuteNonQuery()
                    conn.Close()

                    conOpen()
                    cmdTrans.Connection = conn
                    cmdTrans.CommandText = "UPDATE transactions SET orderTotal = 0, `refundStat`='" & "Refunded" & "' , `reasonRefund`='" & refundReasontxt.Text & "'WHERE transNo ='" & transNoLbl.Text & "' "
                    cmdTrans.ExecuteNonQuery()
                    conn.Close()

                    ' TRANSFERING DATA OF SOLD FOODITEM TO STORAGE [ FOR FUTURE USE LIKE UNDO REFUND ]
                    selectSoldwMaxNum()
                    selectSoldwMinNum()

                    Dim ordrName As String
                    Dim takeOut As String
                    Dim tableNo As Integer
                    Dim dateOrder As String
                    Dim timeOrder As String

                    Dim soldNum As Integer
                    Dim orderPrice As Integer
                    Dim orderQnty As Integer
                    Dim subTotal As Integer

                    While minSoldNum <> 0 And maxSoldNum <> 0

                        ' SELECTING COLUMN FROM SOLDTBL THAT WILL TRANSFER TO REFUND TABLE ONCE IT IS REFUNDED
                        Try
                            conOpen()

                            cmdTrans.Connection = conn
                            cmdTrans.CommandText = "SELECT soldNo FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "' "
                            soldNum = cmdTrans.ExecuteScalar

                            cmdTrans.CommandText = "SELECT orderName FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "' "
                            ordrName = cmdTrans.ExecuteScalar

                            cmdTrans.CommandText = "SELECT orderQuantity FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "' "
                            orderQnty = cmdTrans.ExecuteScalar

                            cmdTrans.CommandText = "SELECT orderPrice FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "' "
                            orderPrice = cmdTrans.ExecuteScalar

                            cmdTrans.CommandText = "SELECT subTotal FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "' "
                            subTotal = cmdTrans.ExecuteScalar

                            cmdTrans.CommandText = "SELECT takeOut FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "' "
                            takeOut = cmdTrans.ExecuteScalar

                            cmdTrans.CommandText = "SELECT tableNo FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "' "
                            tableNo = cmdTrans.ExecuteScalar

                            cmdTrans.CommandText = "SELECT dateOrdered FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "' "
                            dateOrder = cmdTrans.ExecuteScalar

                            cmdTrans.CommandText = "SELECT timeOrdered FROM soldtbl WHERE soldNo = '" & minSoldNum & "' AND transNo = '" & transNoLbl.Text & "' "
                            timeOrder = cmdTrans.ExecuteScalar

                            conn.Close()

                            ' UPDATING THE INVENTORY - ADDING THE REFUNDED QUANTITY TO INVENTORY
                            conOpen()
                            cmdTrans.Connection = conn
                            cmdTrans.CommandText = "SELECT quantity FROM foodmenu WHERE name = '" & ordrName & "'"
                            Dim qntyInv As Integer = cmdTrans.ExecuteScalar
                            qntyInv += orderQnty

                            cmdTrans.CommandText = "UPDATE foodmenu SET `quantity`='" & qntyInv & "' WHERE name = '" & ordrName & "'"
                            cmdTrans.ExecuteNonQuery()

                            ' INSERTING THE SOLD ITEM FROM SOLDTBL TABLE INTO REFUNDED TABLE
                            cmdTrans.CommandText = "INSERT INTO refunditem_table (`soldNum`,`transNo`,`orderName`,`orderQuantity`,`orderPrice`,`subTotal`,`takeOut`,`tableNo`,`dateOrdered`,`timeOrdered`)
                            VALUES ('" & minSoldNum & "', '" & transNoLbl.Text & "','" & ordrName & "','" & orderQnty & "',
                            '" & orderPrice & "','" & subTotal & "','" & takeOut & "','" & tableNo & "','" & dateOrder & "',
                            '" & timeOrder & "')"
                            cmdTrans.ExecuteNonQuery()
                            conn.Close()

                            deleteSoldwMinNum()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error on WhileLoop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            conn.Close()
                        End Try

                        selectSoldwMinNum()
                        selectSoldwMaxNum()
                    End While
                    refundReasonPanelinput.Width = 0
                    refresher()
                    MessageBox.Show("Successfully Refunded", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error on refund command", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try
            End If

        End If

    End Sub

    Private Sub cancelRefund_Click(sender As Object, e As EventArgs) Handles cancelRefund.Click
        refundReasonPanelinput.Width = 0
    End Sub

    ' FUNCTION FOR UNDOING REFUND [ BRINGING BACK SOLD ITEM FROM REFUNDED TABLE TO SOLD TABLE IN DATABASE]
    Dim refMinSoldNum As Integer
    Sub RefwMinSoldNum()
        Try
            ' Getting the refunded fooditem with minimun sold number
            conOpen()
            cmdTrans.Connection = conn
            cmdTrans.CommandText = "SELECT IFNULL(MIN(soldNum),0) FROM refunditem_table WHERE transNO = '" & transNoLbl.Text & "' "
            refMinSoldNum = cmdTrans.ExecuteScalar
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR on undoRefwMinSoldNum()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Sub bringBackRefundedItem()

        Dim ordrName As String
        Dim takeOut As String
        Dim tableNo As Integer
        Dim dateOrder As String
        Dim timeOrder As String

        Dim soldNum As Integer
        Dim orderPrice As Integer
        Dim orderQnty As Integer
        Dim subTotal As Integer

        RefwMinSoldNum()

        While refMinSoldNum <> 0
            Try
                conOpen()
                cmdTrans.Connection = conn

                cmdTrans.CommandText = "SELECT soldNum FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "'  "
                soldNum = cmdTrans.ExecuteScalar

                cmdTrans.CommandText = "SELECT orderName FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "'  "
                ordrName = cmdTrans.ExecuteScalar

                cmdTrans.CommandText = "SELECT orderQuantity FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "'  "
                orderQnty = cmdTrans.ExecuteScalar

                cmdTrans.CommandText = "SELECT orderPrice FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "' "
                orderPrice = cmdTrans.ExecuteScalar

                cmdTrans.CommandText = "SELECT subTotal FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "'  "
                subTotal = cmdTrans.ExecuteScalar

                cmdTrans.CommandText = "SELECT takeOut FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "'  "
                takeOut = cmdTrans.ExecuteScalar

                cmdTrans.CommandText = "SELECT tableNo FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "'  "
                tableNo = cmdTrans.ExecuteScalar

                cmdTrans.CommandText = "SELECT dateOrdered FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "'  "
                dateOrder = cmdTrans.ExecuteScalar

                cmdTrans.CommandText = "SELECT timeOrdered FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "'  "
                timeOrder = cmdTrans.ExecuteScalar
                conn.Close()

                ' UPDATING THE INVENTORY - ADDING THE REFUNDED QUANTITY TO INVENTORY
                conOpen()
                cmdTrans.Connection = conn
                cmdTrans.CommandText = "SELECT quantity FROM foodmenu WHERE name = '" & ordrName & "'"
                Dim qntyInv As Integer = cmdTrans.ExecuteScalar
                qntyInv -= orderQnty

                cmdTrans.CommandText = "UPDATE foodmenu SET `quantity`='" & qntyInv & "' WHERE name = '" & ordrName & "'"
                cmdTrans.ExecuteNonQuery()
                conn.Close()

                ' INSERTING INTO SOLDTBL TABLE INTO REFUNDED TABLE
                conOpen()
                cmdTrans.CommandText = "INSERT INTO soldtbl (`soldNo`,`transNo`,`orderName`,`orderQuantity`,`orderPrice`,`subTotal`,`takeOut`,`tableNo`,`dateOrdered`,`timeOrdered`)
                            VALUES ('" & refMinSoldNum & "', '" & transNoLbl.Text & "','" & ordrName & "','" & orderQnty & "',
                            '" & orderPrice & "','" & subTotal & "','" & takeOut & "','" & tableNo & "','" & dateOrder & "',
                            '" & timeOrder & "')"
                cmdTrans.ExecuteNonQuery()
                conn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR on bringBackRefundedItem()", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try

            conOpen()
            cmdTrans.Connection = conn
            cmdTrans.CommandText = "DELETE FROM refunditem_table WHERE soldNum = '" & refMinSoldNum & "'"
            cmdTrans.ExecuteNonQuery()
            conn.Close()

            RefwMinSoldNum()
        End While

    End Sub

    ' CODE FOR UNDOING REFUND 
    Private Sub undoRefundBtn_Click(sender As Object, e As EventArgs) Handles undoRefundBtn.Click

        If transNoLbl.Text = "0" Then
            MessageBox.Show("No record selected.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim rfndSt As String
            Try
                conOpen()
                cmdTrans.Connection = conn
                cmdTrans.CommandText = "SELECT refundStat FROM transactions WHERE transNO = '" & transNoLbl.Text & "'"
                rfndSt = cmdTrans.ExecuteScalar
                conn.Close()

                If rfndSt = "NO" Then
                    MessageBox.Show("This Transaction is not yet Refunded.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    ' GET DATA SAVED IN REFUNDED TABLE AND TRANSFER TO TRANSACTION TABLE [ UNDOING REFUND ]
                    Try
                        conOpen()
                        cmdTrans.Connection = conn
                        cmdTrans.CommandText = "SELECT subTotal FROM refunded_Table WHERE transNo = '" & transNoLbl.Text & "'"
                        Dim subTotRef As Integer = cmdTrans.ExecuteScalar

                        cmdTrans.CommandText = "UPDATE transactions SET `orderTotal`='" & subTotRef & "', refundStat='" & "NO" & "' , reasonRefund='" & "NONE" & "' WHERE transNo='" & transNoLbl.Text & "'"
                        cmdTrans.ExecuteNonQuery()

                        cmdTrans.CommandText = "DELETE FROM refunded_Table WHERE transNo = '" & transNoLbl.Text & "'"
                        cmdTrans.ExecuteNonQuery()
                        conn.Close()

                        bringBackRefundedItem()
                        refresher()
                        MessageBox.Show("Successfully Undo Refund", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "ERROR on Undoing Refund", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        conn.Close()
                    End Try
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR on Getting Refund Stat", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub searchtxt_TextChanged(sender As Object, e As EventArgs) Handles searchtxt.TextChanged

        If searchtxt.Text <> "" Then
            Try
                conOpen()
                cmdTrans.Connection = conn
                cmdTrans.CommandText = "SELECT * FROM transactions WHERE transNO LIKE '%" & searchtxt.Text.Trim & "%' ORDER BY transNO ASC"
                daTrans.SelectCommand = cmdTrans
                dtTrans.Clear()
                daTrans.Fill(dtTrans)
                dgv1.DataSource = dtTrans

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Searching Transaction Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        Else
            loadTransData()
        End If

    End Sub
End Class
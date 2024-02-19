Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximizeBox = True
        disabler()
        mainFormLoad()

    End Sub

    Sub startedStat()
        Dim cmdStrtd As New MySqlCommand
        Dim dayNum As Integer

        Try
            conOpen()
            cmdStrtd.Connection = conn
            cmdStrtd.CommandText = "SELECT IFNULL(MAX(dayNum),0) FROM started_ended WHERE date = '" & dateLbl.Text & "'"
            dayNum = cmdStrtd.ExecuteScalar
            conn.Close()

            If dayNum > 0 Then
                enabler()
                MessageBox.Show("System recently openned and started day.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error | started Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Public Sub mainFormLoad()

        If accountLoggedInStat = "GUEST MODE" Then
            accountLbl.Text = "GUEST MODE"

            FoodMenuItemToolStripMenuItem.Enabled = False
            ModifyFoodMenuToolStripMenuItem.Enabled = False
            InventoryToolStripMenuItem.Enabled = False

            BusinessOperationToolStripMenuItem.Enabled = False
            TransactionToolStripMenuItem.Enabled = False
            SalesToolStripMenuItem.Enabled = False
            OperationsToolStripMenuItem.Enabled = False

            AccountInfoToolStripMenuItem.Visible = False
            AccountInfoToolStripMenuItem.Enabled = False

            MyAccountToolStripMenuItem.Enabled = False
            LogOutToolStripMenuItem.Enabled = False

            disabler()
            startUp()
            MessageBox.Show("You are just in GUEST MODE", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
            programStarted = "TRUE"

        ElseIf accountLoggedInStat = "CASHIER" Then
            accountLbl.Text = "CASHIER | " & accountLoggedIn.ToString
            idLbl.Text = accountID

            FoodMenuItemToolStripMenuItem.Enabled = True
            ModifyFoodMenuToolStripMenuItem.Enabled = True
            InventoryToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem.Enabled = False

            BusinessOperationToolStripMenuItem.Visible = False
            BusinessOperationToolStripMenuItem.Enabled = False
            TransactionToolStripMenuItem.Enabled = False
            SalesToolStripMenuItem.Enabled = False
            OperationsToolStripMenuItem.Enabled = False

            AccountInfoToolStripMenuItem.Visible = False
            AccountInfoToolStripMenuItem.Enabled = False

            MyAccountToolStripMenuItem.Enabled = True
            LogOutToolStripMenuItem.Enabled = True

            refundBtn.Enabled = False
            startDayBtn.Enabled = True
            startUp()
            MessageBox.Show("Welcome " & accountLoggedIn.ToString, "Successfully Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
            programStarted = "TRUE"
            startedStat()

        ElseIf accountLoggedInStat = "MANAGER" Then
            accountLbl.Text = "MANAGER | " & accountLoggedIn.ToString
            idLbl.Text = accountID

            FoodMenuItemToolStripMenuItem.Enabled = True
            ModifyFoodMenuToolStripMenuItem.Enabled = True
            InventoryToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem.Enabled = False

            BusinessOperationToolStripMenuItem.Enabled = True
            BusinessOperationToolStripMenuItem.Visible = True
            TransactionToolStripMenuItem.Enabled = True
            SalesToolStripMenuItem.Enabled = True
            OperationsToolStripMenuItem.Enabled = True

            AccountInfoToolStripMenuItem.Visible = False
            AccountInfoToolStripMenuItem.Enabled = False

            MyAccountToolStripMenuItem.Enabled = True
            LogOutToolStripMenuItem.Enabled = True

            refundBtn.Enabled = True
            startDayBtn.Enabled = True
            startUp()
            MessageBox.Show("Welcome MANAGER " & accountLoggedIn.ToString, "Successfully Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
            programStarted = "TRUE"
            startedStat()

        ElseIf accountLoggedInStat = "ADMIN" Then
            accountLbl.Text = "ADMIN | " & accountLoggedIn.ToString
            idLbl.Text = accountID

            FoodMenuItemToolStripMenuItem.Enabled = True
            ModifyFoodMenuToolStripMenuItem.Enabled = True
            InventoryToolStripMenuItem.Visible = True
            InventoryToolStripMenuItem.Enabled = True

            BusinessOperationToolStripMenuItem.Enabled = True
            BusinessOperationToolStripMenuItem.Visible = True
            TransactionToolStripMenuItem.Enabled = True
            SalesToolStripMenuItem.Enabled = True
            OperationsToolStripMenuItem.Enabled = True

            AccountInfoToolStripMenuItem.Visible = True
            AccountInfoToolStripMenuItem.Enabled = True

            MyAccountToolStripMenuItem.Enabled = True
            LogOutToolStripMenuItem.Enabled = True

            refundBtn.Enabled = True
            startDayBtn.Enabled = True
            startUp()
            MessageBox.Show("Welcome ADMIN " & accountLoggedIn.ToString, "Successfully Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
            programStarted = "TRUE"
            startedStat()

        End If

    End Sub

    Sub startUp()
        searchtxt.Focus()
        timeOfTheDay.Start()
        dateLbl.Text = DateTime.Now.ToLongDateString
        maxOrderNum()
        maxTransNo()
        loadMenuList()
        placeOrerBtn.Enabled = False
        flp1.Enabled = False
        loadOrderData()
        ComputeTotalOrder()
    End Sub

    '////////////////////////////////////////////  MY MAJOR CODES //////////////////////////////////////////////////////////////

    ' RESPONSIBLE FOR PULLING ALL DATA FROM FOODMENU IN MY DATABASE INTO FLOW LAYOUT PANEL
    Private WithEvents pics As New PictureBox
    Private WithEvents lblP As New Label
    Private WithEvents lblD As New Label
    Public Sub loadMenuList()
        Dim cmdLoadMenu As New MySqlCommand
        Dim drLoadMenu As MySqlDataReader

        Try
            conOpen()
            If searchtxt.Text <> "" Then
                flp1.Controls.Clear()
                cmdLoadMenu.Connection = conn
                cmdLoadMenu.CommandText = "SELECT image, name, price, code FROM foodmenu WHERE name LIKE '%" & searchtxt.Text.Trim & "%' order by code asc"
                drLoadMenu = cmdLoadMenu.ExecuteReader

            ElseIf searchtxt.Text = "" And filterReceiver.Text <> "" Then
                flp1.Controls.Clear()
                cmdLoadMenu.Connection = conn
                cmdLoadMenu.CommandText = "SELECT image, name, price, code FROM foodmenu WHERE category = '" & filterReceiver.Text & "' order by code asc"
                drLoadMenu = cmdLoadMenu.ExecuteReader
            Else
                flp1.Controls.Clear()
                cmdLoadMenu.Connection = conn
                cmdLoadMenu.CommandText = "SELECT image, name, price, code FROM foodmenu order by code asc"
                drLoadMenu = cmdLoadMenu.ExecuteReader
            End If

            While drLoadMenu.Read

                Dim lngth As Long = drLoadMenu.GetBytes(0, 0, Nothing, 0, 0)
                Dim arry(CInt(lngth)) As Byte
                drLoadMenu.GetBytes(0, 0, arry, 0, CInt(lngth))

                pics = New PictureBox
                pics.Width = 120
                pics.Height = 150
                pics.BackgroundImageLayout = ImageLayout.Center
                pics.BorderStyle = BorderStyle.FixedSingle
                pics.Tag = drLoadMenu.Item("code").ToString

                lblD = New Label
                lblD.Width = 120
                lblD.Height = 25
                lblD.BackColor = Color.LightGreen
                lblD.Tag = drLoadMenu.Item("code").ToString

                lblP = New Label
                lblP.Width = 60
                lblP.Height = 25
                lblP.BackColor = Color.DarkOrange
                lblP.Dock = DockStyle.Bottom
                lblP.TextAlign = ContentAlignment.BottomCenter
                lblP.Tag = drLoadMenu.Item("code").ToString

                Dim ms As New System.IO.MemoryStream(arry)
                Dim bitmap As New System.Drawing.Bitmap(ms)
                pics.BackgroundImage = bitmap

                lblD.Text = drLoadMenu.Item("name").ToString
                pics.Controls.Add(lblD)

                lblP.Text = drLoadMenu.Item("price").ToString
                pics.Controls.Add(lblP)

                flp1.Controls.Add(pics)

                AddHandler pics.Click, AddressOf pics_click
                AddHandler lblD.Click, AddressOf pics_click
                AddHandler lblP.Click, AddressOf pics_click
            End While
            drLoadMenu.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | loadMenuList", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try

    End Sub

    ' RESPONSIBLE ON INCREMENTATION OF ORDER NO FROM TEMPORARY ORDER STORAGE
    Dim maxOrder As Integer
    Public Sub maxOrderNum()
        Dim cmdMaxOrderNo As New MySqlCommand
        Try
            conOpen()
            cmdMaxOrderNo.Connection = conn
            cmdMaxOrderNo.CommandText = "SELECT IFNULL(MAX(orderNo),0) FROM temporderstorage "
            maxOrder = cmdMaxOrderNo.ExecuteScalar

            If maxOrder > 0 Then
                orderNum.Text = maxOrder + 1
                dgv1.Enabled = True

            Else
                dgv1.Enabled = False
                orderNum.Text = 1
            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | maxOrderNum", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    ' IT WILL RETURN THE MAX TRANSACTION NUMBER FROM TRANSACTIONS TABLE IN THE DATABASE
    Public Sub maxTransNo()
        Dim cmdMaxTransNo As New MySqlCommand
        Try
            conn.Open()
            cmdMaxTransNo.Connection = conn
            cmdMaxTransNo.CommandText = "SELECT IFNULL(MAX(transNO),0) FROM transactions"
            Dim maxTrans As Integer = cmdMaxTransNo.ExecuteScalar
            If maxTrans > 0 Then
                transactionNoLbl.Text = maxTrans + 1
            Else
                transactionNoLbl.Text = 1
            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | maxTransNo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    ' SEND A CODE TO CODE LABEL EVERY CLICK ON MENU ITEM
    Public Sub pics_click(sender As Object, e As EventArgs)
        codeLbl.Text = "0"
        quantityInput.Width = 356
        codeLbl.Text = sender.tag.ToString
        subTotal.Clear()
        quantityTxt.Clear()
        quantityTxt.Focus()
        modifyOrderPanel.Width = 0
        paymentPanel.Width = 0
    End Sub

    ' AFTER CLICKING ON IMAGE ON FLOWLAYOUPANEL, IT WILL GIVE A CODE TO CODE LABEL AND USE THAT CODE TO BIND ALL DATA RELATED WITH THAT CODE
    Private Sub codeLbl_TextChanged(sender As Object, e As EventArgs) Handles codeLbl.TextChanged
        Dim cmdCodeLbl As New MySqlCommand
        Dim dACodeLbl As New MySqlDataAdapter
        Dim dSCodeLbl As New DataSet

        Try
            conOpen()
            cmdCodeLbl.Connection = conn
            cmdCodeLbl.CommandText = "SELECT name, price, quantity, inventory FROM foodmenu WHERE code = '" & codeLbl.Text & "'"
            dACodeLbl.SelectCommand = cmdCodeLbl
            dSCodeLbl.Clear()
            dACodeLbl.Fill(dSCodeLbl, "foodmenu")

            nameTxtHolder.DataBindings.Add("Text", dSCodeLbl, "foodmenu.name")
            nameTxtHolder.DataBindings.Clear()

            priceTxtHolder.DataBindings.Add("Text", dSCodeLbl, "foodmenu.price")
            priceTxtHolder.DataBindings.Clear()

            quantityTxtHolder.DataBindings.Add("Text", dSCodeLbl, "foodmenu.quantity")
            quantityTxtHolder.DataBindings.Clear()

            includeInventory.DataBindings.Add("Text", dSCodeLbl, "foodmenu.inventory")
            includeInventory.DataBindings.Clear()

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | codeLblTextChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    ' IF THE INPUT QUANTITY IS VALID, IT WILL SAVE THE ORDER DETAILS TO THE TEMPORARY ORDERS' STORAGE
    Dim checkSameorder As String
    Private Sub enterBtn_Click(sender As Object, e As EventArgs) Handles enterBtn.Click
        If quantityTxt.Text = "" Then
            MessageBox.Show("Enter Quantity First", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            quantityTxt.Focus()
        ElseIf CInt(quantityTxt.Text) > CInt(quantityTxtHolder.Text) And includeInventory.Text = "YES" Then
            MessageBox.Show("Not Enough Stocks", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            quantityTxt.Focus()
        Else
            Dim cmdOrder As New MySqlCommand
            If quantityTxt.Text <> "" And quantityTxt.Text <> "0" Then

                ' TO KNOW IF THE SELECTED FOOD ITEM HAS EXISTING ORDER IN TEMPORARY ORDER STORAGE AND IT WILL JUST ADD ON IT
                Try
                    conOpen()
                    cmdOrder.Connection = conn
                    cmdOrder.CommandText = "SELECT orderName FROM temporderstorage WHERE orderName = '" & nameTxtHolder.Text & "'"
                    checkSameorder = cmdOrder.ExecuteScalar
                    conn.Close()

                    If checkSameorder = nameTxtHolder.Text Then
                        Try
                            conOpen()
                            cmdOrder.Connection = conn
                            cmdOrder.CommandText = "SELECT orderQuantity FROM temporderstorage WHERE orderName = '" & nameTxtHolder.Text & "'"
                            Dim Q As Integer = cmdOrder.ExecuteScalar
                            conn.Close()

                            conOpen()
                            cmdOrder.Connection = conn
                            cmdOrder.CommandText = "SELECT total FROM temporderstorage WHERE orderName = '" & nameTxtHolder.Text & "'"
                            Dim tot As Integer = cmdOrder.ExecuteScalar
                            conn.Close()

                            Dim qnty As Integer = Q + quantityTxt.Text
                            Dim total As Integer = tot + subTotal.Text

                            conOpen()
                            cmdOrder.Connection = conn
                            cmdOrder.CommandText = "UPDATE temporderstorage SET orderQuantity  = '" & qnty & "', total = '" & total & "' WHERE orderName = '" & nameTxtHolder.Text & "'"
                            cmdOrder.ExecuteNonQuery()
                            conn.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "ERROR |001", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            conn.Close()
                        Finally
                            quantityInput.Width = 0
                            loadOrderData()
                            ComputeTotalOrder()
                            quantityTxt.Clear()
                            loadMenuList()
                            quantityTxt.Clear()
                            placeOrerBtn.Enabled = True
                            searchtxt.Focus()
                        End Try

                        ' ITEM WILL INSERT INTO TEMPORARY ORDER STORAGE IF THERE'S NO EXISTING SAME ITEM
                    ElseIf quantityTxt.Text <> "" And quantityTxt.Text <> "0" And checkSameorder <> nameTxtHolder.Text Then

                        Try
                            conOpen()
                            cmdOrder.Connection = conn
                            cmdOrder.CommandText = "INSERT INTO temporderstorage 
                        (`orderNo`,`transNo`,`orderName`,`orderQuantity`,`orderPrice`,`total`,`tableNumber`,`dateOrder`,`timeOrder`)
                     VALUES ('" & orderNum.Text & "','" & transactionNoLbl.Text & "','" & nameTxtHolder.Text & "','" & quantityTxt.Text & "','" & priceTxtHolder.Text & "',
                     '" & subTotal.Text & "','" & tableNoLbl.Text & "','" & dateLbl.Text & "','" & timeLbl.Text & "') "
                            cmdOrder.ExecuteNonQuery()

                            conn.Close()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "ERROR | codeLblTextChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            conn.Close()
                        End Try
                        quantityInput.Width = 0
                        loadOrderData()
                        ComputeTotalOrder()

                        quantityTxt.Clear()
                        placeOrerBtn.Enabled = True
                    Else
                        MessageBox.Show("Enter Quantity First!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR | Checking Same Order", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                Finally
                    placeOrerBtn.BackColor = Color.LimeGreen
                    maxOrderNum()
                    cancelOrderBtn.Visible = True
                    searchtxt.Focus()
                End Try
            End If
        End If
    End Sub

    ' IT WILL PULL THE CONTENT OF TEMPORARY ORDER DATA
    Public Sub loadOrderData()
        Dim cmdOrderData As New MySqlCommand
        Dim daOrderData As New MySqlDataAdapter

        Dim dtOrderData As New DataTable

        Try
            conOpen()
            cmdOrderData.Connection = conn
            cmdOrderData.CommandText = "SELECT orderNo, orderName, orderQuantity, orderPrice, total  FROM temporderstorage order by orderNo asc"
            daOrderData.SelectCommand = cmdOrderData
            dtOrderData.Clear()
            daOrderData.Fill(dtOrderData)
            dgv1.DataSource = dtOrderData

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | loadOrderData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try

    End Sub

    ' IT WILL SELECT AND SUM UP ALL TOTAL FROM TEMPORARY ORDERS' STORAGE
    Public Sub ComputeTotalOrder()
        Dim cmdComputeTotal As New MySqlCommand
        Try
            conOpen()
            cmdComputeTotal.Connection = conn
            cmdComputeTotal.CommandText = "SELECT IFNULL(SUM(total),0) FROM temporderstorage"
            Dim computedTotal As Integer = cmdComputeTotal.ExecuteScalar

            If computedTotal > 0 Then
                totalLbl.Text = computedTotal
            Else
                totalLbl.Text = 0
            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | codeLblTextChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try

    End Sub

    ' TO VALIDATE INPUTS FROM USER WHEN ENTERING ORDER QUANTITY
    Private Sub quantityTxt_TextChanged(sender As Object, e As EventArgs) Handles quantityTxt.TextChanged
        Dim p As Integer
        Dim toint As Integer
        Try
            If quantityTxt.Text <> "" Then
                If IsNumeric(quantityTxt.Text) = False Then

                    MessageBox.Show("Number Only!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    quantityTxt.Focus()
                    quantityTxt.Clear()
                    subTotal.Clear()

                ElseIf IsNumeric(quantityTxt.Text) = True And quantityTxt.Text <> 0 Then

                    toint = CInt(quantityTxt.Text)
                    p = CInt(priceTxtHolder.Text)
                    subTotal.Text = (p * toint)

                Else
                    MessageBox.Show("Quantity Must be 1 or More!", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    quantityTxt.Focus()
                    quantityTxt.Clear()
                    subTotal.Clear()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error QuantityInput ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' THIS THE CODE REPONSIBLE FOR SELECTING THE ORDER WITH THE MINIMUM ORDER NO. FROM MY DATABASE
    Public Sub minOrderNumber()
        Dim cmdMinOrderNum As New MySqlCommand
        Try
            conOpen()
            cmdMinOrderNum.Connection = conn
            cmdMinOrderNum.CommandText = "SELECT IFNULL(MIN(orderNo),0) FROM temporderstorage"
            Dim minOrderNum As Integer = cmdMinOrderNum.ExecuteScalar

            If minOrderNum > 0 Then
                minOrderNoLbl.Text = minOrderNum
            Else
                minOrderNoLbl.Text = "0"
            End If

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | minOrderNumber", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    'EVERY TIME THE LABEL FOR ORDER WITH MINIMUM ORDER NO. HAS CHANGED, IT WILL BIND ALL DATA RELATED WITH THAT ORDER NUMBER
    Private Sub minOrderNoLbl_TextChanged(sender As Object, e As EventArgs) Handles minOrderNoLbl.TextChanged
        Dim cmdGetMinOrderData As New MySqlCommand
        Dim daGMOD As New MySqlDataAdapter
        Dim dsGMOD As New DataSet
        If minOrderNoLbl.Text <> 0 Then
            Try
                conOpen()
                cmdGetMinOrderData.Connection = conn
                cmdGetMinOrderData.CommandText = "SELECT * FROM temporderstorage WHERE orderNo='" & minOrderNoLbl.Text & "'"
                daGMOD.SelectCommand = cmdGetMinOrderData
                dsGMOD.Clear()
                daGMOD.Fill(dsGMOD, "temporderstorage")

                t_noTxt.DataBindings.Add("Text", dsGMOD, "temporderstorage.transNo")
                t_noTxt.DataBindings.Clear()

                ordrNameTxt.DataBindings.Add("Text", dsGMOD, "temporderstorage.orderName")
                ordrNameTxt.DataBindings.Clear()

                ordrQntyTxt.DataBindings.Add("Text", dsGMOD, "temporderstorage.orderQuantity")
                ordrQntyTxt.DataBindings.Clear()

                ordrPriceTxt.DataBindings.Add("Text", dsGMOD, "temporderstorage.orderPrice")
                ordrPriceTxt.DataBindings.Clear()

                ordrSubTotTxt.DataBindings.Add("Text", dsGMOD, "temporderstorage.total")
                ordrSubTotTxt.DataBindings.Clear()

                ordrTblNoTxt.DataBindings.Add("Text", dsGMOD, "temporderstorage.tableNumber")
                ordrTblNoTxt.DataBindings.Clear()

                ordrDateTxt.DataBindings.Add("Text", dsGMOD, "temporderstorage.dateOrder")
                ordrDateTxt.DataBindings.Clear()

                ordrTimeTxt.DataBindings.Add("Text", dsGMOD, "temporderstorage.timeOrder")
                ordrTimeTxt.DataBindings.Clear()

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR | minOrderNumberTextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        Else
            t_noTxt.Clear()
            ordrNameTxt.Clear()
            ordrQntyTxt.Clear()
            ordrPriceTxt.Clear()
            ordrSubTotTxt.Clear()
            ordrTblNoTxt.Clear()
            ordrTimeTxt.Clear()
            ordrDateTxt.Clear()
            ComputeTotalOrder()
        End If
    End Sub

    ' MY CODES TO DELETE ORDER DATA FROM TEMPORARY STORAGE, USED IN WHILE LOOP IN PLACE ORDER BUTTON
    Public Sub deleteTempOrder()
        Dim cmdDeleteTemp As New MySqlCommand
        Try
            conOpen()
            cmdDeleteTemp.Connection = conn
            cmdDeleteTemp.CommandText = "DELETE FROM temporderstorage WHERE orderNo = '" & minOrderNoLbl.Text & "' "
            cmdDeleteTemp.ExecuteNonQuery()

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | deleteTempOrder", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    ' FUNCTION FOR SAVING TO TRANSACTIONS
    Public Sub saveToTransactions()
        Dim cmdSaveToTrans As New MySqlCommand
        Try
            conOpen()
            cmdSaveToTrans.Connection = conn
            cmdSaveToTrans.CommandText = "INSERT INTO transactions (`transNO`,`tableNum`,`orderDetails`,`orderTotal`,`dateOrdered`,`timeOrdered`,`refundStat`,`reasonRefund`)
        VALUES ('" & transactionNoLbl.Text & "','" & tableNoLbl.Text & "','" & receiptTxt.Text & "','" & totalSaveLbl.Text & "','" & dateSaveLbl.Text & "','" & timeSaveLbl.Text & "','" & "NO" & "','" & "NONE" & "')"
            cmdSaveToTrans.ExecuteNonQuery()

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | SavingToTransactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        Finally
            maxTransNo()
        End Try
    End Sub

    '  PLACE ORDER, TRANSFER ALL DATA FROM temporderstorage TABLE 

    Private Sub placeOrerBtn_Click(sender As Object, e As EventArgs) Handles placeOrerBtn.Click
        paymentPanel.Width = 275
        paymentInputTxt.Focus()

        quantityInput.Width = 0
        modifyOrderPanel.Width = 0
    End Sub

    ' THIS IS MY CODE FOR PAYMENT AND CONTINUATION OF PLACING ORDER
    Dim totalOrdered As String
    Private Sub enterPaymentBtn_Click(sender As Object, e As EventArgs) Handles enterPaymentBtn.Click
        Try

            If paymentInputTxt.Text = "" Then
                MessageBox.Show("Please Enter an Amount", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                paymentInputTxt.Clear()
                paymentInputTxt.Focus()
                ' JUST VALIDATE THE PAYMENT AMOUNT INPUT
            ElseIf CInt(paymentInputTxt.Text) < CInt(totalLbl.Text) Then
                MessageBox.Show("Amount Entered is less than Net Total", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                paymentInputTxt.Focus()

            Else
                ' CONFIRMING THE ACTION
                Dim confirmOrder As New DialogResult
                confirmOrder = MessageBox.Show("Are you sure to place this order?", "Click OK to Continue", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                If confirmOrder = DialogResult.OK Then
                    totalOrdered = totalLbl.Text
                    totalSaveLbl.Text = totalOrdered

                    ' UPDATING THE AMOUNT ON SELECTED CUSTOMER TABLE
                    Try
                        Dim cmdAmount As New MySqlCommand
                        conOpen()
                        cmdAmount.Connection = conn
                        cmdAmount.CommandText = "UPDATE available_table SET amount = '" & totalOrdered & "' WHERE tableNo = '" & tableNoLbl.Text & "'"
                        cmdAmount.ExecuteNonQuery()

                        conn.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "ERROR | UpdateTableNumberAmount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        conn.Close()
                    End Try

                    minOrderNumber()
                    Dim cmdPlaceOrder As New MySqlCommand

                    If orderNum.Text = 1 Then
                        MessageBox.Show("Make an Order First!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        ' IF ORDER IS NOT EMPTY THE PROCESS WILL CONTINUE
                        ' INSERTING ALL ORDERS ONE BY ONE INTO SOLD TABLE AND TRANSACTION TABLE IN DATABASE
                    Else
                        While minOrderNoLbl.Text <> 0
                            Try
                                conOpen()
                                cmdPlaceOrder.Connection = conn
                                cmdPlaceOrder.CommandText = "INSERT INTO soldtbl (`transNo`,`orderName`,`orderQuantity`,`orderPrice`,`subTotal`,
                                                     `takeOut`,`tableNo`,`dateOrdered`,`timeOrdered`)
                        VALUES ('" & t_noTxt.Text & "','" & ordrNameTxt.Text & "','" & ordrQntyTxt.Text & "','" & ordrPriceTxt.Text & "',
                        '" & ordrSubTotTxt.Text & "','" & takeOutStat.Text & "','" & ordrTblNoTxt.Text & "','" & ordrDateTxt.Text & "',
                        '" & ordrTimeTxt.Text & "')"
                                cmdPlaceOrder.ExecuteNonQuery()
                                conn.Close()

                                ' SUBTRACTING QUANTITY OF ORDERS FROM ITEM'S QUANTITY IN INVENTORY
                                conOpen()
                                cmdPlaceOrder.Connection = conn
                                cmdPlaceOrder.CommandText = "SELECT quantity FROM foodmenu WHERE name = '" & ordrNameTxt.Text & "' AND inventory = '" & "YES" & "'"
                                Dim qnty As Integer = cmdPlaceOrder.ExecuteScalar

                                Dim newQnty As Integer = qnty - CInt(ordrQntyTxt.Text)
                                cmdPlaceOrder.CommandText = "UPDATE foodmenu SET quantity = '" & newQnty & "' WHERE name = '" & ordrNameTxt.Text & "' AND inventory = '" & "YES" & "' "
                                cmdPlaceOrder.ExecuteNonQuery()
                                conn.Close()

                                ' MAKING A COPY OF ORDERED ITEM ONE BY ONE INTO RECEIPT TEXTFIELD BEFORE DELETED
                                receiptTxt.Text = receiptTxt.Text & Environment.NewLine + "Name :" + ordrNameTxt.Text & Environment.NewLine + "Quantity :" + ordrQntyTxt.Text & Environment.NewLine + "Price :" + ordrPriceTxt.Text & Environment.NewLine + "SubTotal :" + ordrSubTotTxt.Text & Environment.NewLine

                                ' FUNCTION TO DELETE ORDER WITH THE MINIMUM ORDER NUMBER
                                deleteTempOrder()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "ERROR | whileLoopInserting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                conn.Close()
                            End Try
                            minOrderNumber()
                        End While

                        receiptTxt.Text = receiptTxt.Text & Environment.NewLine & Environment.NewLine + "TOTAL AMOUNT :" + totalOrdered & Environment.NewLine
                        Dim amtChange As Integer = CInt(paymentInputTxt.Text) - CInt(totalOrdered)
                        receiptTxt.Text = receiptTxt.Text & Environment.NewLine + "Payment Received :" + paymentInputTxt.Text & Environment.NewLine + "Change  :  " + amtChange.ToString & Environment.NewLine & Environment.NewLine
                        refresher()
                        MessageBox.Show("Successfully Place an Order(s)", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        placeOrerBtn.BackColor = Color.AliceBlue
                        placeOrerBtn.Enabled = False
                        maxOrderNum()
                        quantityInput.Width = 0
                        flp1.Enabled = False
                        saveToTransactions()
                        orderBtn.Enabled = True
                        tableNoLbl.Text = "0"
                        Timer1.Enabled = True
                        Button14.Text = "Close Receipt"
                        loadOrderData()
                        loadMenuList()
                        paymentPanel.Width = 0
                        cancelOrderBtn.Visible = False
                        paymentInputTxt.Clear()
                        Button13.Focus()
                        takeOutStat.Clear()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR02 | whileLoopInserting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub cancelOrderBtn_Click(sender As Object, e As EventArgs) Handles cancelOrderBtn.Click

        Dim confirm As New DialogResult
        confirm = MessageBox.Show("Are you sure to cancel current order? Click OK to continue", "Confirm to cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)

        If confirm = DialogResult.OK Then
            Dim cmdCancelOrder As New MySqlCommand

            Try
                conOpen()
                cmdCancelOrder.Connection = conn
                cmdCancelOrder.CommandText = "DELETE FROM temporderstorage"
                cmdCancelOrder.ExecuteNonQuery()
                If tableNoLbl.Text <> 0 Then
                    cmdCancelOrder.CommandText = "UPDATE available_table SET `tableStat` = '" & "NOT OCCUPIED" & "' WHERE `tableNo` ='" & tableNoLbl.Text & "'"
                    cmdCancelOrder.ExecuteNonQuery()
                End If

                MessageBox.Show("Successfully Cancelled Order.", "Order Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error)

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error : CancellingOrder", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            Finally
                loadOrderData()
                cancelOrderBtn.Visible =
                    False
                placeOrerBtn.BackColor = Color.AliceBlue
                totalSaveLbl.Text = "0"
                dateSaveLbl.Text = "Date"
                timeSaveLbl.Text = "Time"
                receiptTxt.Clear()
                tableNoLbl.Text = "0"
                flp1.Enabled = False
                orderBtn.Enabled = True
                placeOrerBtn.Enabled = False
                modifyOrderPanel.Width = 0
                paymentPanel.Width = 0
                quantityInput.Width = 0
                takeOutStat.Clear()
                dgv1.Enabled = False
            End Try
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        paymentPanel.Width = 0
        placeOrerBtn.Enabled = True
        paymentInputTxt.Clear()
    End Sub

    Public Sub AvTableLoadData()
        Dim cmdTable As New MySqlCommand
        Dim dtTable As New DataTable
        Dim daTable As New MySqlDataAdapter

        Try
            conOpen()
            cmdTable.Connection = conn
            cmdTable.CommandText = "SELECT * FROM available_table"
            daTable.SelectCommand = cmdTable
            dtTable.Clear()
            daTable.Fill(dtTable)
            dgv2.DataSource = dtTable
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | LoadingAvailableTable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try

    End Sub

    ' CODE FOR SELECTING CUSTOMER TABLE
    Private Sub selectTableBtn_Click(sender As Object, e As EventArgs) Handles selectTableBtn.Click
        If tableStatTxt.Text = "OCCUPIED" Then
            MessageBox.Show("This Table is Occupied", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf tableNumtxt.Text = "" Then
            MessageBox.Show("You need to select Table first if order is not take out!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            receiptTxt.Clear()
            takeOutStat.Text = "NO"
            tableNoLbl.Text = tableNumtxt.Text
            tableStatTxt.Text = "OCCUPIED"
            totalSaveLbl.Text = "0"
            Dim cmdUpdateTable As New MySqlCommand
            Try
                conOpen()
                cmdUpdateTable.Connection = conn
                cmdUpdateTable.CommandText = "UPDATE available_table SET tableStat = '" & tableStatTxt.Text & "' WHERE tableId = '" & tableId.Text & "'"
                cmdUpdateTable.ExecuteNonQuery()
                conn.Close()

                AvTableLoadData()
                deleteTableBtn.Visible = False
                tableId.Clear()
                tableNumtxt.Clear()
                tableStatTxt.Clear()
                tableAmountTxt.Clear()

                tablePickingPanel.Visible = False
                tablePickingPanel.Width = 0

                dateSaveLbl.Text = dateLbl.Text
                timeSaveLbl.Text = timeLbl.Text
                receiptTxt.Text = "MCBEE FASTFOOD RESTAURANT" & Environment.NewLine & Environment.NewLine + "Transaction No  :  " + transactionNoLbl.Text & Environment.NewLine + "Date  :  " + dateLbl.Text & Environment.NewLine + "Time  :  " + timeLbl.Text & Environment.NewLine + "Table No  :  " + tableNoLbl.Text & Environment.NewLine & Environment.NewLine
                flp1.Enabled = True
                cancelOrderBtn.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR | Updating Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub availableBtn_Click(sender As Object, e As EventArgs) Handles availableBtn.Click
        If tableStatTxt.Text = "NOT OCCUPIED" Then
            MessageBox.Show("This Table is already Not Occupied", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            tableAmountTxt.Text = "0"
            tableStatTxt.Text = "NOT OCCUPIED"

            Dim cmdUpdateTable As New MySqlCommand
            Try
                conOpen()
                cmdUpdateTable.Connection = conn
                cmdUpdateTable.CommandText = "UPDATE available_table SET tableStat = '" & tableStatTxt.Text & "', amount = '" & tableAmountTxt.Text & "' WHERE tableId = '" & tableId.Text & "'"
                cmdUpdateTable.ExecuteNonQuery()

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR | UpdatingTableMakeItOccupied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        End If
        AvTableLoadData()
        deleteTableBtn.Visible = False
        tableId.Clear()
        tableNumtxt.Clear()
        tableStatTxt.Clear()
        tableAmountTxt.Clear()
    End Sub

    Private Sub addTableBtn_Click(sender As Object, e As EventArgs) Handles addTableBtn.Click
        Dim cmdTblNo As New MySqlCommand
        Dim maxTblNum As String
        Try
            conOpen()
            cmdTblNo.Connection = conn
            cmdTblNo.CommandText = "SELECT IFNULL(MAX(tableNo),0) FROM available_table"
            Dim maxTblNo = cmdTblNo.ExecuteScalar

            If maxTblNo > 0 Then
                maxTblNum = maxTblNo + 1
            Else
                maxTblNum = 1
            End If
            conn.Close()

            conOpen()
            cmdTblNo.Connection = conn
            cmdTblNo.CommandText = "INSERT INTO available_table (`tableNo`,`tableStat`,`amount`) VALUES 
            ('" & maxTblNum & "', '" & "NOT OCCUPIED" & "', '" & 0 & "')"
            cmdTblNo.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR | addingNewTable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
        AvTableLoadData()
        deleteTableBtn.Visible = False
        tableId.Clear()
        tableNumtxt.Clear()
        tableStatTxt.Clear()
        tableAmountTxt.Clear()
    End Sub

    Private Sub deleteTableBtn_Click(sender As Object, e As EventArgs) Handles deleteTableBtn.Click
        If tableStatTxt.Text = "OCCUPIED" Then
            MessageBox.Show("You can't Delete Occupied Tables!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim cmdDeleteTbl As New MySqlCommand
            Try
                conOpen()
                cmdDeleteTbl.Connection = conn
                cmdDeleteTbl.CommandText = "DELETE FROM available_table WHERE tableId = '" & tableId.Text & "'"
                cmdDeleteTbl.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR | deletingTable", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
            AvTableLoadData()
            deleteTableBtn.Visible = False
            tableId.Clear()
            tableNumtxt.Clear()
            tableStatTxt.Clear()
            tableAmountTxt.Clear()
        End If

    End Sub

    Private Sub orderBtn_Click(sender As Object, e As EventArgs) Handles orderBtn.Click
        AvTableLoadData()
        tablePickingPanel.Visible = True
        tablePickingPanel.Width = 638
        orderBtn.Enabled = False
        receiptTxt.Clear()
        totalSaveLbl.Text = "Total"
        dateSaveLbl.Text = "date"
        timeSaveLbl.Text = "time"
        Timer2.Enabled = True

    End Sub

    ' ORDER MODIFY
    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Try
            Dim i As Integer = dgv1.CurrentRow.Index
            ordrNumMdfyPnl.Text = dgv1.Item(0, i).Value
            qntyMdfyPnl.Text = dgv1.Item(2, i).Value
            priceMdfy.Text = dgv1.Item(3, i).Value
            quantityInput.Width = 0

            modifyOrderPanel.Width = 350
            maxOrderNum()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        modifyOrderPanel.Width = 0
    End Sub

    ' ADDING QUANTITY TO THE SELECTED ORDER ITEM
    Private Sub addOrderBtn_Click(sender As Object, e As EventArgs) Handles addOrderBtn.Click
        Dim addQnty As Integer
        Dim newTotal As Integer
        Dim qnty As Integer = CInt(qntyMdfyPnl.Text)
        Dim p As Integer = CInt(priceMdfy.Text)
        addQnty = qnty + 1
        qntyMdfyPnl.Text = addQnty
        newTotal = p * addQnty

        If ordrNumMdfyPnl.Text <> "" Then
            Dim cmd As New MySqlCommand
            Try
                conOpen()
                cmd.Connection = conn
                cmd.CommandText = "UPDATE temporderstorage SET orderQuantity = '" & addQnty & "', total = '" & newTotal & "' WHERE orderNo = '" & ordrNumMdfyPnl.Text & "'"
                cmd.ExecuteNonQuery()

                conn.Close()
                loadOrderData()
                ComputeTotalOrder()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "adding to quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        End If
    End Sub

    ' CODE FOR SUBTRACTING QUANTITY FROM SELECTED ORDER ITEM
    Private Sub subtractOrderBtn_Click(sender As Object, e As EventArgs) Handles subtractOrderBtn.Click
        Dim subQnty As Integer
        Dim newTotal As Integer
        Dim qnty As Integer = CInt(qntyMdfyPnl.Text)
        Dim p As Integer = CInt(priceMdfy.Text)

        If qnty > 1 Then
            subQnty = qnty - 1
            qntyMdfyPnl.Text = subQnty
            newTotal = p * subQnty

            If ordrNumMdfyPnl.Text <> "" Then
                Dim cmd As New MySqlCommand
                Try
                    conOpen()
                    cmd.Connection = conn
                    cmd.CommandText = "UPDATE temporderstorage SET orderQuantity = '" & subQnty & "', total = '" & newTotal & "' WHERE orderNo = '" & ordrNumMdfyPnl.Text & "'"
                    cmd.ExecuteNonQuery()

                    conn.Close()
                    loadOrderData()
                    ComputeTotalOrder()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "suctracting quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try
            End If
        Else
            MessageBox.Show("Quantity must be 1 or more", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    ' CODE FOR DELETING ORDER
    Private Sub deleteOrderBtn_Click(sender As Object, e As EventArgs) Handles deleteOrderBtn.Click
        Try
            Dim cmdDel As New MySqlCommand
            conOpen()
            cmdDel.Connection = conn
            cmdDel.CommandText = "SELECT COUNT(orderNo) FROM temporderstorage"
            Dim cnt As Integer = cmdDel.ExecuteScalar
            conn.Close()

            If cnt = 1 Then
                MessageBox.Show("You can't delete all orders, Cancel the order instead", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ElseIf ordrNumMdfyPnl.Text <> "0" Then
                Dim confirm As New DialogResult
                confirm = MessageBox.Show("Delete this order? Click OK to proceed", "Confirmation Needed", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
                If confirm = DialogResult.OK Then
                    Dim cmd As New MySqlCommand
                    Try
                        conOpen()
                        cmd.Connection = conn
                        cmd.CommandText = "DELETE FROM temporderstorage WHERE orderNo = '" & ordrNumMdfyPnl.Text & "'"
                        cmd.ExecuteNonQuery()

                        conn.Close()
                        loadOrderData()
                        ComputeTotalOrder()
                        priceMdfy.Text = "0"
                        qntyMdfyPnl.Text = "0"
                        ordrNumMdfyPnl.Text = "0"
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "deleting order", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        conn.Close()
                    End Try
                End If
            Else
                MessageBox.Show("Click order you want to delete", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "delete button", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try

    End Sub

    ' ================== CODE FOR STARTING DAY ===============

    Dim dNumHold As Integer
    Dim cmdStartEnd As New MySqlCommand

    ' GETTING MAX DAY NUMBER FROM DATABASE
    Sub getmaxDayNum()
        conn.Close()

        Try
            conOpen()
            cmdStartEnd.Connection = conn
            cmdStartEnd.CommandText = "SELECT IFNULL(MAX(dayNum),0) FROM started_ended"
            Dim dayNum As Integer = cmdStartEnd.ExecuteScalar

            If dayNum > 0 Then
                dNumHold = dayNum + 1
            Else
                dNumHold = 1
            End If

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error GetMaxDayNum", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()

        End Try
    End Sub

    Private Sub startDayBtn_Click(sender As Object, e As EventArgs) Handles startDayBtn.Click
        startingMoneyInputPanel.Width = 210
        startingMoneyTxt.Focus()
    End Sub

    ' ENTER STARTING AMOUNT MONEY TO START BUSINESS TRANSACTIONS
    Private Sub enterStrtingMoneyBtn_Click(sender As Object, e As EventArgs) Handles enterStrtingMoneyBtn.Click
        If startingMoneyTxt.Text = "" Or startingMoneyTxt.Text = "0" Or IsNumeric(startingMoneyTxt.Text) = False Then
            MessageBox.Show("Please enter Starting Money", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            getmaxDayNum()
            Try
                conOpen()
                cmdStartEnd.Connection = conn
                cmdStartEnd.CommandText = "INSERT INTO started_ended (`dayNum`, `startedBy`,`startingMoney`,`endedBy`,`grossSales`,`netSales`,`date`, `timeStart`, `timeEnd`) 
            VALUES ('" & dNumHold & "','" & accountLbl.Text & "','" & startingMoneyTxt.Text & "','" & "Not Yet Ended" & "','" & "0" & "','" & "0" & "','" & dateLbl.Text & "', '" & timeLbl.Text & "', '" & "Not yet Ended" & "')"
                cmdStartEnd.ExecuteNonQuery()
                startDayBtn.Enabled = False
                startingMoneyInputPanel.Width = 0
                MessageBox.Show("Day Started. You can now make business transactions", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Starting Day", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            Finally
                enabler()
                started_ended = "TRUE"
                operationRecord.loadData()
            End Try
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        startingMoneyInputPanel.Width = 0
    End Sub

    Sub disabler()
        orderBtn.Enabled = False
        Button17.Enabled = False
        endDayBtn.Enabled = False
        refundBtn.Enabled = False
        startDayBtn.Enabled = False
    End Sub

    Sub enabler()
        orderBtn.Enabled = True
        Button17.Enabled = True
        endDayBtn.Enabled = True
        refundBtn.Enabled = True
        startDayBtn.Enabled = False

    End Sub

    Private Sub startingMoneyTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles startingMoneyTxt.KeyDown
        If e.KeyCode = 13 Then
            If startingMoneyTxt.Text = "" Or startingMoneyTxt.Text = "0" Or IsNumeric(startingMoneyTxt.Text) = False Then
                MessageBox.Show("Please enter Starting Money", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                enterStrtingMoneyBtn.PerformClick()
            End If
        End If

    End Sub

    Dim dayEnded As String = "FALSE"
    Private Sub endDayBtn_Click(sender As Object, e As EventArgs) Handles endDayBtn.Click
        Dim confirm As New DialogResult

        confirm = MessageBox.Show("Are you sure you want to End? There is NO UNDO on this Action.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirm = DialogResult.Yes Then

            Try
                conOpen()
                cmdStartEnd.Connection = conn
                cmdStartEnd.CommandText = " SELECT IFNULL(SUM(orderTotal),0) FROM transactions WHERE dateOrdered = '" & dateLbl.Text & "'"
                grossSales = cmdStartEnd.ExecuteScalar
                Dim gsales As Integer = grossSales
                cmdStartEnd.CommandText = " SELECT startingMoney FROM started_ended WHERE date = '" & dateLbl.Text & "'"
                strtngMny = cmdStartEnd.ExecuteScalar
                conn.Close()
                grossSales += strtngMny

                conOpen()
                cmdStartEnd.Connection = conn
                cmdStartEnd.CommandText = "UPDATE started_ended  SET `endedBy`='" & accountLbl.Text & "' , `grossSales`='" & grossSales & "' , `netSales`='" & gsales & "', `timeEnd`='" & timeLbl.Text & "' WHERE date = '" & dateLbl.Text & "'"
                cmdStartEnd.ExecuteNonQuery()
                conn.Close()
                disabler()
                started_ended = "FALSE"
                operationRecord.loadData()
                MessageBox.Show("Day Ended. Now you can't make any Transaction", "Day Ended", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Ending Day", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try

            dayEnded = "TRUE"
        End If

    End Sub

    ' ////////////////////////////////////////// BASIC CODES //////////////////////////////////////////////////////////////

    Private Sub ModifyFoodMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModifyFoodMenuToolStripMenuItem.Click
        Dim MDM As New Modify_Food_Menu
        If isOpenForm(MDM) Then
            For Each OpenForm In Application.OpenForms()
                If TypeOf (OpenForm) Is Modify_Food_Menu Then
                    CType(OpenForm, Modify_Food_Menu).BringToFront()

                End If
            Next
        Else
            Modify_Food_Menu.Show()
        End If

    End Sub

    Private Sub searchtxt_Click(sender As Object, e As EventArgs) Handles searchtxt.Click
        filterReceiver.Clear()
    End Sub

    Private Sub searchtxt_TextChanged(sender As Object, e As EventArgs) Handles searchtxt.TextChanged
        fColorChange()
        filterReceiver.Clear()
        loadMenuList()
    End Sub

    Private Sub filterReceiver_TextChanged(sender As Object, e As EventArgs) Handles filterReceiver.TextChanged
        searchtxt.Clear()
        loadMenuList()
        fColorChange()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim closing_confirm As New DialogResult
        closing_confirm = MessageBox.Show("Are you sure you want to close Application? It will automatically end day.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If dayEnded = "FALSE" Then
            If closing_confirm = DialogResult.Yes Then
                Try
                    conOpen()
                    cmdStartEnd.Connection = conn
                    cmdStartEnd.CommandText = " SELECT IFNULL(SUM(orderTotal),0) FROM transactions WHERE dateOrdered = '" & dateLbl.Text & "'"
                    grossSales = cmdStartEnd.ExecuteScalar
                    Dim gsales As Integer = grossSales
                    cmdStartEnd.CommandText = " SELECT startingMoney FROM started_ended WHERE date = '" & dateLbl.Text & "'"
                    strtngMny = cmdStartEnd.ExecuteScalar
                    conn.Close()
                    grossSales += strtngMny

                    conOpen()
                    cmdStartEnd.Connection = conn
                    cmdStartEnd.CommandText = "UPDATE started_ended  SET `endedBy`='" & accountLbl.Text & "' , `grossSales`='" & grossSales & "' , `netSales`='" & gsales & "', `timeEnd`='" & timeLbl.Text & "' WHERE date = '" & dateLbl.Text & "'"
                    cmdStartEnd.ExecuteNonQuery()
                    conn.Close()
                    disabler()
                    started_ended = "FALSE"
                    operationRecord.loadData()
                    MessageBox.Show("Day Ended. Now you can't make any Transaction", "Day Ended", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error Ending Day", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try
            Else
                End
            End If
        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        If searchtxt.Text <> "" Or filterReceiver.Text <> "" Then
            filterReceiver.Clear()
            searchtxt.Clear()
        Else
            loadMenuList()
        End If
        fColorChange()
        Button10.ForeColor = Color.Red
    End Sub

    Public Sub fColorChange()
        Button1.ForeColor = Color.Black
        Button2.ForeColor = Color.Black
        Button3.ForeColor = Color.Black
        Button4.ForeColor = Color.Black
        Button6.ForeColor = Color.Black
        Button10.ForeColor = Color.Black
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        searchtxt.Clear()
        filterReceiver.Text = "BURGER"
        fColorChange()
        Button1.ForeColor = Color.Red
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        searchtxt.Clear()
        filterReceiver.Text = "DRINKS"
        fColorChange()
        Button3.ForeColor = Color.Red

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        searchtxt.Clear()
        filterReceiver.Text = "PIZZA"
        fColorChange()
        Button2.ForeColor = Color.Red

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        searchtxt.Clear()
        filterReceiver.Text = "DESSERT"
        fColorChange()
        Button4.ForeColor = Color.Red

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        searchtxt.Clear()
        filterReceiver.Text = "FRIES"
        fColorChange()
        Button6.ForeColor = Color.Red

    End Sub
    ' POP UP WINDOW
    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        quantityInput.Width = 0
        flp1.Enabled = True
    End Sub

    Private Sub quantityTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles quantityTxt.KeyDown
        If e.KeyCode = 13 Then
            enterBtn.PerformClick()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If receiptPanel.Width >= 400 Then
            Timer1.Enabled = False
        Else
            receiptPanel.Width = receiptPanel.Width + 25
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If receiptPanel.Width <= 0 Then
            Timer2.Enabled = False
        Else
            receiptPanel.Width = receiptPanel.Width - 25
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

        If receiptPanel.Width <= 0 Then

            Timer1.Enabled = True
            Button14.Text = "Close Receipt"


        ElseIf receiptPanel.Width = 400 Then
            Timer2.Enabled = True
            Button14.Text = "View Receipt"

        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Timer2.Enabled = True
        Button14.Text = "View Receipt"

    End Sub

    Private Sub dgv2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentClick
        Dim i As Integer = dgv2.CurrentRow.Index
        tableId.Text = dgv2.Item(0, i).Value
        tableNumtxt.Text = dgv2.Item(1, i).Value
        tableStatTxt.Text = dgv2.Item(2, i).Value
        tableAmountTxt.Text = dgv2.Item(3, i).Value
        deleteTableBtn.Visible = True
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        tablePickingPanel.Visible = False
        tablePickingPanel.Width = 0
        If tableNoLbl.Text = 0 And takeOutStat.Text = "" Then
            orderBtn.Enabled = True
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        tablePickingPanel.Visible = True
        tablePickingPanel.Width = 638

        AvTableLoadData()
    End Sub

    Private Sub timeOfTheDay_Tick(sender As Object, e As EventArgs) Handles timeOfTheDay.Tick
        timeLbl.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        flp1.Enabled = True
        receiptTxt.Clear()
        tableNoLbl.Text = "0"
        takeOutStat.Text = "TAKE OUT "
        receiptTxt.Text = "MCBEE FASTFOOD RESTAURANT" & Environment.NewLine & Environment.NewLine + "Transaction No.  :  " + transactionNoLbl.Text & Environment.NewLine + "Date  :  " + dateLbl.Text & Environment.NewLine + "Time  :  " + timeLbl.Text & Environment.NewLine + "Table No.  :  " + tableNoLbl.Text & Environment.NewLine + "* TAKE OUT ONLY *" & Environment.NewLine & Environment.NewLine
        tablePickingPanel.Width = 0
        totalSaveLbl.Text = "0"
        dateSaveLbl.Text = dateLbl.Text
        timeSaveLbl.Text = timeLbl.Text
        cancelOrderBtn.Visible = True

    End Sub

    Private Sub TransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransactionToolStripMenuItem.Click
        Dim trans As New TransactionsRecords
        If isOpenForm(trans) Then
            For Each openForm In Application.OpenForms()
                If TypeOf (openForm) Is TransactionsRecords Then
                    CType(openForm, TransactionsRecords).BringToFront()
                End If
            Next
        Else

            TransactionsRecords.Show()
        End If

    End Sub

    Private Sub paymentInputTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles paymentInputTxt.KeyDown
        If e.KeyCode = 13 Then
            enterPaymentBtn.PerformClick()

        End If
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click

        Dim inv As New InventoryForm
        If isOpenForm(inv) Then
            For Each openForm In Application.OpenForms()
                If TypeOf (openForm) Is InventoryForm Then
                    CType(openForm, InventoryForm).BringToFront()

                End If
            Next
        Else
            InventoryForm.Show()

        End If

    End Sub

    Private Sub paymentInputTxt_TextChanged(sender As Object, e As EventArgs) Handles paymentInputTxt.TextChanged
        If paymentInputTxt.Text <> "" And IsNumeric(paymentInputTxt.Text) = False Then
            MessageBox.Show("Number Only!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            paymentInputTxt.Clear()
            paymentInputTxt.Focus()

        End If
    End Sub

    Private Sub CreateAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateAccountToolStripMenuItem.Click
        Dim createAcc As New createAccount
        If isOpenForm(createAcc) Then
            For Each openForm In Application.OpenForms()
                If TypeOf (openForm) Is createAccount Then
                    CType(openForm, createAccount).BringToFront()
                End If
            Next
        Else

            createAccount.Show()
        End If
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click

        If started_ended = "FALSE" Then
            accountLoggedInStat = "GUEST MODE"
            idLbl.Text = 0
            mainFormLoad()
        Else
            MessageBox.Show("You can't LogOut While Today's Operation is not ended.")
        End If


    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        If accountLoggedInStat <> "GUEST MODE" Then
            MessageBox.Show("There's an Account Currently Logged in. Log Out first to Login an Account", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            Dim login As New loginAccount
            If isOpenForm(login) Then
                For Each openForm In Application.OpenForms()
                    If TypeOf (openForm) Is loginAccount Then
                        CType(openForm, loginAccount).BringToFront()
                    End If
                Next
            Else

                loginAccount.Show()
            End If

        End If

    End Sub

    Private Sub MyAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MyAccountToolStripMenuItem.Click
        Dim myAcc As New myAccount
        If isOpenForm(myAcc) Then
            For Each openForm In Application.OpenForms()
                If TypeOf (openForm) Is myAccount Then
                    CType(openForm, myAccount).BringToFront()
                End If
            Next
        Else

            myAccount.Show()
        End If
    End Sub

    Dim grossSales As Integer
    Dim strtngMny As Integer

    Private Sub refundBtn_Click(sender As Object, e As EventArgs) Handles refundBtn.Click
        Dim choose As New DialogResult

        choose = MessageBox.Show("Do you want to refund by Whole Orders? Click Yes." & vbCrLf & "" & vbCrLf & "Click No to refund by single FoodItem", "Choose type of Refund", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If choose = DialogResult.Yes Then
            Dim trans As New TransactionsRecords
            If isOpenForm(trans) Then
                For Each openForm In Application.OpenForms()
                    If TypeOf (openForm) Is TransactionsRecords Then
                        CType(openForm, TransactionsRecords).BringToFront()
                    End If
                Next
            Else

                TransactionsRecords.Show()
            End If

        ElseIf choose = DialogResult.No Then
            Dim sales As New SalesRecord
            If isOpenForm(sales) Then
                For Each openForm In Application.OpenForms()
                    If TypeOf (openForm) Is SalesRecord Then
                        CType(openForm, SalesRecord).BringToFront()
                    End If
                Next
            Else

                SalesRecord.Show()
            End If
        End If
    End Sub

    Private Sub AdminAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountInfoToolStripMenuItem.Click
        Dim accInfo As New AccountInformation
        If isOpenForm(accInfo) Then
            For Each openForm In Application.OpenForms()
                If TypeOf (openForm) Is AccountInformation Then
                    CType(openForm, AccountInformation).BringToFront()
                End If
            Next
        Else

            AccountInformation.Show()
        End If
    End Sub

    Private Sub SalesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        Dim sales As New SalesRecord
        If isOpenForm(sales) Then
            For Each openForm In Application.OpenForms()
                If TypeOf (openForm) Is SalesRecord Then
                    CType(openForm, SalesRecord).BringToFront()
                End If
            Next
        Else

            SalesRecord.Show()
        End If
    End Sub

    Private Sub OperationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperationsToolStripMenuItem.Click
        Dim oprtns As New operationRecord
        If isOpenForm(oprtns) Then
            For Each openForm In Application.OpenForms()
                If TypeOf (openForm) Is operationRecord Then
                    CType(openForm, operationRecord).BringToFront()
                End If
            Next
        Else

            operationRecord.Show()
        End If
    End Sub

    Private Sub DeveloperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeveloperToolStripMenuItem.Click
        Dim dev As New Developer
        If isOpenForm(dev) Then
            For Each openForm In Application.OpenForms()
                If TypeOf (openForm) Is Developer Then
                    CType(openForm, Developer).BringToFront()
                End If
            Next
        Else
            Developer.Show()
        End If
    End Sub

    Private Sub MaximizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaximizeToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MinimizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinimizeToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Public Function isOpenForm(ByVal form As Form) As Boolean
        Dim formCol As FormCollection
        formCol = Application.OpenForms
        Dim stat As Integer = 0
        For Each frm As Form In formCol
            If frm.Name = form.Name Then
                stat += 1
            End If
        Next
        Return IIf(stat > 0, True, False)
    End Function

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If dayEnded = "FALSE" Then

            Try
                conOpen()
                cmdStartEnd.Connection = conn
                cmdStartEnd.CommandText = " SELECT IFNULL(SUM(orderTotal),0) FROM transactions WHERE dateOrdered = '" & dateLbl.Text & "'"
                grossSales = cmdStartEnd.ExecuteScalar
                Dim gsales As Integer = grossSales
                cmdStartEnd.CommandText = " SELECT startingMoney FROM started_ended WHERE date = '" & dateLbl.Text & "'"
                strtngMny = cmdStartEnd.ExecuteScalar
                conn.Close()
                grossSales += strtngMny

                conOpen()
                cmdStartEnd.Connection = conn
                cmdStartEnd.CommandText = "UPDATE started_ended  SET `endedBy`='" & accountLbl.Text & "' , `grossSales`='" & grossSales & "' , `netSales`='" & gsales & "', `timeEnd`='" & timeLbl.Text & "' WHERE date = '" & dateLbl.Text & "'"
                cmdStartEnd.ExecuteNonQuery()
                conn.Close()
                disabler()
                started_ended = "FALSE"
                operationRecord.loadData()
                MessageBox.Show("Day Ended. Now you can't make any Transaction", "Day Ended", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Ending Day", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        Else
            End
        End If


    End Sub
End Class

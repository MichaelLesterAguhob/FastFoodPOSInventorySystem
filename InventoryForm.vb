Imports MySql.Data.MySqlClient

Public Class InventoryForm
    Dim cmdInventory As New MySqlCommand
    Dim dtInventory As New DataTable
    Dim daInventory As New MySqlDataAdapter

    Private Sub InventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadInventory()
    End Sub

    ' /////////////////////////////////////   MY MAIN CODE   //////////////////////////////////////////////

    ' JUST LOADING ALL DATA FROM DATABASE THAT INCLUDED IN INVENTORY
    Public Sub loadInventory()

        Try
            conOpen()
            cmdInventory.Connection = conn
            cmdInventory.CommandText = "SELECT code, name, category, quantity FROM foodmenu WHERE inventory = 'YES' ORDER BY code ASC "
            daInventory.SelectCommand = cmdInventory
            dtInventory.Clear()
            daInventory.Fill(dtInventory)
            dgv1.DataSource = dtInventory

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR : Loading Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try

    End Sub

    ' SEARCHING DATA WHEN SEARCH TEXT FIELD IS CHANGED
    Private Sub searchtxt_TextChanged(sender As Object, e As EventArgs) Handles searchtxt.TextChanged
        If searchtxt.Text <> "" And cbox1.Text = "QUANTITY" Then
            Try
                conOpen()
                cmdInventory.Connection = conn
                cmdInventory.CommandText = "SELECT code, name, category, quantity FROM foodmenu WHERE quantity LIKE '" & searchtxt.Text & "%' and inventory = 'YES' "
                daInventory.SelectCommand = cmdInventory
                dtInventory.Clear()
                daInventory.Fill(dtInventory)
                dgv1.DataSource = dtInventory

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR : searching in Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        ElseIf searchtxt.Text <> "" And cbox1.Text = "NAME" Then
            Try
                conOpen()
                cmdInventory.Connection = conn
                cmdInventory.CommandText = "SELECT code, name, category, quantity FROM foodmenu WHERE name LIKE '%" & searchtxt.Text & "%' and inventory = 'YES' "
                daInventory.SelectCommand = cmdInventory
                dtInventory.Clear()
                daInventory.Fill(dtInventory)
                dgv1.DataSource = dtInventory

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR : searching in Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        ElseIf searchtxt.Text <> "" And cbox1.Text = "CATEGORY" Then
            Try
                conOpen()
                cmdInventory.Connection = conn
                cmdInventory.CommandText = "SELECT code, name, category, quantity FROM foodmenu WHERE category LIKE '%" & searchtxt.Text & "%' and inventory = 'YES' "
                daInventory.SelectCommand = cmdInventory
                dtInventory.Clear()
                daInventory.Fill(dtInventory)
                dgv1.DataSource = dtInventory

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR : searching in Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        Else
            loadInventory()
        End If
    End Sub
    ' JUST VALIDATING USER INPUT
    Private Sub quantityTxt_TextChanged(sender As Object, e As EventArgs) Handles quantityTxt.TextChanged
        If quantityTxt.Text <> "" And IsNumeric(quantityTxt.Text) = False Then
            MessageBox.Show("Number Only! Check your input!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            quantityTxt.Clear()
            quantityTxt.Focus()

        End If
    End Sub

    Private Sub quantityTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles quantityTxt.KeyDown
        If e.KeyCode = 13 Then
            If quantityTxt.Text = "" Or quantityTxt.Text = "0" Then
                MessageBox.Show("Quantity must be 1 or more! ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                quantityTxt.Focus()
            Else
                setbtn.PerformClick()
            End If

        End If

    End Sub

    ' MODIFYING THE FOOD MENU INVENTORY
    Private Sub setbtn_Click(sender As Object, e As EventArgs) Handles setbtn.Click
        If quantityTxt.Text = "" Then
            MessageBox.Show("Quantity must be 1 or more! ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            quantityTxt.Focus()

        ElseIf searchtxt.Text <> "" Or codeHolderLbl.Text <> 0 Then

            Try
                conOpen()
                cmdInventory.Connection = conn
                cmdInventory.CommandText = "UPDATE foodmenu SET quantity = '" & quantityTxt.Text & "' WHERE code = '" & codeHolderLbl.Text & "'"
                cmdInventory.ExecuteNonQuery()

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error : Setting new Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            Finally
                quantityTxt.Clear()
                loadInventory()
            End Try
        Else
            MessageBox.Show("Select Item First!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            quantityTxt.Focus()
        End If
    End Sub

    ' TRANSFER CODE FROM DATABASE TO LABEL AND USE FOR UPDATING INVENTORY OF AN ITEM
    Private Sub dgv1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Dim i As Integer = dgv1.CurrentRow.Index
        codeHolderLbl.Text = dgv1.Item(0, i).Value
        quantityTxt.Focus()
    End Sub

    Private Sub cbox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbox1.SelectedIndexChanged
        searchtxt.Focus()
    End Sub


End Class
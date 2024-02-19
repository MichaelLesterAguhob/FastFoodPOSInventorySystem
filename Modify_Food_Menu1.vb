Imports MySql.Data.MySqlClient

Public Class Modify_Food_Menu
    Private Sub Modify_Food_Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        dateLbl.Text = DateTime.Now.ToLongDateString

        dgv1.RowsDefaultCellStyle.BackColor = Drawing.Color.LightBlue
        dgv1.AlternatingRowsDefaultCellStyle.BackColor = Drawing.Color.LightGreen

        addbtn.Enabled = False
        deletebtn.Enabled = False
        updatebtn.Enabled = False
        cancelbtn.Visible = False
        getMaxCode()
    End Sub

    ' //////////////////////////////////  THIS IS MY FUNTIONS/METHODS SECTION ///////////////////////////////

    '  GETTING MAX CODE FROM DATABASE 
    Public Sub getMaxCode()
        conn.Close()

        Try
            conOpen()
            cmd.Connection = conn
            cmd.CommandText = "SELECT IFNULL(MAX(code),0) FROM foodmenu"
            Dim code As Integer = cmd.ExecuteScalar
            If code > 0 Then
                conn.Close()
                loadData()
                codetxt.Text = code + 1
                codeHolderMax.Text = code
            Else
                codetxt.Text = 1
            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error | getMaxCOde")
            conn.Close()
        End Try

    End Sub
    '  LOADING DATA FROM DATABASE INTO DATA GRID VIEW 
    Public Sub loadData()
        Try
            conOpen()
            cmd.Connection = conn
            cmd.CommandText = "SELECT code, image, name, price, category, quantity, inventory FROM foodmenu order by code asc"
            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)
            dgv1.DataSource = dt

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error | Loading Data")
            conn.Close()
        End Try

    End Sub

    Sub clearFMT()

        PictureBox1.Image = Nothing
        nametxt.Clear()
        pricetxt.Clear()
        categorytxt.Clear()
        quantitytxt.Clear()
        nametxt.Focus()
        TextBox1.Clear()
        getMaxCode()
    End Sub

    Public Sub readOnlyTXt()
        nametxt.ReadOnly = True
        pricetxt.ReadOnly = True
        categorytxt.ReadOnly = True
        quantitytxt.ReadOnly = True
        browsebtn.Enabled = False
    End Sub

    Public Sub enableTxt()
        nametxt.ReadOnly = False
        pricetxt.ReadOnly = False
        categorytxt.ReadOnly = False
        quantitytxt.ReadOnly = False
        noCbx.Enabled = True
        yesCbx.Enabled = True
        browsebtn.Enabled = True
    End Sub

    '  //////////////////////////////////  THIS IS MY MAIN CODE SECTION ///////////////////////////////

    '  BROWSE FOR IMAGE FILE 
    Dim imagePath As String
    Dim arrImg() As Byte
    Private Sub browsebtn_Click(sender As Object, e As EventArgs) Handles browsebtn.Click
        Try
            Dim ofd As FileDialog = New OpenFileDialog()
            ofd.Filter = "Image File (*.jpg;*.png;*.gif;*.jpeg)|*.jpg;*.bmp;*.gif;*.jpeg"

            If ofd.ShowDialog = DialogResult.OK Then
                imagePath = ofd.FileName
                PictureBox1.ImageLocation = imagePath
                clearBtn.Visible = True

            ElseIf clickStat = 1 Then
                addbtn.Enabled = False

            Else
                addbtn.Enabled = True
                clearBtn.Visible = True
            End If

            ofd = Nothing
            nametxt.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error | Retrieving Image")
        End Try
    End Sub

    '  INSERT FUNTION WITH FOOD MENU IMAGE 
    Dim inv As String = "NO"
    Private Sub addbtn_Click(sender As Object, e As EventArgs) Handles addbtn.Click

        If PictureBox1.ImageLocation = Nothing Then
            MessageBox.Show("Insert Image First before you can add new item", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        ElseIf nametxt.Text = "" Or pricetxt.Text = "" Or categorytxt.Text = "" Or quantitytxt.Text = "" Then
            MessageBox.Show("Fill up all needed information first!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            Try
                conOpen()

                Dim ms As New System.IO.MemoryStream()
                PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                arrImg = ms.GetBuffer()
                Dim fileSize As UInt32
                fileSize = ms.Length
                ms.Close()

                cmd.Connection = conn
                cmd.CommandText = "INSERT INTO foodmenu (`code`,`name`,`price`,`category`,`quantity`,`inventory`,`image`) VALUES ('" & codetxt.Text.Trim & "',
            '" & nametxt.Text.ToUpper.Trim & "','" & pricetxt.Text.Trim & "','" & categorytxt.Text.ToUpper.Trim & "','" & quantitytxt.Text & "','" & inv.ToUpper.Trim & "',@image)"
                cmd.Parameters.AddWithValue("@image", arrImg)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Added New Item", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmd.Parameters.Clear()

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error | Inserting Data With Image")
                conn.Close()
            Finally
                clearFMT()
                loadData()
                addbtn.Enabled = False
                clearBtn.Visible = False
                yesCbx.Checked = False
                noCbx.Checked = False

            End Try
        End If

    End Sub

    '   DISPLAY DATA FROM DATAGRIDVIEW INTO TEXTBOX 
    Dim clickStat As Integer
    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        clickStat = 1

        Dim i As Integer = dgv1.CurrentRow.Index
        codeHolderSelected.Text = dgv1.Item(0, i).Value

        codetxt.Text = dgv1.Item(0, i).Value
        nametxt.Text = dgv1.Item(2, i).Value
        pricetxt.Text = dgv1.Item(3, i).Value
        categorytxt.Text = dgv1.Item(4, i).Value
        quantitytxt.Text = dgv1.Item(5, i).Value
        TextBox1.Text = dgv1.Item(6, i).Value

        noCbx.Enabled = False
        yesCbx.Enabled = False
        deletebtn.Enabled = True
        cancelbtn.Visible = True
        editbtn.Enabled = True
        editbtn.Visible = True
        editbtn.Focus()

        readOnlyTXt()
        addbtn.Enabled = False
    End Sub

    'CODES FOR MY UPDATE BUTTON
    Private Sub updatebtn_Click(sender As Object, e As EventArgs) Handles updatebtn.Click

        Try
            conOpen()

            Dim ms As New System.IO.MemoryStream()
            PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrImg = ms.GetBuffer()
            Dim fileSize As UInt32
            fileSize = ms.Length
            ms.Close()

            cmd.Connection = conn
            cmd.CommandText = "UPDATE foodmenu SET `name`='" & nametxt.Text.ToUpper.Trim & "',`price`='" & pricetxt.Text.ToUpper.Trim & "',
            `category`='" & categorytxt.Text.ToUpper.Trim & "',`quantity`='" & quantitytxt.Text.ToUpper.Trim & "',
            `inventory`='" & inv.ToUpper.Trim & "',`image`=@image WHERE code = '" & codetxt.Text.ToUpper.Trim & "'"
            cmd.Parameters.AddWithValue("@image", arrImg)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Successfully Updated Item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmd.Parameters.Clear()

            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error | Updating Data With Image")
            conn.Close()
        Finally
            getMaxCode()
            clearFMT()
            updatebtn.Enabled = False
            cancelbtn.Visible = False
            nametxt.Focus()
            clickStat = 0
            editbtn.Visible = False
            deletebtn.Enabled = False
            TextBox1.Text = ""
            noCbx.Checked = False
            yesCbx.Checked = False
            searchTxt.Clear()
        End Try
    End Sub

    Dim arrImage() As Byte
    Public Sub replaceItem()

        If codeHolderMax.Text <> codeHolderSelected.Text Then
            Try
                conOpen()
                cmd.Connection = conn
                cmd.CommandText = "UPDATE `foodmenu` SET `code`= '" & codeHolderSelected.Text & "' WHERE `code`='" & codeHolderMax.Text & "'"
                cmd.ExecuteNonQuery()
                conn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error | Deleting and Replacing Data With Image03")
                conn.Close()

            End Try
        Else
            enableTxt()
            loadData()
            clearFMT()
        End If
        enableTxt()
        loadData()
        clearFMT()
    End Sub

    ' CODES FOR MY SINGLE ITEM DELETE BUTTON  
    Private Sub deletebtn_Click(sender As Object, e As EventArgs) Handles deletebtn.Click

        Dim cnfrm As New DialogResult
        cnfrm = MessageBox.Show("Delete this Item?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If cnfrm = DialogResult.Yes Then
            Try
                conn.Open()
                cmd.Connection = conn
                cmd.CommandText = "DELETE FROM foodmenu WHERE code ='" & codetxt.Text & "'"
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Deleted Item", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error | Deleting and Replacing Data With Image02")
                conn.Close()
            Finally
                conn.Close()

                enableTxt()
                replaceItem()
                clearFMT()
            End Try
        End If
        editbtn.Visible = False
        deletebtn.Enabled = False
        updatebtn.Enabled = False
        cancelbtn.Visible = False
        clearBtn.Visible = False
        browsebtn.Enabled = True
        clickStat = 0
        searchTxt.Clear()
    End Sub

    ' DATA BINDINGS FOR ITEM WITH MAX CODE, HOLD THE ITEM WITH THE MAX CODE AND REPLACE THE ITEM DELETED  
    Private Sub codeHolderMax_TextChanged(sender As Object, e As EventArgs) Handles codeHolderMax.TextChanged
        Dim cmd1 As New MySqlCommand
        Try
            conOpen()
            cmd1.Connection = conn
            cmd1.CommandText = "SELECT * FROM foodmenu WHERE code='" & codeHolderMax.Text & "'"
            da.SelectCommand = cmd1
            ds.Clear()
            da.Fill(ds, "foodmenu")

            nameHolder.DataBindings.Add("Text", ds, "foodmenu.name")
            nameHolder.DataBindings.Clear()

            catHolder.DataBindings.Add("Text", ds, "foodmenu.category")
            catHolder.DataBindings.Clear()

            priceHolder.DataBindings.Add("Text", ds, "foodmenu.price")
            priceHolder.DataBindings.Clear()

            qntyHolder.DataBindings.Add("Text", ds, "foodmenu.quantity")
            qntyHolder.DataBindings.Clear()

            invholder.DataBindings.Add("Text", ds, "foodmenu.inventory")
            invholder.DataBindings.Clear()

            conn.Close()
            Try
                conOpen()
                Dim cmd2 As New MySqlCommand
                cmd2.Connection = conn
                cmd2.CommandText = "SELECT image FROM foodmenu WHERE code = '" & codeHolderMax.Text & "'"
                dr = cmd2.ExecuteReader
                dr.Read()

                Dim img() As Byte

                If dr.HasRows Then
                    img = dr("image")
                    Dim ms As New System.IO.MemoryStream(img)
                    pBoxHolder.Image = Image.FromStream(ms)
                    pBoxHolder.SizeMode = PictureBoxSizeMode.AutoSize
                Else
                    pBoxHolder.Image = Nothing
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error | image retrieve")
                conn.Close()
                pBoxHolder.Image = Nothing
            Finally
                conn.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error | Last Item Holder")
            conn.Close()
        End Try

    End Sub

    ' CODES FOR CODE CHANGES TO LOAD IMAGE INTO PICTUREBOX1 
    Private Sub codetxt_TextChanged(sender As Object, e As EventArgs) Handles codetxt.TextChanged
        conOpen()
        Try
            cmd.Connection = conn
            cmd.CommandText = "SELECT image FROM foodmenu WHERE code= '" & codetxt.Text & "'"
            dr = cmd.ExecuteReader
            dr.Read()

            If dr.HasRows Then
                Dim img1() As Byte
                img1 = dr("image")
                Dim ms1 As New System.IO.MemoryStream(img1)
                PictureBox1.Image = Image.FromStream(ms1)
                PictureBox1.SizeMode = PictureBox1.AutoSize
            Else
                PictureBox1.Image = Nothing
            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error | Current row image selected")
            conn.Close()
            PictureBox1.Image = Nothing
        End Try
    End Sub

    ' DELETE ALL ITEM FROM FOODMENU TABLE
    Private Sub confirmDelete_Click(sender As Object, e As EventArgs) Handles confirmDelete.Click
        Try

            If confirmTxt.Text = "CONFIRM" Then
                Try
                    conOpen()
                    cmd.Connection = conn
                    cmd.CommandText = "DELETE FROM foodmenu "
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("SUCCESSFULLY DELETED ALL ITEMS!", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MsgBox(ex.Message)
                    conn.Close()
                    GroupBox4.Visible = False
                End Try
            Else
                MessageBox.Show("TYPE 'CONFIRM' TO CONTINUE ", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Information)
                confirmTxt.Clear()
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            conn.Close()
        Finally
            noCbx.Enabled = True
            yesCbx.Enabled = True
            deletebtn.Enabled = False
            cancelbtn.Visible = False
            editbtn.Enabled = False
            editbtn.Visible = False
        End Try
        loadData()
        getMaxCode()

        pBoxHolder.Image = Nothing
        codeHolderSelected.Clear()
        nameHolder.Clear()
        catHolder.Clear()
        qntyHolder.Clear()
        invholder.Clear()
        codeHolderMax.Clear()
    End Sub

    ' ////////////////////////////////// MY BASIC CODE SECTION /////////////////////////////////////////

    Private Sub yesCbx_CheckedChanged(sender As Object, e As EventArgs) Handles yesCbx.CheckedChanged
        If clickStat = 1 And yesCbx.Checked = True Then
            noCbx.Checked = False
            inv = "YES"
            quantitytxt.ReadOnly = False

        ElseIf clickStat = 0 And yesCbx.Checked = True Then
            noCbx.Checked = False
            inv = "YES"
            quantitytxt.ReadOnly = False
            quantitytxt.Focus()
            clearBtn.Visible = True
        End If
    End Sub

    Private Sub noCbx_CheckedChanged(sender As Object, e As EventArgs) Handles noCbx.CheckedChanged
        If clickStat = 1 And noCbx.Checked = True Then
            yesCbx.Checked = False
            inv = "NO"
            quantitytxt.Text = 0
            quantitytxt.ReadOnly = True

        ElseIf clickStat = 0 And noCbx.Checked = True Then
            yesCbx.Checked = False
            inv = "NO"
            quantitytxt.Text = 0
            quantitytxt.ReadOnly = True
            addbtn.Enabled = True
            addbtn.Focus()
            clearBtn.Visible = True

        End If
    End Sub

    Private Sub nametxt_KeyDown(sender As Object, e As KeyEventArgs) Handles nametxt.KeyDown
        If e.KeyCode = 13 Then
            If nametxt.Text = "" Then
                MessageBox.Show("Fill in the Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                categorytxt.Focus()
            End If
        End If
    End Sub

    Private Sub categorytxt_KeyDown(sender As Object, e As KeyEventArgs) Handles categorytxt.KeyDown
        If e.KeyCode = 13 Then
            If categorytxt.Text = "" Then
                MessageBox.Show("Fill in the Category", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                pricetxt.Focus()
            End If
        End If
    End Sub

    Private Sub pricetxt_KeyDown(sender As Object, e As KeyEventArgs) Handles pricetxt.KeyDown
        If e.KeyCode = 13 Then
            If pricetxt.Text = "" Then
                MessageBox.Show("Fill in the Price", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                yesCbx.Focus()
            End If
        End If
    End Sub

    Private Sub yesCbx_KeyDown(sender As Object, e As KeyEventArgs) Handles yesCbx.KeyDown
        If e.KeyCode = 13 Then
            yesCbx.Checked = True
            quantitytxt.Focus()

        End If
    End Sub

    Private Sub quantitytxt_KeyDown(sender As Object, e As KeyEventArgs) Handles quantitytxt.KeyDown
        If e.KeyCode = 13 Then
            If quantitytxt.Text = "" Then
                MessageBox.Show("Fill in the Quantity", "Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ElseIf clickStat = 1 Then
                updatebtn.Focus()
            Else
                addbtn.Enabled = True
                addbtn.Focus()
            End If
        End If
    End Sub

    Private Sub cancelbtn_Click(sender As Object, e As EventArgs) Handles cancelbtn.Click
        clickStat = 0
        clearFMT()
        TextBox1.Text = ""
        enableTxt()
        editbtn.Enabled = True
        addbtn.Enabled = False
        editbtn.Visible = False
        deletebtn.Enabled = False
        updatebtn.Enabled = False
        cancelbtn.Visible = False
        noCbx.Checked = False
        yesCbx.Checked = False
        noCbx.Enabled = True
        yesCbx.Enabled = True
        searchTxt.Clear()
    End Sub

    Private Sub editbtn_Click(sender As Object, e As EventArgs) Handles editbtn.Click
        enableTxt()
        editbtn.Enabled = False
        updatebtn.Enabled = True
        nametxt.Focus()
        TextBox1.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        PictureBox1.Image = Nothing
        clearFMT()
        yesCbx.Checked = False
        noCbx.Checked = False
        TextBox1.Clear()
        clearBtn.Visible = False
        addbtn.Enabled = False
    End Sub

    Private Sub quantitytxt_TextChanged(sender As Object, e As EventArgs) Handles quantitytxt.TextChanged
        If quantitytxt.Text <> "" And clickStat <> 1 Then
            addbtn.Enabled = True
            clearBtn.Visible = True

        Else
            addbtn.Enabled = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "YES" Then
            yesCbx.Checked = True
        ElseIf TextBox1.Text = "NO" Then
            noCbx.Checked = True
        End If

    End Sub

    Private Sub nametxt_TextChanged(sender As Object, e As EventArgs) Handles nametxt.TextChanged
        If nametxt.Text <> "" And clickStat <> 1 Then
            clearBtn.Visible = True

        End If
    End Sub

    Private Sub categorytxt_TextChanged(sender As Object, e As EventArgs) Handles categorytxt.TextChanged
        If categorytxt.Text <> "" And clickStat <> 1 Then
            clearBtn.Visible = True
        End If
    End Sub

    Private Sub pricetxt_TextChanged(sender As Object, e As EventArgs) Handles pricetxt.TextChanged
        If pricetxt.Text <> "" And clickStat <> 1 Then
            clearBtn.Visible = True
        End If
    End Sub

    Private Sub deleteAllbtn_Click(sender As Object, e As EventArgs) Handles deleteAllbtn.Click
        Dim confirmDel As New DialogResult
        confirmDel = MessageBox.Show("ARE YOU SURE TO DELETE ALL ITEM?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmDel = DialogResult.Yes Then
            GroupBox4.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        confirmTxt.Clear()
        GroupBox4.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timeLbl.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub


    Private Sub searchTxt_TextChanged(sender As Object, e As EventArgs) Handles searchTxt.TextChanged

        Try
            conOpen()
            cmd.Connection = conn
            cmd.CommandText = "SELECT code, image, name, price, category, quantity, inventory FROM foodmenu WHERE name LIKE '%" & searchTxt.Text & "%' ORDER BY code ASC"
            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)
            dgv1.DataSource = dt

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR: searching item", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try

        cancelbtn.PerformClick()
    End Sub


    ' ////////////////////////////////// END OF MY BASIC CODE SECTION /////////////////////////////////////////
End Class
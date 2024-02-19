Imports MySql.Data.MySqlClient

Public Class AccountInformation
    Private Sub AccountInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAccountInfo()
    End Sub


    Dim cmdAccInf As New MySqlCommand
    Dim daAccinf As New MySqlDataAdapter
    Dim dtAccInf As New DataTable
    Sub loadAccountInfo()
        Try
            conOpen()
            cmdAccInf.Connection = conn
            cmdAccInf.CommandText = "SELECT image, accountId, fName, mName, lName, contact,uName, pWord, manager, admin FROM account_table ORDER BY accountId ASC"
            daAccinf.SelectCommand = cmdAccInf
            dtAccInf.Clear()
            daAccinf.Fill(dtAccInf)
            DataGridView1.DataSource = dtAccInf

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Loading Account Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        idTxt.Text = DataGridView1.Item(1, i).Value
        fnameTxt.Text = DataGridView1.Item(2, i).Value
        mnameTxt.Text = DataGridView1.Item(3, i).Value
        lnameTxt.Text = DataGridView1.Item(4, i).Value
        cntctTxt.Text = DataGridView1.Item(5, i).Value
        unameTxt.Text = DataGridView1.Item(6, i).Value
        pwordTxt.Text = DataGridView1.Item(7, i).Value
        managerTxt.Text = DataGridView1.Item(8, i).Value
        adminTxt.Text = DataGridView1.Item(9, i).Value
        clearBtn.Visible = True
        disabler()
        editbtn.Enabled = True
        createBtn.Enabled = False
        deletebtn.Enabled = True
    End Sub

    ' DISPLAY IMAGE FROM DATABASE INTO PICTUREBOX ONCE ACCOUNT IS SELECTED
    Private Sub idTxt_TextChanged(sender As Object, e As EventArgs) Handles idTxt.TextChanged

        If idTxt.Text <> "" Then
            Dim cmdAccInfoImage As New MySqlCommand
            Dim drAccInfo As MySqlDataReader
            Try
                conOpen()
                cmdAccInfoImage.Connection = conn
                cmdAccInfoImage.CommandText = "SELECT image FROM account_table WHERE accountId = '" & idTxt.Text & "'"
                drAccInfo = cmdAccInfoImage.ExecuteReader
                drAccInfo.Read()

                If drAccInfo.HasRows Then
                    Dim img() As Byte
                    img = drAccInfo("image")
                    Dim ms As New System.IO.MemoryStream(img)
                    pBox.Image = Image.FromStream(ms)
                Else
                    pBox.Image = Nothing
                End If

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Loading Account Profile", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
                pBox.Image = Nothing

            End Try
        End If
    End Sub

    ' CODE FOR BROWING IMAGE FROM FILES TO UPLOAD IN DATABASE
    Dim imagePath As String
    Dim arrImg() As Byte
    Private Sub browsebtn_Click(sender As Object, e As EventArgs) Handles browsebtn.Click
        Try
            Dim ofd As FileDialog = New OpenFileDialog()
            ofd.Filter = "Image File (*.jpg;*.png;*.gif;*.jpeg)|*.jpg;*.bmp;*.gif;*.jpeg"

            If ofd.ShowDialog = DialogResult.OK Then
                imagePath = ofd.FileName
                pBox.ImageLocation = imagePath
                clearBtn.Visible = True

            End If

            ofd = Nothing
            fnameTxt.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error | Retrieving Image")
        End Try
    End Sub


    ' CODES FOR CREATING ADMIN ACCOUNT
    Dim cmdAdmin As New MySqlCommand

    Private Sub createBtn_Click(sender As Object, e As EventArgs) Handles createBtn.Click

        If pBox.ImageLocation = Nothing Then
            MessageBox.Show("Upload your Profile Picture", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf fnameTxt.Text = "" Or mnameTxt.Text = "" Or lnameTxt.Text = "" Or cntctTxt.Text = "" Or unameTxt.Text = "" Or pwordTxt.Text = "" Then
            MessageBox.Show("Fill up all fields", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                conOpen()

                Dim ms As New System.IO.MemoryStream()
                pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                arrImg = ms.GetBuffer()
                Dim fileSize As UInt32
                fileSize = ms.Length
                ms.Close()

                cmdAdmin.Connection = conn
                cmdAdmin.CommandText = "INSERT INTO account_table 
                (`accountId`,`fName`,`mName`,`lName`,`contact`,`uName`,`pWord`,`manager`,`admin`,`image`) 
                VALUES (null,'" & fnameTxt.Text.ToUpper.Trim & "','" & mnameTxt.Text.ToUpper.Trim & "',
                '" & lnameTxt.Text.ToUpper.Trim & "','" & cntctTxt.Text.ToUpper.Trim & "','" & unameTxt.Text.Trim & "',
                '" & pwordTxt.Text.Trim & "','" & managerTxt.Text.ToUpper.Trim & "','" & adminTxt.Text.ToUpper.Trim & "',@image)"
                cmdAdmin.Parameters.AddWithValue("@image", arrImg)
                cmdAdmin.ExecuteNonQuery()
                cmdAdmin.Parameters.Clear()
                conn.Close()
                loadAccountInfo()
                MessageBox.Show("Successfully Created Admin Account", "Created Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error | Creating Admin Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            Finally
                clearFields()
                enabler()
                clearBtn.Visible = False
            End Try
        End If
    End Sub

    ' CODE FOR UPDATING ACCOUNT DETAILS
    Private Sub updatebtn_Click(sender As Object, e As EventArgs) Handles updatebtn.Click


        If fnameTxt.Text = "" Or mnameTxt.Text = "" Or lnameTxt.Text = "" Or cntctTxt.Text = "" Or unameTxt.Text = "" Or pwordTxt.Text = "" Then
            MessageBox.Show("Fill up all fields", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf pBox.ImageLocation <> Nothing Then
            Try
                conOpen()

                Dim ms As New System.IO.MemoryStream()
                pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                arrImg = ms.GetBuffer()
                Dim fileSize As UInt32
                fileSize = ms.Length
                ms.Close()

                cmdAdmin.Connection = conn
                cmdAdmin.CommandText = "UPDATE account_table SET `fName`='" & fnameTxt.Text.ToUpper.Trim & "',
                `mName` = '" & mnameTxt.Text.ToUpper.Trim & "', `lName` = '" & lnameTxt.Text.ToUpper.Trim & "',
                `contact` = '" & cntctTxt.Text.ToUpper.Trim & "', `uName` = '" & unameTxt.Text.Trim & "',
                `pWord` = '" & pwordTxt.Text.Trim & "', `manager` = '" & managerTxt.Text.ToUpper.Trim & "',
                `admin` = '" & adminTxt.Text.ToUpper.Trim & "', `image` = @image WHERE accountId = '" & idTxt.Text & "'"
                cmdAdmin.Parameters.AddWithValue("@image", arrImg)
                cmdAdmin.ExecuteNonQuery()
                cmdAdmin.Parameters.Clear()
                conn.Close()
                loadAccountInfo()
                MessageBox.Show("Successfully Updated an Account", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error | Update Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            Finally
                clearFields()
                enabler()
                clearBtn.Visible = False
            End Try
        ElseIf pBox.ImageLocation = Nothing Then
            MessageBox.Show("Upload your Profile Picture", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ' CODE TO DELETE SELECTED ACCOUNT IN DATAGRIDVIEW
    Private Sub deletebtn_Click(sender As Object, e As EventArgs) Handles deletebtn.Click

        Dim confirm As New DialogResult
        confirm = MessageBox.Show("Are you sure you want to deleted this Account?", "Confirm to continue.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirm = DialogResult.Yes And adminTxt.Text = "YES" And idTxt.Text <> "" Then
            MessageBox.Show("You can't delete admin account", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf confirm = DialogResult.Yes And adminTxt.Text <> "YES" Then

            If idTxt.Text = "" Then
                MessageBox.Show("No Account Selected", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Try
                    conOpen()
                    cmdAccInf.Connection = conn
                    cmdAccInf.CommandText = "DELETE FROM account_table WHERE accountId = '" & idTxt.Text & "'"
                    cmdAccInf.ExecuteNonQuery()
                    conn.Close()
                    loadAccountInfo()
                    clearFields()
                    enabler()

                    clearBtn.Visible = False
                    editbtn.Enabled = False
                    createBtn.Enabled = True
                    updatebtn.Enabled = False
                    deletebtn.Enabled = False
                    MessageBox.Show("Successfully Deleted an Account", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error | Deleting an Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()

                End Try
            End If


        End If

    End Sub

    Sub clearFields()
        idTxt.Clear()
        fnameTxt.Clear()
        mnameTxt.Clear()
        lnameTxt.Clear()
        cntctTxt.Clear()
        managerTxt.Text = "NO"
        adminTxt.Text = "YES"
        unameTxt.Clear()
        pwordTxt.Clear()
        pBox.Image = Nothing
        clearBtn.Visible = False
    End Sub

    Sub disabler()
        fnameTxt.ReadOnly = True
        mnameTxt.ReadOnly = True
        lnameTxt.ReadOnly = True
        cntctTxt.ReadOnly = True
        managerTxt.ReadOnly = True
        adminTxt.ReadOnly = True
        unameTxt.ReadOnly = True
        pwordTxt.ReadOnly = True

    End Sub

    Sub enabler()
        fnameTxt.ReadOnly = False
        mnameTxt.ReadOnly = False
        lnameTxt.ReadOnly = False
        cntctTxt.ReadOnly = False
        managerTxt.ReadOnly = False
        adminTxt.ReadOnly = False
        unameTxt.ReadOnly = False
        pwordTxt.ReadOnly = False

    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        clearFields()
        enabler()
        editbtn.Enabled = False
        createBtn.Enabled = True
        updatebtn.Enabled = False
        deletebtn.Enabled = False
        managerTxt.ReadOnly = True
        adminTxt.ReadOnly = True
        fnameTxt.Focus()
    End Sub

    Private Sub editbtn_Click(sender As Object, e As EventArgs) Handles editbtn.Click
        If idTxt.Text <> "" Then
            enabler()
            updatebtn.Enabled = True
            fnameTxt.Focus()
        Else
            MessageBox.Show("No Account Selected", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub fnameTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles fnameTxt.KeyDown
        If e.KeyCode = 13 Then
            If fnameTxt.Text = "" Then
                MessageBox.Show("Fill in the First Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                fnameTxt.Focus()
            Else
                mnameTxt.Focus()
            End If
        End If

    End Sub

    Private Sub mnameTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles mnameTxt.KeyDown
        If e.KeyCode = 13 Then
            If mnameTxt.Text = "" Then
                MessageBox.Show("Fill in the Middle Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                mnameTxt.Focus()
            Else
                lnameTxt.Focus()
            End If
        End If

    End Sub

    Private Sub lnameTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles lnameTxt.KeyDown
        If e.KeyCode = 13 Then
            If lnameTxt.Text = "" Then
                MessageBox.Show("Fill in the Last Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lnameTxt.Focus()
            Else
                cntctTxt.Focus()
            End If
        End If

    End Sub

    Private Sub cntctTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles cntctTxt.KeyDown
        If e.KeyCode = 13 Then
            If cntctTxt.Text = "" Then
                MessageBox.Show("Fill in the Contact", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cntctTxt.Focus()
            Else
                unameTxt.Focus()
            End If
        End If

    End Sub

    Private Sub unameTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles unameTxt.KeyDown
        If e.KeyCode = 13 Then
            If unameTxt.Text = "" Then
                MessageBox.Show("Fill in the Username", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                unameTxt.Focus()
            Else
                pwordTxt.Focus()
            End If
        End If
    End Sub

    Private Sub pwordTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles pwordTxt.KeyDown
        If e.KeyCode = 13 Then
            If pwordTxt.Text = "" Then
                MessageBox.Show("Fill in the Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                pwordTxt.Focus()
            Else
                createBtn.PerformClick()
            End If
        End If

    End Sub

    Private Sub fnameTxt_TextChanged(sender As Object, e As EventArgs) Handles fnameTxt.TextChanged
        If fnameTxt.Text <> "" Then
            clearBtn.Visible = True
        End If
    End Sub

    Private Sub mnameTxt_TextChanged(sender As Object, e As EventArgs) Handles mnameTxt.TextChanged
        If mnameTxt.Text <> "" Then
            clearBtn.Visible = True
        End If
    End Sub

    Private Sub lnameTxt_TextChanged(sender As Object, e As EventArgs) Handles lnameTxt.TextChanged
        If lnameTxt.Text <> "" Then
            clearBtn.Visible = True
        End If
    End Sub

    Private Sub cntctTxt_TextChanged(sender As Object, e As EventArgs) Handles cntctTxt.TextChanged
        If cntctTxt.Text <> "" Then
            clearBtn.Visible = True
        End If
    End Sub

    Private Sub unameTxt_TextChanged(sender As Object, e As EventArgs) Handles unameTxt.TextChanged
        If unameTxt.Text <> "" Then
            clearBtn.Visible = True
        End If
    End Sub

    Private Sub pwordTxt_TextChanged(sender As Object, e As EventArgs) Handles pwordTxt.TextChanged
        If pwordTxt.Text <> "" Then
            clearBtn.Visible = True
        End If
    End Sub


End Class
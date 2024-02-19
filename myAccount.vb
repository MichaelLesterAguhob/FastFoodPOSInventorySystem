Imports System.IO
Imports MySql.Data.MySqlClient

Public Class myAccount
    Dim cmdAcc As New MySqlCommand
    Dim daAcc As New MySqlDataAdapter
    Dim dsAcc As New DataSet
    Dim drAcc As MySqlDataReader

    Private Sub myAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAccountInfo()
        disabler()
    End Sub

    Sub loadAccountInfo()
        idLbl.Text = accountID
        Try
            conOpen()
            cmdAcc.Connection = conn
            cmdAcc.CommandText = "SELECT * FROM account_table WHERE accountId = '" & accountID & "'"
            daAcc.SelectCommand = cmdAcc
            daAcc.Fill(dsAcc, "account_table")
            drAcc = cmdAcc.ExecuteReader
            drAcc.Read()

            fNametxt.DataBindings.Add("Text", dsAcc, "account_table.fName")
            fNametxt.DataBindings.Clear()
            mNameTxt.DataBindings.Add("Text", dsAcc, "account_table.mName")
            mNameTxt.DataBindings.Clear()
            LNameTxt.DataBindings.Add("Text", dsAcc, "account_table.lName")
            LNameTxt.DataBindings.Clear()
            ctxt.DataBindings.Add("Text", dsAcc, "account_table.contact")
            ctxt.DataBindings.Clear()
            uNameTxt.DataBindings.Add("Text", dsAcc, "account_table.uName")
            uNameTxt.DataBindings.Clear()

            Dim img() As Byte

            If drAcc.HasRows Then
                img = drAcc("image")
                Dim ms As New System.IO.MemoryStream(img)
                pBox.Image = Image.FromStream(ms)
            Else
                pBox.Image = Nothing
            End If

            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error loadingAccountInfo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()

        End Try
    End Sub

    Dim imagePath As String
    Dim arrImg() As Byte
    Private Sub uploadBtn_Click(sender As Object, e As EventArgs) Handles uploadBtn.Click
        Try
            Dim ofd As FileDialog = New OpenFileDialog()
            ofd.Filter = "Image File (*.jpg;*.png;*.gif;*.jpeg)|*.jpg;*.bmp;*.gif;*.jpeg"

            If ofd.ShowDialog = DialogResult.OK Then
                imagePath = ofd.FileName
                pBox.ImageLocation = imagePath
            Else
                pBox.ImageLocation = Nothing
            End If
            ofd = Nothing
            fNametxt.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error uploadBtn")
        End Try
    End Sub

    Sub disabler()
        fNametxt.ReadOnly = True
        mNameTxt.ReadOnly = True
        LNameTxt.ReadOnly = True
        ctxt.ReadOnly = True
        uNameTxt.ReadOnly = True

        uploadBtn.Enabled = False
        uploadBtn.Visible = False
        updateBtn.Enabled = False
        cancelBtn.Enabled = False
    End Sub

    Sub enabler()
        fNametxt.ReadOnly = False
        mNameTxt.ReadOnly = False
        LNameTxt.ReadOnly = False
        ctxt.ReadOnly = False
        uNameTxt.ReadOnly = False

        uploadBtn.Enabled = True
        uploadBtn.Visible = True
        updateBtn.Enabled = True
        cancelBtn.Enabled = True
    End Sub

    Private Sub editBtn_Click(sender As Object, e As EventArgs) Handles editBtn.Click
        enabler()
        fNametxt.Focus()
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        disabler()
        loadAccountInfo()
        oldPasstxt.Focus()
    End Sub

    Private Sub changePassBtn_Click(sender As Object, e As EventArgs) Handles changePassBtn.Click
        changePassPanel.Width = 336
    End Sub

    Private Sub cancelChagePass_Click(sender As Object, e As EventArgs) Handles cancelChagePass.Click
        changePassPanel.Width = 0

    End Sub


    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
        If fNametxt.Text <> "" Or LNameTxt.Text <> "" Or mNameTxt.Text <> "" Or ctxt.Text <> "" Or uNameTxt.Text <> "" Or pBox.ImageLocation <> Nothing Then

            Try
                conOpen()

                Dim ms As New System.IO.MemoryStream()
                pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                arrImg = ms.GetBuffer
                Dim fSize As UInt32
                fSize = ms.Length
                ms.Close()

                cmdAcc.Connection = conn
                cmdAcc.CommandText = "UPDATE account_table SET `fName`='" & fNametxt.Text.ToUpper.Trim & "', `mName` = '" & mNameTxt.Text.ToUpper.Trim & "',`lName` = '" & LNameTxt.Text.ToUpper.Trim & "',`contact` = '" & ctxt.Text & "',`uName` = '" & uNameTxt.Text & "', `image` = @image  WHERE accountId = '" & idLbl.Text & "' "
                cmdAcc.Parameters.AddWithValue("@image", arrImg)
                cmdAcc.ExecuteNonQuery()
                MessageBox.Show("Successfully updated your account info.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmdAcc.Parameters.Clear()

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Updating Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            Finally
                Me.Close()
            End Try

        Else
            MessageBox.Show("Check your Input", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Dim curPass As String
    Private Sub changeBtn_Click(sender As Object, e As EventArgs) Handles changeBtn.Click

        If oldPasstxt.Text <> "" Or newPassTxt.Text <> "" Then

            Dim confirm As New DialogResult
            confirm = MessageBox.Show("Confirm to change your Password", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirm = DialogResult.Yes Then
                Try
                    conOpen()
                    cmdAcc.Connection = conn
                    cmdAcc.CommandText = "SELECT pWord FROM account_table WHERE accountID = '" & idLbl.Text & "'"
                    curPass = cmdAcc.ExecuteScalar
                    conn.Close()

                    If oldPasstxt.Text = curPass Then
                        Try
                            conOpen()
                            cmdAcc.Connection = conn
                            cmdAcc.CommandText = "UPDATE account_table SET `pWord`= '" & newPassTxt.Text.Trim & "' WHERE accountID = '" & idLbl.Text & "'"
                            cmdAcc.ExecuteNonQuery()
                            MessageBox.Show("Successfully Changed your Password.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            conn.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error ChangePass", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            conn.Close()
                        Finally
                            newPassTxt.Clear()
                            oldPasstxt.Clear()
                            changePassPanel.Width = 0
                        End Try
                    Else
                        MessageBox.Show("An Old Password you typed didn't matched.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error ChangePass01", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try
            End If
        Else
                MessageBox.Show("Provide the needed information.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub oldPasstxt_KeyDown(sender As Object, e As KeyEventArgs) Handles oldPasstxt.KeyDown
        If e.KeyCode = 13 Then
            If oldPasstxt.Text = "" Then
                MessageBox.Show("Fill in the old Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                oldPasstxt.Focus()
            Else
                newPassTxt.Focus()
            End If
        End If
    End Sub

    Private Sub newPassTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles newPassTxt.KeyDown
        If e.KeyCode = 13 Then
            If newPassTxt.Text = "" Then
                MessageBox.Show("Fill in the old Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                newPassTxt.Focus()
            Else
                changeBtn.PerformClick()
            End If
        End If
    End Sub

End Class
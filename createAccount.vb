Imports MySql.Data.MySqlClient

Public Class createAccount

    Dim cmdCreateAcct As New MySqlCommand

    ' //////////////////////////         MY MAIN CODES           /////////////////////////////////////
    Dim imagePath As String
    Dim arrImage() As Byte

    Private Sub uploadBtn_Click(sender As Object, e As EventArgs) Handles uploadBtn.Click
        Try

            Dim OFD As FileDialog = New OpenFileDialog()
            OFD.Filter = "Image Filter(*.jpg;*.png;*.gif;*.jpeg)|*.jpg;*.bmp;*.gif;*.jpeg"

            If OFD.ShowDialog = DialogResult.OK Then
                imagePath = OFD.FileName
                pBox.ImageLocation = imagePath
            End If

            OFD = Nothing
            fnameTxt.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR : Uploading Image", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub createBtn_Click(sender As Object, e As EventArgs) Handles createBtn.Click
        If fnameTxt.Text = "" Or mnameTxt.Text = "" Or lnameTxt.Text = "" Or cntctTxt.Text = "" Or unameTxt.Text = "" Or pwordTxt.Text = "" Or rpwordTxt.Text = "" Or pBox.ImageLocation = Nothing Then
            MessageBox.Show("Please complete all needed information for your account!", "Check your input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf rpwordTxt.Text <> pwordTxt.Text Then
            MessageBox.Show("Re-typed Password didn't matched", "invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            rpwordTxt.Focus()

        Else
            Try
                Dim ms As New System.IO.MemoryStream()
                pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                arrImage = ms.GetBuffer
                Dim fSize As UInt32
                fSize = ms.Length
                ms.Close()

                conOpen()
                cmdCreateAcct.Connection = conn
                cmdCreateAcct.CommandText = "INSERT INTO account_table (`fName`,`mName`,`lName`,`contact`,`uName`,`pWord`,`manager`,`admin`,`image`) 
                VALUES ('" & fnameTxt.Text.ToUpper.Trim & "', '" & mnameTxt.Text.ToUpper.Trim & "','" & lnameTxt.Text.ToUpper.Trim & "','" & cntctTxt.Text & "',
                '" & unameTxt.Text & "','" & pwordTxt.Text & "','NO','NO', @image) "
                cmdCreateAcct.Parameters.AddWithValue("@image", arrImage)
                cmdCreateAcct.ExecuteNonQuery()
                cmdCreateAcct.Parameters.Clear()

                MessageBox.Show("Successfully Created your Account", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conn.Close()

                clearBtn.PerformClick()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR : Creating an account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try
        End If
    End Sub

    ' LOOK FOR ADMIN CONFIRMATION USING ADMIN PASSWORD TO PROCEED WITH MANAGER ACCOUNT CREATION
    Private Sub enterAdminSecBtn_Click(sender As Object, e As EventArgs) Handles enterAdminSecBtn.Click

        If adminPwordTxt.Text = "" Then
            MessageBox.Show("Enter admin password to Create an Account", "No input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            pwordTxt.Focus()

        ElseIf adminPwordTxt.Text <> "" And rpwordTxt.Text = pwordTxt.Text Then

            Try
                conOpen()
                cmdCreateAcct.Connection = conn
                cmdCreateAcct.CommandText = "SELECT pWord FROM account_table WHERE admin = 'YES' "
                Dim adminPass As String = cmdCreateAcct.ExecuteScalar
                conn.Close()

                '-------------------------------------------------------------------------------------------------------------------------------
                If adminPwordTxt.Text = adminPass Then

                    Panel2.Width = 0
                    '===========================================================================================================================
                    If pBox.ImageLocation = Nothing Or fnameTxt.Text = "" Or mnameTxt.Text = "" Or lnameTxt.Text = "" Or cntctTxt.Text = "" Or unameTxt.Text = "" Or pwordTxt.Text = "" Or rpwordTxt.Text = "" Then
                        MessageBox.Show("Please complete all needed information for your account!", "Check your input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        adminPwordTxt.Clear()
                    Else
                        Try
                            Dim ms As New System.IO.MemoryStream()
                            pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                            arrImage = ms.GetBuffer
                            Dim fSize As UInt32
                            fSize = ms.Length
                            ms.Close()

                            conOpen()
                            cmdCreateAcct.Connection = conn
                            cmdCreateAcct.CommandText = "INSERT INTO account_table (`fName`,`mName`,`lName`,`contact`,`uName`,`pWord`,`manager`,`admin`,`image`) 
                              VALUES ('" & fnameTxt.Text.ToUpper.Trim & "', '" & mnameTxt.Text.ToUpper.Trim & "','" & lnameTxt.Text.ToUpper.Trim & "','" & cntctTxt.Text & "',
                            '" & unameTxt.Text & "','" & pwordTxt.Text & "','YES','NO', @image) "
                            cmdCreateAcct.Parameters.AddWithValue("@image", arrImage)
                            cmdCreateAcct.ExecuteNonQuery()
                            cmdCreateAcct.Parameters.Clear()

                            MessageBox.Show("Successfully Created your Account", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            conn.Close()

                            clearBtn.PerformClick()
                            adminPwordTxt.Clear()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "ERROR : Creating manager account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            conn.Close()
                        End Try
                    End If
                    '===========================================================================================================================
                Else
                    MessageBox.Show("Incorrect Password, Try Again", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    adminPwordTxt.Clear()
                End If
                '-------------------------------------------------------------------------------------------------------------------------------

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR : Admin Security", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
                adminPwordTxt.Clear()
            End Try

        End If

    End Sub

    ' //////////////////////////         MY BASIC CODES           /////////////////////////////////////

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
                MessageBox.Show("Fill in the  Username", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                rpwordTxt.Focus()
            End If
        End If
    End Sub

    Private Sub rpwordTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles rpwordTxt.KeyDown
        If e.KeyCode = 13 Then
            If rpwordTxt.Text = "" Then
                MessageBox.Show("Re-type your Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                rpwordTxt.Focus()
            Else
                createBtn.Focus()
            End If
        End If
    End Sub

    Private Sub cntctTxt_TextChanged(sender As Object, e As EventArgs) Handles cntctTxt.TextChanged
        If cntctTxt.Text <> "" And IsNumeric(cntctTxt.Text) = False Then
            MessageBox.Show("Invalid Contact", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cntctTxt.Clear()
            cntctTxt.Focus()
        End If
    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        pBox.Image = Nothing
        fnameTxt.Clear()
        mnameTxt.Clear()
        lnameTxt.Clear()
        cntctTxt.Clear()
        unameTxt.Clear()
        pwordTxt.Clear()
        rpwordTxt.Clear()
        fnameTxt.Focus()
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub

    Private Sub goToLoginBtn_Click(sender As Object, e As EventArgs) Handles goToLoginBtn.Click
        If programStarted = "FALSE" Then
            Me.Close()

        ElseIf accountLoggedInStat <> "GUEST MODE" Then
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
            Me.Close()
        End If

    End Sub

    Private Sub createAdminBtn_Click(sender As Object, e As EventArgs) Handles createAdminBtn.Click
        If fnameTxt.Text = "" Or mnameTxt.Text = "" Or lnameTxt.Text = "" Or cntctTxt.Text = "" Or unameTxt.Text = "" Or pwordTxt.Text = "" Or rpwordTxt.Text = "" Or pBox.ImageLocation = Nothing Then
            MessageBox.Show("Please complete all needed information for your account!", "Check your input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf rpwordTxt.Text <> pwordTxt.Text Then
            MessageBox.Show("Re-typed Password didn't matched", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            rpwordTxt.Focus()

        Else
            Panel2.Width = 336
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Width = 0
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

End Class
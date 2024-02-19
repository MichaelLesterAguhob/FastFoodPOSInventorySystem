Imports MySql.Data.MySqlClient
Public Class loginAccount
    Dim cmdLogin As New MySqlCommand

    Private Sub loginAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If programStarted = "TRUE" Then
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If programStarted = "FALSE" Then
            accountLoggedInStat = "GUEST MODE"
            Me.Close()
            Form1.Show()
        End If
    End Sub

    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click

        Dim uNameHolder As String
        Dim pWordHolder As String
        Dim accountIDHolder As Integer



        If programStarted = "FALSE" Then

            ' ====================================================================================================================================

            If unameTxt.Text = "" Or pwordTxt.Text = "" Then
                MessageBox.Show("Complete all needed fields to login", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                unameTxt.Focus()

                'CHECKING IF ACCOUNT INFO INPUT IS MATCHED ON CAHIER ACCOUNT
            ElseIf unameTxt.Text <> "" Or pwordTxt.Text <> "" Then

                Try
                    conOpen()
                    cmdLogin.Connection = conn
                    cmdLogin.CommandText = "SELECT uName FROM account_table WHERE uName = '" & unameTxt.Text.Trim & "' AND admin = 'NO' AND manager = 'NO' "
                    uNameHolder = cmdLogin.ExecuteScalar
                    cmdLogin.CommandText = "SELECT pWord FROM account_table WHERE pWord = '" & pwordTxt.Text.Trim & "' AND admin = 'NO' AND manager = 'NO' AND uName = '" & unameTxt.Text & "'"
                    pWordHolder = cmdLogin.ExecuteScalar
                    conn.Close()

                    ' ====================================================================================================================================
                    If unameTxt.Text = uNameHolder And pwordTxt.Text = pWordHolder Then
                        accountLoggedInStat = "CASHIER"
                        accountLoggedIn = uNameHolder

                        Try
                            conOpen()
                            cmdLogin.Connection = conn
                            cmdLogin.CommandText = "SELECT accountId FROM account_table WHERE uName = '" & uNameHolder & "'  AND pWord = '" & pWordHolder & "'"
                            accountIDHolder = cmdLogin.ExecuteScalar
                            accountID = accountIDHolder
                            conn.Close()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error 001")
                            conn.Close()
                        End Try

                        Me.Close()
                        Form1.Show()

                        ' IF INFO INPUT IS NOT MATCHED ON CASHIER TYPE OF ACCOUNT, IT WILL CHECK ON MANAGER ACCOUNT
                    ElseIf unameTxt.Text <> uNameHolder And pwordTxt.Text <> pWordHolder Then
                        conOpen()
                        cmdLogin.Connection = conn
                        cmdLogin.CommandText = "SELECT uName FROM account_table WHERE uName = '" & unameTxt.Text & "' AND admin = 'NO' AND manager = 'YES' "
                        uNameHolder = cmdLogin.ExecuteScalar
                        cmdLogin.CommandText = "SELECT pWord FROM account_table WHERE pWord = '" & pwordTxt.Text & "' AND admin = 'NO' AND manager = 'YES' AND uName = '" & unameTxt.Text & "' "
                        pWordHolder = cmdLogin.ExecuteScalar
                        conn.Close()

                        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        If unameTxt.Text = uNameHolder And pwordTxt.Text = pWordHolder Then
                            accountLoggedInStat = "MANAGER"
                            accountLoggedIn = uNameHolder

                            Try
                                conOpen()
                                cmdLogin.Connection = conn
                                cmdLogin.CommandText = "SELECT accountId FROM account_table WHERE uName = '" & uNameHolder & "'  AND pWord = '" & pWordHolder & "'"
                                accountIDHolder = cmdLogin.ExecuteScalar
                                accountID = accountIDHolder
                                conn.Close()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error 002")
                                conn.Close()
                            End Try

                            Me.Close()
                            Form1.Show()

                            ' IF INFO INPUT IS NOT MATCHED ON MANAGER TYPE OF ACCOUNT, IT WILL CHECK ON ADMIN ACCOUNT
                        ElseIf unameTxt.Text <> uNameHolder And pwordTxt.Text <> pWordHolder Then
                            conOpen()
                            cmdLogin.Connection = conn
                            cmdLogin.CommandText = "SELECT uName FROM account_table WHERE uName = '" & unameTxt.Text & "' AND admin = 'YES' AND manager = 'NO' "
                            uNameHolder = cmdLogin.ExecuteScalar
                            cmdLogin.CommandText = "SELECT pWord FROM account_table WHERE pWord = '" & pwordTxt.Text & "' AND admin = 'YES' AND manager = 'NO' AND uName = '" & unameTxt.Text & "'"
                            pWordHolder = cmdLogin.ExecuteScalar
                            conn.Close()

                            ' -------------------------------------------------------------------------------------------------------------------------------
                            If unameTxt.Text = uNameHolder And pwordTxt.Text = pWordHolder Then
                                accountLoggedInStat = "ADMIN"
                                accountLoggedIn = uNameHolder

                                Try
                                    conOpen()
                                    cmdLogin.Connection = conn
                                    cmdLogin.CommandText = "SELECT accountId FROM account_table WHERE uName = '" & uNameHolder & "'  AND pWord = '" & pWordHolder & "'"
                                    accountIDHolder = cmdLogin.ExecuteScalar
                                    accountID = accountIDHolder
                                    conn.Close()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error 003")
                                    conn.Close()
                                End Try

                                Me.Close()
                                Form1.Show()
                            Else
                                MessageBox.Show("We can't find your Account", "LogIn Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                pwordTxt.Focus()
                            End If
                            ' -------------------------------------------------------------------------------------------------------------------------------
                        Else
                            MessageBox.Show("We can't find your Account", "LogIn Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            pwordTxt.Focus()
                        End If
                        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    Else
                        MessageBox.Show("We can't find your Account", "LogIn Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        pwordTxt.Focus()
                    End If
                    ' ====================================================================================================================================

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR : LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try
            End If
            ' ====================================================================================================================================

        ElseIf programStarted = "TRUE" Then

            ' ====================================================================================================================================
            If unameTxt.Text = "" Or pwordTxt.Text = "" Then
                MessageBox.Show("Complete all needed fields to login", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                unameTxt.Focus()

                ' CHECKING IF ACCOUNT INFO INPUT IS MATCHED ON CASHIER TYPE OF ACCOUNT
            ElseIf unameTxt.Text <> "" Or pwordTxt.Text <> "" Then
                Try
                    conOpen()
                    cmdLogin.Connection = conn
                    cmdLogin.CommandText = "SELECT uName FROM account_table WHERE uName = '" & unameTxt.Text & "' AND admin = 'NO' AND manager = 'NO' "
                    uNameHolder = cmdLogin.ExecuteScalar
                    cmdLogin.CommandText = "SELECT pWord FROM account_table WHERE pWord = '" & pwordTxt.Text & "' AND admin = 'NO' AND manager = 'NO' AND uName = '" & unameTxt.Text & "' "
                    pWordHolder = cmdLogin.ExecuteScalar
                    conn.Close()

                    ' ====================================================================================================================================
                    If unameTxt.Text = uNameHolder And pwordTxt.Text = pWordHolder Then
                        accountLoggedInStat = "CASHIER"
                        accountLoggedIn = uNameHolder

                        Try
                            conOpen()
                            cmdLogin.Connection = conn
                            cmdLogin.CommandText = "SELECT accountId FROM account_table WHERE uName = '" & uNameHolder & "'  AND pWord = '" & pWordHolder & "'"
                            accountIDHolder = cmdLogin.ExecuteScalar
                            accountID = accountIDHolder
                            conn.Close()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error 004")
                            conn.Close()
                        End Try

                        Me.Close()
                        Form1.mainFormLoad()

                        ' IF INFO INPUT IS NOT MATCHED ON CASHIER TYPE OF ACCOUNT, IT WILL CHECK ON MANAGER ACCOUNT
                    ElseIf unameTxt.Text <> uNameHolder And pwordTxt.Text <> pWordHolder Then
                        conOpen()
                        cmdLogin.Connection = conn
                        cmdLogin.CommandText = "SELECT uName FROM account_table WHERE uName = '" & unameTxt.Text & "' AND admin = 'NO' AND manager = 'YES' "
                        uNameHolder = cmdLogin.ExecuteScalar
                        cmdLogin.CommandText = "SELECT pWord FROM account_table WHERE pWord = '" & pwordTxt.Text & "' AND admin = 'NO' AND manager = 'YES' AND uName = '" & unameTxt.Text & "' "
                        pWordHolder = cmdLogin.ExecuteScalar
                        conn.Close()

                        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        If unameTxt.Text = uNameHolder And pwordTxt.Text = pWordHolder Then
                            accountLoggedInStat = "MANAGER"
                            accountLoggedIn = uNameHolder

                            Try
                                conOpen()
                                cmdLogin.Connection = conn
                                cmdLogin.CommandText = "SELECT accountId FROM account_table WHERE uName = '" & uNameHolder & "'  AND pWord = '" & pWordHolder & "'"
                                accountIDHolder = cmdLogin.ExecuteScalar
                                accountID = accountIDHolder
                                conn.Close()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error 006")
                                conn.Close()
                            End Try

                            Me.Close()
                            Form1.mainFormLoad()


                            ' IF INFO INPUT IS NOT MATCHED ON MANAGER TYPE OF ACCOUNT, IT WILL CHECK ON ADMIN ACCOUNT
                        ElseIf unameTxt.Text <> uNameHolder And pwordTxt.Text <> pWordHolder Then
                            conOpen()
                            cmdLogin.Connection = conn
                            cmdLogin.CommandText = "SELECT uName FROM account_table WHERE uName = '" & unameTxt.Text & "' AND admin = 'YES' AND manager = 'NO' "
                            uNameHolder = cmdLogin.ExecuteScalar
                            cmdLogin.CommandText = "SELECT pWord FROM account_table WHERE pWord = '" & pwordTxt.Text & "' AND admin = 'YES' AND manager = 'NO' AND uName = '" & unameTxt.Text & "' "
                            pWordHolder = cmdLogin.ExecuteScalar
                            conn.Close()

                            ' -------------------------------------------------------------------------------------------------------------------------------
                            If unameTxt.Text = uNameHolder And pwordTxt.Text = pWordHolder Then
                                accountLoggedInStat = "ADMIN"
                                accountLoggedIn = uNameHolder

                                Try
                                    conOpen()
                                    cmdLogin.Connection = conn
                                    cmdLogin.CommandText = "SELECT accountId FROM account_table WHERE uName = '" & uNameHolder & "'  AND pWord = '" & pWordHolder & "'"
                                    accountIDHolder = cmdLogin.ExecuteScalar
                                    accountID = accountIDHolder
                                    conn.Close()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error 007")
                                    conn.Close()
                                End Try

                                Me.Close()
                                Form1.mainFormLoad()
                            Else
                                MessageBox.Show("We can't find your Account", "LogIn Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                unameTxt.Focus()
                            End If
                            ' -------------------------------------------------------------------------------------------------------------------------------
                        Else
                            MessageBox.Show("We can't find your Account", "LogIn Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            unameTxt.Focus()
                        End If
                        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    Else
                        MessageBox.Show("We can't find your Account", "LogIn Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        unameTxt.Focus()
                    End If
                    ' ====================================================================================================================================

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR : LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                End Try
            End If
        End If
        ' ====================================================================================================================================

    End Sub
    Dim dialog As New DialogResult
    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click

        If programStarted = "FALSE" Then
            dialog = MessageBox.Show("Are you sure you want to Cancel Login? if yes, Program will Close", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                End
            End If

        ElseIf programStarted = "TRUE" Then
            Me.Close()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If programStarted = "TRUE" Then
            createAccount.Show()
            Me.Close()
        ElseIf programStarted = "FALSE" Then
            createAccount.Show()
        End If

    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        unameTxt.Clear()
        pwordTxt.Clear()
        unameTxt.Focus()
    End Sub

    Private Sub unameTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles unameTxt.KeyDown
        If e.KeyCode = 13 Then
            If unameTxt.Text = "" Then
                MessageBox.Show("Fill in the Username ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                unameTxt.Focus()
            Else
                pwordTxt.Focus()
            End If
        End If

    End Sub

    Private Sub pwordTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles pwordTxt.KeyDown
        If e.KeyCode = 13 Then
            If pwordTxt.Text = "" Then
                MessageBox.Show("Fill in the Password ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                pwordTxt.Focus()
            Else
                loginBtn.PerformClick()
            End If
        End If
    End Sub

    Private Sub unameTxt_TextChanged(sender As Object, e As EventArgs) Handles unameTxt.TextChanged
        If unameTxt.Text <> "" Or pwordTxt.Text <> "" Then
            clearBtn.Visible = True
        Else
            clearBtn.Visible = False

        End If
    End Sub

    Private Sub pwordTxt_TextChanged(sender As Object, e As EventArgs) Handles pwordTxt.TextChanged
        If unameTxt.Text <> "" Or pwordTxt.Text <> "" Then
            clearBtn.Visible = True
        Else
            clearBtn.Visible = False

        End If
    End Sub
End Class
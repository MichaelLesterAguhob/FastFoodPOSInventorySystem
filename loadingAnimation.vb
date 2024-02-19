Public Class loadingAnimation
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label2.Width >= 400 Then
            Me.Timer1.Enabled = False
            Me.Hide()

            Try
                conOpen()
                If conn.State = System.Data.ConnectionState.Open Then
                    MessageBox.Show("Successfully Connected to the database", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    conn.Close()
                    loginAccount.Show()
                Else
                    End
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error | loading animation")
                conn.Close()
                End
            End Try
        Else
            Label2.Width = Label2.Width + 50
        End If
    End Sub
    Private Sub loadingAnimation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Width = 0
        Timer1.Enabled = True

    End Sub
End Class
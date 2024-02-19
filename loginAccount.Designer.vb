<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class loginAccount
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.pwordTxt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.unameTxt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.loginBtn = New System.Windows.Forms.Button()
        Me.clearBtn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.gBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(537, 59)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "LOGIN ACCOUNT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.cancelBtn)
        Me.Panel1.Controls.Add(Me.loginBtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 213)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(537, 58)
        Me.Panel1.TabIndex = 17
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Aqua
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_left_43
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(246, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(150, 44)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "GO TO CREATE ACCOUNT"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cancelBtn
        '
        Me.cancelBtn.BackColor = System.Drawing.Color.IndianRed
        Me.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelBtn.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_cancel_43
        Me.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cancelBtn.Location = New System.Drawing.Point(425, 6)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(107, 44)
        Me.cancelBtn.TabIndex = 33
        Me.cancelBtn.Text = "CANCEL"
        Me.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cancelBtn.UseVisualStyleBackColor = False
        '
        'pwordTxt
        '
        Me.pwordTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pwordTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pwordTxt.Font = New System.Drawing.Font("Wingdings", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.pwordTxt.Location = New System.Drawing.Point(167, 81)
        Me.pwordTxt.Name = "pwordTxt"
        Me.pwordTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.pwordTxt.Size = New System.Drawing.Size(324, 21)
        Me.pwordTxt.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(129, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "ENTER PASSWORD :"
        '
        'unameTxt
        '
        Me.unameTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.unameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.unameTxt.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unameTxt.Location = New System.Drawing.Point(167, 49)
        Me.unameTxt.Name = "unameTxt"
        Me.unameTxt.Size = New System.Drawing.Size(324, 22)
        Me.unameTxt.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "ENTER USERNAME :"
        '
        'gBox1
        '
        Me.gBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gBox1.Controls.Add(Me.pwordTxt)
        Me.gBox1.Controls.Add(Me.clearBtn)
        Me.gBox1.Controls.Add(Me.Label5)
        Me.gBox1.Controls.Add(Me.unameTxt)
        Me.gBox1.Controls.Add(Me.Label4)
        Me.gBox1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gBox1.Location = New System.Drawing.Point(0, 62)
        Me.gBox1.Name = "gBox1"
        Me.gBox1.Size = New System.Drawing.Size(537, 151)
        Me.gBox1.TabIndex = 16
        Me.gBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.SkyBlue
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_enter_43
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(128, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 44)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "LATER"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'loginBtn
        '
        Me.loginBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loginBtn.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loginBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_login_43
        Me.loginBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.loginBtn.Location = New System.Drawing.Point(3, 6)
        Me.loginBtn.Name = "loginBtn"
        Me.loginBtn.Size = New System.Drawing.Size(110, 44)
        Me.loginBtn.TabIndex = 32
        Me.loginBtn.Text = "LOGIN"
        Me.loginBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.loginBtn.UseVisualStyleBackColor = False
        '
        'clearBtn
        '
        Me.clearBtn.BackColor = System.Drawing.Color.LightSalmon
        Me.clearBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearBtn.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clearBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_broom_26
        Me.clearBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.clearBtn.Location = New System.Drawing.Point(363, 111)
        Me.clearBtn.Name = "clearBtn"
        Me.clearBtn.Size = New System.Drawing.Size(128, 31)
        Me.clearBtn.TabIndex = 34
        Me.clearBtn.Text = "CLEAR INPUTS"
        Me.clearBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.clearBtn.UseVisualStyleBackColor = False
        Me.clearBtn.Visible = False
        '
        'loginAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 271)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "loginAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "loginAccount"
        Me.Panel1.ResumeLayout(False)
        Me.gBox1.ResumeLayout(False)
        Me.gBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents clearBtn As Button
    Friend WithEvents cancelBtn As Button
    Friend WithEvents loginBtn As Button
    Friend WithEvents pwordTxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents unameTxt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents gBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class

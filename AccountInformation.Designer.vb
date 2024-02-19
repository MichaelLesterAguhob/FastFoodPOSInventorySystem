<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountInformation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.editbtn = New System.Windows.Forms.Button()
        Me.updatebtn = New System.Windows.Forms.Button()
        Me.deletebtn = New System.Windows.Forms.Button()
        Me.createBtn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.browsebtn = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.adminTxt = New System.Windows.Forms.TextBox()
        Me.managerTxt = New System.Windows.Forms.TextBox()
        Me.idTxt = New System.Windows.Forms.TextBox()
        Me.lnameTxt = New System.Windows.Forms.TextBox()
        Me.clearBtn = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mnameTxt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pwordTxt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.unameTxt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cntctTxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pBox = New System.Windows.Forms.PictureBox()
        Me.fnameTxt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column10 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(1314, 59)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ACCOUNT INFORMATION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.editbtn)
        Me.Panel1.Controls.Add(Me.updatebtn)
        Me.Panel1.Controls.Add(Me.deletebtn)
        Me.Panel1.Controls.Add(Me.createBtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 545)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1314, 68)
        Me.Panel1.TabIndex = 2
        '
        'editbtn
        '
        Me.editbtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.editbtn.BackColor = System.Drawing.Color.LimeGreen
        Me.editbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.editbtn.Enabled = False
        Me.editbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editbtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_edit_30
        Me.editbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.editbtn.Location = New System.Drawing.Point(719, 16)
        Me.editbtn.Name = "editbtn"
        Me.editbtn.Size = New System.Drawing.Size(162, 39)
        Me.editbtn.TabIndex = 23
        Me.editbtn.Text = "EDIT"
        Me.editbtn.UseVisualStyleBackColor = False
        '
        'updatebtn
        '
        Me.updatebtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.updatebtn.BackColor = System.Drawing.Color.Aqua
        Me.updatebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.updatebtn.Enabled = False
        Me.updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.updatebtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updatebtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_update_30
        Me.updatebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.updatebtn.Location = New System.Drawing.Point(887, 16)
        Me.updatebtn.Name = "updatebtn"
        Me.updatebtn.Size = New System.Drawing.Size(162, 39)
        Me.updatebtn.TabIndex = 18
        Me.updatebtn.Text = "UPDATE"
        Me.updatebtn.UseVisualStyleBackColor = False
        '
        'deletebtn
        '
        Me.deletebtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.deletebtn.BackColor = System.Drawing.Color.IndianRed
        Me.deletebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.deletebtn.Enabled = False
        Me.deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deletebtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deletebtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_remove_30
        Me.deletebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.deletebtn.Location = New System.Drawing.Point(498, 16)
        Me.deletebtn.Name = "deletebtn"
        Me.deletebtn.Size = New System.Drawing.Size(190, 39)
        Me.deletebtn.TabIndex = 17
        Me.deletebtn.Text = "DELETE ACCOUNT"
        Me.deletebtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.deletebtn.UseVisualStyleBackColor = False
        '
        'createBtn
        '
        Me.createBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createBtn.BackColor = System.Drawing.Color.LightGreen
        Me.createBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.createBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.addNew
        Me.createBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.createBtn.Location = New System.Drawing.Point(1055, 16)
        Me.createBtn.Name = "createBtn"
        Me.createBtn.Size = New System.Drawing.Size(246, 39)
        Me.createBtn.TabIndex = 2
        Me.createBtn.Text = "CREATE ADMIN ACCOUNT"
        Me.createBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.createBtn.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.browsebtn)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.adminTxt)
        Me.GroupBox1.Controls.Add(Me.managerTxt)
        Me.GroupBox1.Controls.Add(Me.idTxt)
        Me.GroupBox1.Controls.Add(Me.lnameTxt)
        Me.GroupBox1.Controls.Add(Me.clearBtn)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.mnameTxt)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.pwordTxt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.unameTxt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cntctTxt)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.pBox)
        Me.GroupBox1.Controls.Add(Me.fnameTxt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(908, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 486)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Account Info."
        '
        'browsebtn
        '
        Me.browsebtn.BackColor = System.Drawing.Color.LightGreen
        Me.browsebtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.browsebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.browsebtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browsebtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_upload_30
        Me.browsebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.browsebtn.Location = New System.Drawing.Point(265, 94)
        Me.browsebtn.Name = "browsebtn"
        Me.browsebtn.Size = New System.Drawing.Size(129, 30)
        Me.browsebtn.TabIndex = 41
        Me.browsebtn.Text = "Upload Profile"
        Me.browsebtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.browsebtn.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 263)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 17)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "ACCOUNT TYPE :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 293)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 17)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "MANAGER  :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(23, 318)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 17)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "ADMIN :"
        '
        'adminTxt
        '
        Me.adminTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.adminTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.adminTxt.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adminTxt.Location = New System.Drawing.Point(129, 316)
        Me.adminTxt.Name = "adminTxt"
        Me.adminTxt.Size = New System.Drawing.Size(50, 22)
        Me.adminTxt.TabIndex = 37
        Me.adminTxt.Text = "YES"
        '
        'managerTxt
        '
        Me.managerTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.managerTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.managerTxt.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerTxt.Location = New System.Drawing.Point(129, 291)
        Me.managerTxt.Name = "managerTxt"
        Me.managerTxt.Size = New System.Drawing.Size(50, 22)
        Me.managerTxt.TabIndex = 36
        Me.managerTxt.Text = "NO"
        '
        'idTxt
        '
        Me.idTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.idTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.idTxt.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idTxt.Location = New System.Drawing.Point(24, 20)
        Me.idTxt.Name = "idTxt"
        Me.idTxt.ReadOnly = True
        Me.idTxt.Size = New System.Drawing.Size(45, 22)
        Me.idTxt.TabIndex = 35
        Me.idTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lnameTxt
        '
        Me.lnameTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lnameTxt.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnameTxt.Location = New System.Drawing.Point(127, 198)
        Me.lnameTxt.Name = "lnameTxt"
        Me.lnameTxt.Size = New System.Drawing.Size(269, 22)
        Me.lnameTxt.TabIndex = 28
        '
        'clearBtn
        '
        Me.clearBtn.BackColor = System.Drawing.Color.LightSalmon
        Me.clearBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearBtn.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clearBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_close_30
        Me.clearBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.clearBtn.Location = New System.Drawing.Point(129, 444)
        Me.clearBtn.Name = "clearBtn"
        Me.clearBtn.Size = New System.Drawing.Size(104, 27)
        Me.clearBtn.TabIndex = 34
        Me.clearBtn.Text = "DESELECT"
        Me.clearBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.clearBtn.UseVisualStyleBackColor = False
        Me.clearBtn.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 198)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 17)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "LAST NAME :"
        '
        'mnameTxt
        '
        Me.mnameTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mnameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mnameTxt.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnameTxt.Location = New System.Drawing.Point(127, 172)
        Me.mnameTxt.Name = "mnameTxt"
        Me.mnameTxt.Size = New System.Drawing.Size(269, 22)
        Me.mnameTxt.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "MIDDLE NAME :"
        '
        'pwordTxt
        '
        Me.pwordTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pwordTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pwordTxt.Font = New System.Drawing.Font("Wingdings", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.pwordTxt.Location = New System.Drawing.Point(129, 404)
        Me.pwordTxt.Name = "pwordTxt"
        Me.pwordTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.pwordTxt.Size = New System.Drawing.Size(267, 21)
        Me.pwordTxt.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 404)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "PASSWORD :"
        '
        'unameTxt
        '
        Me.unameTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.unameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.unameTxt.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unameTxt.Location = New System.Drawing.Point(129, 378)
        Me.unameTxt.Name = "unameTxt"
        Me.unameTxt.Size = New System.Drawing.Size(267, 22)
        Me.unameTxt.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 380)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "USERNAME :"
        '
        'cntctTxt
        '
        Me.cntctTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cntctTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cntctTxt.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cntctTxt.Location = New System.Drawing.Point(127, 224)
        Me.cntctTxt.Name = "cntctTxt"
        Me.cntctTxt.Size = New System.Drawing.Size(148, 22)
        Me.cntctTxt.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "CONTACT :"
        '
        'pBox
        '
        Me.pBox.BackColor = System.Drawing.Color.Aqua
        Me.pBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pBox.Location = New System.Drawing.Point(163, 28)
        Me.pBox.Name = "pBox"
        Me.pBox.Size = New System.Drawing.Size(96, 96)
        Me.pBox.TabIndex = 16
        Me.pBox.TabStop = False
        '
        'fnameTxt
        '
        Me.fnameTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fnameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fnameTxt.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fnameTxt.Location = New System.Drawing.Point(127, 146)
        Me.fnameTxt.Name = "fnameTxt"
        Me.fnameTxt.Size = New System.Drawing.Size(269, 22)
        Me.fnameTxt.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "FIRST NAME :"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.Location = New System.Drawing.Point(0, 59)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(902, 486)
        Me.DataGridView1.TabIndex = 15
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "image"
        Me.Column10.HeaderText = "PROFILE"
        Me.Column10.Name = "Column10"
        Me.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "accountID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "fName"
        Me.Column2.HeaderText = "FIRST NAME"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "mName"
        Me.Column3.HeaderText = "MIDDLE NAME"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "lName"
        Me.Column4.HeaderText = "LAST NAME"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "contact"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "CONTACT"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "uName"
        Me.Column6.HeaderText = "USERNAME"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "pWord"
        Me.Column7.HeaderText = "PASSWORD"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "manager"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column8.HeaderText = "MANAGER"
        Me.Column8.Name = "Column8"
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "admin"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column9.HeaderText = "ADMIN"
        Me.Column9.Name = "Column9"
        '
        'AccountInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1314, 613)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AccountInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AccountInformation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lnameTxt As TextBox
    Friend WithEvents clearBtn As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents mnameTxt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents pwordTxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents unameTxt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cntctTxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pBox As PictureBox
    Friend WithEvents fnameTxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents idTxt As TextBox
    Friend WithEvents Column10 As DataGridViewImageColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents adminTxt As TextBox
    Friend WithEvents managerTxt As TextBox
    Friend WithEvents createBtn As Button
    Friend WithEvents deletebtn As Button
    Friend WithEvents updatebtn As Button
    Friend WithEvents editbtn As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents browsebtn As Button
End Class

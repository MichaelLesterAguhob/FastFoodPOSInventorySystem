<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TransactionsRecords
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.timeLbl = New System.Windows.Forms.Label()
        Me.viewAllRecBtn = New System.Windows.Forms.Button()
        Me.dateLbl = New System.Windows.Forms.Label()
        Me.undoRefundBtn = New System.Windows.Forms.Button()
        Me.refundBtn = New System.Windows.Forms.Button()
        Me.todayTransBtn = New System.Windows.Forms.Button()
        Me.refundedBtn = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.transNoLbl = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.searchtxt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.refundReasonPanelinput = New System.Windows.Forms.Panel()
        Me.cancelRefund = New System.Windows.Forms.Button()
        Me.refundNowBtn = New System.Windows.Forms.Button()
        Me.refundReasontxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.reasonTxt = New System.Windows.Forms.TextBox()
        Me.orderTotalLbl = New System.Windows.Forms.Label()
        Me.orderDetailLbl = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.refundReasonPanelinput.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.timeLbl)
        Me.Panel2.Controls.Add(Me.viewAllRecBtn)
        Me.Panel2.Controls.Add(Me.dateLbl)
        Me.Panel2.Controls.Add(Me.undoRefundBtn)
        Me.Panel2.Controls.Add(Me.refundBtn)
        Me.Panel2.Controls.Add(Me.todayTransBtn)
        Me.Panel2.Controls.Add(Me.refundedBtn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 626)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1312, 69)
        Me.Panel2.TabIndex = 16
        '
        'timeLbl
        '
        Me.timeLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.timeLbl.BackColor = System.Drawing.Color.Transparent
        Me.timeLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timeLbl.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_time_24
        Me.timeLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.timeLbl.Location = New System.Drawing.Point(1168, 35)
        Me.timeLbl.Name = "timeLbl"
        Me.timeLbl.Size = New System.Drawing.Size(137, 24)
        Me.timeLbl.TabIndex = 19
        Me.timeLbl.Text = "03:26:23 am"
        Me.timeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'viewAllRecBtn
        '
        Me.viewAllRecBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.viewAllRecBtn.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewAllRecBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_view_all_50
        Me.viewAllRecBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.viewAllRecBtn.Location = New System.Drawing.Point(902, 10)
        Me.viewAllRecBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.viewAllRecBtn.Name = "viewAllRecBtn"
        Me.viewAllRecBtn.Size = New System.Drawing.Size(190, 51)
        Me.viewAllRecBtn.TabIndex = 6
        Me.viewAllRecBtn.Text = "VIEW ALL RECORDS"
        Me.viewAllRecBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.viewAllRecBtn.UseVisualStyleBackColor = True
        '
        'dateLbl
        '
        Me.dateLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dateLbl.BackColor = System.Drawing.Color.Transparent
        Me.dateLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateLbl.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_today_24
        Me.dateLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.dateLbl.Location = New System.Drawing.Point(1168, 7)
        Me.dateLbl.Name = "dateLbl"
        Me.dateLbl.Size = New System.Drawing.Size(137, 24)
        Me.dateLbl.TabIndex = 18
        Me.dateLbl.Text = "Jun 23, 2000"
        Me.dateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'undoRefundBtn
        '
        Me.undoRefundBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.undoRefundBtn.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.undoRefundBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_return_50
        Me.undoRefundBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.undoRefundBtn.Location = New System.Drawing.Point(240, 10)
        Me.undoRefundBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.undoRefundBtn.Name = "undoRefundBtn"
        Me.undoRefundBtn.Size = New System.Drawing.Size(150, 51)
        Me.undoRefundBtn.TabIndex = 5
        Me.undoRefundBtn.Text = "UNDO REFUND"
        Me.undoRefundBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.undoRefundBtn.UseVisualStyleBackColor = True
        '
        'refundBtn
        '
        Me.refundBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.refundBtn.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refundBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_refund_56
        Me.refundBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.refundBtn.Location = New System.Drawing.Point(3, 10)
        Me.refundBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.refundBtn.Name = "refundBtn"
        Me.refundBtn.Size = New System.Drawing.Size(230, 51)
        Me.refundBtn.TabIndex = 4
        Me.refundBtn.Text = "REFUND SELECTED TRANS."
        Me.refundBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.refundBtn.UseVisualStyleBackColor = True
        '
        'todayTransBtn
        '
        Me.todayTransBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.todayTransBtn.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.todayTransBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_today_50
        Me.todayTransBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.todayTransBtn.Location = New System.Drawing.Point(688, 10)
        Me.todayTransBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.todayTransBtn.Name = "todayTransBtn"
        Me.todayTransBtn.Size = New System.Drawing.Size(208, 51)
        Me.todayTransBtn.TabIndex = 3
        Me.todayTransBtn.Text = "TODAY TRANSACTIONS"
        Me.todayTransBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.todayTransBtn.UseVisualStyleBackColor = True
        '
        'refundedBtn
        '
        Me.refundedBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.refundedBtn.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refundedBtn.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_analyze_50
        Me.refundedBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.refundedBtn.Location = New System.Drawing.Point(397, 10)
        Me.refundedBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.refundedBtn.Name = "refundedBtn"
        Me.refundedBtn.Size = New System.Drawing.Size(164, 51)
        Me.refundedBtn.TabIndex = 2
        Me.refundedBtn.Text = "VIEW REFUNDED"
        Me.refundedBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.refundedBtn.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 546)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "NET TOTAL :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(224, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "REFUND REASON:"
        '
        'transNoLbl
        '
        Me.transNoLbl.AutoSize = True
        Me.transNoLbl.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transNoLbl.Location = New System.Drawing.Point(101, 29)
        Me.transNoLbl.Name = "transNoLbl"
        Me.transNoLbl.Size = New System.Drawing.Size(15, 16)
        Me.transNoLbl.TabIndex = 10
        Me.transNoLbl.Text = "0"
        Me.transNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "TRANS. NO.  :"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.searchtxt)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1312, 57)
        Me.Panel3.TabIndex = 15
        '
        'searchtxt
        '
        Me.searchtxt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchtxt.Location = New System.Drawing.Point(974, 28)
        Me.searchtxt.Name = "searchtxt"
        Me.searchtxt.Size = New System.Drawing.Size(169, 20)
        Me.searchtxt.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_search_19
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(891, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 18)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Search"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_transaction_approved_30
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(421, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(440, 36)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "TRANSACTIONS RECORD"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.refundReasonPanelinput)
        Me.Panel1.Controls.Add(Me.dgv1)
        Me.Panel1.Location = New System.Drawing.Point(0, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(892, 567)
        Me.Panel1.TabIndex = 19
        '
        'refundReasonPanelinput
        '
        Me.refundReasonPanelinput.Controls.Add(Me.cancelRefund)
        Me.refundReasonPanelinput.Controls.Add(Me.refundNowBtn)
        Me.refundReasonPanelinput.Controls.Add(Me.refundReasontxt)
        Me.refundReasonPanelinput.Controls.Add(Me.Label3)
        Me.refundReasonPanelinput.Location = New System.Drawing.Point(416, 152)
        Me.refundReasonPanelinput.Name = "refundReasonPanelinput"
        Me.refundReasonPanelinput.Size = New System.Drawing.Size(0, 355)
        Me.refundReasonPanelinput.TabIndex = 1
        '
        'cancelRefund
        '
        Me.cancelRefund.BackColor = System.Drawing.Color.LightCoral
        Me.cancelRefund.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancelRefund.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cancelRefund.Location = New System.Drawing.Point(318, 310)
        Me.cancelRefund.Name = "cancelRefund"
        Me.cancelRefund.Size = New System.Drawing.Size(125, 33)
        Me.cancelRefund.TabIndex = 17
        Me.cancelRefund.Text = "Cancel Refund"
        Me.cancelRefund.UseVisualStyleBackColor = False
        '
        'refundNowBtn
        '
        Me.refundNowBtn.BackColor = System.Drawing.Color.LightSkyBlue
        Me.refundNowBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.refundNowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.refundNowBtn.Location = New System.Drawing.Point(16, 310)
        Me.refundNowBtn.Name = "refundNowBtn"
        Me.refundNowBtn.Size = New System.Drawing.Size(125, 33)
        Me.refundNowBtn.TabIndex = 16
        Me.refundNowBtn.Text = "Refund Now"
        Me.refundNowBtn.UseVisualStyleBackColor = False
        '
        'refundReasontxt
        '
        Me.refundReasontxt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refundReasontxt.BackColor = System.Drawing.SystemColors.Control
        Me.refundReasontxt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.refundReasontxt.Location = New System.Drawing.Point(-441, 58)
        Me.refundReasontxt.Multiline = True
        Me.refundReasontxt.Name = "refundReasontxt"
        Me.refundReasontxt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.refundReasontxt.Size = New System.Drawing.Size(427, 235)
        Me.refundReasontxt.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightCoral
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 45)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Reason for Refund"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv1.BackgroundColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column1, Me.Column11, Me.Column3, Me.Column5, Me.Column4, Me.Column6, Me.Column7})
        Me.dgv1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgv1.Location = New System.Drawing.Point(0, 0)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.RowHeadersVisible = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv1.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(897, 567)
        Me.dgv1.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "transNO"
        Me.Column2.HeaderText = "TRANS. NO."
        Me.Column2.Name = "Column2"
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "tableNum"
        Me.Column1.HeaderText = "TABLE NO."
        Me.Column1.Name = "Column1"
        '
        'Column11
        '
        Me.Column11.DataPropertyName = "orderDetails"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column11.HeaderText = "ORDER DETAILS"
        Me.Column11.Name = "Column11"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "orderTotal"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column3.HeaderText = "ORDER TOTAL"
        Me.Column3.Name = "Column3"
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "dateOrdered"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column5.HeaderText = "DATE"
        Me.Column5.Name = "Column5"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "timeOrdered"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column4.HeaderText = "TIME"
        Me.Column4.Name = "Column4"
        Me.Column4.ToolTipText = "TIME ORDERED"
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "refundStat"
        Me.Column6.HeaderText = "REFUND STAT"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "reasonRefund"
        Me.Column7.HeaderText = "REASON"
        Me.Column7.Name = "Column7"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.reasonTxt)
        Me.Panel4.Controls.Add(Me.orderTotalLbl)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.transNoLbl)
        Me.Panel4.Controls.Add(Me.orderDetailLbl)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Location = New System.Drawing.Point(895, 58)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(417, 567)
        Me.Panel4.TabIndex = 20
        '
        'reasonTxt
        '
        Me.reasonTxt.BackColor = System.Drawing.SystemColors.Control
        Me.reasonTxt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.reasonTxt.Location = New System.Drawing.Point(230, 56)
        Me.reasonTxt.Multiline = True
        Me.reasonTxt.Name = "reasonTxt"
        Me.reasonTxt.Size = New System.Drawing.Size(154, 155)
        Me.reasonTxt.TabIndex = 16
        '
        'orderTotalLbl
        '
        Me.orderTotalLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.orderTotalLbl.AutoSize = True
        Me.orderTotalLbl.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.orderTotalLbl.Location = New System.Drawing.Point(91, 547)
        Me.orderTotalLbl.Name = "orderTotalLbl"
        Me.orderTotalLbl.Size = New System.Drawing.Size(15, 16)
        Me.orderTotalLbl.TabIndex = 15
        Me.orderTotalLbl.Text = "0"
        Me.orderTotalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'orderDetailLbl
        '
        Me.orderDetailLbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.orderDetailLbl.BackColor = System.Drawing.SystemColors.Control
        Me.orderDetailLbl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.orderDetailLbl.Location = New System.Drawing.Point(13, 55)
        Me.orderDetailLbl.Multiline = True
        Me.orderDetailLbl.Name = "orderDetailLbl"
        Me.orderDetailLbl.ReadOnly = True
        Me.orderDetailLbl.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.orderDetailLbl.Size = New System.Drawing.Size(402, 488)
        Me.orderDetailLbl.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Image = Global.FastFoodPOSInventorySystem.My.Resources.Resources.icons8_view_details_27
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(415, 28)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "TRANSACTION DETAILS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'TransactionsRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1312, 695)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "TransactionsRecords"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TransactionsRecords"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.refundReasonPanelinput.ResumeLayout(False)
        Me.refundReasonPanelinput.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents refundBtn As Button
    Friend WithEvents todayTransBtn As Button
    Friend WithEvents refundedBtn As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents transNoLbl As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As Panel
    Friend WithEvents orderDetailLbl As TextBox
    Friend WithEvents orderTotalLbl As Label
    Friend WithEvents reasonTxt As TextBox
    Friend WithEvents undoRefundBtn As Button
    Friend WithEvents refundReasonPanelinput As Panel
    Friend WithEvents cancelRefund As Button
    Friend WithEvents refundNowBtn As Button
    Friend WithEvents refundReasontxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents viewAllRecBtn As Button
    Friend WithEvents timeLbl As Label
    Friend WithEvents dateLbl As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents searchtxt As TextBox
    Friend WithEvents Label5 As Label
End Class

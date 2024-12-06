<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DCD
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DCD))
        DataGridView1 = New DataGridView()
        Button1 = New Button()
        dltbtn = New Button()
        stsbtn = New Button()
        editbtn = New Button()
        bckpbtn = New Button()
        mm = New GroupBox()
        DateTimePicker1 = New DateTimePicker()
        TableLayoutPanel3 = New TableLayoutPanel()
        Label2 = New Label()
        chkFilterByDate = New CheckBox()
        Label3 = New Label()
        fltrmpc = New CheckBox()
        fltrdisposed = New CheckBox()
        fltrinstorage = New CheckBox()
        Label5 = New Label()
        fltrncn = New CheckBox()
        Label4 = New Label()
        fltrdp = New CheckBox()
        fltrlp = New CheckBox()
        fltrtc = New CheckBox()
        fltrtrml = New CheckBox()
        fltradm = New CheckBox()
        fltrstp = New CheckBox()
        fltrnx1 = New CheckBox()
        fltrsta = New CheckBox()
        fltrnx2 = New CheckBox()
        Panel1 = New Panel()
        FilterResultCountLabel = New Label()
        srchtxtbx = New TextBox()
        Label1 = New Label()
        totalLabel = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        TableLayoutPanel4 = New TableLayoutPanel()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        mm.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.Gainsboro
        DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.DarkRed
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = Color.DarkRed
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridView1.ColumnHeadersHeight = 40
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.Location = New Point(12, 12)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = Color.Firebrick
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle4.SelectionBackColor = Color.Firebrick
        DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(643, 606)
        DataGridView1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Right
        Button1.BackColor = Color.DarkRed
        Button1.FlatAppearance.BorderColor = Color.DimGray
        Button1.FlatAppearance.MouseOverBackColor = Color.DarkGray
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = Color.White
        Button1.Location = New Point(38, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 50)
        Button1.TabIndex = 1
        Button1.Text = "ADD"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' dltbtn
        ' 
        dltbtn.Anchor = AnchorStyles.Left
        dltbtn.BackColor = Color.DarkRed
        dltbtn.Enabled = False
        dltbtn.FlatAppearance.BorderColor = Color.DimGray
        dltbtn.FlatAppearance.MouseOverBackColor = Color.DarkGray
        dltbtn.FlatStyle = FlatStyle.Flat
        dltbtn.ForeColor = Color.White
        dltbtn.Location = New Point(291, 4)
        dltbtn.Name = "dltbtn"
        dltbtn.Size = New Size(120, 50)
        dltbtn.TabIndex = 2
        dltbtn.Text = "DELETE"
        dltbtn.UseVisualStyleBackColor = False
        ' 
        ' stsbtn
        ' 
        stsbtn.Anchor = AnchorStyles.Left
        stsbtn.BackColor = Color.DarkRed
        stsbtn.Enabled = False
        stsbtn.FlatAppearance.BorderColor = Color.DimGray
        stsbtn.FlatAppearance.MouseOverBackColor = Color.DarkGray
        stsbtn.FlatStyle = FlatStyle.Flat
        stsbtn.ForeColor = Color.White
        stsbtn.Location = New Point(228, 6)
        stsbtn.Name = "stsbtn"
        stsbtn.Size = New Size(120, 50)
        stsbtn.TabIndex = 3
        stsbtn.Text = "Set Status to Disposed"
        stsbtn.UseVisualStyleBackColor = False
        ' 
        ' editbtn
        ' 
        editbtn.Anchor = AnchorStyles.None
        editbtn.BackColor = Color.DarkRed
        editbtn.Enabled = False
        editbtn.FlatAppearance.BorderColor = Color.DimGray
        editbtn.FlatAppearance.MouseOverBackColor = Color.DarkGray
        editbtn.FlatStyle = FlatStyle.Flat
        editbtn.ForeColor = Color.White
        editbtn.Location = New Point(164, 4)
        editbtn.Name = "editbtn"
        editbtn.Size = New Size(120, 50)
        editbtn.TabIndex = 4
        editbtn.Text = "EDIT"
        editbtn.UseVisualStyleBackColor = False
        ' 
        ' bckpbtn
        ' 
        bckpbtn.Anchor = AnchorStyles.Right
        bckpbtn.BackColor = Color.DarkRed
        bckpbtn.FlatAppearance.BorderColor = Color.DimGray
        bckpbtn.FlatAppearance.MouseOverBackColor = Color.DarkGray
        bckpbtn.FlatStyle = FlatStyle.Flat
        bckpbtn.ForeColor = Color.White
        bckpbtn.Location = New Point(102, 6)
        bckpbtn.Name = "bckpbtn"
        bckpbtn.Size = New Size(120, 50)
        bckpbtn.TabIndex = 7
        bckpbtn.Text = "Export Filtered Devices"
        bckpbtn.UseVisualStyleBackColor = False
        ' 
        ' mm
        ' 
        mm.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        mm.BackColor = Color.Silver
        mm.Controls.Add(DateTimePicker1)
        mm.Controls.Add(TableLayoutPanel3)
        mm.Controls.Add(Panel1)
        mm.Controls.Add(srchtxtbx)
        mm.Controls.Add(Label1)
        mm.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        mm.Location = New Point(664, 98)
        mm.Name = "mm"
        mm.Size = New Size(450, 364)
        mm.TabIndex = 8
        mm.TabStop = False
        mm.Text = "Filters:"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        DateTimePicker1.CalendarFont = New Font("Segoe UI", 8F)
        DateTimePicker1.CalendarMonthBackground = Color.Black
        DateTimePicker1.Enabled = False
        DateTimePicker1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.Location = New Point(319, 63)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(117, 29)
        DateTimePicker1.TabIndex = 37
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel3.Controls.Add(Label2, 0, 0)
        TableLayoutPanel3.Controls.Add(chkFilterByDate, 2, 1)
        TableLayoutPanel3.Controls.Add(Label3, 1, 0)
        TableLayoutPanel3.Controls.Add(fltrmpc, 0, 5)
        TableLayoutPanel3.Controls.Add(fltrdisposed, 2, 4)
        TableLayoutPanel3.Controls.Add(fltrinstorage, 2, 3)
        TableLayoutPanel3.Controls.Add(Label5, 2, 0)
        TableLayoutPanel3.Controls.Add(fltrncn, 0, 4)
        TableLayoutPanel3.Controls.Add(Label4, 2, 2)
        TableLayoutPanel3.Controls.Add(fltrdp, 0, 1)
        TableLayoutPanel3.Controls.Add(fltrlp, 0, 2)
        TableLayoutPanel3.Controls.Add(fltrtc, 0, 3)
        TableLayoutPanel3.Controls.Add(fltrtrml, 1, 6)
        TableLayoutPanel3.Controls.Add(fltradm, 1, 1)
        TableLayoutPanel3.Controls.Add(fltrstp, 1, 5)
        TableLayoutPanel3.Controls.Add(fltrnx1, 1, 2)
        TableLayoutPanel3.Controls.Add(fltrsta, 1, 4)
        TableLayoutPanel3.Controls.Add(fltrnx2, 1, 3)
        TableLayoutPanel3.Font = New Font("Segoe UI", 12F)
        TableLayoutPanel3.Location = New Point(11, 28)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 7
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel3.Size = New Size(429, 235)
        TableLayoutPanel3.TabIndex = 12
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.BackColor = Color.Silver
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label2.Location = New Point(3, 6)
        Label2.Name = "Label2"
        Label2.Size = New Size(136, 21)
        Label2.TabIndex = 9
        Label2.Text = "Device Type:"
        ' 
        ' chkFilterByDate
        ' 
        chkFilterByDate.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        chkFilterByDate.AutoSize = True
        chkFilterByDate.Location = New Point(288, 42)
        chkFilterByDate.Name = "chkFilterByDate"
        chkFilterByDate.Size = New Size(138, 14)
        chkFilterByDate.TabIndex = 38
        chkFilterByDate.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.BackColor = Color.Silver
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label3.Location = New Point(145, 6)
        Label3.Name = "Label3"
        Label3.Size = New Size(137, 21)
        Label3.TabIndex = 10
        Label3.Text = "Plant:"
        ' 
        ' fltrmpc
        ' 
        fltrmpc.Anchor = AnchorStyles.Left
        fltrmpc.AutoSize = True
        fltrmpc.Font = New Font("Segoe UI", 9F)
        fltrmpc.Location = New Point(3, 172)
        fltrmpc.Name = "fltrmpc"
        fltrmpc.Size = New Size(98, 19)
        fltrmpc.TabIndex = 40
        fltrmpc.Text = "MACHINE PC"
        fltrmpc.UseVisualStyleBackColor = True
        ' 
        ' fltrdisposed
        ' 
        fltrdisposed.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        fltrdisposed.AutoSize = True
        fltrdisposed.Location = New Point(288, 136)
        fltrdisposed.Name = "fltrdisposed"
        fltrdisposed.Size = New Size(138, 25)
        fltrdisposed.TabIndex = 30
        fltrdisposed.Text = "DISPOSED"
        fltrdisposed.UseVisualStyleBackColor = True
        ' 
        ' fltrinstorage
        ' 
        fltrinstorage.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        fltrinstorage.AutoSize = True
        fltrinstorage.Location = New Point(288, 103)
        fltrinstorage.Name = "fltrinstorage"
        fltrinstorage.Size = New Size(138, 25)
        fltrinstorage.TabIndex = 31
        fltrinstorage.Text = "IN STORAGE"
        fltrinstorage.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.BackColor = Color.Silver
        Label5.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label5.Location = New Point(288, 6)
        Label5.Name = "Label5"
        Label5.Size = New Size(138, 21)
        Label5.TabIndex = 23
        Label5.Text = "Date:"
        ' 
        ' fltrncn
        ' 
        fltrncn.Anchor = AnchorStyles.Left
        fltrncn.AutoSize = True
        fltrncn.Font = New Font("Segoe UI", 10F)
        fltrncn.Location = New Point(3, 137)
        fltrncn.Name = "fltrncn"
        fltrncn.Size = New Size(104, 23)
        fltrncn.TabIndex = 39
        fltrncn.Text = "No Control#"
        fltrncn.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Location = New Point(288, 72)
        Label4.Name = "Label4"
        Label4.Size = New Size(138, 21)
        Label4.TabIndex = 11
        Label4.Text = "Status:"
        ' 
        ' fltrdp
        ' 
        fltrdp.Anchor = AnchorStyles.Left
        fltrdp.AutoSize = True
        fltrdp.Location = New Point(3, 37)
        fltrdp.Name = "fltrdp"
        fltrdp.Size = New Size(94, 25)
        fltrdp.TabIndex = 32
        fltrdp.Text = "DESKTOP"
        fltrdp.UseVisualStyleBackColor = True
        ' 
        ' fltrlp
        ' 
        fltrlp.Anchor = AnchorStyles.Left
        fltrlp.AutoSize = True
        fltrlp.Location = New Point(3, 70)
        fltrlp.Name = "fltrlp"
        fltrlp.Size = New Size(84, 25)
        fltrlp.TabIndex = 33
        fltrlp.Text = "LAPTOP"
        fltrlp.UseVisualStyleBackColor = True
        ' 
        ' fltrtc
        ' 
        fltrtc.Anchor = AnchorStyles.Left
        fltrtc.AutoSize = True
        fltrtc.Font = New Font("Segoe UI", 10F)
        fltrtc.Location = New Point(3, 104)
        fltrtc.Name = "fltrtc"
        fltrtc.Size = New Size(107, 23)
        fltrtc.TabIndex = 34
        fltrtc.Text = "THIN CLIENT"
        fltrtc.UseVisualStyleBackColor = True
        ' 
        ' fltrtrml
        ' 
        fltrtrml.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        fltrtrml.AutoSize = True
        fltrtrml.Location = New Point(145, 204)
        fltrtrml.Name = "fltrtrml"
        fltrtrml.Size = New Size(137, 25)
        fltrtrml.TabIndex = 29
        fltrtrml.Text = "THERMAL"
        fltrtrml.UseVisualStyleBackColor = True
        ' 
        ' fltradm
        ' 
        fltradm.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        fltradm.AutoSize = True
        fltradm.Location = New Point(145, 37)
        fltradm.Name = "fltradm"
        fltradm.Size = New Size(137, 25)
        fltradm.TabIndex = 24
        fltradm.Text = "ADM"
        fltradm.UseVisualStyleBackColor = True
        ' 
        ' fltrstp
        ' 
        fltrstp.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        fltrstp.AutoSize = True
        fltrstp.Location = New Point(145, 169)
        fltrstp.Name = "fltrstp"
        fltrstp.Size = New Size(137, 25)
        fltrstp.TabIndex = 28
        fltrstp.Text = "STA-P"
        fltrstp.UseVisualStyleBackColor = True
        ' 
        ' fltrnx1
        ' 
        fltrnx1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        fltrnx1.AutoSize = True
        fltrnx1.Location = New Point(145, 70)
        fltrnx1.Name = "fltrnx1"
        fltrnx1.Size = New Size(137, 25)
        fltrnx1.TabIndex = 25
        fltrnx1.Text = "NX1"
        fltrnx1.UseVisualStyleBackColor = True
        ' 
        ' fltrsta
        ' 
        fltrsta.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        fltrsta.AutoSize = True
        fltrsta.Location = New Point(145, 136)
        fltrsta.Name = "fltrsta"
        fltrsta.Size = New Size(137, 25)
        fltrsta.TabIndex = 27
        fltrsta.Text = "STA-A"
        fltrsta.UseVisualStyleBackColor = True
        ' 
        ' fltrnx2
        ' 
        fltrnx2.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        fltrnx2.AutoSize = True
        fltrnx2.Location = New Point(145, 103)
        fltrnx2.Name = "fltrnx2"
        fltrnx2.Size = New Size(137, 25)
        fltrnx2.TabIndex = 26
        fltrnx2.Text = "NX2"
        fltrnx2.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Gray
        Panel1.Controls.Add(FilterResultCountLabel)
        Panel1.Location = New Point(1, 317)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(448, 45)
        Panel1.TabIndex = 41
        ' 
        ' FilterResultCountLabel
        ' 
        FilterResultCountLabel.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        FilterResultCountLabel.AutoSize = True
        FilterResultCountLabel.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        FilterResultCountLabel.Location = New Point(17, 9)
        FilterResultCountLabel.Name = "FilterResultCountLabel"
        FilterResultCountLabel.Size = New Size(132, 25)
        FilterResultCountLabel.TabIndex = 36
        FilterResultCountLabel.Text = "Filtered Total:"
        ' 
        ' srchtxtbx
        ' 
        srchtxtbx.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        srchtxtbx.Font = New Font("Segoe UI", 12F)
        srchtxtbx.Location = New Point(108, 273)
        srchtxtbx.Name = "srchtxtbx"
        srchtxtbx.Size = New Size(272, 29)
        srchtxtbx.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label1.Location = New Point(45, 276)
        Label1.Name = "Label1"
        Label1.Size = New Size(65, 21)
        Label1.TabIndex = 6
        Label1.Text = "Search:"
        ' 
        ' totalLabel
        ' 
        totalLabel.Anchor = AnchorStyles.None
        totalLabel.AutoSize = True
        totalLabel.Font = New Font("Segoe UI", 15F, FontStyle.Bold Or FontStyle.Underline)
        totalLabel.Location = New Point(38, 10)
        totalLabel.Name = "totalLabel"
        totalLabel.Size = New Size(373, 28)
        totalLabel.TabIndex = 9
        totalLabel.Text = "Total Number of Disposed Computers:"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35.7954559F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 28.4090939F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35.7954559F))
        TableLayoutPanel1.Controls.Add(Button1, 0, 0)
        TableLayoutPanel1.Controls.Add(dltbtn, 2, 0)
        TableLayoutPanel1.Controls.Add(editbtn, 1, 0)
        TableLayoutPanel1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        TableLayoutPanel1.Location = New Point(664, 468)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(450, 59)
        TableLayoutPanel1.TabIndex = 10
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(bckpbtn, 0, 0)
        TableLayoutPanel2.Controls.Add(stsbtn, 1, 0)
        TableLayoutPanel2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        TableLayoutPanel2.Location = New Point(663, 533)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(450, 62)
        TableLayoutPanel2.TabIndex = 11
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Controls.Add(totalLabel, 0, 0)
        TableLayoutPanel4.Location = New Point(664, 12)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 1
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Size = New Size(449, 48)
        TableLayoutPanel4.TabIndex = 12
        ' 
        ' DCD
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gainsboro
        ClientSize = New Size(1125, 630)
        Controls.Add(TableLayoutPanel4)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(mm)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "DCD"
        StartPosition = FormStartPosition.Manual
        Text = "DISPOSED COMPUTERS DATABASE"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        mm.ResumeLayout(False)
        mm.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents dltbtn As Button
    Friend WithEvents stsbtn As Button
    Friend WithEvents editbtn As Button
    Friend WithEvents bckpbtn As Button
    Friend WithEvents mm As GroupBox
    Friend WithEvents fltrmpc As CheckBox
    Friend WithEvents fltrncn As CheckBox
    Friend WithEvents chkFilterByDate As CheckBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents FilterResultCountLabel As Label
    Friend WithEvents fltrtc As CheckBox
    Friend WithEvents srchtxtbx As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents fltrlp As CheckBox
    Friend WithEvents fltrdp As CheckBox
    Friend WithEvents fltrinstorage As CheckBox
    Friend WithEvents fltrdisposed As CheckBox
    Friend WithEvents fltrtrml As CheckBox
    Friend WithEvents fltrstp As CheckBox
    Friend WithEvents fltrsta As CheckBox
    Friend WithEvents fltrnx2 As CheckBox
    Friend WithEvents fltrnx1 As CheckBox
    Friend WithEvents fltradm As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents totalLabel As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel

End Class

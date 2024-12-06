<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewMainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewMainForm))
        MenuStrip1 = New MenuStrip()
        DCDToolStripMenuItem = New ToolStripMenuItem()
        RDBToolStripMenuItem = New ToolStripMenuItem()
        ReportGenToolStripMenuItem = New ToolStripMenuItem()
        UploadCsvToolStripMenuItem = New ToolStripMenuItem()
        PrintReportToolStripMenuItem = New ToolStripMenuItem()
        PanelMain = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        dmtrigger = New CheckBox()
        LabelUsername = New Label()
        MenuStrip1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.LightSteelBlue
        MenuStrip1.Items.AddRange(New ToolStripItem() {DCDToolStripMenuItem, RDBToolStripMenuItem, ReportGenToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1334, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' DCDToolStripMenuItem
        ' 
        DCDToolStripMenuItem.Name = "DCDToolStripMenuItem"
        DCDToolStripMenuItem.Size = New Size(147, 20)
        DCDToolStripMenuItem.Text = "Disposed Computers DB"
        ' 
        ' RDBToolStripMenuItem
        ' 
        RDBToolStripMenuItem.Name = "RDBToolStripMenuItem"
        RDBToolStripMenuItem.Size = New Size(201, 20)
        RDBToolStripMenuItem.Text = "Contracts and Devices Renewal DB"
        ' 
        ' ReportGenToolStripMenuItem
        ' 
        ReportGenToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {UploadCsvToolStripMenuItem, PrintReportToolStripMenuItem})
        ReportGenToolStripMenuItem.Name = "ReportGenToolStripMenuItem"
        ReportGenToolStripMenuItem.Size = New Size(59, 20)
        ReportGenToolStripMenuItem.Text = "Reports"
        ' 
        ' UploadCsvToolStripMenuItem
        ' 
        UploadCsvToolStripMenuItem.Name = "UploadCsvToolStripMenuItem"
        UploadCsvToolStripMenuItem.Size = New Size(180, 22)
        UploadCsvToolStripMenuItem.Text = "Upload Csv"
        ' 
        ' PrintReportToolStripMenuItem
        ' 
        PrintReportToolStripMenuItem.Name = "PrintReportToolStripMenuItem"
        PrintReportToolStripMenuItem.Size = New Size(180, 22)
        PrintReportToolStripMenuItem.Text = "Export Report"
        ' 
        ' PanelMain
        ' 
        PanelMain.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PanelMain.Location = New Point(0, 26)
        PanelMain.Name = "PanelMain"
        PanelMain.Size = New Size(1333, 664)
        PanelMain.TabIndex = 1
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TableLayoutPanel1.BackColor = Color.LightSteelBlue
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 54.5F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 45.5F))
        TableLayoutPanel1.Controls.Add(dmtrigger, 1, 0)
        TableLayoutPanel1.Controls.Add(LabelUsername, 0, 0)
        TableLayoutPanel1.Location = New Point(1114, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(219, 24)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' dmtrigger
        ' 
        dmtrigger.Anchor = AnchorStyles.None
        dmtrigger.AutoSize = True
        dmtrigger.ForeColor = Color.Black
        dmtrigger.Location = New Point(127, 3)
        dmtrigger.Name = "dmtrigger"
        dmtrigger.Size = New Size(84, 18)
        dmtrigger.TabIndex = 7
        dmtrigger.Text = "Dark Mode"
        dmtrigger.UseVisualStyleBackColor = True
        ' 
        ' LabelUsername
        ' 
        LabelUsername.Anchor = AnchorStyles.Right
        LabelUsername.AutoSize = True
        LabelUsername.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        LabelUsername.Location = New Point(63, 2)
        LabelUsername.Name = "LabelUsername"
        LabelUsername.Size = New Size(53, 19)
        LabelUsername.TabIndex = 0
        LabelUsername.Text = "Label1"
        ' 
        ' NewMainForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1334, 690)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(MenuStrip1)
        Controls.Add(PanelMain)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Name = "NewMainForm"
        Text = "ISS System"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DCDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RDBToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportGenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelMain As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dmtrigger As CheckBox
    Friend WithEvents LabelUsername As Label
    Friend WithEvents PrintReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadCsvToolStripMenuItem As ToolStripMenuItem
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainPageTab
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainPageTab))
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        TabPage3 = New TabPage()
        LabelUsername = New Label()
        dmtrigger = New CheckBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        TabControl1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1350, 729)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Size = New Size(1342, 701)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Disposed Computers Database"
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(1342, 701)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Contract and Devices Renewals Database"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' TabPage3
        ' 
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(1342, 701)
        TabPage3.TabIndex = 2
        TabPage3.Text = "ISS Reports"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' LabelUsername
        ' 
        LabelUsername.Anchor = AnchorStyles.Right
        LabelUsername.AutoSize = True
        LabelUsername.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        LabelUsername.Location = New Point(68, 1)
        LabelUsername.Name = "LabelUsername"
        LabelUsername.Size = New Size(53, 19)
        LabelUsername.TabIndex = 0
        LabelUsername.Text = "Label1"
        ' 
        ' dmtrigger
        ' 
        dmtrigger.Anchor = AnchorStyles.None
        dmtrigger.AutoSize = True
        dmtrigger.ForeColor = Color.Black
        dmtrigger.Location = New Point(134, 3)
        dmtrigger.Name = "dmtrigger"
        dmtrigger.Size = New Size(84, 16)
        dmtrigger.TabIndex = 7
        dmtrigger.Text = "Dark Mode"
        dmtrigger.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 54.5F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 45.5F))
        TableLayoutPanel1.Controls.Add(dmtrigger, 1, 0)
        TableLayoutPanel1.Controls.Add(LabelUsername, 0, 0)
        TableLayoutPanel1.Location = New Point(1122, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(228, 22)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' MainPageTab
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.AliceBlue
        ClientSize = New Size(1350, 729)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(TabControl1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "MainPageTab"
        StartPosition = FormStartPosition.CenterParent
        Text = "ISS System"
        TabControl1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dmtrigger As CheckBox
    Friend WithEvents LabelUsername As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel

End Class

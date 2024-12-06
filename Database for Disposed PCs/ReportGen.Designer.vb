<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportGen
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
        GroupBox2 = New GroupBox()
        Label6 = New Label()
        ComboBoxCSVFiles = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        CheckBox1 = New CheckBox()
        TextBox1 = New TextBox()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        btnUpload = New Button()
        ComboBoxPlants = New ComboBox()
        ComboBoxReport = New ComboBox()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Anchor = AnchorStyles.None
        GroupBox2.BackColor = Color.Silver
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(ComboBoxCSVFiles)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(CheckBox1)
        GroupBox2.Controls.Add(TextBox1)
        GroupBox2.Controls.Add(TextBox3)
        GroupBox2.Controls.Add(TextBox2)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(btnUpload)
        GroupBox2.Controls.Add(ComboBoxPlants)
        GroupBox2.Controls.Add(ComboBoxReport)
        GroupBox2.FlatStyle = FlatStyle.Flat
        GroupBox2.ForeColor = Color.Black
        GroupBox2.Location = New Point(28, 14)
        GroupBox2.Margin = New Padding(4)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(4)
        GroupBox2.Size = New Size(500, 464)
        GroupBox2.TabIndex = 14
        GroupBox2.TabStop = False
        GroupBox2.Text = "Report Settings"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.Location = New Point(42, 153)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(133, 21)
        Label6.TabIndex = 22
        Label6.Text = "Year And Quarter:"
        ' 
        ' ComboBoxCSVFiles
        ' 
        ComboBoxCSVFiles.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxCSVFiles.Font = New Font("Segoe UI", 12F)
        ComboBoxCSVFiles.FormattingEnabled = True
        ComboBoxCSVFiles.Items.AddRange(New Object() {"ADM", "NX1", "NX2", "STA", "STP", "TP"})
        ComboBoxCSVFiles.Location = New Point(257, 149)
        ComboBoxCSVFiles.Margin = New Padding(4)
        ComboBoxCSVFiles.Name = "ComboBoxCSVFiles"
        ComboBoxCSVFiles.Size = New Size(206, 29)
        ComboBoxCSVFiles.TabIndex = 21
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(42, 344)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(45, 21)
        Label3.TabIndex = 20
        Label3.Text = "Date:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(42, 295)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(137, 21)
        Label2.TabIndex = 19
        Label2.Text = "Enforcement Date:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(42, 246)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(147, 21)
        Label1.TabIndex = 18
        Label1.Text = "Document Number:"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Font = New Font("Segoe UI", 12F)
        CheckBox1.Location = New Point(42, 198)
        CheckBox1.Margin = New Padding(4)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(131, 25)
        CheckBox1.TabIndex = 14
        CheckBox1.Text = "Edit Document"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Enabled = False
        TextBox1.Font = New Font("Segoe UI", 12F)
        TextBox1.Location = New Point(257, 242)
        TextBox1.Margin = New Padding(4)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(198, 29)
        TextBox1.TabIndex = 15
        ' 
        ' TextBox3
        ' 
        TextBox3.Enabled = False
        TextBox3.Font = New Font("Segoe UI", 12F)
        TextBox3.Location = New Point(257, 340)
        TextBox3.Margin = New Padding(4)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(198, 29)
        TextBox3.TabIndex = 17
        ' 
        ' TextBox2
        ' 
        TextBox2.Enabled = False
        TextBox2.Font = New Font("Segoe UI", 12F)
        TextBox2.Location = New Point(257, 291)
        TextBox2.Margin = New Padding(4)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(198, 29)
        TextBox2.TabIndex = 16
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(42, 100)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(48, 21)
        Label4.TabIndex = 12
        Label4.Text = "Plant:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(42, 51)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(60, 21)
        Label5.TabIndex = 13
        Label5.Text = "Report:"
        ' 
        ' btnUpload
        ' 
        btnUpload.BackColor = Color.DarkRed
        btnUpload.FlatAppearance.BorderColor = Color.DimGray
        btnUpload.FlatStyle = FlatStyle.Flat
        btnUpload.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpload.ForeColor = Color.White
        btnUpload.Location = New Point(165, 398)
        btnUpload.Margin = New Padding(4)
        btnUpload.Name = "btnUpload"
        btnUpload.Size = New Size(160, 55)
        btnUpload.TabIndex = 1
        btnUpload.Text = "Export to PDF"
        btnUpload.UseVisualStyleBackColor = False
        ' 
        ' ComboBoxPlants
        ' 
        ComboBoxPlants.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxPlants.Font = New Font("Segoe UI", 12F)
        ComboBoxPlants.FormattingEnabled = True
        ComboBoxPlants.Items.AddRange(New Object() {"ADM", "NX1", "NX2", "STA", "STP", "TP"})
        ComboBoxPlants.Location = New Point(257, 96)
        ComboBoxPlants.Margin = New Padding(4)
        ComboBoxPlants.Name = "ComboBoxPlants"
        ComboBoxPlants.Size = New Size(206, 29)
        ComboBoxPlants.TabIndex = 4
        ' 
        ' ComboBoxReport
        ' 
        ComboBoxReport.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxReport.Font = New Font("Segoe UI", 12F)
        ComboBoxReport.FormattingEnabled = True
        ComboBoxReport.Items.AddRange(New Object() {"INVENTORY MASTERLIST", "PM", "HRC"})
        ComboBoxReport.Location = New Point(257, 43)
        ComboBoxReport.Margin = New Padding(4)
        ComboBoxReport.Name = "ComboBoxReport"
        ComboBoxReport.Size = New Size(206, 29)
        ComboBoxReport.TabIndex = 9
        ' 
        ' ReportGen
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gainsboro
        ClientSize = New Size(564, 491)
        Controls.Add(GroupBox2)
        Font = New Font("Segoe UI", 12F)
        Margin = New Padding(4)
        Name = "ReportGen"
        StartPosition = FormStartPosition.CenterParent
        Text = "Form1"
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnUpload As Button
    Friend WithEvents ComboBoxPlants As ComboBox
    Friend WithEvents ComboBoxReport As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBoxCSVFiles As ComboBox


End Class

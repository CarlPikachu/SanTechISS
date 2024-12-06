<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCSV
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
        cboCSVFiles = New ComboBox()
        ComboBox2 = New ComboBox()
        dataGridViewSummary = New DataGridView()
        openFileDialog1 = New OpenFileDialog()
        dataGridViewOSD = New DataGridView()
        Panel1 = New Panel()
        Label5 = New Label()
        dataGridViewOSS = New DataGridView()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        dataGridViewOSTC = New DataGridView()
        dataGridViewOSL = New DataGridView()
        CType(dataGridViewSummary, ComponentModel.ISupportInitialize).BeginInit()
        CType(dataGridViewOSD, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(dataGridViewOSS, ComponentModel.ISupportInitialize).BeginInit()
        CType(dataGridViewOSTC, ComponentModel.ISupportInitialize).BeginInit()
        CType(dataGridViewOSL, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cboCSVFiles
        ' 
        cboCSVFiles.DropDownStyle = ComboBoxStyle.DropDownList
        cboCSVFiles.FormattingEnabled = True
        cboCSVFiles.Location = New Point(12, 12)
        cboCSVFiles.Name = "cboCSVFiles"
        cboCSVFiles.Size = New Size(121, 23)
        cboCSVFiles.TabIndex = 0
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(12, 336)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(121, 23)
        ComboBox2.TabIndex = 1
        ' 
        ' dataGridViewSummary
        ' 
        dataGridViewSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewSummary.Location = New Point(0, 24)
        dataGridViewSummary.Name = "dataGridViewSummary"
        dataGridViewSummary.RowHeadersVisible = False
        dataGridViewSummary.Size = New Size(400, 199)
        dataGridViewSummary.TabIndex = 3
        ' 
        ' openFileDialog1
        ' 
        openFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' dataGridViewOSD
        ' 
        dataGridViewOSD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewOSD.Location = New Point(406, 24)
        dataGridViewOSD.Name = "dataGridViewOSD"
        dataGridViewOSD.RowHeadersVisible = False
        dataGridViewOSD.Size = New Size(400, 199)
        dataGridViewOSD.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(dataGridViewOSS)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(dataGridViewOSTC)
        Panel1.Controls.Add(dataGridViewOSL)
        Panel1.Controls.Add(dataGridViewSummary)
        Panel1.Controls.Add(dataGridViewOSD)
        Panel1.Location = New Point(12, 44)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1293, 262)
        Panel1.TabIndex = 5
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(1624, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(80, 21)
        Label5.TabIndex = 12
        Label5.Text = "Server OS"
        ' 
        ' dataGridViewOSS
        ' 
        dataGridViewOSS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewOSS.Location = New Point(1624, 24)
        dataGridViewOSS.Name = "dataGridViewOSS"
        dataGridViewOSS.RowHeadersVisible = False
        dataGridViewOSS.Size = New Size(400, 199)
        dataGridViewOSS.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(1218, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(52, 21)
        Label4.TabIndex = 10
        Label4.Text = "TC OS"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(812, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 21)
        Label3.TabIndex = 9
        Label3.Text = "Laptop OS"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(406, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 21)
        Label2.TabIndex = 8
        Label2.Text = "Desktop OS"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(85, 21)
        Label1.TabIndex = 7
        Label1.Text = "All Devices"
        ' 
        ' dataGridViewOSTC
        ' 
        dataGridViewOSTC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewOSTC.Location = New Point(1218, 24)
        dataGridViewOSTC.Name = "dataGridViewOSTC"
        dataGridViewOSTC.RowHeadersVisible = False
        dataGridViewOSTC.Size = New Size(400, 199)
        dataGridViewOSTC.TabIndex = 6
        ' 
        ' dataGridViewOSL
        ' 
        dataGridViewOSL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewOSL.Location = New Point(812, 24)
        dataGridViewOSL.Name = "dataGridViewOSL"
        dataGridViewOSL.RowHeadersVisible = False
        dataGridViewOSL.Size = New Size(400, 199)
        dataGridViewOSL.TabIndex = 5
        ' 
        ' ViewCSV
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1317, 625)
        Controls.Add(Panel1)
        Controls.Add(ComboBox2)
        Controls.Add(cboCSVFiles)
        Name = "ViewCSV"
        Text = "Form1"
        CType(dataGridViewSummary, ComponentModel.ISupportInitialize).EndInit()
        CType(dataGridViewOSD, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(dataGridViewOSS, ComponentModel.ISupportInitialize).EndInit()
        CType(dataGridViewOSTC, ComponentModel.ISupportInitialize).EndInit()
        CType(dataGridViewOSL, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents cboCSVFiles As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents dataGridViewSummary As DataGridView
    Friend WithEvents openFileDialog1 As OpenFileDialog
    Friend WithEvents dataGridViewOSD As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dataGridViewOSTC As DataGridView
    Friend WithEvents dataGridViewOSL As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents dataGridViewOSS As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSVupload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CSVupload))
        Label1 = New Label()
        uploadButton = New Button()
        Label2 = New Label()
        ComboBox1 = New ComboBox()
        MaskedTextBox1 = New MaskedTextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(128, 15)
        Label1.TabIndex = 1
        Label1.Text = "Enter Quarter and Year:"
        ' 
        ' uploadButton
        ' 
        uploadButton.Anchor = AnchorStyles.Right
        uploadButton.BackColor = Color.DarkRed
        uploadButton.FlatAppearance.BorderColor = Color.DimGray
        uploadButton.FlatAppearance.MouseOverBackColor = Color.DarkGray
        uploadButton.FlatStyle = FlatStyle.Flat
        uploadButton.ForeColor = Color.White
        uploadButton.Location = New Point(79, 69)
        uploadButton.Name = "uploadButton"
        uploadButton.Size = New Size(78, 30)
        uploadButton.TabIndex = 3
        uploadButton.Text = "Upload"
        uploadButton.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(22, 35)
        Label2.Name = "Label2"
        Label2.Size = New Size(27, 15)
        Label2.TabIndex = 2
        Label2.Text = "For:"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Q1", "Q2", "Q3", "Q4"})
        ComboBox1.Location = New Point(55, 32)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(68, 23)
        ComboBox1.TabIndex = 5
        ' 
        ' MaskedTextBox1
        ' 
        MaskedTextBox1.Location = New Point(129, 32)
        MaskedTextBox1.Mask = "0000"
        MaskedTextBox1.Name = "MaskedTextBox1"
        MaskedTextBox1.Size = New Size(91, 23)
        MaskedTextBox1.TabIndex = 6
        ' 
        ' CSVupload
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(245, 111)
        Controls.Add(MaskedTextBox1)
        Controls.Add(ComboBox1)
        Controls.Add(uploadButton)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "CSVupload"
        Text = "Upload Csv"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents uploadButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
End Class

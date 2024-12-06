<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddOrEditWindow
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddOrEditWindow))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        SerialNumbertxtbx = New TextBox()
        Typetxtbx = New TextBox()
        Locationtxtbx = New TextBox()
        Savebtn = New Button()
        Brandtxtbx = New TextBox()
        net911txtbx = New TextBox()
        Warrantytxtbx = New TextBox()
        pdpicker = New DateTimePicker()
        PPtxtbx = New TextBox()
        Label8 = New Label()
        Importbtn = New Button()
        Panel1 = New Panel()
        Label10 = New Label()
        StatusComboBox = New ComboBox()
        Label9 = New Label()
        Button1 = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(16, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 21)
        Label1.TabIndex = 0
        Label1.Text = "Serial Number:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(16, 51)
        Label2.Name = "Label2"
        Label2.Size = New Size(45, 21)
        Label2.TabIndex = 1
        Label2.Text = "Type:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(16, 88)
        Label3.Name = "Label3"
        Label3.Size = New Size(121, 21)
        Label3.TabIndex = 2
        Label3.Text = "Date Purchased:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(306, 16)
        Label4.Name = "Label4"
        Label4.Size = New Size(54, 21)
        Label4.TabIndex = 3
        Label4.Text = "Brand:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(306, 53)
        Label5.Name = "Label5"
        Label5.Size = New Size(65, 21)
        Label5.TabIndex = 4
        Label5.Text = "Net911:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(306, 88)
        Label6.Name = "Label6"
        Label6.Size = New Size(77, 21)
        Label6.TabIndex = 5
        Label6.Text = "Warranty:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F)
        Label7.ForeColor = Color.Black
        Label7.Location = New Point(16, 158)
        Label7.Name = "Label7"
        Label7.Size = New Size(105, 21)
        Label7.TabIndex = 6
        Label7.Text = "Device Name:"
        ' 
        ' SerialNumbertxtbx
        ' 
        SerialNumbertxtbx.Font = New Font("Segoe UI", 12F)
        SerialNumbertxtbx.Location = New Point(151, 13)
        SerialNumbertxtbx.Name = "SerialNumbertxtbx"
        SerialNumbertxtbx.Size = New Size(149, 29)
        SerialNumbertxtbx.TabIndex = 7
        ' 
        ' Typetxtbx
        ' 
        Typetxtbx.Font = New Font("Segoe UI", 12F)
        Typetxtbx.Location = New Point(151, 48)
        Typetxtbx.Name = "Typetxtbx"
        Typetxtbx.Size = New Size(149, 29)
        Typetxtbx.TabIndex = 8
        ' 
        ' Locationtxtbx
        ' 
        Locationtxtbx.Font = New Font("Segoe UI", 12F)
        Locationtxtbx.Location = New Point(151, 155)
        Locationtxtbx.Name = "Locationtxtbx"
        Locationtxtbx.Size = New Size(149, 29)
        Locationtxtbx.TabIndex = 13
        ' 
        ' Savebtn
        ' 
        Savebtn.BackColor = Color.DarkRed
        Savebtn.Enabled = False
        Savebtn.FlatAppearance.BorderColor = Color.DimGray
        Savebtn.FlatStyle = FlatStyle.Flat
        Savebtn.Font = New Font("Segoe UI", 12F)
        Savebtn.ForeColor = Color.White
        Savebtn.Location = New Point(211, 244)
        Savebtn.Name = "Savebtn"
        Savebtn.Size = New Size(137, 40)
        Savebtn.TabIndex = 14
        Savebtn.Text = "ADD"
        Savebtn.UseVisualStyleBackColor = False
        ' 
        ' Brandtxtbx
        ' 
        Brandtxtbx.Font = New Font("Segoe UI", 12F)
        Brandtxtbx.Location = New Point(389, 13)
        Brandtxtbx.Name = "Brandtxtbx"
        Brandtxtbx.Size = New Size(149, 29)
        Brandtxtbx.TabIndex = 9
        ' 
        ' net911txtbx
        ' 
        net911txtbx.Font = New Font("Segoe UI", 12F)
        net911txtbx.Location = New Point(389, 50)
        net911txtbx.Name = "net911txtbx"
        net911txtbx.Size = New Size(149, 29)
        net911txtbx.TabIndex = 15
        ' 
        ' Warrantytxtbx
        ' 
        Warrantytxtbx.Font = New Font("Segoe UI", 12F)
        Warrantytxtbx.Location = New Point(389, 85)
        Warrantytxtbx.Name = "Warrantytxtbx"
        Warrantytxtbx.Size = New Size(149, 29)
        Warrantytxtbx.TabIndex = 16
        ' 
        ' pdpicker
        ' 
        pdpicker.Font = New Font("Segoe UI", 12F)
        pdpicker.Format = DateTimePickerFormat.Short
        pdpicker.Location = New Point(151, 85)
        pdpicker.Name = "pdpicker"
        pdpicker.Size = New Size(149, 29)
        pdpicker.TabIndex = 17
        ' 
        ' PPtxtbx
        ' 
        PPtxtbx.Font = New Font("Segoe UI", 12F)
        PPtxtbx.Location = New Point(151, 120)
        PPtxtbx.Name = "PPtxtbx"
        PPtxtbx.Size = New Size(149, 29)
        PPtxtbx.TabIndex = 18
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F)
        Label8.ForeColor = Color.Black
        Label8.Location = New Point(16, 123)
        Label8.Name = "Label8"
        Label8.Size = New Size(114, 21)
        Label8.TabIndex = 19
        Label8.Text = "Purchase Price:"
        ' 
        ' Importbtn
        ' 
        Importbtn.BackColor = Color.DarkRed
        Importbtn.FlatAppearance.BorderColor = Color.DimGray
        Importbtn.FlatStyle = FlatStyle.Flat
        Importbtn.Font = New Font("Segoe UI", 9F)
        Importbtn.ForeColor = Color.White
        Importbtn.Location = New Point(68, 244)
        Importbtn.Name = "Importbtn"
        Importbtn.Size = New Size(137, 40)
        Importbtn.TabIndex = 20
        Importbtn.Text = "Import from excel"
        Importbtn.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Silver
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(StatusComboBox)
        Panel1.Controls.Add(net911txtbx)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(PPtxtbx)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(pdpicker)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Warrantytxtbx)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Locationtxtbx)
        Panel1.Controls.Add(SerialNumbertxtbx)
        Panel1.Controls.Add(Brandtxtbx)
        Panel1.Controls.Add(Typetxtbx)
        Panel1.Location = New Point(11, 37)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(550, 201)
        Panel1.TabIndex = 21
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 12F)
        Label10.ForeColor = Color.Black
        Label10.Location = New Point(306, 123)
        Label10.Name = "Label10"
        Label10.Size = New Size(55, 21)
        Label10.TabIndex = 21
        Label10.Text = "Status:"
        ' 
        ' StatusComboBox
        ' 
        StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        StatusComboBox.Font = New Font("Segoe UI", 12F)
        StatusComboBox.FormattingEnabled = True
        StatusComboBox.Items.AddRange(New Object() {"Active", "Inactive"})
        StatusComboBox.Location = New Point(389, 120)
        StatusComboBox.Name = "StatusComboBox"
        StatusComboBox.Size = New Size(149, 29)
        StatusComboBox.TabIndex = 20
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Gainsboro
        Label9.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        Label9.ForeColor = Color.Black
        Label9.Location = New Point(11, 9)
        Label9.Name = "Label9"
        Label9.Size = New Size(139, 25)
        Label9.TabIndex = 22
        Label9.Text = "Device Details:"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DarkRed
        Button1.FlatAppearance.BorderColor = Color.DimGray
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 12F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(354, 244)
        Button1.Name = "Button1"
        Button1.Size = New Size(137, 40)
        Button1.TabIndex = 23
        Button1.Text = "Cancel"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' AddOrEditWindow
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gainsboro
        ClientSize = New Size(573, 298)
        Controls.Add(Button1)
        Controls.Add(Label9)
        Controls.Add(Panel1)
        Controls.Add(Importbtn)
        Controls.Add(Savebtn)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "AddOrEditWindow"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Add or Edit Device"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents SerialNumbertxtbx As TextBox
    Friend WithEvents Typetxtbx As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Locationtxtbx As TextBox
    Friend WithEvents Savebtn As Button
    Friend WithEvents Brandtxtbx As TextBox
    Friend WithEvents net911txtbx As TextBox
    Friend WithEvents Warrantytxtbx As TextBox
    Friend WithEvents pdpicker As DateTimePicker
    Friend WithEvents PPtxtbx As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Importbtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents StatusComboBox As ComboBox
End Class

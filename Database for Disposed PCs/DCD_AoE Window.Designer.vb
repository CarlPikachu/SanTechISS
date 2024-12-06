<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DCDAoEwindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DCDAoEwindow))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        cstdntxtbx = New TextBox()
        actionbtn = New Button()
        cancelbtn = New Button()
        datetxt = New DateTimePicker()
        Label5 = New Label()
        rbdisposed = New RadioButton()
        rbinstorage = New RadioButton()
        cntrlnumtxtbx = New TextBox()
        planttxtbx = New ComboBox()
        importbtn = New Button()
        Panel1 = New Panel()
        Label6 = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(8, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(127, 21)
        Label1.TabIndex = 0
        Label1.Text = "Control Number:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(8, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(48, 21)
        Label2.TabIndex = 1
        Label2.Text = "Plant:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(8, 85)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 21)
        Label3.TabIndex = 2
        Label3.Text = "Custodian:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.Location = New Point(11, 126)
        Label4.Name = "Label4"
        Label4.Size = New Size(45, 21)
        Label4.TabIndex = 3
        Label4.Text = "Date:"
        ' 
        ' cstdntxtbx
        ' 
        cstdntxtbx.Font = New Font("Segoe UI", 12F)
        cstdntxtbx.Location = New Point(141, 82)
        cstdntxtbx.Name = "cstdntxtbx"
        cstdntxtbx.Size = New Size(249, 29)
        cstdntxtbx.TabIndex = 6
        ' 
        ' actionbtn
        ' 
        actionbtn.BackColor = Color.DarkRed
        actionbtn.FlatAppearance.BorderColor = Color.DimGray
        actionbtn.FlatStyle = FlatStyle.Flat
        actionbtn.Font = New Font("Microsoft Sans Serif", 8.25F)
        actionbtn.ForeColor = Color.White
        actionbtn.Location = New Point(153, 243)
        actionbtn.Name = "actionbtn"
        actionbtn.Size = New Size(124, 40)
        actionbtn.TabIndex = 8
        actionbtn.Text = "Add"
        actionbtn.UseVisualStyleBackColor = False
        ' 
        ' cancelbtn
        ' 
        cancelbtn.BackColor = Color.DarkRed
        cancelbtn.FlatAppearance.BorderColor = Color.DimGray
        cancelbtn.FlatStyle = FlatStyle.Flat
        cancelbtn.Font = New Font("Microsoft Sans Serif", 8.25F)
        cancelbtn.ForeColor = Color.White
        cancelbtn.Location = New Point(283, 243)
        cancelbtn.Name = "cancelbtn"
        cancelbtn.Size = New Size(119, 40)
        cancelbtn.TabIndex = 9
        cancelbtn.Text = "Cancel"
        cancelbtn.UseVisualStyleBackColor = False
        ' 
        ' datetxt
        ' 
        datetxt.CustomFormat = "dd MMMM yyyy"
        datetxt.Font = New Font("Segoe UI", 12F)
        datetxt.Format = DateTimePickerFormat.Custom
        datetxt.Location = New Point(141, 120)
        datetxt.Name = "datetxt"
        datetxt.Size = New Size(249, 29)
        datetxt.TabIndex = 10
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.Location = New Point(11, 161)
        Label5.Name = "Label5"
        Label5.Size = New Size(55, 21)
        Label5.TabIndex = 12
        Label5.Text = "Status:"
        ' 
        ' rbdisposed
        ' 
        rbdisposed.AutoSize = True
        rbdisposed.Font = New Font("Segoe UI", 12F)
        rbdisposed.Location = New Point(141, 159)
        rbdisposed.Name = "rbdisposed"
        rbdisposed.Size = New Size(101, 25)
        rbdisposed.TabIndex = 13
        rbdisposed.TabStop = True
        rbdisposed.Text = "DISPOSED"
        rbdisposed.UseVisualStyleBackColor = True
        ' 
        ' rbinstorage
        ' 
        rbinstorage.AutoSize = True
        rbinstorage.Font = New Font("Segoe UI", 12F)
        rbinstorage.Location = New Point(271, 159)
        rbinstorage.Name = "rbinstorage"
        rbinstorage.Size = New Size(115, 25)
        rbinstorage.TabIndex = 14
        rbinstorage.TabStop = True
        rbinstorage.Text = "IN STORAGE"
        rbinstorage.UseVisualStyleBackColor = True
        ' 
        ' cntrlnumtxtbx
        ' 
        cntrlnumtxtbx.Font = New Font("Segoe UI", 12F)
        cntrlnumtxtbx.Location = New Point(141, 12)
        cntrlnumtxtbx.Name = "cntrlnumtxtbx"
        cntrlnumtxtbx.Size = New Size(249, 29)
        cntrlnumtxtbx.TabIndex = 4
        ' 
        ' planttxtbx
        ' 
        planttxtbx.Font = New Font("Segoe UI", 12F)
        planttxtbx.FormattingEnabled = True
        planttxtbx.Items.AddRange(New Object() {"ADM", "NX1", "NX2", "STA-A", "STA-P", "THERMAL"})
        planttxtbx.Location = New Point(141, 47)
        planttxtbx.Name = "planttxtbx"
        planttxtbx.Size = New Size(121, 29)
        planttxtbx.TabIndex = 15
        ' 
        ' importbtn
        ' 
        importbtn.BackColor = Color.DarkRed
        importbtn.FlatAppearance.BorderColor = Color.DimGray
        importbtn.FlatStyle = FlatStyle.Flat
        importbtn.Font = New Font("Microsoft Sans Serif", 8.25F)
        importbtn.ForeColor = Color.White
        importbtn.Location = New Point(23, 243)
        importbtn.Name = "importbtn"
        importbtn.Size = New Size(124, 40)
        importbtn.TabIndex = 16
        importbtn.Text = "Import excel"
        importbtn.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Silver
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(cntrlnumtxtbx)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(planttxtbx)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(rbinstorage)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(rbdisposed)
        Panel1.Controls.Add(cstdntxtbx)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(datetxt)
        Panel1.Location = New Point(12, 37)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(405, 200)
        Panel1.TabIndex = 17
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Gainsboro
        Label6.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(12, 9)
        Label6.Name = "Label6"
        Label6.Size = New Size(139, 25)
        Label6.TabIndex = 18
        Label6.Text = "Device Details:"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' DCDAoEwindow
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gainsboro
        ClientSize = New Size(428, 300)
        Controls.Add(Label6)
        Controls.Add(Panel1)
        Controls.Add(importbtn)
        Controls.Add(cancelbtn)
        Controls.Add(actionbtn)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "DCDAoEwindow"
        Text = "Add/Edit Disposed Computer"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cstdntxtbx As TextBox
    Friend WithEvents actionbtn As Button
    Friend WithEvents cancelbtn As Button
    Friend WithEvents datetxt As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents rbdisposed As RadioButton
    Friend WithEvents rbinstorage As RadioButton
    Friend WithEvents cntrlnumtxtbx As TextBox
    Private Sub cntrlnumtxtbx_TextChanged(sender As Object, e As EventArgs) Handles cntrlnumtxtbx.TextChanged
        ' Convert text to uppercase
        cntrlnumtxtbx.Text = cntrlnumtxtbx.Text.ToUpper()
        ' Move cursor to the end of the text
        cntrlnumtxtbx.SelectionStart = cntrlnumtxtbx.Text.Length
    End Sub
    Private Sub planttxtbx_TextChanged(sender As Object, e As EventArgs) Handles planttxtbx.TextChanged
        ' Convert text to uppercase
        planttxtbx.Text = planttxtbx.Text.ToUpper()
        ' Move cursor to the end of the text
        planttxtbx.SelectionStart = planttxtbx.Text.Length
    End Sub
    Private Sub cstdntxtbx_TextChanged(sender As Object, e As EventArgs) Handles cstdntxtbx.TextChanged
        ' Convert text to uppercase
        cstdntxtbx.Text = cstdntxtbx.Text.ToUpper()
        ' Move cursor to the end of the text
        cstdntxtbx.SelectionStart = cstdntxtbx.Text.Length
    End Sub
    Private Sub planttxtbx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles planttxtbx.KeyPress
        e.Handled = True
    End Sub

    Friend WithEvents planttxtbx As ComboBox
    Friend WithEvents importbtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loginform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        UsernameTextBox = New TextBox()
        PasswordTextBox = New TextBox()
        LoginButton = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
        Label3 = New Label()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' UsernameTextBox
        ' 
        UsernameTextBox.Font = New Font("Segoe UI", 16F)
        UsernameTextBox.Location = New Point(128, 5)
        UsernameTextBox.Name = "UsernameTextBox"
        UsernameTextBox.Size = New Size(196, 36)
        UsernameTextBox.TabIndex = 0
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Font = New Font("Segoe UI", 16F)
        PasswordTextBox.Location = New Point(128, 47)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.Size = New Size(196, 36)
        PasswordTextBox.TabIndex = 1
        ' 
        ' LoginButton
        ' 
        LoginButton.BackColor = Color.DarkRed
        LoginButton.FlatAppearance.BorderColor = Color.DimGray
        LoginButton.FlatStyle = FlatStyle.Flat
        LoginButton.Font = New Font("Segoe UI", 16F)
        LoginButton.ForeColor = Color.WhiteSmoke
        LoginButton.Location = New Point(128, 89)
        LoginButton.Name = "LoginButton"
        LoginButton.Size = New Size(90, 39)
        LoginButton.TabIndex = 2
        LoginButton.Text = "Login"
        LoginButton.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 16F)
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(3, 5)
        Label1.Name = "Label1"
        Label1.Size = New Size(116, 30)
        Label1.TabIndex = 3
        Label1.Text = "Username:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 16F)
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(11, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(108, 30)
        Label2.TabIndex = 4
        Label2.Text = "Password:"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSteelBlue
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(LoginButton)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(UsernameTextBox)
        Panel1.Controls.Add(PasswordTextBox)
        Panel1.Location = New Point(12, 72)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(351, 138)
        Panel1.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        Label3.ForeColor = Color.WhiteSmoke
        Label3.Location = New Point(68, 23)
        Label3.Name = "Label3"
        Label3.Size = New Size(290, 37)
        Label3.TabIndex = 6
        Label3.Text = "ISS DBMS Login Page"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources.login_icon_png_27
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(75, 72)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CornflowerBlue
        ClientSize = New Size(379, 224)
        Controls.Add(PictureBox1)
        Controls.Add(Label3)
        Controls.Add(Panel1)
        ForeColor = SystemColors.InactiveCaptionText
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ISS Database Management System"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents UsernameTextBox As TextBox
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class

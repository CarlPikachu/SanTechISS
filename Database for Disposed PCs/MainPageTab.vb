Public Class MainPageTab
    Private loggedInUsername As String

    ' Constructor to receive the username
    Public Sub New(username As String)
        InitializeComponent()
        loggedInUsername = username
        UpdateUsernameLabel()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create an instance of the DCD form
        Dim dcdForm As New DCD()
        InitializeForm(dcdForm, TabPage1)

        ' Create an instance of the RDB form
        Dim rdbForm As New RDB()
        InitializeForm(rdbForm, TabPage2)

        ' Create an instance of the ReportGen form
        Dim rptForm As New ReportGen()
        InitializeForm(rptForm, TabPage3)
    End Sub

    Private Sub InitializeForm(form As Form, tabPage As TabPage)
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        tabPage.Controls.Add(form)
        form.Show()
        UpdateDarkMode(form)
    End Sub

    Private Sub UpdateUsernameLabel()
        LabelUsername.Text = loggedInUsername
    End Sub

    Private Sub dmtrigger_CheckedChanged(sender As Object, e As EventArgs) Handles dmtrigger.CheckedChanged
        UpdateFormColors()
        UpdateExistingForms()
    End Sub

    Private Sub UpdateFormColors()
        Dim baseColor2 As Color = If(dmtrigger.Checked, Color.FromArgb(90, 90, 90), Color.AliceBlue)
        Dim fontColor As Color = If(dmtrigger.Checked, Color.White, Color.Black)

        ' Update tab colors based on dark mode
        TabPage1.BackColor = baseColor2
        TabPage2.BackColor = baseColor2
        TabPage3.BackColor = baseColor2
        LabelUsername.ForeColor = fontColor
        dmtrigger.ForeColor = fontColor
        Me.BackColor = baseColor2
    End Sub

    Private Sub UpdateExistingForms()
        For Each tabPage As TabPage In Me.TabControl1.TabPages
            For Each form As Form In tabPage.Controls
                If Not form.IsDisposed Then
                    UpdateDarkMode(form)
                End If
            Next
        Next
    End Sub


    Private Sub UpdateDarkMode(form As Form)
        If TypeOf form Is DCD Then
            CType(form, DCD).DarkModeEnabled = dmtrigger.Checked
        ElseIf TypeOf form Is RDB Then
            CType(form, RDB).DarkModeEnabled = dmtrigger.Checked
        ElseIf TypeOf form Is ReportGen Then
            CType(form, ReportGen).DarkModeEnabled = dmtrigger.Checked
        End If
    End Sub

End Class

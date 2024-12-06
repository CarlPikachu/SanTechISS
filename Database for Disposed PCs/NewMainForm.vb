Public Class NewMainForm
    Private loggedInUsername As String
    Private currentForm As Form
    Private allForms As New Dictionary(Of String, Form)()

    Public Sub New(username As String)
        InitializeComponent()
        loggedInUsername = username
        UpdateUsernameLabel()
    End Sub

    Private Sub MainPageTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllForms()
        ShowForm("DCD")
    End Sub

    Private Sub DCDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DCDToolStripMenuItem.Click
        ShowForm("DCD")
    End Sub

    Private Sub RDBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RDBToolStripMenuItem.Click
        ShowForm("RDB")
    End Sub

    Private Sub UploadCsvToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadCsvToolStripMenuItem.Click
        Dim csvUploadForm As New CSVupload()
        csvUploadForm.DarkModeEnabled = dmtrigger.Checked
        csvUploadForm.Show()
    End Sub

    Private Sub PrintReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintReportToolStripMenuItem.Click
        ShowForm("ReportGen")
    End Sub

    Private Sub LoadAllForms()
        allForms("DCD") = New DCD()
        allForms("RDB") = New RDB()
        allForms("ReportGen") = New ReportGen()

        For Each form As Form In allForms.Values
            form.TopLevel = False
            form.FormBorderStyle = FormBorderStyle.None
            form.Dock = DockStyle.Fill
            PanelMain.Controls.Add(form)
            form.Hide()
        Next
    End Sub

    Private Sub ShowForm(formName As String)
        If currentForm IsNot Nothing Then
            currentForm.Hide()
        End If

        Dim formToShow As Form = allForms(formName)
        formToShow.Show()
        currentForm = formToShow
        UpdateDarkMode(formToShow)
    End Sub

    Private Sub UpdateUsernameLabel()
        LabelUsername.Text = loggedInUsername
    End Sub

    Private Sub dmtrigger_CheckedChanged(sender As Object, e As EventArgs) Handles dmtrigger.CheckedChanged
        ' Call to update dark mode appearance without closing or reloading the form
        UpdateFormColors()
        UpdateExistingForms()
    End Sub

    Private Sub UpdateFormColors()
        ' Update the appearance of the main form and other child forms based on dark mode toggle
        Dim baseColor2 As Color = If(dmtrigger.Checked, Color.FromArgb(90, 90, 90), Color.AliceBlue)
        Dim fontColor As Color = If(dmtrigger.Checked, Color.White, Color.Black)
        Dim btnColor As Color = If(dmtrigger.Checked, Color.FromArgb(10, 10, 10), Color.DarkRed)
        Dim baseColor As Color = If(dmtrigger.Checked, Color.FromArgb(50, 50, 50), Color.LightSteelBlue)

        ' Update main form's controls (PanelMain, LabelUsername, etc.)
        PanelMain.BackColor = baseColor2
        LabelUsername.ForeColor = fontColor
        dmtrigger.ForeColor = fontColor
        Me.BackColor = baseColor2
        MenuStrip1.BackColor = baseColor
        LabelUsername.BackColor = baseColor
        dmtrigger.BackColor = baseColor
        TableLayoutPanel1.BackColor = baseColor
        MenuStrip1.ForeColor = fontColor
        PrintReportToolStripMenuItem.BackColor = baseColor
        PrintReportToolStripMenuItem.ForeColor = fontColor
        UploadCsvToolStripMenuItem.BackColor = baseColor
        UploadCsvToolStripMenuItem.ForeColor = fontColor
    End Sub

    Private Sub UpdateExistingForms()
        ' Apply the dark mode settings to all the currently loaded forms
        If currentForm IsNot Nothing AndAlso Not currentForm.IsDisposed Then
            UpdateDarkMode(currentForm)
        End If

        ' Apply dark mode to all other forms as well
        For Each form As Form In allForms.Values
            If form IsNot currentForm Then
                UpdateDarkMode(form)
            End If
        Next
    End Sub

    Private Sub UpdateDarkMode(form As Form)
        ' Set the dark mode for individual forms
        If TypeOf form Is DCD Then
            CType(form, DCD).DarkModeEnabled = dmtrigger.Checked
        ElseIf TypeOf form Is RDB Then
            CType(form, RDB).DarkModeEnabled = dmtrigger.Checked
        ElseIf TypeOf form Is ReportGen Then
            CType(form, ReportGen).DarkModeEnabled = dmtrigger.Checked
        ElseIf TypeOf form Is CSVupload Then
            CType(form, CSVupload).DarkModeEnabled = dmtrigger.Checked
        End If
    End Sub
End Class

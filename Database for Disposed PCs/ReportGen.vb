Imports System.IO
Imports FastReport
Imports FastReport.Export.PdfSimple
Imports Microsoft.VisualBasic.FileIO
Imports System.Data

Public Class ReportGen

    Private WithEvents fileWatcher As FileSystemWatcher

    Private Sub ReportGen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFileWatcher()
        PopulateComboBoxWithFiles()
    End Sub

    Private Sub InitializeFileWatcher()
        Dim folderPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSV DATA")
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        fileWatcher = New FileSystemWatcher(folderPath)
        fileWatcher.NotifyFilter = NotifyFilters.FileName Or NotifyFilters.LastWrite Or NotifyFilters.Size
        fileWatcher.Filter = "*.csv"
        fileWatcher.EnableRaisingEvents = True
    End Sub

    Private Sub fileWatcher_Changed(sender As Object, e As FileSystemEventArgs) Handles fileWatcher.Changed, fileWatcher.Created, fileWatcher.Deleted, fileWatcher.Renamed
        PopulateComboBoxWithFiles()
    End Sub

    Private Sub PopulateComboBoxWithFiles()
        Dim folderPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSV DATA")

        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        ComboBoxCSVFiles.Items.Clear()

        Dim csvFiles As String() = Directory.GetFiles(folderPath, "*.csv")

        For Each filePath As String In csvFiles
            ' Get the file name without the extension
            Dim fileNameWithoutExtension As String = Path.GetFileNameWithoutExtension(filePath)
            ComboBoxCSVFiles.Items.Add(fileNameWithoutExtension)
        Next

        If ComboBoxCSVFiles.Items.Count > 0 Then
            ComboBoxCSVFiles.SelectedIndex = 0
        End If
    End Sub


    Private Sub editDocnum(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        TextBox1.Enabled = CheckBox1.Checked
        TextBox2.Enabled = CheckBox1.Checked
        TextBox3.Enabled = CheckBox1.Checked
    End Sub

    Private Sub btnExportReport_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Try
            If ComboBoxReport.SelectedIndex = -1 Then
                MessageBox.Show("Please select a report first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If ComboBoxPlants.SelectedIndex = -1 Then
                MessageBox.Show("Please select a plant first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If ComboBoxCSVFiles.SelectedIndex = -1 Then
                MessageBox.Show("Please select a CSV file first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedPlant As String = ComboBoxPlants.SelectedItem.ToString()
            Dim selectedReport As String = ComboBoxReport.SelectedItem.ToString()

            ' Set the report path based on the selected report
            Dim reportPath As String = String.Empty
            If selectedReport = "INVENTORY MASTERLIST" Then
                reportPath = Path.Combine(Application.StartupPath, "Reports\HRCLIST.frx")
            ElseIf selectedReport = "PM" Then
                reportPath = Path.Combine(Application.StartupPath, "Reports\PM.frx")
            ElseIf selectedReport = "HRC" Then
                reportPath = Path.Combine(Application.StartupPath, "Reports\HRC PER PC.frx")
            End If

            ' Get the selected CSV file name and append ".csv" extension
            Dim selectedCsvFile As String = ComboBoxCSVFiles.SelectedItem.ToString()
            Dim csvFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSV DATA", selectedCsvFile & ".csv")

            ' Ensure the file exists before proceeding
            If Not File.Exists(csvFilePath) Then
                MessageBox.Show("The selected CSV file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Using report As New Report()
                ' Load the CSV data into a DataTable
                Dim CSVData As DataTable = LoadCsv(csvFilePath)
                Dim filteredData As DataTable = FilterDataByPlant(CSVData, selectedPlant)

                report.RegisterData(filteredData, "DATACSV")
                report.Load(reportPath)

                ' Check if CheckBox1 is checked and update the report fields
                If CheckBox1.Checked Then
                    Dim textField1 As TextObject = CType(report.FindObject("Cell2"), TextObject)
                    Dim textField2 As TextObject = CType(report.FindObject("Cell4"), TextObject)
                    Dim textField3 As TextObject = CType(report.FindObject("Text5"), TextObject)

                    If textField1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(TextBox1.Text) Then
                        textField1.Text = TextBox1.Text
                    End If

                    If textField2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(TextBox2.Text) Then
                        textField2.Text = TextBox2.Text
                    End If

                    If textField3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(TextBox3.Text) Then
                        textField3.Text = TextBox3.Text
                    End If
                End If

                report.Prepare()
                ExportToPdf(report)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub ExportToPdf(report As Report)
        Try
            Using saveFileDialog As New SaveFileDialog()
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf"
                saveFileDialog.Title = "Save Report as PDF"

                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    Using pdfExport As New PDFSimpleExport()
                        pdfExport.Export(report, saveFileDialog.FileName)
                    End Using
                    MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error exporting report to PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function LoadCsv(filePath As String) As DataTable
        Dim dataTable As New DataTable()

        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(","c)
            parser.HasFieldsEnclosedInQuotes = True

            If Not parser.EndOfData Then
                Dim headers = parser.ReadFields()
                For Each header In headers
                    dataTable.Columns.Add(header.Trim())
                Next
            End If

            While Not parser.EndOfData
                Dim rows = parser.ReadFields()
                dataTable.Rows.Add(rows)
            End While
        End Using

        Return dataTable
    End Function

    Private Function FilterDataByPlant(dataTable As DataTable, selectedPlant As String) As DataTable
        Dim filteredDataTable As DataTable = dataTable.Clone()

        For Each row As DataRow In dataTable.Rows
            If row("12_部門OAリーダ/Department OA Leader/资产负责人ID").ToString() = selectedPlant Then
                filteredDataTable.ImportRow(row)
            End If
        Next

        Return filteredDataTable
    End Function

    Private _darkModeEnabled As Boolean

    Private Sub myButton_Paint(sender As Object, e As PaintEventArgs) Handles btnUpload.Paint
        Dim button As Button = DirectCast(sender, Button)

        ' Return if the button is enabled
        If button.Enabled Then Return

        ' Determine background color and font color based on dark mode
        Dim backgrounddisColor As Color = If(DarkModeEnabled, Color.DimGray, Color.LightCoral)

        ' Draw the background
        e.Graphics.FillRectangle(New SolidBrush(backgrounddisColor), e.ClipRectangle)

        ' Wrap and measure text
        Dim textLines As String() = WrapText(button.Text, button.Font, button.Width)
        Dim totalHeight As Single = textLines.Sum(Function(line) e.Graphics.MeasureString(line, button.Font).Height)

        ' Draw centered text
        Dim currentY As Single = (button.Height - totalHeight) / 2
        For Each line As String In textLines
            Dim textSize As SizeF = e.Graphics.MeasureString(line, button.Font)
            Dim textX As Single = (button.Width - textSize.Width) / 2
            e.Graphics.DrawString(line, button.Font, Brushes.DarkGray, New PointF(textX, currentY))
            currentY += textSize.Height
        Next
    End Sub

    Private Function WrapText(text As String, font As Font, maxWidth As Integer) As String()
        Dim lines As New List(Of String)
        Dim currentLine As String = ""

        For Each word As String In text.Split(" "c)
            Dim testLine As String = If(String.IsNullOrEmpty(currentLine), word, $"{currentLine} {word}")
            If TextRenderer.MeasureText(testLine, font).Width > maxWidth Then
                If Not String.IsNullOrEmpty(currentLine) Then lines.Add(currentLine)
                currentLine = word
            Else
                currentLine = testLine
            End If
        Next

        If Not String.IsNullOrEmpty(currentLine) Then lines.Add(currentLine)
        Return lines.ToArray()
    End Function

    Public Property DarkModeEnabled As Boolean
        Get
            Return _darkModeEnabled
        End Get
        Set(value As Boolean)
            _darkModeEnabled = value
            UpdateFormColors()
        End Set
    End Property

    Public Sub UpdateFormColors()
        Dim btnColor As Color = If(DarkModeEnabled, Color.FromArgb(10, 10, 10), Color.DarkRed)
        Dim baseColor As Color = If(DarkModeEnabled, Color.FromArgb(50, 50, 50), Color.LightSteelBlue)
        Dim baseColor2 As Color = If(DarkModeEnabled, Color.FromArgb(100, 100, 100), Color.AliceBlue)
        Dim cellColor As Color = If(DarkModeEnabled, Color.FromArgb(80, 80, 80), Color.MistyRose)
        Dim fontColor As Color = If(DarkModeEnabled, Color.White, Color.Black)

        btnUpload.BackColor = btnColor

        Dim labels As Control() = {Label1, Label2, Label3, Label4, Label5, GroupBox2}
        For Each lbl As Control In labels
            lbl.BackColor = baseColor
            lbl.ForeColor = fontColor
        Next

        Me.BackColor = baseColor2
    End Sub

End Class

Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class DCD
    Private connectionString As String = "server=localhost;user id=root;password=;database=disposedcomputers"

    Private dataTable As New DataTable()
    Private WithEvents addForm As DCDAoEwindow

    ' Load event for the main form
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "MM yyyy"
        DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 12)
        Me.FormBorderStyle = FormBorderStyle.None
        LoadData()
    End Sub

    ' Function to get the total record count
    Private Function GetTotalRecordCount() As Integer
        Dim query As String = "SELECT COUNT(*) FROM disposed WHERE 1 = 1"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    Return Convert.ToInt32(command.ExecuteScalar())
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                    Return 0
                End Try
            End Using
        End Using
    End Function

    ' Function to load data into DataGridView
    Private Sub LoadData()
        Dim query As String = "SELECT * FROM disposed WHERE 1 = 1"

        ' Search filter
        Dim search As String = " AND (ControlNumber LIKE @search OR Custodian LIKE @search)"
        query &= search

        ' Total record count
        Dim totalCount As Integer = GetTotalRecordCount()
        totalLabel.Text = "Total Number of Disposed Computers: " & totalCount.ToString()

        ' Plant filters
        Dim selectedPlants As New List(Of String)()
        AddSelectedPlant(selectedPlants, fltradm, "ADM")
        AddSelectedPlant(selectedPlants, fltrnx1, "NX1")
        AddSelectedPlant(selectedPlants, fltrnx2, "NX2")
        AddSelectedPlant(selectedPlants, fltrsta, "STA-A")
        AddSelectedPlant(selectedPlants, fltrstp, "STA-P")
        AddSelectedPlant(selectedPlants, fltrtrml, "THERMAL")

        If selectedPlants.Count > 0 Then
            query &= " AND Plant IN ('" & String.Join("','", selectedPlants) & "')"
        End If

        ' Status filters
        Dim selectedStatus As New List(Of String)()
        AddSelectedStatus(selectedStatus, fltrdisposed, "DISPOSED")
        AddSelectedStatus(selectedStatus, fltrinstorage, "IN STORAGE")

        If selectedStatus.Count > 0 Then
            query &= " AND Status IN ('" & String.Join("','", selectedStatus) & "')"
        End If

        ' Device filters
        Dim selectedDevice As New List(Of String)()
        AddSelectedDevice(selectedDevice, fltrdp, "-D")
        AddSelectedDevice(selectedDevice, fltrlp, "-L")
        AddSelectedDevice(selectedDevice, fltrtc, "-T")
        AddSelectedDevice(selectedDevice, fltrncn, "NO CONTROL")
        AddSelectedDevice(selectedDevice, fltrmpc, "MACHINE PC")

        If selectedDevice.Count > 0 Then
            Dim deviceQuery As String = String.Join(" OR ", selectedDevice.Select(Function(device) "ControlNumber LIKE '%" & device & "%'"))
            query &= " AND (" & deviceQuery & ")"
        End If

        ' Date filter
        If chkFilterByDate.Checked Then
            Dim selectedDate As Date = DateTimePicker1.Value
            Dim startDate As Date = New Date(selectedDate.Year, selectedDate.Month, 1)
            Dim endDate As Date = startDate.AddMonths(1).AddDays(-1)
            query &= " AND (Date >= @startDate AND Date <= @endDate)"
        End If

        ' Load data into DataGridView
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    dataTable.Clear()
                    Dim adapter As New MySqlDataAdapter(command)
                    adapter.SelectCommand.Parameters.AddWithValue("@search", "%" & srchtxtbx.Text & "%")
                    If chkFilterByDate.Checked Then
                        adapter.SelectCommand.Parameters.AddWithValue("@startDate", New Date(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, 1))
                        adapter.SelectCommand.Parameters.AddWithValue("@endDate", New Date(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, 1).AddMonths(1).AddDays(-1))
                    End If
                    adapter.Fill(dataTable)
                    DataGridView1.DataSource = dataTable
                    DataGridView1.Columns("id").Visible = False
                    FilterResultCountLabel.Text = "Filtered Total: " & DataGridView1.Rows.Count

                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
        DataGridView1.Columns(1).Width = "140"

        ' Set all other columns to fill the remaining space
        For Each column As DataGridViewColumn In DataGridView1.Columns
            If column.Index <> 1 Then
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        Next
    End Sub

    ' Helper methods to add selected filters
    Private Sub AddSelectedPlant(selectedPlants As List(Of String), checkBox As CheckBox, plant As String)
        If checkBox.Checked Then
            selectedPlants.Add(plant)
        End If
    End Sub

    Private Sub AddSelectedStatus(selectedStatus As List(Of String), checkBox As CheckBox, status As String)
        If checkBox.Checked Then
            selectedStatus.Add(status)
        End If
    End Sub

    Private Sub AddSelectedDevice(selectedDevice As List(Of String), checkBox As CheckBox, device As String)
        If checkBox.Checked Then
            selectedDevice.Add(device)
        End If
    End Sub

    ' Event handler for filter checkboxes and search text
    Private Sub FilterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles fltradm.CheckedChanged, fltrnx1.CheckedChanged, fltrnx2.CheckedChanged, fltrsta.CheckedChanged, fltrstp.CheckedChanged, fltrtrml.CheckedChanged, fltrdisposed.CheckedChanged, fltrinstorage.CheckedChanged, fltrdp.CheckedChanged, fltrlp.CheckedChanged, fltrtc.CheckedChanged, fltrncn.CheckedChanged, fltrmpc.CheckedChanged, srchtxtbx.TextChanged, DateTimePicker1.ValueChanged
        LoadData()
    End Sub

    ' Event handler for date filter checkbox
    Private Sub chkFilterByDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkFilterByDate.CheckedChanged
        LoadData()
        DateTimePicker1.Enabled = chkFilterByDate.Checked
    End Sub

    ' Event handler for DataGridView cell click
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        EnableButtons()
    End Sub

    ' Enable action buttons
    Private Sub EnableButtons()
        dltbtn.Enabled = True
        stsbtn.Enabled = True
        editbtn.Enabled = True
    End Sub

    ' Event handler for AddForm data added event
    Private Sub AddForm_DataAdded(sender As Object, e As EventArgs)
        LoadData()
    End Sub

    ' Event handler for Add button click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenAoEWindow("Add")
    End Sub

    ' Event handler for Edit button click
    Private Sub editbtn_Click(sender As Object, e As EventArgs) Handles editbtn.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim id As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)
            Dim controlNumber As String = selectedRow.Cells("ControlNumber").Value.ToString()
            Dim plant As String = selectedRow.Cells("Plant").Value.ToString()
            Dim custodian As String = selectedRow.Cells("Custodian").Value.ToString()
            Dim [date] As Date = Convert.ToDateTime(selectedRow.Cells("Date").Value)
            Dim status As String = selectedRow.Cells("Status").Value.ToString()

            OpenAoEWindow("Save", id, controlNumber, plant, custodian, [date], status)
        Else
            MessageBox.Show("Please select a row to edit.")
        End If
    End Sub

    ' Open Add/Edit window
    Private Sub OpenAoEWindow(ByVal actionText As String,
                             Optional ByVal id As Integer = 0,
                             Optional ByVal controlNumber As String = "",
                             Optional ByVal plant As String = "",
                             Optional ByVal custodian As String = "",
                             Optional ByVal [date] As Date = Nothing,
                             Optional ByVal status As String = "")

        Dim addForm As New DCDAoEwindow(id, controlNumber, plant, custodian, [date], status, actionText)
        AddHandler addForm.DataAdded, AddressOf AddForm_DataAdded
        addForm.DarkModeEnabled = _darkModeEnabled
        addForm.Show()
    End Sub

    ' Event handler for Delete button click
    Private Sub dltbtn_Click(sender As Object, e As EventArgs) Handles dltbtn.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
                Dim idToDelete As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)
                Using connection As New MySqlConnection(connectionString)
                    Using command As New MySqlCommand("DELETE FROM disposed WHERE id = @id", connection)
                        command.Parameters.AddWithValue("@id", idToDelete)
                        Try
                            connection.Open()
                            command.ExecuteNonQuery()
                            DataGridView1.Rows.Remove(selectedRow)
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Using
                End Using
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
        LoadData()
    End Sub

    ' Event handler for Status button click
    Private Sub stsbtn_Click(sender As Object, e As EventArgs) Handles stsbtn.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim newStatus As String = "DISPOSED" ' Set new status directly to "DISPOSED"

            For Each selectedRow As DataGridViewRow In DataGridView1.SelectedRows
                Using connection As New MySqlConnection(connectionString)
                    Using command As New MySqlCommand("UPDATE disposed SET status = @status WHERE id = @id", connection)
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(selectedRow.Cells("id").Value))
                        command.Parameters.AddWithValue("@status", newStatus)
                        Try
                            connection.Open()
                            command.ExecuteNonQuery()
                            selectedRow.Cells("status").Value = newStatus ' Update the cell value in the DataGridView
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Using
                End Using
            Next

            MessageBox.Show("Status of selected records successfully changed to 'DISPOSED'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select one or more rows to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    ' Event handler for Backup button click
    Private Sub backupbtn(sender As Object, e As EventArgs) Handles bckpbtn.Click
        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel File (*.xlsx)|*.xlsx"
            saveFileDialog.Title = "Save Database Backup"
            saveFileDialog.FileName = "disposed_computers_backup_" & DateTime.Now.ToString("yyyyMMdd")

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = saveFileDialog.FileName

                If filePath.EndsWith(".xlsx") Then
                    ExportToExcel(filePath)
                Else
                    MessageBox.Show("Unsupported file format.")
                End If
            End If
        End Using
    End Sub

    ' Function to export data to Excel
    ' Function to export filtered data from DataGridView to Excel
    Private Sub ExportToExcel(filePath As String)
        Try
            Dim workbook As New XLWorkbook()
            Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Disposed Computers")

            ' Export column headers
            For i As Integer = 0 To DataGridView1.Columns.Count - 1
                worksheet.Cell(1, i + 1).Value = DataGridView1.Columns(i).HeaderText
            Next

            ' Export data rows
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                For j As Integer = 0 To DataGridView1.Columns.Count - 1
                    worksheet.Cell(i + 2, j + 1).Value = DataGridView1.Rows(i).Cells(j).Value?.ToString() ' Use ?.ToString to handle potential null values
                Next
            Next

            ' Save the Excel file
            workbook.SaveAs(filePath)
            MessageBox.Show("Filtered data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub


    ' Property and method for dark mode support
    Private _darkModeEnabled As Boolean

    Private Sub myButton_Paint(sender As Object, e As PaintEventArgs) Handles editbtn.Paint, bckpbtn.Paint, stsbtn.Paint, dltbtn.Paint
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
        Dim basecolor3 As Color = If(DarkModeEnabled, Color.FromArgb(45, 45, 45), Color.Lavender)
        Dim cellColor As Color = If(DarkModeEnabled, Color.FromArgb(80, 80, 80), Color.MistyRose)
        Dim cellColor2 As Color = If(DarkModeEnabled, Color.FromArgb(80, 80, 80), Color.MistyRose)
        Dim hlightcolor As Color = If(DarkModeEnabled, Color.FromArgb(35, 35, 35), Color.Firebrick)
        Dim fontColor As Color = If(DarkModeEnabled, Color.White, Color.Black)
        Dim noteColor As Color = If(DarkModeEnabled, Color.White, Color.DarkRed)
        Dim panelcolor As Color = If(DarkModeEnabled, Color.FromArgb(45, 45, 45), Color.FromArgb(220, 220, 250))


        ' Buttons
        Dim buttons As Control() = {Button1, editbtn, stsbtn, dltbtn, bckpbtn}
        For Each btn As Control In buttons
            btn.BackColor = btnColor
        Next

        ' DataGridView
        DataGridView1.DefaultCellStyle.BackColor = cellColor
        DataGridView1.DefaultCellStyle.ForeColor = fontColor
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = cellColor2
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = btnColor
        DataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = btnColor
        DataGridView1.RowsDefaultCellStyle.SelectionBackColor = hlightcolor
        Panel1.BackColor = basecolor3

        ' Other Controls
        Dim labels As Control() = {mm, fltrdp, fltrlp, fltrtc, fltrncn, fltrmpc, fltradm, fltrnx1, fltrnx2,
                                   fltrsta, fltrstp, fltrtrml, fltrdisposed, fltrinstorage, Label1, Label2,
                                   Label3, Label4, Label5}
        For Each lbl As Control In labels
            lbl.BackColor = baseColor
            lbl.ForeColor = fontColor
        Next

        totalLabel.BackColor = baseColor2
        totalLabel.ForeColor = fontColor
        Me.BackColor = baseColor2
    End Sub

End Class

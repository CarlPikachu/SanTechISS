Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class DCDAoEwindow
    Private ReadOnly _id As Integer
    Private ReadOnly _actionText As String
    Private ReadOnly connectionString As String = "server=localhost;user id=root;password=;database=disposedcomputers"

    Public Sub New(ByVal id As Integer,
                   ByVal controlNumber As String,
                   ByVal plant As String,
                   ByVal custodian As String,
                   ByVal [date] As Date,
                   ByVal status As String,
                   ByVal actionText As String)

        InitializeComponent()

        _id = id
        _actionText = actionText

        cntrlnumtxtbx.Text = controlNumber
        planttxtbx.Text = plant
        cstdntxtbx.Text = custodian
        datetxt.Value = If([date] <> DateTime.MinValue, [date], DateTime.Today)

        If status = "DISPOSED" Then
            rbdisposed.Checked = True
        Else
            rbinstorage.Checked = True
        End If

        actionbtn.Text = _actionText
    End Sub

    Private Sub DCDAoEwindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If actionbtn.Text = "Save" Then
            cntrlnumtxtbx.Enabled = False
            importbtn.Enabled = False
        End If

        AddHandler cntrlnumtxtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler planttxtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler cstdntxtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler datetxt.ValueChanged, AddressOf CheckAllFieldsFilled

        ' Initial check to disable the button if fields are empty at the start
        CheckAllFieldsFilled()
    End Sub

    ' Method to check if all required fields are filled
    Private Sub CheckAllFieldsFilled()
        ' Disable the action button if any of the fields are empty
        If String.IsNullOrWhiteSpace(cntrlnumtxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(planttxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(cstdntxtbx.Text) OrElse
           datetxt.Value = DateTime.MinValue Then

            actionbtn.Enabled = False
        Else
            actionbtn.Enabled = True
        End If
    End Sub

    Private Sub actionbtn_Click(sender As Object, e As EventArgs) Handles actionbtn.Click
        If ValidateInputs() Then
            Select Case actionbtn.Text
                Case "Add"
                    AddData()
                Case "Save"
                    UpdateData()
                Case Else
                    MessageBox.Show("Invalid action.")
            End Select
        End If
    End Sub

    Private Sub AddData()
        Dim controlNumber = cntrlnumtxtbx.Text
        Dim plant = planttxtbx.Text
        Dim custodian = cstdntxtbx.Text
        Dim [date] = datetxt.Value
        Dim status = If(rbdisposed.Checked, "DISPOSED", "IN STORAGE")

        If controlNumber = "MACHINE PC" OrElse controlNumber = "NO CONTROL NO." Then
            InsertData(controlNumber, plant, custodian, [date], status)
        Else
            If IsControlNumberDuplicate(controlNumber) Then
                MessageBox.Show("A record with this ControlNumber already exists. Please use a different ControlNumber.")
            Else
                InsertData(controlNumber, plant, custodian, [date], status)
            End If
        End If
    End Sub

    Private Sub InsertData(controlNumber As String, plant As String, custodian As String, [date] As Date, status As String)
        Dim insertQuery As String = "INSERT INTO disposed (ControlNumber, Plant, Custodian, Date, Status) VALUES (@ControlNumber, @Plant, @Custodian, @Date, @Status)"

        ExecuteNonQuery(insertQuery, New MySqlParameter() {
            New MySqlParameter("@ControlNumber", controlNumber),
            New MySqlParameter("@Plant", plant),
            New MySqlParameter("@Custodian", custodian),
            New MySqlParameter("@Date", [date]),
            New MySqlParameter("@Status", status)
        })
    End Sub

    Private Sub UpdateData()
        Dim controlNumber = cntrlnumtxtbx.Text
        Dim plant = planttxtbx.Text
        Dim custodian = cstdntxtbx.Text
        Dim [date] = datetxt.Value
        Dim status = If(rbdisposed.Checked, "DISPOSED", "IN STORAGE")

        Dim query = "UPDATE disposed SET Plant = @Plant, Custodian = @Custodian, Date = @Date, Status = @Status WHERE id = @id"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@Plant", plant),
            New MySqlParameter("@Custodian", custodian),
            New MySqlParameter("@Date", [date]),
            New MySqlParameter("@Status", status),
            New MySqlParameter("@id", _id)
        }

        ExecuteNonQuery(query, parameters)
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(cntrlnumtxtbx.Text) Then
            MessageBox.Show("Control number cannot be empty.")
            Return False
        End If

        Dim dateValue As Date = datetxt.Value
        If dateValue = DateTime.MinValue Then
            MessageBox.Show("Please enter a valid date.")
            Return False
        End If

        Return True
    End Function

    Private Sub ExecuteNonQuery(query As String, parameters As MySqlParameter())
        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddRange(parameters)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Operation completed successfully.")
            Close()
            RaiseEvent DataAdded(Me, EventArgs.Empty)
        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Function IsControlNumberDuplicate(controlNumber As String) As Boolean
        Dim checkQuery As String = "SELECT COUNT(*) FROM disposed WHERE ControlNumber = @ControlNumber"
        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Using command As New MySqlCommand(checkQuery, connection)
                command.Parameters.AddWithValue("@ControlNumber", controlNumber)
                Return Convert.ToInt32(command.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

    Private Sub ImportFromExcel(filePath As String)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Using workbook As New XLWorkbook(filePath)
                    Dim worksheet As IXLWorksheet = workbook.Worksheet(1)

                    For Each row As IXLRow In worksheet.RowsUsed().Skip(1)
                        Dim controlNumber As String = row.Cell(2).Value.ToString()
                        Dim plant As String = row.Cell(3).Value.ToString()
                        Dim custodian As String = row.Cell(4).Value.ToString()
                        Dim dateValue As String = row.Cell(5).Value.ToString()
                        Dim status As String = If(row.Cell(6).Value.ToString().ToUpper() = "DISPOSED", "DISPOSED", "IN STORAGE")

                        If Not (controlNumber = "MACHINE PC" OrElse controlNumber = "NO CONTROL NO.") AndAlso IsControlNumberDuplicate(controlNumber) Then
                            MessageBox.Show($"Control number '{controlNumber}' already exists. Skipping this record.")
                            Continue For
                        End If

                        Dim dateParsed As DateTime
                        If Not DateTime.TryParse(dateValue, dateParsed) Then
                            MessageBox.Show($"Invalid date format: {dateValue}. Skipping this record.")
                            Continue For
                        End If

                        InsertData(controlNumber, plant, custodian, dateParsed, status)
                    Next
                End Using
            End Using

            MessageBox.Show("Import completed successfully.")
        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub importbtn_Click(sender As Object, e As EventArgs) Handles importbtn.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"
            openFileDialog.Title = "Select an Excel File"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ImportFromExcel(openFileDialog.FileName)
            End If
        End Using
    End Sub

    Private Sub cancelbtn_Click(sender As Object, e As EventArgs) Handles cancelbtn.Click
        Close()
    End Sub

    Public Event DataAdded As EventHandler

    Private Sub myButton_Paint(sender As Object, e As PaintEventArgs) Handles actionbtn.Paint, cancelbtn.Paint, importbtn.Paint
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

    Private _darkModeEnabled As Boolean
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
        Dim btnColor As Color = If(DarkModeEnabled, Color.Black, Color.DarkRed)
        Dim baseColor As Color = If(DarkModeEnabled, Color.FromArgb(50, 50, 50), Color.LightSteelBlue)
        Dim baseColor2 As Color = If(DarkModeEnabled, Color.FromArgb(90, 90, 90), Color.AliceBlue)
        Dim fontColor As Color = If(DarkModeEnabled, Color.White, Color.Black)

        Dim buttons As Control() = {importbtn, actionbtn, cancelbtn}
        For Each btn As Control In buttons
            btn.BackColor = btnColor
        Next

        Dim labels As Control() = {Label1, Label2, Label3, Label4, Label5, Panel1}
        For Each lbl As Control In labels
            lbl.BackColor = baseColor
            lbl.ForeColor = fontColor
        Next

        Label6.BackColor = baseColor2
        Label6.ForeColor = fontColor
        Me.BackColor = baseColor2
    End Sub
End Class

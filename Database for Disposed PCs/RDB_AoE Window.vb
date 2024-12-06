Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class AddOrEditWindow
    Private _connectionString As String
    Private _serialno As String
    Private renewalsDBForm As RDB

    Private Sub AddOrEditWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Savebtn.Text = "Save" Then
            Importbtn.Enabled = False
        End If

        ' Attach the TextChanged event to all relevant textboxes
        AddHandler SerialNumbertxtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler Typetxtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler Brandtxtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler PPtxtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler net911txtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler Warrantytxtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler Locationtxtbx.TextChanged, AddressOf CheckAllFieldsFilled
        AddHandler StatusComboBox.TextChanged, AddressOf CheckAllFieldsFilled

        ' Initial check to disable the button if fields are empty at the start
        CheckAllFieldsFilled()
    End Sub

    Public Sub New(connectionString As String, renewalsDBForm As RDB, Optional serialno As String = "")
        InitializeComponent()
        _connectionString = connectionString
        Me.renewalsDBForm = renewalsDBForm
        _serialno = serialno

        If Not String.IsNullOrEmpty(serialno) Then
            PopulateDataForSerialNumber(serialno)
        End If
    End Sub

    ' Method to check if all required fields are filled
    Private Sub CheckAllFieldsFilled()
        ' Disable the Save button if any of the fields are empty or ComboBox is not selected
        If String.IsNullOrWhiteSpace(SerialNumbertxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(Typetxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(Brandtxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(PPtxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(net911txtbx.Text) OrElse
           String.IsNullOrWhiteSpace(Warrantytxtbx.Text) OrElse
           String.IsNullOrWhiteSpace(Locationtxtbx.Text) OrElse
           StatusComboBox.SelectedIndex = -1 Then

            Savebtn.Enabled = False
        Else
            Savebtn.Enabled = True
        End If
    End Sub

    Private Sub PopulateDataForSerialNumber(serialno As String)
        Dim query As String = "SELECT * FROM devicesrenewal WHERE serialno = @serialno"

        Using connection As New MySqlConnection(_connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@serialno", serialno)
                connection.Open()

                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        LoadDataFromReader(reader)
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadDataFromReader(reader As MySqlDataReader)
        SerialNumbertxtbx.Text = reader("serialno").ToString()
        Typetxtbx.Text = reader("prodtype").ToString()
        Brandtxtbx.Text = reader("brand").ToString()
        pdpicker.Value = CType(reader("purchdate"), Date)
        PPtxtbx.Text = reader("purchprice").ToString()
        net911txtbx.Text = reader("net911").ToString()
        Warrantytxtbx.Text = reader("warranty").ToString()
        Locationtxtbx.Text = reader("location").ToString()

        ' Set ComboBox value
        StatusComboBox.SelectedItem = reader("status").ToString()

        SerialNumbertxtbx.Enabled = False
        Savebtn.Text = "Save"
    End Sub

    Private Sub InsertData()
        Dim query As String = "INSERT INTO devicesrenewal (serialno, prodtype, purchdate, purchprice, brand, net911, warranty, location, status) " &
                              "VALUES (@serialno, @prodtype, @purchdate, @purchprice, @brand, @net911, @warranty, @location, @status)"
        ExecuteNonQuery(query)
    End Sub

    Private Sub UpdateData()
        Dim query As String = "UPDATE devicesrenewal SET prodtype = @prodtype, brand = @brand, purchdate = @purchdate, purchprice = @purchprice, " &
                              "net911 = @net911, warranty = @warranty, location = @location, status = @status WHERE serialno = @serialno"
        ExecuteNonQuery(query)
    End Sub

    Private Sub ExecuteNonQuery(query As String)
        Using connection As New MySqlConnection(_connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@serialno", SerialNumbertxtbx.Text)
                command.Parameters.AddWithValue("@prodtype", Typetxtbx.Text)
                command.Parameters.AddWithValue("@brand", Brandtxtbx.Text)
                command.Parameters.AddWithValue("@purchdate", pdpicker.Value)
                command.Parameters.AddWithValue("@purchprice", PPtxtbx.Text)
                command.Parameters.AddWithValue("@net911", net911txtbx.Text)
                command.Parameters.AddWithValue("@warranty", Warrantytxtbx.Text)
                command.Parameters.AddWithValue("@location", Locationtxtbx.Text)

                ' Add status from ComboBox
                command.Parameters.AddWithValue("@status", StatusComboBox.SelectedItem.ToString())

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Operation successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Call the LoadData function from the renewalsDBForm to refresh the DataGridView
                        renewalsDBForm.LoadData()

                        ' Close the AddOrEditWindow after operation
                        Me.Close()
                    Else
                        MessageBox.Show("Operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As MySqlException
                    MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub


    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        If Savebtn.Text = "Save" Then
            UpdateData()
        Else
            InsertData()
        End If
    End Sub

    Private Sub ImportFromExcel(filePath As String)
        Dim checkQuery As String = "SELECT COUNT(*) FROM devicesrenewal WHERE serialno = @serialno"
        Dim insertQuery As String = "INSERT INTO devicesrenewal (serialno, prodtype, brand, purchdate, purchprice, net911, warranty, location, status) " &
                                    "VALUES (@serialno, @prodtype, @brand, @purchdate, @purchprice, @net911, @warranty, @location, @status)"

        Using connection As New MySqlConnection(_connectionString)
            Using checkCommand As New MySqlCommand(checkQuery, connection)
                Using command As New MySqlCommand(insertQuery, connection)
                    connection.Open()
                    Using workbook As New XLWorkbook(filePath)
                        Dim worksheet As IXLWorksheet = workbook.Worksheet(1)

                        For Each row As IXLRow In worksheet.RowsUsed().Skip(1)
                            Dim serialNo As String = row.Cell(2).Value.ToString()
                            Dim prodType As String = row.Cell(3).Value.ToString()
                            Dim brand As String = row.Cell(4).Value.ToString()
                            Dim purchDate As DateTime = row.Cell(5).GetDateTime()
                            Dim purchPrice As Decimal = Decimal.Parse(row.Cell(6).Value.ToString())
                            Dim net911 As String = row.Cell(7).Value.ToString()
                            Dim warranty As String = row.Cell(8).Value.ToString()
                            Dim location As String = row.Cell(9).Value.ToString()
                            Dim status As String = row.Cell(10).Value.ToString() ' Assuming status is in the 10th column

                            checkCommand.Parameters.Clear()
                            checkCommand.Parameters.AddWithValue("@serialno", serialNo)
                            Dim count As Integer = Convert.ToInt32(checkCommand.ExecuteScalar())

                            If count > 0 Then
                                MessageBox.Show($"Serial number '{serialNo}' already exists. Skipping this record.")
                                Continue For
                            End If

                            command.Parameters.Clear()
                            command.Parameters.AddWithValue("@serialno", serialNo)
                            command.Parameters.AddWithValue("@prodtype", prodType)
                            command.Parameters.AddWithValue("@brand", brand)
                            command.Parameters.AddWithValue("@purchdate", purchDate)
                            command.Parameters.AddWithValue("@purchprice", purchPrice)
                            command.Parameters.AddWithValue("@net911", net911)
                            command.Parameters.AddWithValue("@warranty", warranty)
                            command.Parameters.AddWithValue("@location", location)
                            command.Parameters.AddWithValue("@status", status)
                            command.ExecuteNonQuery()
                        Next
                        MessageBox.Show("Data imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Importbtn_Click(sender As Object, e As EventArgs) Handles Importbtn.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"
            openFileDialog.Title = "Select an Excel File"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ImportFromExcel(openFileDialog.FileName)
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

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

    Private Sub myButton_Paint(sender As Object, e As PaintEventArgs) Handles Savebtn.Paint, Importbtn.Paint, Button1.Paint
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

    Public Sub UpdateFormColors()
        Dim btnColor As Color = If(DarkModeEnabled, Color.Black, Color.DarkRed)
        Dim baseColor As Color = If(DarkModeEnabled, Color.FromArgb(50, 50, 50), Color.LightSteelBlue)
        Dim baseColor2 As Color = If(DarkModeEnabled, Color.FromArgb(90, 90, 90), Color.AliceBlue)
        Dim fontColor As Color = If(DarkModeEnabled, Color.White, Color.Black)

        Importbtn.BackColor = btnColor
        Savebtn.BackColor = btnColor
        Button1.BackColor = btnColor
        Panel1.BackColor = baseColor

        Dim labels As Control() = {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label10}
        For Each lbl As Control In labels
            lbl.ForeColor = fontColor
            lbl.BackColor = baseColor
        Next

        Label9.BackColor = baseColor2
        Label9.ForeColor = fontColor
        Me.BackColor = baseColor2
    End Sub
End Class

Imports Microsoft.VisualBasic.FileIO
Imports System.IO

Public Class CSVupload
    Private ReadOnly ExpectedHeaders As String() = {"Device Type", "Asset #", "Device Name", "Manufacturer", "Description", "Asset Status", "E-mail", "04_PC分類/PC Category/PC分类", "01_設置場所詳細/Description of installment location/放置场所详细", "03_製造番号(S/N)/Serial number(S/N)/生产号(S/N)", "12_部門OAリーダ/Department OA Leader/资产负责人ID", "13_部門OAリーダ所属部署/Department OA Leader belonging section/资产负责人部门代码", "29_追加MAC アドレス/Additional MAC Address/追加MAC地址", "34_自由記入項目1/Free item 1/自由填写项目1", "35_自由記入項目2/Free item 2/自由填写项目2", "36_自由記入項目3/Free item 3/自由填写项目3", "37_自由記入項目4/Free item 4/自由填写项目4", "Model", "Processor", "Total Memory", "Storage Capacity", "IP Address", "MAC Address", "Operating System"}

    Private _darkModeEnabled As Boolean

    ' When the form is loaded, ensure the colors are set based on the dark mode state
    Private Sub CSVupload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure the form colors are updated based on the dark mode setting
        UpdateFormColors()

        ' Ensure that CSV DATA folder exists in the application's directory
        Dim folderPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSV DATA")
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        ' Set initial state
        uploadButton.Enabled = False

        ' Hook up the events to monitor changes
        AddHandler MaskedTextBox1.TextChanged, AddressOf Controls_Changed
        AddHandler ComboBox1.SelectedIndexChanged, AddressOf Controls_Changed
    End Sub

    ' Controls changed event to enable/disable the upload button
    Private Sub Controls_Changed(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(MaskedTextBox1.Text) AndAlso ComboBox1.SelectedIndex <> -1 Then
            uploadButton.Enabled = True ' Enable the upload button
        Else
            uploadButton.Enabled = False ' Disable the upload button
        End If
    End Sub

    ' Handle the button click for uploading CSV file
    Private Sub UploadButton_Click(sender As Object, e As EventArgs) Handles uploadButton.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv"
            openFileDialog.Title = "Select CSV File"
            openFileDialog.InitialDirectory = "\\10.110.33.62\iss_docs\iso_documents\ISS Inventory\ITDM Inventory\Hardware CSV File"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedFilePath As String = openFileDialog.FileName
                Dim year As String = MaskedTextBox1.Text
                Dim quarter As String = ComboBox1.SelectedItem.ToString()

                ' Validate the CSV headers
                Dim missingColumns As List(Of String) = ValidateCsvHeaders(selectedFilePath)
                If missingColumns.Count > 0 Then
                    MessageBox.Show("The CSV file is missing the following columns: " & String.Join(", ", missingColumns), "Invalid CSV", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' Proceed with file upload
                Dim folderPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSV DATA")
                Dim destinationFileName As String = year & " " & quarter & ".csv"
                Dim destinationPath As String = Path.Combine(folderPath, destinationFileName)

                ' Confirm overwrite if the file already exists
                If File.Exists(destinationPath) Then
                    Dim result As DialogResult = MessageBox.Show("The file already exists. Do you want to overwrite it?", "Overwriting Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If result = DialogResult.Yes Then
                        Try
                            File.Copy(selectedFilePath, destinationPath, True)
                            MessageBox.Show("File uploaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As Exception
                            MessageBox.Show("Error uploading file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Else
                    Try
                        File.Copy(selectedFilePath, destinationPath, True)
                        MessageBox.Show("File uploaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Error uploading file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Using
    End Sub

    ' Function to validate if the CSV has the correct headers
    Private Function ValidateCsvHeaders(filePath As String) As List(Of String)
        Dim missingColumns As New List(Of String)
        Using parser As New TextFieldParser(filePath)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")
            If Not parser.EndOfData Then
                Dim headers As String() = parser.ReadFields().Select(Function(h) h.Trim()).ToArray()
                For Each expectedHeader In ExpectedHeaders
                    If Not headers.Contains(expectedHeader) Then
                        missingColumns.Add(expectedHeader)
                    End If
                Next
            Else
                missingColumns.AddRange(ExpectedHeaders) ' If file is empty, all columns are missing
            End If
        End Using
        Return missingColumns
    End Function

    ' Dark mode property and color update method
    Public Property DarkModeEnabled As Boolean
        Get
            Return _darkModeEnabled
        End Get
        Set(value As Boolean)
            _darkModeEnabled = value
            UpdateFormColors()
        End Set
    End Property

    Private Sub myButton_Paint(sender As Object, e As PaintEventArgs) Handles uploadButton.Paint
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
        Dim btnColor As Color = If(DarkModeEnabled, Color.FromArgb(10, 10, 10), Color.DarkRed)
        Dim baseColor As Color = If(DarkModeEnabled, Color.FromArgb(50, 50, 50), Color.LightSteelBlue)
        Dim baseColor2 As Color = If(DarkModeEnabled, Color.FromArgb(100, 100, 100), Color.AliceBlue)
        Dim cellColor As Color = If(DarkModeEnabled, Color.FromArgb(80, 80, 80), Color.MistyRose)
        Dim fontColor As Color = If(DarkModeEnabled, Color.White, Color.Black)

        ' Update form colors and button colors
        uploadButton.BackColor = btnColor
        Label1.BackColor = baseColor2
        Label2.BackColor = baseColor2
        Label1.ForeColor = fontColor
        Label2.ForeColor = fontColor
        Me.BackColor = baseColor2
    End Sub
End Class

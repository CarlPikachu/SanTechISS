Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.FileIO  ' For better CSV parsing

Public Class ViewCSV

    Private Sub SummarizeCSV(csvFilePath As String)
        ' Create a DataTable to store the summarized data for devices
        Dim summaryTable As New DataTable()
        summaryTable.Columns.Add("Plant")
        summaryTable.Columns.Add("Desktops", GetType(Integer))
        summaryTable.Columns.Add("Laptops", GetType(Integer))
        summaryTable.Columns.Add("Servers", GetType(Integer))
        summaryTable.Columns.Add("TC", GetType(Integer))  ' Thin Clients
        summaryTable.Columns.Add("Total", GetType(Integer)) ' Total column for each row

        ' Create a DataTable to store the summarized data for OS versions (Windows 10, 11, 7)
        Dim osTable As New DataTable()
        osTable.Columns.Add("Plant")
        osTable.Columns.Add("Windows 10", GetType(Integer))
        osTable.Columns.Add("Windows 11", GetType(Integer))
        osTable.Columns.Add("Windows 7", GetType(Integer))
        osTable.Columns.Add("Total", GetType(Integer))

        ' Create a DataTable to store the summarized data for Laptop OS versions (Windows 10, 11, 7)
        Dim laptopOsTable As New DataTable()
        laptopOsTable.Columns.Add("Plant")
        laptopOsTable.Columns.Add("Windows 10", GetType(Integer))
        laptopOsTable.Columns.Add("Windows 11", GetType(Integer))
        laptopOsTable.Columns.Add("Windows 7", GetType(Integer))
        laptopOsTable.Columns.Add("Total", GetType(Integer))

        ' Create a DataTable to store the summarized data for Thin Client OS versions (Windows 10, 11, Embedded 7)
        Dim tcOsTable As New DataTable()
        tcOsTable.Columns.Add("Plant")
        tcOsTable.Columns.Add("Windows 10", GetType(Integer))
        tcOsTable.Columns.Add("Windows 11", GetType(Integer))
        tcOsTable.Columns.Add("Windows Embedded 7", GetType(Integer)) ' Handle Windows Embedded 7e 32
        tcOsTable.Columns.Add("Total", GetType(Integer))

        ' Dictionary to hold device counts per plant
        Dim deviceCounts As New Dictionary(Of String, Dictionary(Of String, Integer))()
        Dim osCounts As New Dictionary(Of String, Dictionary(Of String, Integer))()
        Dim laptopOsCounts As New Dictionary(Of String, Dictionary(Of String, Integer))() ' For laptop OS counts
        Dim tcOsCounts As New Dictionary(Of String, Dictionary(Of String, Integer))() ' For thin client OS counts

        ' Check if file exists
        If Not File.Exists(csvFilePath) Then
            MessageBox.Show("CSV file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Use TextFieldParser to read the CSV file, handles quoted commas better
        Using parser As New TextFieldParser(csvFilePath, Encoding.Default)
            parser.HasFieldsEnclosedInQuotes = True  ' Handle quoted fields
            parser.SetDelimiters(",")  ' CSV delimiter is comma

            ' Read the header line
            If Not parser.EndOfData Then
                Dim headers As String() = parser.ReadFields()

                ' Find the indexes of the relevant columns
                Dim deviceTypeIndex As Integer = Array.IndexOf(headers, "Device Type")
                Dim osIndex As Integer = Array.IndexOf(headers, "Operating System") ' Assuming Operating System column
                Dim pcCategoryIndex As Integer = Array.IndexOf(headers, "04_PC分類/PC Category/PC分类")
                Dim plantLocationIndex As Integer = Array.IndexOf(headers, "12_部門OAリーダ/Department OA Leader/资产负责人ID")

                ' Check if the indexes are valid
                If deviceTypeIndex = -1 OrElse osIndex = -1 OrElse pcCategoryIndex = -1 OrElse plantLocationIndex = -1 Then
                    MessageBox.Show("One or more required columns are missing in the CSV file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Loop through each line in the CSV (excluding the header)
                While Not parser.EndOfData
                    Dim fields As String() = parser.ReadFields()

                    ' Check if the current row has the expected number of columns
                    If fields.Length > plantLocationIndex Then
                        ' Get the values for device type, OS, PC category, and plant location
                        Dim deviceType As String = fields(deviceTypeIndex).Trim()
                        Dim os As String = fields(osIndex).Trim()
                        Dim pcCategory As String = fields(pcCategoryIndex).Trim()
                        Dim plantLocation As String = fields(plantLocationIndex).Trim()

                        ' If plant location is empty or missing, assign to "No Plant"
                        If String.IsNullOrEmpty(plantLocation) Then
                            plantLocation = "No Plant"
                        End If

                        ' Ensure the dictionary for the plant exists for device counts
                        If Not deviceCounts.ContainsKey(plantLocation) Then
                            deviceCounts(plantLocation) = New Dictionary(Of String, Integer) From {
                            {"Desktops", 0},
                            {"Laptops", 0},
                            {"Servers", 0},
                            {"Thin Clients", 0}
                        }
                        End If

                        ' Ensure the dictionary for the plant exists for OS counts
                        If Not osCounts.ContainsKey(plantLocation) Then
                            osCounts(plantLocation) = New Dictionary(Of String, Integer) From {
                            {"Windows 10", 0},
                            {"Windows 11", 0},
                            {"Windows 7", 0}
                        }
                        End If

                        ' Ensure the dictionary for the plant exists for Laptop OS counts
                        If Not laptopOsCounts.ContainsKey(plantLocation) Then
                            laptopOsCounts(plantLocation) = New Dictionary(Of String, Integer) From {
                            {"Windows 10", 0},
                            {"Windows 11", 0},
                            {"Windows 7", 0}
                        }
                        End If

                        ' Ensure the dictionary for the plant exists for Thin Client OS counts
                        If Not tcOsCounts.ContainsKey(plantLocation) Then
                            tcOsCounts(plantLocation) = New Dictionary(Of String, Integer) From {
                            {"Windows 10", 0},
                            {"Windows 11", 0},
                            {"Windows Embedded 7", 0}  ' This will track Embedded 7 as Windows 7 equivalent
                        }
                        End If

                        ' Count the device type for this plant
                        If deviceType = "PC" Then
                            If pcCategory.Contains("デスクトップ/Desktop PC/台式") Then
                                deviceCounts(plantLocation)("Desktops") += 1

                                ' Normalize the OS string to check the main version
                                Dim osVersion As String = os.ToUpper().Trim()

                                ' Check for Windows 10, 11, or 7 in the OS string (ignore extra details like Pro, Enterprise, etc.)
                                If osVersion.Contains("10") Then
                                    osCounts(plantLocation)("Windows 10") += 1
                                ElseIf osVersion.Contains("11") Then
                                    osCounts(plantLocation)("Windows 11") += 1
                                ElseIf osVersion.Contains("7") Then
                                    osCounts(plantLocation)("Windows 7") += 1
                                End If
                            ElseIf pcCategory.Contains("ノート/Notebook PC/笔记本") Then
                                deviceCounts(plantLocation)("Laptops") += 1

                                ' Count the laptop OS versions
                                Dim osVersion As String = os.ToUpper().Trim()
                                If osVersion.Contains("10") Then
                                    laptopOsCounts(plantLocation)("Windows 10") += 1
                                ElseIf osVersion.Contains("11") Then
                                    laptopOsCounts(plantLocation)("Windows 11") += 1
                                ElseIf osVersion.Contains("7") Then
                                    laptopOsCounts(plantLocation)("Windows 7") += 1
                                End If
                            End If
                        ElseIf deviceType = "Server" Then
                            deviceCounts(plantLocation)("Servers") += 1
                        ElseIf deviceType = "シンクライアント" Then
                            deviceCounts(plantLocation)("Thin Clients") += 1

                            ' Count the Thin Client OS versions (e.g., Windows Embedded 7e 32)
                            Dim osVersion As String = os.ToUpper().Trim()
                            If osVersion.Contains("10") Then
                                tcOsCounts(plantLocation)("Windows 10") += 1
                            ElseIf osVersion.Contains("11") Then
                                tcOsCounts(plantLocation)("Windows 11") += 1
                            ElseIf osVersion.Contains("WIN7E") Then
                                tcOsCounts(plantLocation)("Windows Embedded 7") += 1
                            End If
                        End If
                    End If
                End While
            End If
        End Using

        ' Initialize totals for devices
        Dim totalDesktops As Integer = 0
        Dim totalLaptops As Integer = 0
        Dim totalServers As Integer = 0
        Dim totalThinClients As Integer = 0
        Dim totalAllDevices As Integer = 0

        ' Initialize totals for OS counts (General, Laptop, and Thin Client)
        Dim totalWindows10 As Integer = 0
        Dim totalWindows11 As Integer = 0
        Dim totalWindows7 As Integer = 0
        Dim totalWindowsEmbedded7 As Integer = 0 ' For Thin Clients with Embedded 7
        Dim totalOSDevices As Integer = 0
        Dim totalTCDevices As Integer = 0 ' For Thin Client devices

        ' Populate the device counts DataTable
        For Each plant In deviceCounts.Keys
            Dim row As DataRow = summaryTable.NewRow()
            row("Plant") = plant
            row("Desktops") = deviceCounts(plant)("Desktops")
            row("Laptops") = deviceCounts(plant)("Laptops")
            row("Servers") = deviceCounts(plant)("Servers")
            row("TC") = deviceCounts(plant)("Thin Clients")

            ' Calculate the total for this plant (Desktops + Laptops + Servers + Thin Clients)
            Dim rowTotal As Integer = deviceCounts(plant)("Desktops") + deviceCounts(plant)("Laptops") + deviceCounts(plant)("Servers") + deviceCounts(plant)("Thin Clients")
            row("Total") = rowTotal

            ' Add to the overall totals
            totalDesktops += deviceCounts(plant)("Desktops")
            totalLaptops += deviceCounts(plant)("Laptops")
            totalServers += deviceCounts(plant)("Servers")
            totalThinClients += deviceCounts(plant)("Thin Clients")
            totalAllDevices += rowTotal

            summaryTable.Rows.Add(row)
        Next

        ' Populate the OS counts DataTable
        ' Initialize totals for each category by OS type
        Dim totalDesktopsWin7 As Integer = 0
        Dim totalDesktopsWin10 As Integer = 0
        Dim totalDesktopsWin11 As Integer = 0

        Dim totalLaptopsWin7 As Integer = 0
        Dim totalLaptopsWin10 As Integer = 0
        Dim totalLaptopsWin11 As Integer = 0

        Dim totalServersWin7 As Integer = 0
        Dim totalServersWin10 As Integer = 0
        Dim totalServersWin11 As Integer = 0

        Dim totalThinClientsWin7 As Integer = 0
        Dim totalThinClientsWin10 As Integer = 0
        Dim totalThinClientsWin11 As Integer = 0
        Dim totalThinClientsWinEmbedded7 As Integer = 0 ' For Thin Clients with Embedded 7

        ' Populate the OS counts DataTable (General Devices)
        For Each plant In osCounts.Keys
            Dim row As DataRow = osTable.NewRow()
            row("Plant") = plant
            row("Windows 10") = osCounts(plant)("Windows 10")
            row("Windows 11") = osCounts(plant)("Windows 11")
            row("Windows 7") = osCounts(plant)("Windows 7")

            ' Calculate the total for this plant (Windows 10 + Windows 11 + Windows 7)
            Dim rowTotal As Integer = osCounts(plant)("Windows 10") + osCounts(plant)("Windows 11") + osCounts(plant)("Windows 7")
            row("Total") = rowTotal

            ' Add to the specific totals for each OS and device type
            totalDesktopsWin7 += osCounts(plant)("Windows 7")
            totalDesktopsWin10 += osCounts(plant)("Windows 10")
            totalDesktopsWin11 += osCounts(plant)("Windows 11")

            osTable.Rows.Add(row)
        Next

        ' Populate the Laptop OS counts DataTable
        For Each plant In laptopOsCounts.Keys
            Dim row As DataRow = laptopOsTable.NewRow()
            row("Plant") = plant
            row("Windows 10") = laptopOsCounts(plant)("Windows 10")
            row("Windows 11") = laptopOsCounts(plant)("Windows 11")
            row("Windows 7") = laptopOsCounts(plant)("Windows 7")

            ' Calculate the total for this plant (Windows 10 + Windows 11 + Windows 7)
            Dim rowTotal As Integer = laptopOsCounts(plant)("Windows 10") + laptopOsCounts(plant)("Windows 11") + laptopOsCounts(plant)("Windows 7")
            row("Total") = rowTotal

            ' Add to the specific totals for each OS and device type
            totalLaptopsWin7 += laptopOsCounts(plant)("Windows 7")
            totalLaptopsWin10 += laptopOsCounts(plant)("Windows 10")
            totalLaptopsWin11 += laptopOsCounts(plant)("Windows 11")

            laptopOsTable.Rows.Add(row)
        Next

        ' Populate the Thin Client OS counts DataTable
        For Each plant In tcOsCounts.Keys
            Dim row As DataRow = tcOsTable.NewRow()
            row("Plant") = plant
            row("Windows 10") = tcOsCounts(plant)("Windows 10")
            row("Windows 11") = tcOsCounts(plant)("Windows 11")
            row("Windows Embedded 7") = tcOsCounts(plant)("Windows Embedded 7")

            ' Calculate the total for this plant (Windows 10 + Windows 11 + Windows Embedded 7)
            Dim rowTotal As Integer = tcOsCounts(plant)("Windows 10") + tcOsCounts(plant)("Windows 11") + tcOsCounts(plant)("Windows Embedded 7")
            row("Total") = rowTotal

            ' Add to the specific totals for each OS and device type

            totalThinClientsWin10 += tcOsCounts(plant)("Windows 10")
            totalThinClientsWin11 += tcOsCounts(plant)("Windows 11")
            totalThinClientsWinEmbedded7 += tcOsCounts(plant)("Windows Embedded 7")

            tcOsTable.Rows.Add(row)
        Next

        ' Add the total row for devices in summaryTable (Desktops, Laptops, Servers, Thin Clients)
        Dim totalRow As DataRow = summaryTable.NewRow()
        totalRow("Plant") = "Total"
        totalRow("Desktops") = totalDesktops
        totalRow("Laptops") = totalLaptops
        totalRow("Servers") = totalServers
        totalRow("TC") = totalThinClients
        totalRow("Total") = totalAllDevices
        summaryTable.Rows.Add(totalRow)

        ' Add the total row for OS counts in osTable (Windows 7 for Desktops, etc.)
        Dim osTotalRow As DataRow = osTable.NewRow()
        osTotalRow("Plant") = "Total"
        osTotalRow("Windows 7") = totalDesktopsWin7 + totalLaptopsWin7 + totalServersWin7 + totalThinClientsWin7
        osTotalRow("Windows 10") = totalDesktopsWin10 + totalLaptopsWin10 + totalServersWin10 + totalThinClientsWin10
        osTotalRow("Windows 11") = totalDesktopsWin11 + totalLaptopsWin11 + totalServersWin11 + totalThinClientsWin11
        osTotalRow("Total") = osTotalRow("Windows 7") + osTotalRow("Windows 10") + osTotalRow("Windows 11")
        osTable.Rows.Add(osTotalRow)

        ' Add the total row for Laptop OS counts in laptopOsTable
        Dim laptopOsTotalRow As DataRow = laptopOsTable.NewRow()
        laptopOsTotalRow("Plant") = "Total"
        laptopOsTotalRow("Windows 7") = totalLaptopsWin7
        laptopOsTotalRow("Windows 10") = totalLaptopsWin10
        laptopOsTotalRow("Windows 11") = totalLaptopsWin11
        laptopOsTotalRow("Total") = laptopOsTotalRow("Windows 7") + laptopOsTotalRow("Windows 10") + laptopOsTotalRow("Windows 11")
        laptopOsTable.Rows.Add(laptopOsTotalRow)

        ' Add the total row for Thin Client OS counts in tcOsTable
        Dim tcOsTotalRow As DataRow = tcOsTable.NewRow()
        tcOsTotalRow("Plant") = "Total"

        tcOsTotalRow("Windows 10") = totalThinClientsWin10
        tcOsTotalRow("Windows 11") = totalThinClientsWin11
        tcOsTotalRow("Windows Embedded 7") = totalThinClientsWinEmbedded7
        tcOsTotalRow("Total") = tcOsTotalRow("Windows 10") + tcOsTotalRow("Windows 11") + tcOsTotalRow("Windows Embedded 7")
        tcOsTable.Rows.Add(tcOsTotalRow)

        ' Set the DataSource of the DataGridViews
        dataGridViewSummary.DataSource = summaryTable
        dataGridViewSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dataGridViewOSD.DataSource = osTable
        dataGridViewOSD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dataGridViewOSL.DataSource = laptopOsTable
        dataGridViewOSL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dataGridViewOSTC.DataSource = tcOsTable
        dataGridViewOSTC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill


    End Sub




    Private Sub cboCSVFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCSVFiles.SelectedIndexChanged
        ' Check if an item is selected in the ComboBox
        If cboCSVFiles.SelectedItem IsNot Nothing Then
            ' Get the selected file name from the ComboBox
            Dim selectedFileName As String = cboCSVFiles.SelectedItem.ToString()

            ' Define the full file path
            Dim filePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSV DATA", selectedFileName)

            ' Call the SummarizeCSV method to load the selected CSV file's data
            SummarizeCSV(filePath)
        End If
    End Sub

    Private Sub ViewCSV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Define the folder path for CSV files
        Dim folderPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSV DATA")

        ' Check if the folder exists
        If Directory.Exists(folderPath) Then
            ' Get all CSV files in the directory
            Dim csvFiles As String() = Directory.GetFiles(folderPath, "*.csv")

            ' Clear any existing items in the ComboBox
            cboCSVFiles.Items.Clear()

            ' Add the file names (without the path) to the ComboBox
            For Each filePath In csvFiles
                ' Add only the file name (not the full path) to the ComboBox
                cboCSVFiles.Items.Add(Path.GetFileName(filePath))
            Next

            ' Optional: Automatically select the first item in the ComboBox if desired
            If cboCSVFiles.Items.Count > 0 Then
                cboCSVFiles.SelectedIndex = 0
            End If
        Else
            MessageBox.Show("CSV DATA folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class

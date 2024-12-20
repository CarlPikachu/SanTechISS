Imports MySql.Data.MySqlClient
Imports System.Text

Public Class RDB
    Private connectionString As String = "server=10.110.33.26;user id=Admin;password=s@nt3ch2;database=disposedcomputers"
    Private dataTable As New DataTable()

    ' Device details
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        LoadDataToListBox(ListBox1)
        CountTotalSerialNumbers()
    End Sub

    Private Sub CountTotalSerialNumbers()
        ' Queries to count total serial numbers, active devices, inactive devices, and devices for renewal
        Dim totalQuery As String = "SELECT COUNT(serialno) FROM devicesrenewal"
        Dim activeQuery As String = "SELECT COUNT(serialno) FROM devicesrenewal WHERE status = 'active'"
        Dim inactiveQuery As String = "SELECT COUNT(serialno) FROM devicesrenewal WHERE status = 'inactive'"
        Dim renewalQuery As String = "SELECT COUNT(d.serialno) FROM devicesrenewal d " &
                                 "WHERE EXISTS (SELECT 1 FROM renewaldates r " &
                                 "WHERE r.serialno = d.serialno " &
                                 "AND MONTH(r.NextRenewalMonth) = MONTH(CURDATE()) " &
                                 "AND YEAR(r.NextRenewalMonth) = YEAR(CURDATE()))"

        ' Execute the queries and update the labels
        Using connection As New MySqlConnection(connectionString),
          totalCommand As New MySqlCommand(totalQuery, connection),
          activeCommand As New MySqlCommand(activeQuery, connection),
          inactiveCommand As New MySqlCommand(inactiveQuery, connection),
          renewalCommand As New MySqlCommand(renewalQuery, connection)

            Try
                connection.Open()

                ' Get total number of serial numbers
                Dim totalSerialNumbers As Integer = Convert.ToInt32(totalCommand.ExecuteScalar())
                totalrdlabel.Text = "" & totalSerialNumbers

                ' Get total number of active devices
                Dim activeDevices As Integer = Convert.ToInt32(activeCommand.ExecuteScalar())
                actlabel.Text = "" & activeDevices

                ' Get total number of inactive devices
                Dim inactiveDevices As Integer = Convert.ToInt32(inactiveCommand.ExecuteScalar())
                inactlabel.Text = "" & inactiveDevices

                ' Get total number of devices for renewal
                Dim renewalDevices As Integer = Convert.ToInt32(renewalCommand.ExecuteScalar())
                mrlabel.Text = "" & renewalDevices

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub


    Public Sub LoadData()
        ' Select only the latest renewalfee and contractTerm from renewaldates
        Dim query As String = "
        SELECT d.*, rd.renewalfee, rd.contractTerm
        FROM devicesrenewal d
        LEFT JOIN (
            SELECT serialno, renewalfee, contractTerm
            FROM renewaldates
            WHERE NextRenewalMonth = (
                SELECT MAX(NextRenewalMonth)
                FROM renewaldates r2
                WHERE r2.serialno = renewaldates.serialno
            )
        ) rd ON d.serialno = rd.serialno
        WHERE d.serialno LIKE @search"

        Dim selectedProdTypes As New List(Of String)
        Dim statusConditions As New List(Of String)

        ' Dynamic query building (same as before)
        If CheckBox8.Checked Then statusConditions.Add("d.status = 'active'")
        If CheckBox7.Checked Then statusConditions.Add("d.status = 'inactive'")
        If statusConditions.Count > 0 Then query &= " AND (" & String.Join(" OR ", statusConditions) & ")"

        If CheckBox1.Checked Then selectedProdTypes.Add("'Server'")
        If CheckBox2.Checked Then selectedProdTypes.Add("'Tape Drive'")
        If CheckBox3.Checked Then selectedProdTypes.Add("'Switch'")
        If CheckBox4.Checked Then query &= " AND d.prodtype NOT IN ('Server', 'Tape Drive', 'Firewall', 'Switch')"
        If CheckBox5.Checked Then selectedProdTypes.Add("'Firewall'")

        If selectedProdTypes.Count > 0 Then
            Dim prodTypeFilter As String = String.Join(", ", selectedProdTypes)
            query &= " AND d.prodtype IN (" & prodTypeFilter & ")"
        End If

        If CheckBox6.Checked Then
            query &= " AND EXISTS (
            SELECT 1 
            FROM renewaldates r 
            WHERE r.serialno = d.serialno 
            AND MONTH(r.NextRenewalMonth) = MONTH(CURDATE()) 
            AND YEAR(r.NextRenewalMonth) = YEAR(CURDATE())
        )"
        End If

        Using connection As New MySqlConnection(connectionString),
          command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@search", "%" & TextBox1.Text & "%")
            Dim adapter As New MySqlDataAdapter(command)
            Try
                connection.Open()
                dataTable.Clear()
                adapter.Fill(dataTable)

                ' Bind only serialno and prodtype to DataGridView2
                DataGridView2.DataSource = dataTable.DefaultView.ToTable(False, "serialno", "prodtype")
                AutoSizeDataGridViewColumns(DataGridView2)
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub


    Public Sub ExportToExcel()
        If dataTable.Rows.Count = 0 Then
            MessageBox.Show("No data available to export.")
            Return
        End If

        Try
            Dim saveFileDialog As New SaveFileDialog() With {
            .Filter = "Excel Files|*.xlsx",
            .Title = "Save as Excel File"
        }

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Using workbook As New ClosedXML.Excel.XLWorkbook()
                    Dim worksheet = workbook.Worksheets.Add("Devices")
                    worksheet.Cell(1, 1).InsertTable(dataTable, True)

                    ' Rename the location column to Device Name
                    Dim locationColumn = worksheet.Row(1).Cells().FirstOrDefault(Function(c) c.Value.ToString().ToLower() = "location")
                    If locationColumn IsNot Nothing Then
                        locationColumn.Value = "Device Name"
                    End If

                    workbook.SaveAs(saveFileDialog.FileName)
                End Using

                MessageBox.Show("Data exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting data: " & ex.Message)
        End Try
    End Sub


    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        ExportToExcel()
    End Sub


    Private Sub dmtrigger_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged,
             CheckBox4.CheckedChanged, CheckBox5.CheckedChanged, CheckBox6.CheckedChanged, CheckBox7.CheckedChanged, CheckBox8.CheckedChanged
        LoadData()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadData()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            PerformSearch()
        End If
    End Sub

    Private Sub PerformSearch()
        Dim searchText As String = TextBox1.Text.Trim()

        If String.IsNullOrWhiteSpace(searchText) Then
            SNlabel.Text = "Enter Serial Number"
            ResetDeviceDetails()
            DataGridView1.DataSource = Nothing
            actionbtn.Enabled = False
            ClearTextBoxes()
            deletebtn2.Enabled = False
            editbtn.Enabled = False
            deletebtn.Enabled = False
            Return
        End If

        Dim query As String = "SELECT devicesrenewal.* FROM devicesrenewal WHERE devicesrenewal.serialno = @SearchText"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@SearchText", searchText)
                connection.Open()

                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        PopulateDeviceDetails(reader)
                        PopulateRenewalDataGrid(searchText)
                        EnableTextBoxes()
                        editbtn.Enabled = True
                        deletebtn.Enabled = True
                    Else
                        ResetDeviceDetails()
                        DataGridView1.DataSource = Nothing
                        actionbtn.Enabled = False
                        deletebtn2.Enabled = False
                    End If
                End Using
            End Using
        End Using
        ClearTextBoxes()
        deletebtn2.Enabled = False
    End Sub

    Private Sub ResetDeviceDetails()
        SNlabel.Text = "Serial Number"
        typelabel.Text = ""
        pdlabel.Text = ""
        pplabel.Text = ""
        brandlabel.Text = ""
        net911label.Text = ""
        loclabel.Text = ""
        wrntylabel.Text = ""
        statuslbl.Text = ""
        DisableButtonsAndTextBoxes()
    End Sub

    Private Sub PopulateDeviceDetails(reader As MySqlDataReader)
        SNlabel.Text = reader("serialno").ToString()
        typelabel.Text = reader("prodtype").ToString()
        brandlabel.Text = reader("brand").ToString()
        pdlabel.Text = CType(reader("purchdate"), Date).ToString("MMMM dd yyyy")
        pplabel.Text = reader("purchprice").ToString()
        net911label.Text = reader("net911").ToString()
        loclabel.Text = reader("location").ToString()
        wrntylabel.Text = reader("warranty").ToString()
        statuslbl.Text = reader("status").ToString()
        ' Enable buttons if a device is found
        EnableTextBoxes()
        editbtn.Enabled = True
        deletebtn.Enabled = True
    End Sub

    Private Sub clrBtn_Click(sender As Object, e As EventArgs) Handles clrBtn.Click
        TextBox1.Text = ""
        PerformSearch()
    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles addbtn.Click
        Dim aoe As New AddOrEditWindow(connectionString, Me) With {
        .DarkModeEnabled = _darkModeEnabled
    }

        AddHandler aoe.FormClosed, AddressOf OnChildFormClosed

        aoe.ShowDialog()
    End Sub

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles editbtn.Click
        Dim serialNumber As String = SNlabel.Text.Trim()


        If String.IsNullOrEmpty(serialNumber) Then
            MessageBox.Show("Please select a serial number to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim aoe As New AddOrEditWindow(connectionString, Me, serialNumber) With {
        .DarkModeEnabled = _darkModeEnabled
    }


        AddHandler aoe.FormClosed, AddressOf OnChildFormClosed

        aoe.ShowDialog()
    End Sub


    Private Sub OnChildFormClosed(sender As Object, e As FormClosedEventArgs)
        PerformSearch()
    End Sub



    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles deletebtn.Click
        Try
            Dim confirmationResult = MessageBox.Show("Are you sure you want to delete the searched serial number?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmationResult = DialogResult.Yes Then
                Dim serialNumber = SNlabel.Text.Trim
                If Not String.IsNullOrEmpty(serialNumber) Then
                    DeleteDevice(serialNumber)
                Else
                    MessageBox.Show("No serial number to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteDevice(serialNumber As String)
        Dim deleteQuery As String = "DELETE FROM devicesrenewal WHERE serialno = @serialno"
        Using connection As New MySqlConnection(connectionString),
              command As New MySqlCommand(deleteQuery, connection)
            command.Parameters.AddWithValue("@serialno", serialNumber)
            connection.Open()
            If command.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Device deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PerformSearch()
            Else
                MessageBox.Show("Failed to delete device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        LoadData()
        ResetDeviceDetails()
        TextBox1.Text = ""
    End Sub

    Public Sub RefreshDataGridView()
        PerformSearch()
    End Sub

    ' Renewal dates info
    Private Sub EnableTextBoxes()
        actionbtn.Enabled = True
        actionbtn.Text = "ADD"
        EnableRenewalTextBoxes()
    End Sub

    Private Sub DisableButtonsAndTextBoxes()
        actionbtn.Enabled = False
        ClearTextBoxes()
        DisableRenewalTextBoxes()
    End Sub

    Private Sub EnableRenewalTextBoxes()
        renewaldatetxtbx.Enabled = True
        renewalfeetxtbx.Enabled = True
        contractTermtxtbx.Enabled = True
        nextrenewaltxtbx.Enabled = True
    End Sub

    Private Sub DisableRenewalTextBoxes()
        renewaldatetxtbx.Enabled = False
        renewalfeetxtbx.Enabled = False
        contractTermtxtbx.Enabled = False
        nextrenewaltxtbx.Enabled = False
    End Sub

    Private Sub PopulateRenewalDataGrid(serialNumber As String)
        Dim renewaldatesQuery As String = "SELECT id, DATE_FORMAT(renewaldate, '%M %d %Y') AS PastRenewalDate, renewalfee, contractTerm, DATE_FORMAT(NextRenewalMonth, '%M %Y') AS NextRenewalDate FROM renewaldates WHERE serialno = @serialno"
        Using connection As New MySqlConnection(connectionString),
              command As New MySqlCommand(renewaldatesQuery, connection)
            command.Parameters.AddWithValue("@serialno", serialNumber)
            connection.Open()

            Dim renewaldatesAdapter As New MySqlDataAdapter(command)
            Dim renewaldatesTable As New DataTable()
            renewaldatesAdapter.Fill(renewaldatesTable)
            DataGridView1.DataSource = renewaldatesTable
            DataGridView1.Columns("id").Visible = False
            AutoSizeDataGridViewColumns(DataGridView1)
        End Using
    End Sub

    Private Sub AutoSizeDataGridViewColumns(dgv As DataGridView)
        For Each column As DataGridViewColumn In dgv.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
    End Sub

    Private Sub PopulateTextBoxesFromGrid(selectedRow As DataGridViewRow)
        renewaldatetxtbx.Value = Convert.ToDateTime(selectedRow.Cells("PastRenewalDate").Value)
        renewalfeetxtbx.Text = selectedRow.Cells("RenewalFee").Value.ToString()
        contractTermtxtbx.Text = selectedRow.Cells("contractTerm").Value.ToString()
        nextrenewaltxtbx.Value = Convert.ToDateTime(selectedRow.Cells("NextRenewalDate").Value)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            PopulateTextBoxesFromGrid(DataGridView1.Rows(e.RowIndex))
            actionbtn.Text = "Save"
            deletebtn2.Enabled = True
            clrBtn2.Enabled = True
        End If
    End Sub

    Private Sub ActionButton_Click(sender As Object, e As EventArgs) Handles actionbtn.Click
        Try
            Dim serialNumber = SNlabel.Text.Trim()
            If actionbtn.Text = "Save" Then
                UpdateRenewalData(serialNumber, DataGridView1.CurrentRow.Cells("id").Value)
            Else
                InsertRenewalData(serialNumber)
            End If
            ClearTextBoxes()
            actionbtn.Text = "ADD"
            deletebtn2.Enabled = False
            clrBtn2.Enabled = False
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteButton2_Click(sender As Object, e As EventArgs) Handles deletebtn2.Click
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim confirmationResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmationResult = DialogResult.Yes Then
                    DeleteRenewalData(DataGridView1.SelectedRows(0).Cells("id").Value)
                End If
            Else
                MessageBox.Show("Please select a row to delete.")
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateRenewalData(serialNumber As String, id As Integer)
        Dim updateQuery As String = "UPDATE renewaldates SET renewaldate = @renewaldate, renewalfee = @renewalfee, contractTerm = @contractTerm, NextRenewalMonth = @NextRenewalMonth WHERE id = @id"
        Using connection As New MySqlConnection(connectionString),
              command As New MySqlCommand(updateQuery, connection)
            command.Parameters.AddWithValue("@renewaldate", renewaldatetxtbx.Value)
            command.Parameters.AddWithValue("@renewalfee", renewalfeetxtbx.Text)
            command.Parameters.AddWithValue("@contractTerm", contractTermtxtbx.Text)
            command.Parameters.AddWithValue("@NextRenewalMonth", nextrenewaltxtbx.Value)
            command.Parameters.AddWithValue("@id", id)

            connection.Open()
            If command.ExecuteNonQuery() > 0 Then
                PerformSearch()
            Else
                MessageBox.Show("Failed to update renewal data.")
            End If
        End Using
    End Sub

    Private Sub InsertRenewalData(serialNumber As String)
        Dim insertQuery As String = "INSERT INTO renewaldates (serialno, renewaldate, renewalfee, contractTerm, NextRenewalMonth) VALUES (@SerialNumber, @RenewalDate, @RenewalFee, @contractTerm, @NextRenewalMonth)"
        Using connection As New MySqlConnection(connectionString),
              command As New MySqlCommand(insertQuery, connection)
            command.Parameters.AddWithValue("@SerialNumber", serialNumber)
            command.Parameters.AddWithValue("@RenewalDate", renewaldatetxtbx.Value)
            command.Parameters.AddWithValue("@RenewalFee", renewalfeetxtbx.Text)
            command.Parameters.AddWithValue("@contractTerm", contractTermtxtbx.Text)
            command.Parameters.AddWithValue("@NextRenewalMonth", nextrenewaltxtbx.Value)

            connection.Open()
            If command.ExecuteNonQuery() > 0 Then
                PerformSearch()
            Else
                MessageBox.Show("Failed to add renewal data.")
            End If
        End Using
    End Sub

    Private Sub DeleteRenewalData(id As Integer)
        Dim deleteQuery As String = "DELETE FROM renewaldates WHERE ID = @ID"
        Using connection As New MySqlConnection(connectionString),
              command As New MySqlCommand(deleteQuery, connection)
            command.Parameters.AddWithValue("@ID", id)
            connection.Open()
            If command.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Record deleted successfully.")
                PerformSearch() ' Refresh the DataGridView
            Else
                MessageBox.Show("Failed to delete record.")
            End If
        End Using
    End Sub

    Private Sub ClearTextBoxes()
        renewaldatetxtbx.Value = DateTime.Now
        renewalfeetxtbx.Text = ""
        contractTermtxtbx.Text = ""
        nextrenewaltxtbx.Value = DateTime.Now
        actionbtn.Text = "ADD"
        clrBtn2.Enabled = False
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            TextBox1.Text = DataGridView2.Rows(e.RowIndex).Cells("serialno").Value.ToString()
            PerformSearch()
        End If
    End Sub

    Private Sub clrBtn2_Click(sender As Object, e As EventArgs) Handles clrBtn2.Click
        ClearTextBoxes()
        deletebtn2.Enabled = False
    End Sub

    'email section
    Public Sub LoadDataToListBox(ListBox1 As ListBox)
        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT EmailAddress FROM emailrecipients"
            Using command As New MySqlCommand(query, connection)
                Dim dataTable As New DataTable()
                Using dataAdapter As New MySqlDataAdapter(command)
                    dataAdapter.Fill(dataTable)
                End Using
                ListBox1.Items.Clear()
                For Each row As DataRow In dataTable.Rows
                    ListBox1.Items.Add(row("EmailAddress").ToString())
                Next
            End Using
        End Using
    End Sub

    Private Sub delbtneml_Click(sender As Object, e As EventArgs) Handles delbtneml.Click
        If ListBox1.SelectedIndex <> -1 Then
            Dim selectedEmail = ListBox1.SelectedItem.ToString
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query = "DELETE FROM emailrecipients WHERE EmailAddress = @EmailAddress"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@EmailAddress", selectedEmail)
                    command.ExecuteNonQuery()
                End Using
            End Using
            ListBox1.Items.Remove(selectedEmail)
        Else
            MessageBox.Show("Please select an email to delete.")
        End If
    End Sub

    Private Sub addButtoneml_Click(sender As Object, e As KeyPressEventArgs) Handles txtbx1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim newEmail = txtbx1.Text.Trim
            If Not String.IsNullOrEmpty(newEmail) Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()
                    Dim query = "INSERT INTO emailrecipients (EmailAddress) VALUES (@EmailAddress)"
                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.AddWithValue("@EmailAddress", newEmail)
                        command.ExecuteNonQuery()
                    End Using
                End Using
                LoadDataToListBox(ListBox1)
            Else
                MessageBox.Show("Please enter an email address.")
            End If
        End If
    End Sub


    Private Sub Msendbtn_Click(sender As Object, e As EventArgs) Handles Msendbtn.Click
        Dim currentMonth = Date.Today.Month
        Dim currentYear = Date.Today.Year
        ' Update lastSentMonth to 13
        UpdateLastSentMonth(connectionString, 13, currentYear)
        CheckAndSendRenewalEmail(connectionString)

    End Sub

    Private Sub UpdateLastSentMonth(connectionString As String, month As Integer, year As Integer)
        Dim query As String = "UPDATE emailhistory SET lastSentMonth = @Month, lastSentYear = @Year WHERE ID = 1"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Month", month)
                command.Parameters.AddWithValue("@Year", year)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'Appearance and Customization
    Private _darkModeEnabled As Boolean
    Private Sub myButton_Paint(sender As Object, e As PaintEventArgs) Handles editbtn.Paint, deletebtn2.Paint, clrBtn2.Paint, deletebtn.Paint, actionbtn.Paint
        Dim button = DirectCast(sender, Button)

        If button.Enabled Then Return ' Return early if enabled, no need to repaint.

        ' Use DarkModeEnabled to determine background color and font color
        Dim backgrounddisColor = If(DarkModeEnabled, Color.DimGray, Color.LightCoral)
        e.Graphics.FillRectangle(New SolidBrush(backgrounddisColor), e.ClipRectangle) ' Draw background

        ' Center and wrap the text
        Dim textLines = WrapText(button.Text, button.Font, button.Width)
        Dim totalHeight = textLines.Sum(Function(line) e.Graphics.MeasureString(line, button.Font).Height)
        Dim currentY = (button.Height - totalHeight) / 2

        For Each line In textLines
            Dim textSize = e.Graphics.MeasureString(line, button.Font)
            Dim textX = (button.Width - textSize.Width) / 2
            e.Graphics.DrawString(line, button.Font, Brushes.DarkGray, New PointF(textX, currentY))
            currentY += textSize.Height
        Next
    End Sub

    Private Function WrapText(text As String, font As Font, maxWidth As Integer) As String()
        Dim lines As New List(Of String)
        Dim currentLine As String = ""

        For Each word As String In text.Split(" "c)
            Dim testLine As String = If(String.IsNullOrEmpty(currentLine), word, $"{currentLine} {word}")
            ' Use StringBuilder for better performance with large texts.
            If TextRenderer.MeasureText(testLine, font).Width > maxWidth Then
                If currentLine.Length > 0 Then lines.Add(currentLine)
                currentLine = word
            Else
                currentLine = testLine
            End If
        Next
        If currentLine.Length > 0 Then lines.Add(currentLine)
        Return lines.ToArray()
    End Function

    Private Sub UpdateControlProperties(controls() As Control, propertyName As String, value As Object)
        For Each ctrl As Control In controls
            Select Case propertyName
                Case "BackColor"
                    ctrl.BackColor = DirectCast(value, Color)
                Case "ForeColor"
                    ctrl.ForeColor = DirectCast(value, Color)
            End Select
        Next
    End Sub

    Public Property DarkModeEnabled As Boolean
        Get
            Return _darkModeEnabled
        End Get
        Set(value As Boolean)
            _darkModeEnabled = value
            UpdateFormColors()
            Me.Invalidate() ' Redraw the form when dark mode changes.
        End Set
    End Property

    Public Sub UpdateFormColors()
        ' Consolidate colors
        Dim btnColor As Color = If(DarkModeEnabled, Color.Black, Color.DarkRed)
        Dim baseColor As Color = If(DarkModeEnabled, Color.FromArgb(50, 50, 50), Color.LightSteelBlue)
        Dim baseColor2 As Color = If(DarkModeEnabled, Color.FromArgb(90, 90, 90), Color.AliceBlue)
        Dim basecolor3 As Color = If(DarkModeEnabled, Color.FromArgb(45, 45, 45), Color.FromArgb(220, 220, 250))
        Dim cellColor As Color = If(DarkModeEnabled, Color.FromArgb(85, 85, 85), Color.MistyRose)
        Dim rhColor As Color = If(DarkModeEnabled, Color.FromArgb(65, 65, 65), Color.FromArgb(176, 214, 250))
        Dim cellColor2 As Color = If(DarkModeEnabled, Color.FromArgb(85, 85, 85), Color.MistyRose)
        Dim hlightcolor As Color = If(DarkModeEnabled, Color.FromArgb(35, 35, 35), Color.PowderBlue)
        Dim fontColor As Color = If(DarkModeEnabled, Color.White, Color.Black)
        Dim noteColor As Color = If(DarkModeEnabled, Color.White, Color.DarkRed)

        ' Update button background colors
        UpdateControlProperties({addbtn, editbtn, actionbtn, deletebtn, deletebtn2, delbtneml, Msendbtn, clrBtn, clrBtn2, ButtonExport}, "BackColor", btnColor)

        ' Update label and text color
        UpdateControlProperties({
        SNlabel, typelabel, pdlabel, pplabel, brandlabel, net911label, loclabel, wrntylabel,
        Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label10, Label11, TableLayoutPanel5,
        grpbx1, GroupBox3, GroupBox1, ListBox1, DIGB, Label12, Label14, Label15, Label16, Label17, totalrdlabel, actlabel, inactlabel, mrlabel, statuslbl
    }, "ForeColor", fontColor)

        UpdateControlProperties({Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label12, Label14, Label15, Label16, Label17}, "BackColor", rhColor)

        ' Update DataGridView1 and DataGridView2 styling
        UpdateDataGridViewColors(DataGridView1, cellColor, fontColor, cellColor2, btnColor, hlightcolor)
        UpdateDataGridViewColors(DataGridView2, cellColor, fontColor, cellColor2, btnColor, hlightcolor)

        ' Update group boxes, list boxes, and form background
        grpbx1.BackColor = baseColor
        GroupBox1.BackColor = baseColor
        GroupBox3.BackColor = baseColor
        TableLayoutPanel6.BackColor = basecolor3
        DIGB.BackColor = baseColor
        ListBox1.BackColor = baseColor
        Label9.ForeColor = noteColor
        Label10.BackColor = baseColor
        TableLayoutPanel3.BackColor = basecolor3
        ListBox1.BackColor = basecolor3
        Label11.BackColor = baseColor
        TableLayoutPanel5.BackColor = baseColor
        Me.BackColor = baseColor2
    End Sub

    Private Sub UpdateDataGridViewColors(dgv As DataGridView, backColor As Color, foreColor As Color, altBackColor As Color, headerColor As Color, selectionColor As Color)
        dgv.DefaultCellStyle.BackColor = backColor
        dgv.DefaultCellStyle.SelectionForeColor = foreColor
        dgv.RowsDefaultCellStyle.ForeColor = foreColor
        dgv.AlternatingRowsDefaultCellStyle.BackColor = altBackColor
        dgv.ColumnHeadersDefaultCellStyle.BackColor = headerColor
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerColor
        dgv.RowsDefaultCellStyle.SelectionBackColor = selectionColor
    End Sub

End Class

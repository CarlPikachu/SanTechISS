Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Text

Module EmailHelper
    Public Sub CheckAndSendRenewalEmail(connectionString As String)

        Dim today As Date = Date.Today
        Dim isFirstWeekOfMonth As Boolean = today.Day <= 100
        Dim lastSentMonth As Integer
        Dim lastSentYear As Integer

        ' Retrieve the last sent month and year from the database
        GetLastSentMonthAndYear(connectionString, lastSentMonth, lastSentYear)

        ' Check if it's the first week of the month and if the email has not been sent yet this month
        If isFirstWeekOfMonth AndAlso (today.Month <> lastSentMonth OrElse today.Year <> lastSentYear) Then
            Dim devicesToRenew As List(Of DeviceInfo) = GetDevicesToRenew(connectionString, today.Month)

            If devicesToRenew.Count > 0 Then
                MessageBox.Show("There are devices up for renewal this month and emails have not been sent. Please wait as the system sends emails. There will be a confirmation once done.", "Monthly Devices for Renewal Check")
                Dim recipientAddresses As List(Of String) = GetRecipientEmailAddresses(connectionString)
                Dim allEmailsSentSuccessfully As Boolean = True

                For Each recipientAddress As String In recipientAddresses
                    Dim emailBody As String = BuildEmailBody(devicesToRenew)

                    ' Create a formal subject line
                    Dim subject As String = $"{today:MMMM yyyy} Devices Renewal Notification"

                    If Not SendEmail("STI-SYS@proterial.com", recipientAddress, subject, emailBody) Then
                        allEmailsSentSuccessfully = False
                    End If
                Next

                If allEmailsSentSuccessfully Then
                    UpdateLastSentMonthAndYear(connectionString, today.Month, today.Year)
                    MessageBox.Show("Emails regarding devices up for renewal this month sent successfully.", "Monthly Devices for Renewal Check", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Some emails failed to send. Please check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        End If
    End Sub

    Private Function GetDevicesToRenew(connectionString As String, currentMonth As Integer) As List(Of DeviceInfo)
        Dim devicesToRenew As New List(Of DeviceInfo)

        Dim query As String = "
            SELECT rd.serialno, dd.prodtype, dd.purchdate, dd.location
            FROM renewaldates rd
            INNER JOIN devicesrenewal dd ON rd.serialno = dd.serialno
            WHERE MONTH(rd.NextRenewalMonth) = @CurrentMonth
        "

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@CurrentMonth", currentMonth)
                connection.Open()

                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim device As New DeviceInfo With {
                            .SerialNo = reader("serialno").ToString(),
                            .ProdType = reader("prodtype").ToString(),
                            .PurchaseDate = reader("purchdate").ToString(),
                            .Location = reader("location").ToString()
                        }
                        devicesToRenew.Add(device)
                    End While
                End Using
            End Using
        End Using

        Return devicesToRenew
    End Function

    Private Function GetRecipientEmailAddresses(connectionString As String) As List(Of String)
        Dim recipientAddresses As New List(Of String)()
        Dim query As String = "SELECT EmailAddress FROM emailrecipients"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        recipientAddresses.Add(reader("EmailAddress").ToString())
                    End While
                End Using
            End Using
        End Using

        Return recipientAddresses
    End Function

    Private Function SendEmail(senderAddress As String, recipientAddress As String, subject As String, body As String) As Boolean
        Try
            Dim smtpClient As New SmtpClient("mlgw.intra.proterial.com") With {
                .Port = 25,
                .Credentials = New NetworkCredential("STI-SYS@proterial.com", "alexa80"),
                .EnableSsl = False
            }

            Dim mailMessage As New MailMessage() With {
                .From = New MailAddress(senderAddress),
                .Subject = subject,
                .Body = body,
                .IsBodyHtml = False
            }
            mailMessage.To.Add(recipientAddress)

            smtpClient.Send(mailMessage)
            Return True
        Catch ex As Exception
            MessageBox.Show("An error occurred while sending the email: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub GetLastSentMonthAndYear(connectionString As String, ByRef lastSentMonth As Integer, ByRef lastSentYear As Integer)
        Dim query As String = "SELECT LastSentMonth, LastSentYear FROM EmailHistory WHERE ID = 1"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        lastSentMonth = Convert.ToInt32(reader("LastSentMonth"))
                        lastSentYear = Convert.ToInt32(reader("LastSentYear"))
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub UpdateLastSentMonthAndYear(connectionString As String, currentMonth As Integer, currentYear As Integer)
        Dim query As String = "UPDATE EmailHistory SET LastSentMonth = @CurrentMonth, LastSentYear = @CurrentYear WHERE ID = 1"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@CurrentMonth", currentMonth)
                command.Parameters.AddWithValue("@CurrentYear", currentYear)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function BuildEmailBody(devicesToRenew As List(Of DeviceInfo)) As String
        Dim emailBody As New StringBuilder()
        emailBody.AppendLine($"Greetings from the ISS system.")
        emailBody.AppendLine("")
        emailBody.AppendLine($"There are {devicesToRenew.Count} device(s) or contract(s) up for renewal this month:")
        emailBody.AppendLine("")

        For Each device In devicesToRenew
            emailBody.AppendLine($"   Serial Number: {device.SerialNo}")
            emailBody.AppendLine($"   Product Type: {device.ProdType}")
            emailBody.AppendLine($"   Purchase Date: {device.PurchaseDate}")
            emailBody.AppendLine($"   Location: {device.Location}")
            emailBody.AppendLine()
        Next

        emailBody.AppendLine("Please ensure that the devices mentioned are renewed promptly.")
        emailBody.AppendLine("Thank you for your attention to this matter.")
        emailBody.AppendLine("")
        emailBody.AppendLine("ISS System")
        Return emailBody.ToString()
    End Function

    Class DeviceInfo
        Public Property SerialNo As String
        Public Property ProdType As String
        Public Property PurchaseDate As String
        Public Property Location As String
    End Class
End Module

Imports MySql.Data.MySqlClient

Public Class LoginForm

    Private connectionString As String = "server=10.110.33.26;user id=Admin;password=s@nt3ch2;database=disposedcomputers"

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim username As String = UsernameTextBox.Text
        Dim password As String = PasswordTextBox.Text

        If AuthenticateUser(username, password) Then
            Dim MainPageForm As New NewMainForm(username)
            AddHandler MainPageForm.FormClosed, AddressOf MainPageFormClosed
            MainPageForm.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid username or password. Please try again.")
        End If
    End Sub


    Private Function AuthenticateUser(username As String, password As String) As Boolean
        Dim query As String = "SELECT * FROM users1 WHERE username = @username AND password = @password"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)

                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        Return True
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Return False
    End Function

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PasswordTextBox.UseSystemPasswordChar = True
        Dim connectionString As String = "server=10.110.33.26;user id=Admin;password=s@nt3ch2;database=disposedcomputers"
        EmailHelper.CheckAndSendRenewalEmail(connectionString)
    End Sub

    Private Sub MainPageFormClosed(sender As Object, e As FormClosedEventArgs)
        Application.Exit()
    End Sub

    Private Sub enterPressTextBox_TextChanged(sender As Object, e As KeyPressEventArgs) Handles UsernameTextBox.KeyPress, PasswordTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LoginButton_Click(sender, e)
        End If
    End Sub


End Class

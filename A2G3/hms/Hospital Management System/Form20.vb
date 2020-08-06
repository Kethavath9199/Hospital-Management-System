Imports System.Security.Cryptography
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports System.Net.Mail
Imports System.Net

Public Class Form20
    Dim con As New OleDbConnection
#Region "Functions"
    Private Function StringtoMd5(ByRef Content As String) As String
        Dim M5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim ByteString() As Byte = System.Text.Encoding.ASCII.GetBytes(Content)
        ByteString = M5.ComputeHash(ByteString)
        Dim FinalString As String = Nothing

        For Each bt As Byte In ByteString
            FinalString &= bt.ToString("x2")
        Next
        Return FinalString.ToUpper()
    End Function
#End Region

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        DateTimePicker1.Value = Now.Date()
        ComboBox1.Text = ""
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox7.Clear()
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close_Form.Click
        Me.Close()
        ' Form8.Show()
    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Try
            TextBox1.Text = TextBox1.Text.Trim()
            ' If any of the required fields is empty, displaying an error message and exiting from the sub
            If ComboBox1.Text = "" Or DateTimePicker1.Text = "" Or TextBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
                MessageBox.Show("Can't leave any field empty", "Empty Field")
                Exit Sub
            End If

            Dim nam As String = TextBox1.Text

            ' Restricting the length of the name input to 50 characters
            If nam.Length > 50 Then
                MessageBox.Show("Name can't be more than 50 characters long", "Too long name")
                Exit Sub
            Else

                ' The patient name should contain only alphabets and no extra spaces in between
                For i As Integer = 0 To nam.Length - 1
                    Console.WriteLine(nam(i))
                    If (Asc(nam(i)) >= Asc("A") And Asc(nam(i)) <= Asc("Z")) Or (Asc(nam(i)) >= Asc("a") And Asc(nam(i)) <= Asc("z")) Then
                        Continue For
                    ElseIf i < nam.Length - 1 Then
                        If nam(i) = " " And nam(i + 1) = " " Then
                            MessageBox.Show("Patient Name can not contain multiple spaces in between", "Not valid name")
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Patient Name can not contain digit or any special characters", "Not valid name")
                        Exit Sub
                    End If
                Next
            End If
            If TextBox4.Text.Length <> 10 Or TextBox4.Text.Contains(",") Or TextBox4.Text.Contains(".") Or TextBox4.Text.Contains("(") Or TextBox4.Text.Contains("-") Or TextBox4.Text.Contains(" ") Or Not IsNumeric(TextBox4.Text) Or TextBox4.Text.Contains("+") Then
                MessageBox.Show("Enter valid 10-digit mobile number without +91 or 0 in the beginning", "Invalid Input")
                Exit Sub
            End If
            con.Open()
            Dim username As String = TextBox5.Text
            Dim password As String = TextBox7.Text
            Dim query As String = ""
            query = "Select * From Patient_DataBase Where UserName = '" & username & "' "
            Dim cmd As New OleDbCommand(query, con)
            Dim reader As OleDbDataReader
            reader = cmd.ExecuteReader()
            Dim count As Integer = 0
            While (reader.Read)
                count += 1
            End While
            reader.Close()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            If (count >= 1) Then
                MessageBox.Show("Username Already Exist")
                TextBox5.Clear()

                con.Close()
                Exit Sub
            Else

                Dim insertString As String = "Insert into Patient_DataBase([Name],[DOB],[Gender],[UserName],[Password_Doc],[Phone_Number],[Email]) Values(?,?,?,?,?,?,?)"
                Dim command As OleDbCommand = New OleDbCommand(insertString, con)
                command.Parameters.Add(New OleDbParameter("Name", CType(TextBox1.Text, String)))
                command.Parameters.Add(New OleDbParameter("DOB", CType(DateTimePicker1.Text, String)))
                command.Parameters.Add(New OleDbParameter("Gender", CType(ComboBox1.Text, String)))
                command.Parameters.Add(New OleDbParameter("UserName", CType(TextBox5.Text, String)))
                command.Parameters.Add(New OleDbParameter("Password_Doc", CType(StringtoMd5(TextBox7.Text), String)))
                command.Parameters.Add(New OleDbParameter("Phone_Number", CType(TextBox4.Text, String)))
                command.Parameters.Add(New OleDbParameter("Email", CType(TextBox6.Text, String)))

                command.ExecuteNonQuery()
                command.CommandText = "SELECT @@IDENTITY"
                MessageBox.Show("ID:" & command.ExecuteScalar & vbCrLf, "Added Successfully")
                Try
                    Dim email_doc As String = TextBox6.Text
                    Dim Smtp_Server As New SmtpClient
                    Dim email As New MailMessage
                    Smtp_Server.UseDefaultCredentials = False
                    Smtp_Server.Credentials = New Net.NetworkCredential("softwarelab20192@gmail.com", "software2019")
                    Smtp_Server.Port = 587
                    Smtp_Server.EnableSsl = True
                    Smtp_Server.Host = "smtp.gmail.com"
                    email = New MailMessage
                    email.From = New MailAddress("softwarelab20192@gmail.com")
                    email.To.Add(email_doc)
                    email.Subject = "Patient SignUp@IITG Hospital"
                    email.IsBodyHtml = True
                    email.Body = "Name:" & CType(TextBox1.Text, String) & vbCrLf & "DOB:" & CType(DateTimePicker1.Text, String) & "Gender" & CType(ComboBox1.Text, String) & vbCrLf & "UserName" & CType(TextBox5.Text, String) & vbCrLf & "Phone_Number" & CType(TextBox4.Text, String) & vbCrLf & "Email" & CType(TextBox6.Text, String) & vbCrLf & "We will always be by your side" & vbCrLf & "Regards" & vbCrLf & "I-CARE Hospital"
                    Smtp_Server.Send(email)
                    MessageBox.Show("Successfully sent confirmation email")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                command.Dispose()
                con.Close()

                'Dim smtp_server As New SmtpClient("10.3.3.42", "465")
                'Dim email As New MailMessage
                'smtp_server.UseDefaultCredentials = False
                'smtp_server.Credentials = New System.Net.NetworkCredential("rakeshcsetopper@gmail.com", "rakeshspa6")
                'smtp_server.EnableSsl = True


                'email.From = New MailAddress("rakeshcsetopper@gmail.com")
                'email.To.Add("prsrakeshgupta@gmail.com")
                'email.Subject = "Patient successfully added"
                'email.Body = "Name:" & CType(TextBox1.Text, String) & vbCrLf & "DOB:" & CType(DateTimePicker1.Text, String) & "Gender" & CType(ComboBox1.Text, String) & vbCrLf & "UserName" & CType(TextBox5.Text, String) & vbCrLf & "Phone_Number" & CType(TextBox4.Text, String) & vbCrLf & "Email" & CType(TextBox6.Text, String) & vbCrLf & "We will always be by your side" & vbCrLf & "Regards" & vbCrLf & "I-CARE Hospital"
                'email.IsBodyHtml = False
                'smtp_server.Send(email)
                'MessageBox.Show("successfull")
            End If
            'TextBox1.Clear()
            'DateTimePicker1.Clear()
            'ComboBox1.Clear()
            'TextBox4.Clear()
            'TextBox5.Clear()
            'TextBox7.Clear()
            'TextBox6.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox7.UseSystemPasswordChar = True Then
            TextBox7.UseSystemPasswordChar = False
        Else
            TextBox7.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Form20_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DateTimePicker1.Value = Now.Date
        DateTimePicker1.MinDate = Now.Date().AddYears(-130)
        DateTimePicker1.MaxDate = Now.Date
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        con.ConnectionString = connectionstring

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class
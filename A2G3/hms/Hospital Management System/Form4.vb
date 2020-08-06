Imports System.Data.OleDb
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Public Class Form14
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
    Dim con As New OleDbConnection
    Private Sub Clear(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.Controls.Clear()
        TextBox6.Clear()
        TextBox5.Clear()
        TextBox7.Clear()
    End Sub

    Private Sub Close_btn(sender As Object, e As EventArgs) Handles Button3.Click

        Form12.Enabled = True
        Me.Close()
    End Sub
    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        con.ConnectionString = connectionstring
    End Sub

    Private Sub Add(sender As Object, e As EventArgs) Handles Button1.Click
       
        ' Duplicate checking to be done
        ' Email sent

        If TextBox1.Text = "" Or ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox7.Text = "" Then
            MessageBox.Show("Can't leave any field empty", "Empty Field")
            Exit Sub
        ElseIf ComboBox1.SelectedItem <> "Emergency" And TextBox6.Text = "" Then
            MessageBox.Show("Can't leave any field empty", "Empty Field")
            Exit Sub
        Else
            If TextBox4.Text.Length <> 10 Or TextBox4.Text.Contains(",") Or TextBox4.Text.Contains(".") Or TextBox4.Text.Contains("(") Or TextBox4.Text.Contains("-") Or TextBox4.Text.Contains(" ") Or Not IsNumeric(TextBox4.Text) Or TextBox4.Text.Contains("+") Then
                MessageBox.Show("Enter valid 10-digit mobile number without +91 or 0 in the beginning", "Invalid Input")
                Exit Sub
            End If
            con.Open()
            Dim insertString As String = "Insert into Doctor_DataBase([Doc_Name],[Email],[PhoneNumber],[Department],[Address],[UserName],[Password_Doc],[OPD]) Values(?,?,?,?,?,?,?,?)"
            Dim cmd As OleDbCommand = New OleDbCommand(insertString, con)
            'cmd.Parameters.Add(New OleDbParameter("ID", CType(TextBox6.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Doc_Name", CType(TextBox1.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Email", CType(TextBox2.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("PhoneNumber", CType(TextBox4.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Department", CType(ComboBox1.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Address", CType(TextBox3.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("UserName", CType(TextBox5.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Password_Doc", CType(StringtoMd5(TextBox7.Text), String)))
            cmd.Parameters.Add(New OleDbParameter("OPD", CType(TextBox6.Text, String)))

            Try
                cmd.ExecuteNonQuery()
                cmd.CommandText = "SELECT @@IDENTITY"
                MessageBox.Show("ID" & cmd.ExecuteScalar.ToString, "Successfully Added")
                Try
                    Dim email_doc As String = TextBox2.Text
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
                    email.Body = "Name:" & CType(TextBox1.Text, String) & vbCrLf & "UserName" & CType(TextBox5.Text, String) & vbCrLf & "Regards" & vbCrLf & "I-CARE Hospital"
                    Smtp_Server.Send(email)
                    MessageBox.Show("Successfully sent confirmation email")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                cmd.Dispose()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                ComboBox1.Controls.Clear()
                TextBox5.Clear()
                TextBox7.Clear()
                TextBox6.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            con.Close()
            Me.Close()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox7.UseSystemPasswordChar = True Then
            TextBox7.UseSystemPasswordChar = False
        Else
            TextBox7.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Emergency" Then
            TextBox6.Text = ""
            TextBox6.Enabled = False
        Else
            TextBox6.Enabled = True
        End If
    End Sub
End Class
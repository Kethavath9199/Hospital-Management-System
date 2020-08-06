Imports System.Data.OleDb
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Public Class Form18
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
   
    Private Sub Form18_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        con.ConnectionString = connectionstring
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Can't leave any field empty", "Empty Field")
        End If
        If TextBox4.Text.Length <> 10 Or TextBox4.Text.Contains(",") Or TextBox4.Text.Contains(".") Or TextBox4.Text.Contains("(") Or TextBox4.Text.Contains("-") Or TextBox4.Text.Contains(" ") Or Not IsNumeric(TextBox4.Text) Or TextBox4.Text.Contains("+") Then
            MessageBox.Show("Enter valid 10-digit mobile number without +91 or 0 in the beginning", "Invalid Input")
            Exit Sub
        End If

        Dim insertString As String = "Insert into Pharmacist_DataBase([Phar_Name],[Email],[Phone],[Address]) Values(?,?,?,?)"
        Dim cmd As OleDbCommand = New OleDbCommand(insertString, con)
        cmd.Parameters.Add(New OleDbParameter("Phar_Name", CType(TextBox1.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Email", CType(TextBox2.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Phone", CType(TextBox4.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Address", CType(TextBox3.Text, String)))

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
                email.Body = "Name:" & CType(TextBox1.Text, String) & vbCrLf & "Successfully Added" & vbCrLf & "Regards" & vbCrLf & "I-CARE Hospital"
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

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        con.Close()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

   
End Class
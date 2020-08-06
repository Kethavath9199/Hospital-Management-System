Imports System.Net.Mail
Imports System.Net
Imports System.Data.OleDb
Imports System.IO
Public Class Form10
    Dim conn As New OleDbConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Try
            Dim appointed_doc As String = ""
            Dim doc_list As List(Of String) = SearchEmergencyDoctors()

            Console.WriteLine(doc_list(0))
            For Each doc In doc_list
                Console.WriteLine(doc)
                If Appoint_Doctor(doc) Then
                    appointed_doc = doc
                    Exit For
                End If
            Next
            If appointed_doc = "" Then
                MessageBox.Show("No Doctor available", "Sorry")
                conn.Close()
                Exit Sub
            End If

            Dim age As String = CType(ComboBox1.Text, String)
            Dim reason As String = CType(ComboBox2.Text, String)
            Dim dateofacc As String = Now.Date
            Dim timeofacc As String = Now.TimeOfDay.ToString
            Dim comp As String = "No"
            Dim insertString As String = "INSERT INTO Emergency_DataBase([Reason],[Age],[Accident_Date],[Accident_Time],[Appointed_Doctor],[Completed]) VALUES('" & reason & "','" & age & "','" & dateofacc & "','" & timeofacc & "','" & appointed_doc & "','" & comp & "')"
            Dim cmd As OleDbCommand = New OleDbCommand(insertString, conn)
            cmd.Parameters.Add(New OleDbParameter("Reason", CType(reason, String)))
            cmd.Parameters.Add(New OleDbParameter("Age", CType(age, String)))
            cmd.Parameters.Add(New OleDbParameter("Accident_Date", CType(dateofacc, String)))
            cmd.Parameters.Add(New OleDbParameter("Accident_Time", CType(timeofacc, String)))
            cmd.Parameters.Add(New OleDbParameter("Appointed_Doctor", CType(appointed_doc, String)))
            cmd.Parameters.Add(New OleDbParameter("Completed", CType(comp, String)))
            'ComboBox1.Text = ""
            'ComboBox2.Text = ""
            'ComboBox3.Text = ""
            'ComboBox4.Text = ""
            'ComboBox5.Text = ""
            'TextBox1.Clear()
            'TextBox2.Clear()
            '  Me.Close()
            Dim emergency_id As Integer
            Try
                ' Displaying the generated patient id and the chosen appointment details
                cmd.ExecuteNonQuery()
                cmd.CommandText = "SELECT @@IDENTITY"
                emergency_id = cmd.ExecuteScalar
                MessageBox.Show("Emergency ID:" & emergency_id & vbCrLf & "Doctor_Appointed:" & appointed_doc)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            'CODE TO SEND EMAIL TO DOCTOR
            Dim email_doc As String
            Dim dt As New DataTable
            Dim da As New OleDbDataAdapter
            da = New OleDbDataAdapter("Select * from Doctor_Database where Doc_Name like '%" & appointed_doc & "%' ", conn)
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                For Each column As DataColumn In dt.Columns
                    If column.ColumnName = "Email" Then
                        email_doc = row(column)
                    End If
                Next
            Next

            Try
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
                email.Subject = "Emergency_Situation@IITG Hospital"
                email.IsBodyHtml = True
                email.Body = "You are appointed with an Emergency case of ID:" & emergency_id & "We require your presence at utmost emergency"
                Smtp_Server.Send(email)
                MessageBox.Show("Message has been sent to the allocated doctor.We will be ready with the requiremnets")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Close()

        End Try
        conn.Close()

    End Sub


    Function SearchEmergencyDoctors() As List(Of String)
        Dim doc_list As New List(Of String)
        Dim flag As Boolean = False


        Try
            Dim query As String = "Select * From Doctor_DataBase where Department like 'Emergency'"

            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While (reader.Read())

                doc_list.Add(reader.GetString(1))
                ' MessageBox.Show(reader.GetString(4))
                flag = True
            End While

            reader.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return doc_list
    End Function
    Private Function Appoint_Doctor(doc) As String
        ' Dim doc As String



        Dim flag As Boolean = True
        Try
            Dim query As String = "Select * From Emergency_DataBase where Appointed_Doctor like '" & doc & "' and Completed like 'No'"
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While (reader.Read())
                'MessageBox.Show(reader.GetString(4)
                flag = False
            End While

            reader.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

        If flag = True Then
            Return True
        End If
        Return False
    End Function
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        conn.ConnectionString = connectionstring
    End Sub
End Class
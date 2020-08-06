Imports System.Security.Cryptography
Imports System.Data.OleDb
Imports System.Text
Imports System.IO
Imports System.Net.Mail

Public Class Form26
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

    Private Sub Form26_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED

        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        con.ConnectionString = connectionstring
    End Sub

    Private Function GetPassword(db As String, username As String) As String
        Dim str As String = ""
        Try

            con.Open()
            ' Dim res As String = DateTime.ParseExact(d, "DD-MM-YYYY", VBCodeProvider)

            Dim query As String = "Select * From " & db & " where UserName like '" & username & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(query, con)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While (reader.Read())
                If db = "Doctor_DataBase" Then
                    str = reader.GetString(8)
                Else
                    str = reader.GetString(5)
                End If

            End While

            reader.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()

        End Try
        Return str
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As String
        If GroupBox1.Text = "Doctor" Then
            db = "Doctor_DataBase"
        Else
            db = "Patient_DataBase"
        End If
        Try
            Dim str As String = GetPassword(db, TextBox4.Text)
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
                MessageBox.Show("Any field can't be empty")
                Exit Sub
            End If
            con.Open()
            Dim cm As OleDbCommand
            ' MessageBox.Show(.Text)

            Dim pass As String = StringtoMd5(TextBox2.Text)
            If StringtoMd5(TextBox1.Text) <> str Then
                MessageBox.Show("Wrong Old Password")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()

            ElseIf TextBox2.Text <> TextBox3.Text Then
                MessageBox.Show("New password entered wrong")
                TextBox2.Clear()
                TextBox3.Clear()
            Else

                cm = New OleDbCommand("UPDATE " & db & " SET Password_Doc ='" & pass & "'", con)
                MessageBox.Show("Successfully changed password")
                cm.ExecuteNonQuery()
                cm.Dispose()
            End If
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.UseSystemPasswordChar = True Then
            TextBox1.UseSystemPasswordChar = False
        Else
            TextBox1.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.UseSystemPasswordChar = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox3.UseSystemPasswordChar = True Then
            TextBox3.UseSystemPasswordChar = False
        Else
            TextBox3.UseSystemPasswordChar = True
        End If
    End Sub
End Class
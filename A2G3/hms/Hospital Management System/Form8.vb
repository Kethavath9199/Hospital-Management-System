
Imports System.Security.Cryptography
Imports System.Data.OleDb
Imports System.Text
Imports System.IO

Public Class Form8


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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim con As New OleDbConnection
            'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
            Dim path As String = Directory.GetCurrentDirectory
            path = Directory.GetParent(path).ToString
            path = Directory.GetParent(path).ToString
            Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

            con.ConnectionString = connectionstring

            Dim username As String = TextBox1.Text
            Dim password As String = CType(StringtoMd5(TextBox2.Text), String)
            Dim query As String = ""
            query = "Select * From Patient_DataBase Where Username = '" & username & "' And Password_Doc = '" & password & "'; "

            con.Open()
            Dim cmd As New OleDbCommand(query, con)
            Dim reader As OleDbDataReader
            reader = cmd.ExecuteReader()
            Dim count As Integer = 0
            While (reader.Read)
                count += 1
            End While
            con.Close()
            If (count <> 1) Then
                MessageBox.Show("Username or Password is incorrect!")
            Else
                Form41.Close()
                Form41.user.Text = TextBox1.Text
                Form41.Show()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.UseSystemPasswordChar = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form20.Show()
        Me.Hide()
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
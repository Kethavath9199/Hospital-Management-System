Imports System.Data.OleDb
Imports System.IO
Public Class Form19
    Dim con As New OleDbConnection
  

    Private Sub Form19_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        con.ConnectionString = connectionstring
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        con.Open()

        'Fetching the Information and adding it into the textboxes
        da = New OleDbDataAdapter("Select * from Pharmacist_DataBase where ID like '%" & TextBox6.Text & "%' ", con)

        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            For Each column As DataColumn In dt.Columns

                If column.ColumnName = "Phar_Name" Then
                    TextBox1.Text = row(column)
                End If
                If column.ColumnName = "Email" Then
                    TextBox2.Text = row(column)
                End If
                If column.ColumnName = "Address" Then
                    TextBox3.Text = row(column)
                End If
                If column.ColumnName = "Phone" Then
                    TextBox4.Text = row(column)
                End If
                

            Next
        Next
        con.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        con.Open()
        Dim cm As OleDbCommand


        Try
            cm = New OleDbCommand("UPDATE Pharmacist_DataBase SET Phone ='" & TextBox4.Text & "'  where ( ID Like '" & CInt(TextBox6.Text) & "' )", con)

            cm.ExecuteNonQuery()
            cm.Dispose()

            cm = New OleDbCommand("UPDATE Pharmacist_DataBase SET Email ='" & TextBox2.Text & "'  where ( ID Like '" & CInt(TextBox6.Text) & "' )", con)

            cm.ExecuteNonQuery()
            cm.Dispose()

            cm = New OleDbCommand("UPDATE Pharmacist_DataBase SET Address ='" & TextBox3.Text & "'  where ( ID Like '" & CInt(TextBox6.Text) & "' )", con)

            cm.ExecuteNonQuery()
            cm.Dispose()
            MessageBox.Show("Updated Successfully")


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        con.Close()
    End Sub

End Class
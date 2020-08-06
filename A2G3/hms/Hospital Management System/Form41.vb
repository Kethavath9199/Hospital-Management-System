Imports System.Data.OleDb
Imports System.IO

Public Class Form41
    Dim con As New OleDbConnection
    Private Sub Appointments_List()
        Try
            Dim dt As New DataTable
            Dim da As New OleDbDataAdapter
            'FlowLayoutPanel1.Controls.Clear()
            con.Open()

            da = New OleDbDataAdapter("Select * from Patient_DataBase where UserName like '" & user.Text & "'", con)
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                For Each column As DataColumn In dt.Columns

                    If column.ColumnName = "ID" Then
                        TextBox2.Text = row(column)
                    End If
                    If column.ColumnName = "Name" Then
                        nam.Text = row(column)
                    End If
                    If column.ColumnName = "DOB" Then
                        birth.Text = row(column)
                    End If
                    If column.ColumnName = "Phone_Number" Then
                        TextBox1.Text = row(column)
                    End If

                    If column.ColumnName = "Gender" Then
                        gen.Text = row(column)
                    End If
                    If column.ColumnName = "Email" Then
                        TextBox3.Text = row(column)
                    End If

                Next
            Next
            dt.Clear()






            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub


    Private Sub Appointments_List1()
        Try
            Dim dt As New DataTable
            Dim da As New OleDbDataAdapter
            'FlowLayoutPanel1.Controls.Clear()
            con.Open()

            da = New OleDbDataAdapter("Select * from Patient_DataBase where ID like '" & CInt(TextBox2.Text) & "'", con)
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                For Each column As DataColumn In dt.Columns

                    If column.ColumnName = "UserName" Then
                        user.Text = row(column)
                    End If
                    If column.ColumnName = "Name" Then
                        nam.Text = row(column)
                    End If
                    If column.ColumnName = "DOB" Then
                        birth.Text = row(column)
                    End If
                    If column.ColumnName = "Phone_Number" Then
                        TextBox1.Text = row(column)
                    End If

                    If column.ColumnName = "Gender" Then
                        gen.Text = row(column)
                    End If
                    If column.ColumnName = "Email" Then
                        TextBox3.Text = row(column)
                    End If

                Next
            Next
            dt.Clear()






            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Form41_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED

        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        con.ConnectionString = connectionstring

        If user.Text <> "" Then
            Appointments_List()
        ElseIf TextBox2.Text <> "" Then
            Appointments_List1()
        End If





        Appointments_List()
    End Sub

    
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Form23.Refresh()


            Form23.TextBox1.Text = Me.nam.Text
            Form23.TextBox1.Enabled = False
            Form23.ComboBox5.SelectedItem = Me.gen.Text
            Form23.ComboBox5.Enabled = False
            Form23.DateTimePicker2.Value = CType(Me.birth.Text, Date)
            Form23.DateTimePicker2.Enabled = False
            Form23.TextBox2.Text = Me.TextBox1.Text
            Form23.TextBox2.Enabled = False
            Form23.TextBox3.Text = Me.TextBox2.Text
            Form23.TextBox3.Enabled = False
            Me.Hide()
            Form23.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Form71.TextBox2.Text = CInt(TextBox2.Text)
            Form71.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
       
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Enabled = True
        TextBox3.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        con.Open()
        Dim cm As OleDbCommand
        MessageBox.Show(user.Text)


        cm = New OleDbCommand("UPDATE Patient_DataBase SET Phone_Number ='" & TextBox1.Text & "'  where ( ID Like '" & CInt(TextBox2.Text) & "' )", con)

        cm.ExecuteNonQuery()
        cm.Dispose()

        cm = New OleDbCommand("UPDATE Doctor_DataBase SET Email ='" & TextBox3.Text & "'  where ( ID Like '" & CInt(TextBox2.Text) & "' )", con)

        cm.ExecuteNonQuery()
        cm.Dispose()

        con.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form26.GroupBox1.Text = "Patient"
        Form26.TextBox4.Text = Me.user.Text
        Form26.Show()
    End Sub
End Class

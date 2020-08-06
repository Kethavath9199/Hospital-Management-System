Imports System.Data.OleDb
Imports System.IO

Public Class Form17

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

    Dim flag_select As Int16 = 0
    Dim con As New OleDbConnection
    Private Sub Appointments_List()
        Try
            Dim dt As New DataTable
            Dim da As New OleDbDataAdapter
            FlowLayoutPanel1.Controls.Clear()
            con.Open()

            da = New OleDbDataAdapter("Select * from Doctor_DataBase where ID like '%" & user.Text & "%' ", con)
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                For Each column As DataColumn In dt.Columns
                    If column.ColumnName = "UserName" Then
                        TextBox2.Text = row(column)
                    End If
                  

                    If column.ColumnName = "Doc_Name" Then
                        nam.Text = row(column)
                    End If
                    If column.ColumnName = "Department" Then
                        dept.Text = row(column)
                    End If
                    If column.ColumnName = "PhoneNumber" Then
                        pho.Text = row(column)
                    End If
                    If column.ColumnName = "Email" Then
                        mail.Text = row(column)
                    End If

                Next
            Next

            dt.Clear()
            If dept.Text = "Emergency" Then
                da = New OleDbDataAdapter("Select * from Emergency_DataBase where Appointed_Doctor like '%" & nam.Text & "%' and Completed like 'No'", con)
                da.Fill(dt)
                ComboBox1.Visible = False
                TextBox1.Visible = False
                Button8.Visible = False
                Label5.Text = "Appointments_List"
                Label7.Text = "*click to mark as completed"
                For Each row As DataRow In dt.Rows
                    Dim newpatient As New row_list_doc
                    For Each column As DataColumn In dt.Columns

                        If column.ColumnName = "ID" Then
                            newpatient.Text = "     Id  :   " & row(column).ToString
                        End If
                        If column.ColumnName = "Accident_Date" Then
                            newpatient.Text = newpatient.Text & "                 Date  :   " & row(column).ToString
                        End If

                    Next
                    FlowLayoutPanel1.Controls.Add(newpatient)
                Next

            Else
                If ComboBox1.Text = "Patient_Name" Then
                    da = New OleDbDataAdapter("Select * from Appointment_DataBase where Doctor_Name like '%" & nam.Text & "%' And  Patient_Name like '%" & TextBox1.Text & "%' ", con)
                    da.Fill(dt)
                ElseIf ComboBox1.Text = "Patient_ID" Then
                    da = New OleDbDataAdapter("Select * from Appointment_DataBase where Doctor_Name like '%" & nam.Text & "%' And Patient_ID like '%" & TextBox1.Text & "%' ", con)
                    da.Fill(dt)
                Else
                    da = New OleDbDataAdapter("Select * from Appointment_DataBase where Doctor_Name like '%" & nam.Text & "%' And  Date_Of_Appointment like '%" & TextBox1.Text & "%' ", con)
                    da.Fill(dt)
                End If

                For Each row As DataRow In dt.Rows
                    Dim newpatient As New row_list_doc
                    For Each column As DataColumn In dt.Columns

                        If column.ColumnName = "Patient_Name" Then
                            newpatient.Text = newpatient.Text & "                Patient_Name   :   " & row(column).ToString
                        End If
                        If column.ColumnName = "Patient_ID" Then
                            newpatient.Text = "     Patient_ID   :   " & row(column).ToString
                        End If
                        If column.ColumnName = "Date_Of_Appointment" Then
                            newpatient.Text = newpatient.Text & "                 Date  :   " & row(column).ToString
                        End If
                    Next
                    FlowLayoutPanel1.Controls.Add(newpatient)
                Next
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Form17_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED

        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"
        ComboBox1.Text = "Patient_ID"
        DateTimePicker1.Visible = False
        con.ConnectionString = connectionstring
        TextBox1.Clear()
        Appointments_List()
        flag_select = 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Date" Then
            DateTimePicker1.Visible = True
            TextBox1.Text = DateTimePicker1.Value.ToShortDateString
        Else
            DateTimePicker1.Visible = False
            TextBox1.Clear()
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Appointments_List()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If (flag_select = 1) Then
            TextBox1.Text = DateTimePicker1.Value.ToShortDateString
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mail.Enabled = True
        pho.Enabled = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        con.Open()
        Dim cm As OleDbCommand


        cm = New OleDbCommand("UPDATE Doctor_DataBase SET PhoneNumber ='" & pho.Text & "'  where ( ID Like '" & CInt(user.Text) & "' )", con)

        cm.ExecuteNonQuery()
        cm.Dispose()

        cm = New OleDbCommand("UPDATE Doctor_DataBase SET Email ='" & mail.Text & "'  where ( ID Like '" & CInt(user.Text) & "' )", con)

        cm.ExecuteNonQuery()
        cm.Dispose()

        con.Close()
    End Sub


    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form26.GroupBox1.Text = "Doctor"
        Form26.TextBox4.Text = Me.TextBox2.Text
        Form26.Show()
    End Sub
End Class
'----------------------------- CLASS FOR ADDING OBJECTS IN THE SEARCH LAYOUT PANEL ---------------------------------------  
Public Class row_list_doc
    Inherits Button

    Public Sub New()
        AutoSize = False
        Dock = DockStyle.Top
        BackColor = Color.AliceBlue
        FlatStyle = Windows.Forms.FlatStyle.Flat
        FlatAppearance.BorderSize = 0
        Margin = New Padding(4, 4, 4, 0)
        Size = New Size(525, 30)
        TextAlign = ContentAlignment.MiddleLeft

    End Sub
    Private Sub When_clicked() Handles Me.Click
        Try
            Dim con As New OleDbConnection
            'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED

            Dim path As String = Directory.GetCurrentDirectory
            path = Directory.GetParent(path).ToString
            path = Directory.GetParent(path).ToString
            Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"
            con.ConnectionString = connectionstring
            Dim cm As OleDbCommand
            Dim chec As String = "Yes"
            If Form17.dept.Text = "Emergency" Then
                Dim text_display As String = Me.Text
                Dim flag As Int16 = 0
                Dim text_array As Array = text_display.ToArray
                text_display = ""
                For i = 1 To text_array.Length() - 1
                    If text_array.GetValue(i) = "D" Then
                        Exit For
                    End If
                    If flag = 1 Then
                        text_display = text_display & text_array.GetValue(i)
                    End If
                    If text_array.GetValue(i) = ":" Then
                        flag = 1
                    End If

                Next
                text_display.Trim()

                con.Open()
                cm = New OleDbCommand("UPDATE  Emergency_DataBase SET Completed ='" & chec & "'  where  ( ID Like '" & CInt(text_display) & "' )", con)
                If MessageBox.Show("Are u sure,The case is Completed", "Warning", MessageBoxButtons.YesNo) = DialogResult.No Then
                    con.Close()
                    Exit Sub
                End If
                Try
                    cm.ExecuteNonQuery()
                    cm.Dispose()
                    MessageBox.Show("Marked As Completed")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                con.Close()
            Else
                Dim text_display As String = Me.Text
                Dim flag As Int16 = 0
                Dim flag_p As Int16 = 0
                Dim text_array As Array = text_display.ToArray
                text_display = ""
                For i = 1 To text_array.Length() - 1
                    If text_array.GetValue(i) = "P" And flag_p = 1 Then
                        Exit For
                    End If
                    If text_array.GetValue(i) = "P" And flag_p = 0 Then
                        flag_p = 1
                    End If
                    If flag = 1 Then
                        text_display = text_display & text_array.GetValue(i)
                    End If
                    If text_array.GetValue(i) = ":" Then
                        flag = 1
                    End If

                Next
                text_display.Trim()
                Form15.TextBox2.Text = CInt(text_display)
                Form15.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
       
    End Sub
End Class
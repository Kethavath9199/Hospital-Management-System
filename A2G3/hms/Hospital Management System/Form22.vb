Imports System.Data.OleDb
Imports System.IO

Public Class Form22
    Dim con As New OleDbConnection

    Private Sub Search_List()
        FlowLayoutPanel2.Controls.Clear()
        con.Open()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        If ComboBox1.Text = "Floor" Then
            da = New OleDbDataAdapter("Select * from RoomAllocation_Database where Floor_Number like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        ElseIf ComboBox1.Text = "Room_Number" Then
            da = New OleDbDataAdapter("Select * from RoomAllocation_Database where Room_Number like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        ElseIf ComboBox1.Text = "Patient_ID" Then
            da = New OleDbDataAdapter("Select * from RoomAllocation_Database where Patient_ID like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        ElseIf ComboBox1.Text = "Emergency_ID" Then
            da = New OleDbDataAdapter("Select * from RoomAllocation_Database where Emergency_ID like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        Else
            da = New OleDbDataAdapter("Select * from RoomAllocation_Database where Room_ID like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        End If

        For Each row As DataRow In dt.Rows
            Dim newpatient As New Dataroom
            For Each column As DataColumn In dt.Columns

                If column.ColumnName = "Patient_ID" Then
                    newpatient.Text = newpatient.Text & "          Patient_ID   :   " & row(column).ToString
                End If
                If column.ColumnName = "Emergency_ID" Then
                    newpatient.Text = newpatient.Text & "          Emergecny_ID   :   " & row(column).ToString
                End If
                If column.ColumnName = "Room_ID" Then
                    newpatient.Text = "     Room_ID   :   " & row(column).ToString
                End If

            Next
            FlowLayoutPanel2.Controls.Add(newpatient)
        Next

        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form22_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED

        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"
        ComboBox1.Text = "Patient_ID"
        con.ConnectionString = connectionstring
        Search_List()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Clear()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Search_List()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Clear()
    End Sub

    Private Sub clear_Click(sender As Object, e As EventArgs) Handles clear.Click
        TextBox2.Clear()
        TextBox5.Clear()
        TextBox4.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub add_item_Click(sender As Object, e As EventArgs) Handles add_item.Click
        con.Open()
        If TextBox2.Text = "" Or TextBox5.Text = "" Then
            MessageBox.Show("Can't leave Allocated field empty", "Empty Field")
        End If
        If TextBox5.Text > 5 Then
            MessageBox.Show("The floor number Cant exceed 5.")
            TextBox5.Clear()
            Exit Sub
        End If
        If TextBox2.Text > 40 Then
            MessageBox.Show("The Room number Cant exceed 40.")
            TextBox2.Clear()
            Exit Sub
        End If
        Dim room_id As Int16
        room_id = TextBox5.Text * 100 + TextBox2.Text

        Dim query As String = ""
        Dim count1 As Integer = 0
        Dim count2 As Integer = 0
        Dim count3 As Integer = 0
        Dim reader As OleDbDataReader
        Dim cmd As OleDbCommand
        Dim cmmd As OleDbCommand = New OleDbCommand
        Dim cm As OleDbCommand = New OleDbCommand

        query = "Select * From RoomAllocation_DataBase Where Room_ID Like '" & room_id & "' "
        cmd = New OleDbCommand(query, con)
        reader = cmd.ExecuteReader()
        While (reader.Read)
            count1 += 1
        End While

        query = "Select * From Patient_DataBase Where ID Like '" & TextBox4.Text & "' "
        cmd = New OleDbCommand(query, con)
        reader = cmd.ExecuteReader()
        While (reader.Read)
            count2 += 1
        End While

        query = "Select * From Emergency_DataBase Where ID Like '" & TextBox3.Text & "' "
        cmd = New OleDbCommand(query, con)
        reader = cmd.ExecuteReader()
        While (reader.Read)
            count3 += 1
        End While

        If (count1 >= 1) Then
            MessageBox.Show("Room Is Already Allocated.Check In The Search Function And re-enter")
            TextBox5.Clear()
            TextBox2.Clear()
        ElseIf ComboBox2.Text = "Normal_Patient" And count2 = 0 Then
            TextBox4.Clear()
            MessageBox.Show("The entered patient_ID doesnt exist")
        ElseIf ComboBox2.Text = "Emergency" And count3 = 0 Then
            TextBox3.Clear()
            MessageBox.Show("The entered Emergency_ID doesnt exist")
        Else
            Dim insertString As String

            insertString = "Insert into RoomAllocation_DataBase([Floor_Number],[Room_Number],[Patient_ID],[Emergency_ID]) Values(?,?,?,?)"
            cmd = New OleDbCommand(insertString, con)
            cmd.Parameters.Add(New OleDbParameter("Floor_Number", CType(TextBox5.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Room_Number", CType(TextBox2.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Patient_ID", CType(TextBox4.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Emergency_ID", CType(TextBox3.Text, String)))
            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                MessageBox.Show("Successfully added into roomallocation database")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            'Update the patient or Emergency DataBase also               
            If ComboBox2.Text = "Normal_Patient" Then
                cm = New OleDbCommand("UPDATE  Patient_DataBase SET Room_Allocated ='" & room_id & "'  where  ( ID like '" & TextBox4.Text & "' )", con)
            Else
                cm = New OleDbCommand("UPDATE  Emergency_DataBase SET Room_Allocated ='" & room_id & "'  where  ( ID like '" & TextBox3.Text & "' )", con)
            End If

            Try
                cm.ExecuteNonQuery()
                cm.Dispose()
                MessageBox.Show("Successfully added into the patient/emergency database")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
        con.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Normal_Patient" Then
            TextBox4.Enabled = True
        Else
            TextBox3.Enabled = False
        End If
    End Sub
End Class
'----------------------------- CLASS FOR ADDING OBJECTS IN THE SEARCH LAYOUT PANEL ---------------------------------------  
Public Class Dataroom
    Inherits Button

    Public Sub New()
        AutoSize = False
        Dock = DockStyle.Top
        BackColor = Color.AliceBlue
        FlatStyle = Windows.Forms.FlatStyle.Flat
        FlatAppearance.BorderSize = 0
        Margin = New Padding(4, 4, 4, 0)
        Size = New Size(602, 30)
        TextAlign = ContentAlignment.MiddleLeft

    End Sub

    Private Sub When_clicked() Handles Me.Click
    End Sub
End Class

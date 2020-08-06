Imports System.Data.OleDb
Imports System.IO

Public Class Form12
    'GLOBAL VARIABLES DECLARATION
    Dim Flag_select As String
    Dim con As New OleDbConnection
    Dim search_flag As Int16 = 0


    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED

        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        con.ConnectionString = connectionstring
    End Sub
    Private Sub Patients_List()
        FlowLayoutPanel2.Controls.Clear()
        con.Open()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        If ComboBox1.Text = "NAME" Then
            da = New OleDbDataAdapter("Select * from Patient_DataBase where Name like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        Else

            da = New OleDbDataAdapter("Select * from Patient_DataBase where ID like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        End If

        For Each row As DataRow In dt.Rows
            Dim newpatient As New Datalist
            For Each column As DataColumn In dt.Columns

                If column.ColumnName = "Name" Then
                    newpatient.Text = newpatient.Text & "              NAME   :   " & row(column).ToString
                End If
                If column.ColumnName = "ID" Then

                    newpatient.Text = "     ID   :   " & row(column).ToString
                End If

            Next
            FlowLayoutPanel2.Controls.Add(newpatient)
        Next

        con.Close()
    End Sub

    Private Sub Doctors_List()
        FlowLayoutPanel2.Controls.Clear()
        con.Open()

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        If ComboBox1.Text = "NAME" Then
            da = New OleDbDataAdapter("Select * from Doctor_DataBase where Doc_Name like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        Else

            da = New OleDbDataAdapter("Select * from Doctor_DataBase where ID like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        End If

        For Each row As DataRow In dt.Rows
            Dim newpatient As New Datalist
            For Each column As DataColumn In dt.Columns

                If column.ColumnName = "Doc_Name" Then
                    newpatient.Text = newpatient.Text & "              NAME   :   " & row(column).ToString
                End If
                If column.ColumnName = "ID" Then
                    newpatient.Text = "     ID   :   " & row(column).ToString
                End If

            Next
            FlowLayoutPanel2.Controls.Add(newpatient)
        Next
        con.Close()
    End Sub

    Private Sub Pharmacists_List()
        FlowLayoutPanel2.Controls.Clear()
        con.Open()

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        If ComboBox1.Text = "NAME" Then
            da = New OleDbDataAdapter("Select * from Pharmacist_DataBase where Phar_Name like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        Else

            da = New OleDbDataAdapter("Select * from Pharmacist_DataBase where ID like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        End If

        For Each row As DataRow In dt.Rows
            Dim newpatient As New Datalist
            For Each column As DataColumn In dt.Columns

                If column.ColumnName = "Phar_Name" Then
                    newpatient.Text = newpatient.Text & "              NAME   :   " & row(column).ToString
                End If
                If column.ColumnName = "ID" Then
                    newpatient.Text = "     ID   :   " & row(column).ToString
                End If

            Next
            FlowLayoutPanel2.Controls.Add(newpatient)
        Next
        con.Close()
    End Sub

    Private Sub Nurses_List()
        FlowLayoutPanel2.Controls.Clear()
        con.Open()

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        If ComboBox1.Text = "NAME" Then
            da = New OleDbDataAdapter("Select * from Nurse_DataBase where Nurse_Name like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        Else

            da = New OleDbDataAdapter("Select * from Nurse_DataBase where ID like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        End If

        For Each row As DataRow In dt.Rows
            Dim newpatient As New Datalist
            For Each column As DataColumn In dt.Columns

                If column.ColumnName = "Nurse_Name" Then
                    newpatient.Text = newpatient.Text & "              NAME   :   " & row(column).ToString
                End If
                If column.ColumnName = "ID" Then
                    newpatient.Text = "     ID   :   " & row(column).ToString
                End If

            Next
            FlowLayoutPanel2.Controls.Add(newpatient)
        Next

        con.Close()

    End Sub

    Private Sub Laboratarists_List()
        FlowLayoutPanel2.Controls.Clear()
        con.Open()

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        If ComboBox1.Text = "NAME" Then
            da = New OleDbDataAdapter("Select * from Laboratorist_DataBase where Lab_Name like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        Else

            da = New OleDbDataAdapter("Select * from Laboratorist_DataBase where ID like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        End If

        For Each row As DataRow In dt.Rows
            Dim newpatient As New Datalist
            For Each column As DataColumn In dt.Columns

                If column.ColumnName = "Lab_Name" Then
                    newpatient.Text = newpatient.Text & "              NAME   :   " & row(column).ToString
                End If
                If column.ColumnName = "ID" Then
                    newpatient.Text = "     ID   :   " & row(column).ToString
                End If

            Next
            FlowLayoutPanel2.Controls.Add(newpatient)
        Next

        con.Close()

    End Sub

    Private Sub Appointments_List()
        FlowLayoutPanel2.Controls.Clear()
        con.Open()

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        If ComboBox1.Text = "DOCTOR_NAME" Then
            da = New OleDbDataAdapter("Select * from Appointment_DataBase where Doctor_Name like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        ElseIf ComboBox1.Text = "PATIENT_NAME" Then
            da = New OleDbDataAdapter("Select * from Appointment_DataBase where Patient_Name like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        ElseIf ComboBox1.Text = "Department" Then
            da = New OleDbDataAdapter("Select * from Appointment_DataBase where Department like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        Else
            da = New OleDbDataAdapter("Select * from Appointment_DataBase where Patient_ID like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        End If

        For Each row As DataRow In dt.Rows
            Dim newpatient As New Datalist
            For Each column As DataColumn In dt.Columns

                If column.ColumnName = "Patient_Name" Then
                    newpatient.Text = newpatient.Text & "                PATIENT NAME   :   " & row(column).ToString
                End If
                If column.ColumnName = "ID" Then
                    newpatient.Text = "     ID   :   " & row(column).ToString
                End If
                If column.ColumnName = "Doctor_Name" Then
                    newpatient.Text = newpatient.Text & "                 DOCTOR NAME   :   " & row(column).ToString
                End If
            Next
            FlowLayoutPanel2.Controls.Add(newpatient)
        Next

        con.Close()
    End Sub

    Private Sub Users(sender As Object, e As EventArgs) Handles Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click
        Dim b As Button = sender
        'NORMAL SETTINGS OF COMBOBOX AND TEXTBOX FOR SEARCHING
        Label1.Text = "SEARCH " + b.Text + " BY"
        ComboBox1.Enabled = True
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("NAME")
        ComboBox1.Items.Add("ID_number")
        ComboBox1.Text = "ID_number"
        TextBox1.Enabled = True
        Flag_select = b.Text

        'Data Base Part
        For Each btn As Button In FlowLayoutPanel4.Controls         'For colour effect of the selected button
            btn.BackColor = SystemColors.GradientActiveCaption
        Next
        b.BackColor = Color.LightBlue
        FlowLayoutPanel2.Controls.Clear()

        search_flag = 0
        If b.Text = "Patients" Then                                  'Selecting based on which person the user wants
            Patients_List()
        ElseIf b.Text = "Doctors" Then
            Doctors_List()
        ElseIf b.Text = "Pharmacists" Then
            Pharmacists_List()
        ElseIf b.Text = "Nurses" Then
            Nurses_List()
        ElseIf b.Text = "Laboratorists" Then
            Laboratarists_List()
        End If

    End Sub


    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim b As Button = sender

        'NORMAL SETTINGS OF COMBOBOX AND TEXTBOX FOR SEARCHING
        Label1.Text = "SEARCH " + b.Text + " BY"
        ComboBox1.Enabled = True
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("DOCTOR_NAME")
        ComboBox1.Items.Add("PATIENT_NAME")
        ComboBox1.Items.Add("Appointment_number")
        ComboBox1.Items.Add("Department")
        ComboBox1.Text = "Appointment_number"
        TextBox1.Enabled = True
        Flag_select = b.Text
        'Data Base Part
        For Each btn As Button In FlowLayoutPanel4.Controls         'For colour effect of the selected button
            btn.BackColor = SystemColors.GradientActiveCaption
        Next
        b.BackColor = Color.LightBlue
        FlowLayoutPanel2.Controls.Clear()

        search_flag = 0
        Appointments_List()

    End Sub

    Private Sub add_button(sender As Object, e As EventArgs) Handles Button6.Click, Button7.Click
        Dim b As Button = sender
        If b.Text = "Add nurse" Then
            Form13.GroupBox1.Text = "Nurse Information"
        Else
            Form13.GroupBox1.Text = "Laboratorist Information"
        End If

        Form13.Show()
    End Sub

    Private Sub doctor_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form14.Show()
    End Sub

    Private Sub patient_Click(sender As Object, e As EventArgs)

        Form15.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Form23.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        search_flag = 1
        If Flag_select = "Appointments" Then   'Appointments
            Appointments_List()
        ElseIf Flag_select = "Doctors" Then    'Doctors
            Doctors_List()
        ElseIf Flag_select = "Patients" Then    'Patients
            Patients_List()
        ElseIf Flag_select = "Nurses" Then      'Nurses
            Nurses_List()
        ElseIf Flag_select = "Pharmacists" Then  'Pharmacists
            Pharmacists_List()
        Else                              'Laboratorists 

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Clear()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Form18.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Form22.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Me.Hide()
        Form20.Show()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Form31.Show()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Form24.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class

'----------------------------- CLASS FOR ADDING OBJECTS IN THE SEARCH LAYOUT PANEL ---------------------------------------  
Public Class Datalist
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
        Try
            Dim text_display As String = Me.Text
            Dim flag As Int16 = 0
            Dim text_array As Array = text_display.ToArray
            text_display = ""
            For i = 1 To text_array.Length() - 1
                If text_array.GetValue(i) = "N" Then
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

            If Form12.Label1.Text = "SEARCH Patients BY" Then
                Form41.TextBox2.Text = CInt(text_display)
                Form41.Show()
            End If
            If Form12.Label1.Text = "SEARCH Doctors BY" Then
                Form17.user.Text = CInt(text_display)
                Form17.Show()
            End If
            If Form12.Label1.Text = "SEARCH Pharmacists BY" Then
                Form19.TextBox6.Text = CInt(text_display)
                Form19.Show()
            End If
            If Form12.Label1.Text = "SEARCH Nurses BY" Then
                Form11.GroupBox2.Text = "Nurse Information"
                Form11.TextBox6.Text = CInt(text_display)
                Form11.Show()
            End If
            If Form12.Label1.Text = "SEARCH Laboratorists BY" Then
                Form11.GroupBox2.Text = "Laboratorist Information"
                Form11.TextBox6.Text = CInt(text_display)
                Form11.Show()
            End If
            If Form12.Label1.Text = "SEARCH Appointments BY" Then

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub

End Class

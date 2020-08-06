Imports System.Data.OleDb
Imports System.IO
Imports System.Net.Mail

Public Class Form23
    Dim conn As New OleDbConnection
    Private Sub Form23_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setting the background colour and the min,max and current dates of the two datetime pickers whenever the form is loaded
        Me.BackColor = Color.AliceBlue
        DateTimePicker1.Value = Now.Date
        DateTimePicker2.Value = Now.Date
        DateTimePicker1.MinDate = Now.Date.AddDays(1)
        DateTimePicker1.MaxDate = Now.Date().AddDays(7)
        DateTimePicker2.MinDate = Now.Date().AddYears(-130)
        DateTimePicker2.MaxDate = Now.Date
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED

        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        conn.ConnectionString = connectionstring
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Date_of_appointment.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub Send_Click(sender As Object, e As EventArgs) Handles Send.Click
    '    If txtfrom.Text.Length = 0 Then
    '        MessageBox.Show("Write a starting Mail Address,Else a common from default will be sent")
    '        txtfrom.Text &= "softwarelab25@gmail.com"
    '    End If
    '    If txtsub.Text.Length = 0 Then
    '        MessageBox.Show("Write a proper Subject,Else a common Subject will be sent")
    '        txtsub.Text &= "Need Help"
    '    End If
    '    If choose.Text = "Hospital" Then
    '        txtto.Text = "annanyapr@gmail.com"
    '    ElseIf choose.Text = "Fire Station" Then
    '        txtto.Text = "avira170101014@iitg.ac.in"
    '    ElseIf choose.Text = "Police" Then
    '        txtto.Text = "arany170101011@iitg.ac.in"
    '        'Else
    '        ' MessageBox.Show("Choose Atleast 1 from the above", "Error")
    '    End If
    'End Sub
    ' Function to search in the Appointment_Database with given field and value
    Function Search(field As String, input As String) As Boolean
        Dim flag As Boolean = False
        Try
            conn.Open()
            Dim query As String = "Select * From Appointment_DataBase where " & field & " like '" & input & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While (reader.Read())
                'MessageBox.Show(reader.GetString(4))
                flag = True
            End While

            reader.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()

        End Try
        If flag = True Then
            Return True
        End If
        Return False
    End Function


    Function SearchPatientID(id As Integer, nam As String, dob As Date) As Boolean
        Dim flag As Boolean = False
        Try
            conn.Open()
            Dim query As String = "Select * From Patient_DataBase where ID like '" & id & "' and Name like '" & nam & "' and DOB like '" & dob & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While (reader.Read())
                'MessageBox.Show(reader.GetString(4))
                flag = True
            End While

            reader.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()

        End Try
        If flag = True Then
            Return True
        End If
        Return False
    End Function


    ' Function to check if there is a conflict in terms of the appointment timing of a particular doctor at the selected time and slot  
    Function SearchConflict(selected_date As Date, time As String, doctor As String) As Boolean
        Dim flag As Boolean = False
        Try
            conn.Open()
            Dim query As String = "Select * From Appointment_DataBase where Date_of_Appointment like '" & selected_date & "' and Time_Slot like '" & time & "' and Doctor_Name like '" & doctor & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While (reader.Read())
                ' MessageBox.Show(reader.GetString(2))
                flag = True
            End While

            reader.Close()
            cmd.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()


        End Try
        If flag = True Then
            Return True
        End If
        Return False
    End Function

    ' Function to check availability of a particular doctor on a particular day 
    Function Anytime_available(selected_date As Date, doctor As String) As String

        ' First checks if available in the morning half, if not, then in the afternoon half
        If Before_available(selected_date, doctor) <> "" Then
            Return Before_available(selected_date, doctor)
        End If

        If After_available(selected_date, doctor) <> "" Then
            Return After_available(selected_date, doctor)
        End If

    End Function

    ' Function to check availability of a particular doctor on a particular day in the morning half. It makes the selection for the comboboxes 2 and 4 in the function itself.
    Function Before_available(selected_date As Date, doctor As String) As String
        ' If the doctor's OPD is not there on the given date, then return empty string
        If Not Is_Available(doctor, selected_date) Then
            Return ""
        End If
        If ComboBox2.Text = "" Or ComboBox2.Text = "Any Doctor" Then
            ComboBox4.Items.Clear()
            ComboBox4.Items.Add("9:00-9:10")
            ComboBox4.Items.Add("9:10-9:20")
            ComboBox4.Items.Add("9:20-9:30")
            ComboBox4.Items.Add("9:30-9:40")
            ComboBox4.Items.Add("9:40-9:50")
            ComboBox4.Items.Add("9:50-10:00")
            ComboBox4.Items.Add("10:00-10:10")
            ComboBox4.Items.Add("10:10-10:20")
            ComboBox4.Items.Add("10:20-10:30")
            ComboBox4.Items.Add("10:30-10:40")
            ComboBox4.Items.Add("10:40-10:50")
            ComboBox4.Items.Add("10:50-11:00")
            ComboBox4.Items.Add("11:00-11:10")
            ComboBox4.Items.Add("11:10-11:20")
            ComboBox4.Items.Add("11:20-11:30")
            ComboBox4.Items.Add("11:30-11:40")
            ComboBox4.Items.Add("11:40-11:50")
            ComboBox4.Items.Add("11:50-12:00")
            ComboBox4.Items.Add("12:00-12:10")
            ComboBox4.Items.Add("12:10-12:20")
            ComboBox4.Items.Add("12:20-12:30")
            ComboBox4.Items.Add("12:30-12:40")
            ComboBox4.Items.Add("12:40-12:50")
            ComboBox4.Items.Add("12:50-13:00")
        End If

        ' Checking for the different time slots one by one
        Dim time As String
        For i As Integer = 9 To 12

            time = i & ":00-" & i & ":10"
            If Not SearchConflict(selected_date, time, doctor) Then
                ComboBox4.SelectedItem = i & ":00-" & i & ":10"
                ComboBox2.SelectedItem = doctor
                '  Console.WriteLine(ComboBox4.SelectedItem)
                Return ComboBox4.SelectedItem
            End If
            For j As Integer = 10 To 40 Step 10
                time = i & ":" & j & "-" & i & ":" & j + 10
                If Not SearchConflict(selected_date, time, doctor) Then
                    ComboBox4.SelectedItem = i & ":" & j & "-" & i & ":" & j + 10
                    ComboBox2.SelectedItem = doctor
                    Return ComboBox4.SelectedItem
                End If
            Next
            time = i & ":50-" & i + 1 & ":00"
            If Not SearchConflict(selected_date, time, doctor) Then
                ComboBox4.SelectedItem = i & ":50-" & i + 1 & ":00"
                ComboBox2.SelectedItem = doctor
                Return ComboBox4.SelectedItem
            End If
        Next
        Return ""
    End Function

    ' Function to check availability of a particular doctor on a particular day in the afternoon half. It makes the selection for the comboboxes 2 and 4 in the function itself.
    Function After_available(selected_date As Date, doctor As String) As String
        ' If the doctor's OPD is not there on the given date, then return empty string
        If Not Is_Available(doctor, selected_date) Then
            Return ""
        End If
        ComboBox4.Items.Clear()

        ComboBox4.Items.Add("14:00-14:10")
        ComboBox4.Items.Add("14:10-14:20")
        ComboBox4.Items.Add("14:20-14:30")
        ComboBox4.Items.Add("14:30-14:40")
        ComboBox4.Items.Add("14:40-14:50")
        ComboBox4.Items.Add("14:50-15:00")
        ComboBox4.Items.Add("15:00-15:10")
        ComboBox4.Items.Add("15:10-15:20")
        ComboBox4.Items.Add("15:20-15:30")
        ComboBox4.Items.Add("15:30-15:40")
        ComboBox4.Items.Add("15:40-15:50")
        ComboBox4.Items.Add("15:50-16:00")
        ComboBox4.Items.Add("16:00-16:10")
        ComboBox4.Items.Add("16:10-16:20")
        ComboBox4.Items.Add("16:20-16:30")
        ComboBox4.Items.Add("16:30-16:40")
        ComboBox4.Items.Add("16:40-16:50")
        ComboBox4.Items.Add("16:50-17:00")

        ' Checking for the different time slots one by one
        Dim time As String
        For i As Integer = 14 To 16

            time = i & ":00-" & i & ":10"
            If Not SearchConflict(selected_date, time, doctor) Then
                ComboBox4.SelectedItem = i & ":00-" & i & ":10"
                ComboBox2.SelectedItem = doctor
                '  Console.WriteLine(ComboBox4.SelectedItem)
                Return ComboBox4.SelectedItem
            End If
            For j As Integer = 10 To 40 Step 10
                time = i & ":" & j & "-" & i & ":" & j + 10
                If Not SearchConflict(selected_date, time, doctor) Then
                    ComboBox4.SelectedItem = i & ":" & j & "-" & i & ":" & j + 10
                    ComboBox2.SelectedItem = doctor
                    Return ComboBox4.SelectedItem
                End If
            Next
            time = i & ":50-" & i + 1 & ":00"
            If Not SearchConflict(selected_date, time, doctor) Then
                ComboBox4.SelectedItem = i & ":50-" & i + 1 & ":00"
                ComboBox2.SelectedItem = doctor
                Return ComboBox4.SelectedItem
            End If
        Next
        Return ""
    End Function

    ' Checking if the given doctor has the OPD on the given date by looking into the Doctor_Database
    Function Is_Available(doctor As String, d As Date) As Boolean
        Dim flag As Boolean = False
        Try
            conn.Open()
            ' Dim res As String = DateTime.ParseExact(d, "DD-MM-YYYY", VBCodeProvider)

            Dim query As String = "Select * From Doctor_DataBase where OPD like '%" & d.DayOfWeek.ToString & "%' and Doc_Name like '" & doctor & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While (reader.Read())
                'MessageBox.Show(reader.GetString(4))
                flag = True
            End While

            reader.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()

        End Try
        Return flag
    End Function

    ' Function to make changes in the doctor drop down list according to the department chosen and according to the date chosen by confirming the OPD 
    Function changeDoctorList(dep As String) As Boolean
        Dim str As New List(Of String)()
        Dim flag As Boolean = False
        Try
            conn.Open()
            Dim query As String = "Select * From Doctor_DataBase where Department like '" & dep & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While (reader.Read())
                str.Add(reader.GetString(1))
                ' Console.WriteLine(reader.GetString(1))
                ' MessageBox.Show(reader.GetString(3).ToString)

            End While
            reader.Close()
            cmd.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
        ComboBox2.Items.Clear()
        For Each i In str
            If Is_Available(i, DateTimePicker1.Text) Then
                ComboBox2.Items.Add(i)
                flag = True
            End If
        Next
        Return flag
    End Function

    ' Function to make changes to the available slots according to the doctor chosen
    Function changeSlotList(doc As String) As Boolean

        ' First adding all the slots
        Dim str As New List(Of String)()
        Try
            If ComboBox3.Text <> "" And ComboBox3.Text <> "Anytime" And ComboBox1.Text <> "" Then
                ComboBox4.Items.Clear()
                ComboBox4.Enabled = True
                Select Case ComboBox3.Text
                    Case "Morning(9am-1pm)"
                        ComboBox4.Items.Add("9:00-9:10")
                        ComboBox4.Items.Add("9:10-9:20")
                        ComboBox4.Items.Add("9:20-9:30")
                        ComboBox4.Items.Add("9:30-9:40")
                        ComboBox4.Items.Add("9:40-9:50")
                        ComboBox4.Items.Add("9:50-10:00")
                        ComboBox4.Items.Add("10:00-10:10")
                        ComboBox4.Items.Add("10:10-10:20")
                        ComboBox4.Items.Add("10:20-10:30")
                        ComboBox4.Items.Add("10:30-10:40")
                        ComboBox4.Items.Add("10:40-10:50")
                        ComboBox4.Items.Add("10:50-11:00")
                        ComboBox4.Items.Add("11:00-11:10")
                        ComboBox4.Items.Add("11:10-11:20")
                        ComboBox4.Items.Add("11:20-11:30")
                        ComboBox4.Items.Add("11:30-11:40")
                        ComboBox4.Items.Add("11:40-11:50")
                        ComboBox4.Items.Add("11:50-12:00")
                        ComboBox4.Items.Add("12:00-12:10")
                        ComboBox4.Items.Add("12:10-12:20")
                        ComboBox4.Items.Add("12:20-12:30")
                        ComboBox4.Items.Add("12:30-12:40")
                        ComboBox4.Items.Add("12:40-12:50")
                        ComboBox4.Items.Add("12:50-13:00")
                    Case "Afternoon(2pm-5pm)"
                        ComboBox4.Items.Add("14:00-14:10")
                        ComboBox4.Items.Add("14:10-14:20")
                        ComboBox4.Items.Add("14:20-14:30")
                        ComboBox4.Items.Add("14:30-14:40")
                        ComboBox4.Items.Add("14:40-14:50")
                        ComboBox4.Items.Add("14:50-15:00")
                        ComboBox4.Items.Add("15:00-15:10")
                        ComboBox4.Items.Add("15:10-15:20")
                        ComboBox4.Items.Add("15:20-15:30")
                        ComboBox4.Items.Add("15:30-15:40")
                        ComboBox4.Items.Add("15:40-15:50")
                        ComboBox4.Items.Add("15:50-16:00")
                        ComboBox4.Items.Add("16:00-16:10")
                        ComboBox4.Items.Add("16:10-16:20")
                        ComboBox4.Items.Add("16:20-16:30")
                        ComboBox4.Items.Add("16:30-16:40")
                        ComboBox4.Items.Add("16:40-16:50")
                        ComboBox4.Items.Add("16:50-17:00")
                End Select
            End If

            ' If the user has chosen Any Doctor option, then excluding the slots which are not available for all the doctors
            If doc = "Any Doctor" Then
                For Each slot In ComboBox4.Items
                    Dim flag As Boolean = True
                    For Each d In ComboBox2.Items
                        If d = "Any Doctor" Then
                            Continue For
                        End If
                        If Not SearchConflict(DateTimePicker1.Text, slot, d) Then
                            flag = False
                            Console.WriteLine(flag)
                        End If
                    Next
                    If flag = True Then
                        str.Add(slot)
                    End If
                Next
                ' Otherwise excluding the slots already been taken up for the chosen doctor 
            Else
                conn.Open()
                Dim query As String = "Select * From Appointment_DataBase where Doctor_Name like '" & doc & "'"
                Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()
                While (reader.Read())
                    str.Add(reader.GetString(6))
                    ' Console.WriteLine(reader.GetString(6))
                    ' MessageBox.Show(reader.GetString(3).ToString)

                End While
                reader.Close()
                cmd.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
        For Each i In str
            ComboBox4.Items.Remove(i)
        Next

        ' If no slot is free then displaying a sorry message 
        ' ComboBox4.Enabled = True
        If ComboBox4.Items.Count = 0 Then
            ComboBox4.Enabled = False
            MessageBox.Show("The chosen doctor is not free on the selected half of the chosen date", "Sorry")
        End If
        '  Return flag
    End Function

    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click

        
        ' First trimming away the white space at the beginning and end of the patient's name

        TextBox1.Text = TextBox1.Text.Trim()
        ' If any of the required fields is empty, displaying an error message and exiting from the sub
        If ComboBox1.Text = "" Or DateTimePicker1.Text = "" Or TextBox1.Text = "" Or ComboBox3.Text = "" Or TextBox2.Text = "" Or ComboBox5.Text = "" Or DateTimePicker2.Text = "" Or ComboBox2.Text = "" Then
            MessageBox.Show("Can't leave any required field empty", "Empty Field")
            Exit Sub
        End If
        If TextBox3.Text = "" Then
            MessageBox.Show("Can't leave Patient_ID field empty, if new patient then first sign up")
            Exit Sub
        ElseIf Not SearchPatientID(TextBox3.Text, TextBox1.Text, DateTimePicker2.Text) Then
            MessageBox.Show("The entered id and patient details are not consistent with each other", "Wrong input")
            Exit Sub
        End If
        Dim nam As String = TextBox1.Text

        ' Restricting the length of the name input to 50 characters
        If nam.Length > 50 Then
            MessageBox.Show("Name can't be more than 50 characters long", "Too long name")
            Exit Sub
        Else

            ' The patient name should contain only alphabets and no extra spaces in between
            For i As Integer = 0 To nam.Length - 1
                Console.WriteLine(nam(i))
                If (Asc(nam(i)) >= Asc("A") And Asc(nam(i)) <= Asc("Z")) Or (Asc(nam(i)) >= Asc("a") And Asc(nam(i)) <= Asc("z")) Then
                    Continue For
                ElseIf i < nam.Length - 1 Then
                    If nam(i) = " " And nam(i + 1) = " " Then
                        MessageBox.Show("Patient Name can not contain multiple spaces in between", "Not valid name")
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Patient Name can not contain digit or any special characters", "Not valid name")
                    Exit Sub
                End If
            Next
        End If

        ' The mobile number has to be exactly 10 digits long and should contain only digits
        If TextBox2.Text.Length <> 10 Or TextBox2.Text.Contains(",") Or TextBox2.Text.Contains(".") Or TextBox2.Text.Contains("(") Or TextBox2.Text.Contains("-") Or TextBox2.Text.Contains(" ") Or Not IsNumeric(TextBox2.Text) Or TextBox2.Text.Contains("+") Then
            MessageBox.Show("Enter valid 10-digit mobile number without +91 or 0 in the beginning", "Invalid Input")
            Exit Sub
        End If

        'If Search("Patient_Name", TextBox1.Text) Then
        '    MessageBox.Show("Can't book multip", "Already exists")
        ' Double verification for not allowing overlapping appointments
        If (ComboBox2.Text <> "Any Doctor") And ComboBox4.Text <> "" And SearchConflict(DateTimePicker1.Text, ComboBox4.Text, ComboBox2.Text) Then
            MessageBox.Show("The selected doctor is not available at the chosen time slot.Please select another time or doctor")
        Else
            ' Selecting doctor and time slot in case it is not being mentioned by the user and allocating them to the user
            ' Also displaying sorry Message boxes if the chosen doctor or no doctor is free in the chosen time
            If (ComboBox2.Text = "Any Doctor") And (ComboBox4.Text <> "") Then
                For i As Integer = 1 To ComboBox2.Items.Count - 1
                    ComboBox2.SelectedIndex = i
                    If Not SearchConflict(DateTimePicker1.Text, ComboBox4.Text, ComboBox2.SelectedItem) Then
                        Exit For
                    End If
                Next
                ' ComboBox2.SelectedItem = "Any Doctor"

            ElseIf ComboBox4.Text = "" Then
                If ComboBox3.Text = "Anytime" Then
                    If ComboBox2.Text = "Any Doctor" Or ComboBox2.Text = "" Then
                        Dim flag As Boolean = False
                        For i As Integer = 1 To ComboBox2.Items.Count - 1
                            ComboBox2.SelectedIndex = i
                            If Anytime_available(DateTimePicker1.Text, ComboBox2.SelectedItem) <> "" Then
                                flag = True
                                Exit For
                            End If
                        Next
                        If flag = False Then
                            MessageBox.Show("No doctor free on the chosen day", "Sorry")
                            Exit Sub
                        End If
                        ' ComboBox2.SelectedItem = "Any Doctor"
                    Else
                        If Anytime_available(DateTimePicker1.Text, ComboBox2.SelectedItem) = "" Then
                            MessageBox.Show("The chosen doctor is not free on the chosen day", "Sorry")
                            Exit Sub
                        End If
                    End If
                ElseIf ComboBox3.Text = "Morning(9am-1pm)" Then
                    If ComboBox2.Text = "Any Doctor" Or ComboBox2.Text = "" Then
                        Dim flag As Boolean = False
                        For i As Integer = 1 To ComboBox2.Items.Count - 1
                            ComboBox2.SelectedIndex = i
                            If Before_available(DateTimePicker1.Text, ComboBox2.SelectedItem) <> "" Then
                                flag = True
                                Exit For
                            End If
                        Next
                        If flag = False Then
                            MessageBox.Show("No doctor free in the morning half", "Sorry")
                            Exit Sub
                        End If
                        ' ComboBox2.SelectedItem = "Any Doctor"
                    Else
                        If Before_available(DateTimePicker1.Text, ComboBox2.SelectedItem) = "" Then
                            MessageBox.Show("The chosen doctor is not free in the morning half", "Sorry")
                            Exit Sub
                        End If
                    End If
                Else
                    If ComboBox2.Text = "Any Doctor" Or ComboBox2.Text = "" Then
                        Dim flag As Boolean = False
                        For i As Integer = 1 To ComboBox2.Items.Count - 1
                            ComboBox2.SelectedIndex = i
                            If After_available(DateTimePicker1.Text, ComboBox2.SelectedItem) <> "" Then
                                flag = True
                                Exit For
                            End If
                        Next
                        If flag = False Then
                            MessageBox.Show("No doctor free in the afternoon half", "Sorry")
                            Exit Sub
                        End If
                        ' ComboBox2.SelectedItem = "Any Doctor"
                    Else
                        If After_available(DateTimePicker1.Text, ComboBox2.SelectedItem) = "" Then
                            MessageBox.Show("The chosen doctor is not free in the afternoon half", "Sorry")
                            Exit Sub
                        End If
                    End If
                End If
            End If

            ' Entering the details into the Appointment_DataBase
            Dim dep As String = CType(ComboBox1.Text, String)
            Dim predoc As String = CType(ComboBox2.Text, String)
            Dim predate As String = CType(DateTimePicker1.Text, String)
            Dim name As String = CType(TextBox1.Text, String)
            Dim pretime As String = CType(ComboBox4.Text, String)
            Dim number As String = CType(TextBox2.Text, String)
            Dim age As String = CType(DateTimePicker2.Text, String)
            Dim gender As String = CType(ComboBox5.Text, String)
            Dim patient_id As String = CType(TextBox3.Text, String)

            conn.Open()
            Dim insertString As String = "INSERT INTO Appointment_DataBase([Patient_Name],[DOB],[Gender],[Department],[Doctor_Name],[Date_of_Appointment],[Time_Slot],[Mobile_Number],[Patient_ID]) VALUES('" & name & "','" & age & "','" & gender & "','" & dep & "','" & predoc & "','" & predate & "','" & pretime & "','" & number & "','" & patient_id & "')"
            Dim cmd As OleDbCommand = New OleDbCommand(insertString, conn)
            cmd.Parameters.Add(New OleDbParameter("Patient_Name", CType(name, String)))
            cmd.Parameters.Add(New OleDbParameter("DOB", CType(age, String)))
            cmd.Parameters.Add(New OleDbParameter("Gender", CType(gender, String)))
            cmd.Parameters.Add(New OleDbParameter("Department", CType(dep, String)))
            cmd.Parameters.Add(New OleDbParameter("Doctor_Name", CType(predoc, String)))
            cmd.Parameters.Add(New OleDbParameter("Date_of_Appointment", CType(predate, String)))
            cmd.Parameters.Add(New OleDbParameter("Time_Slot", CType(pretime, String)))
            cmd.Parameters.Add(New OleDbParameter("Mobile_Number", CType(number, String)))
            cmd.Parameters.Add(New OleDbParameter("Patient_ID", CType(patient_id, String)))



            


            

            Try
                ' Displaying the generated patient id and the chosen appointment details
                cmd.ExecuteNonQuery()
                cmd.CommandText = "SELECT @@IDENTITY"
                Dim str As String = "Appointment_ID" & cmd.ExecuteScalar & vbCrLf & "Appointed Doctor: " & predoc & vbCrLf & predate & "  " & pretime
                MessageBox.Show("Appointment_ID" & cmd.ExecuteScalar & vbCrLf & "Appointed Doctor: " & predoc & vbCrLf & predate & "  " & pretime, "Successfully Added")
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
                    email.Body = str & vbCrLf & "Regards" & vbCrLf & "I-CARE Hospital"
                    Smtp_Server.Send(email)
                    MessageBox.Show("Successfully sent confirmation email")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                cmd.Dispose()

                ComboBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                ComboBox4.Text = ""
                ComboBox5.Text = ""
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                Me.Close()
            Catch ex As Exception

            End Try
            conn.Close()
        End If

    End Sub

    ' Button to return to the previous form
    Public Sub Back_Click(sender As Object, e As EventArgs)
        'Me.Hide()
        'Form12.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    ' Changing the entries of the doctor list whenever the selected department is changed
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' MessageBox.Show(SearchDoctor(ComboBox1.SelectedItem))
        If ComboBox1.Text <> "" And DateTimePicker1.Text <> "" Then
            ComboBox2.Enabled = True
            ' ComboBox4.Enabled = True
        End If
        ComboBox2.Items.Clear()

        If Not changeDoctorList(ComboBox1.SelectedItem) Then
            ComboBox2.Enabled = False
            MessageBox.Show("No doctors available for the selected date,please change the date", "Sorry")
            Submit.Enabled = False
        Else
            Submit.Enabled = True
            ComboBox2.Items.Insert(0, "Any Doctor")
        End If

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    ' Changing the selected slot and available slots if neededonce the selected doctor is changed
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox3.Text = "Anytime" Then
            Exit Sub
        End If
        If ComboBox3.Text <> "Anytime" Then
            ComboBox4.Enabled = True
        End If
        'If ComboBox4.Text <> "" Then
        '    Exit Sub
        'End If
        Dim temp As String = ComboBox4.Text
        If ComboBox2.Text <> "" And ComboBox2.Text <> "Any Doctor" And ComboBox4.Text <> "" Then
            If SearchConflict(DateTimePicker1.Text, ComboBox4.Text, ComboBox2.SelectedItem) Then
                ComboBox4.Text = ""
                ComboBox4.Items.Clear()
            End If
        End If

        changeSlotList(ComboBox2.SelectedItem)
        If temp <> "" And Not SearchConflict(DateTimePicker1.Text, temp, ComboBox2.SelectedItem) Then
            ComboBox4.SelectedItem = temp
        End If
        'If ComboBox3.Text <> "" And ComboBox3.Text <> "Anytime" And ComboBox1.Text <> "" Then
        '    ComboBox4.Items.Clear()
        '    ComboBox4.Enabled = True
        '    '  ComboBox4.Items.Add("Anytime")
        '    Select Case ComboBox3.Text
        '        Case "Morning(9am-1pm)"
        '            ComboBox4.Items.Add("9:00-9:10")
        '            ComboBox4.Items.Add("9:10-9:20")
        '            ComboBox4.Items.Add("9:20-9:30")
        '            ComboBox4.Items.Add("9:30-9:40")
        '            ComboBox4.Items.Add("9:40-9:50")
        '            ComboBox4.Items.Add("9:50-10:00")
        '            ComboBox4.Items.Add("10:00-10:10")
        '            ComboBox4.Items.Add("10:10-10:20")
        '            ComboBox4.Items.Add("10:20-10:30")
        '            ComboBox4.Items.Add("10:30-10:40")
        '            ComboBox4.Items.Add("10:40-10:50")
        '            ComboBox4.Items.Add("10:50-11:00")
        '            ComboBox4.Items.Add("11:00-11:10")
        '            ComboBox4.Items.Add("11:10-11:20")
        '            ComboBox4.Items.Add("11:20-11:30")
        '            ComboBox4.Items.Add("11:30-11:40")
        '            ComboBox4.Items.Add("11:40-11:50")
        '            ComboBox4.Items.Add("11:50-12:00")
        '            ComboBox4.Items.Add("12:00-12:10")
        '            ComboBox4.Items.Add("12:10-12:20")
        '            ComboBox4.Items.Add("12:20-12:30")
        '            ComboBox4.Items.Add("12:30-12:40")
        '            ComboBox4.Items.Add("12:40-12:50")
        '            ComboBox4.Items.Add("12:50-13:00")
        '        Case "Afternoon(2pm-5pm)"
        '            ComboBox4.Items.Add("14:00-14:10")
        '            ComboBox4.Items.Add("14:10-14:20")
        '            ComboBox4.Items.Add("14:20-14:30")
        '            ComboBox4.Items.Add("14:30-14:40")
        '            ComboBox4.Items.Add("14:40-14:50")
        '            ComboBox4.Items.Add("14:50-15:00")
        '            ComboBox4.Items.Add("15:00-15:10")
        '            ComboBox4.Items.Add("15:10-15:20")
        '            ComboBox4.Items.Add("15:20-15:30")
        '            ComboBox4.Items.Add("15:30-15:40")
        '            ComboBox4.Items.Add("15:40-15:50")
        '            ComboBox4.Items.Add("15:50-16:00")
        '            ComboBox4.Items.Add("16:00-16:10")
        '            ComboBox4.Items.Add("16:10-16:20")
        '            ComboBox4.Items.Add("16:20-16:30")
        '            ComboBox4.Items.Add("16:30-16:40")
        '            ComboBox4.Items.Add("16:40-16:50")
        '            ComboBox4.Items.Add("16:50-17:00")
        '    End Select
        'End If

        '    ComboBox4.Enabled = False
        '    MessageBox.Show("The chosen doctor is not free on the selected date,please change the date", "Sorry")
        '    Submit.Enabled = False
        'Else
        'For Each slot In ComboBox4.Items
        '    If SearchConflict(DateTimePicker1.Text, slot, ComboBox2.Text) Then
        '        ComboBox4.Items.Remove(slot)
        '    End If
        'Next
        'If ComboBox4.Items.Count = 0 Then
        '    ComboBox4.Enabled = False
        '    MessageBox.Show("The chosen doctor is not free on the selected date,please change the date", "Sorry")
        '    Submit.Enabled = False
        'Else
        '    Submit.Enabled = True
        '    ' ComboBox2.Items.Insert(0, "Any Doctor")
        'End If

    End Sub

    ' Enabling the department dropbox and changing the contents of the time slot drop box according to the chosen preferred time
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ComboBox1.Enabled = True
        ComboBox4.Items.Clear()
        If ComboBox3.Text = "Anytime" Then
            ComboBox4.Enabled = False

        ElseIf ComboBox3.Text <> "" Then
            If ComboBox2.Text <> "" Then
                ComboBox4.Enabled = True
            End If

            Select Case ComboBox3.Text
                Case "Morning(9am-1pm)"
                    ComboBox4.Items.Add("9:00-9:10")
                    ComboBox4.Items.Add("9:10-9:20")
                    ComboBox4.Items.Add("9:20-9:30")
                    ComboBox4.Items.Add("9:30-9:40")
                    ComboBox4.Items.Add("9:40-9:50")
                    ComboBox4.Items.Add("9:50-10:00")
                    ComboBox4.Items.Add("10:00-10:10")
                    ComboBox4.Items.Add("10:10-10:20")
                    ComboBox4.Items.Add("10:20-10:30")
                    ComboBox4.Items.Add("10:30-10:40")
                    ComboBox4.Items.Add("10:40-10:50")
                    ComboBox4.Items.Add("10:50-11:00")
                    ComboBox4.Items.Add("11:00-11:10")
                    ComboBox4.Items.Add("11:10-11:20")
                    ComboBox4.Items.Add("11:20-11:30")
                    ComboBox4.Items.Add("11:30-11:40")
                    ComboBox4.Items.Add("11:40-11:50")
                    ComboBox4.Items.Add("11:50-12:00")
                    ComboBox4.Items.Add("12:00-12:10")
                    ComboBox4.Items.Add("12:10-12:20")
                    ComboBox4.Items.Add("12:20-12:30")
                    ComboBox4.Items.Add("12:30-12:40")
                    ComboBox4.Items.Add("12:40-12:50")
                    ComboBox4.Items.Add("12:50-13:00")
                Case "Afternoon(2pm-5pm)"
                    ComboBox4.Items.Add("14:00-14:10")
                    ComboBox4.Items.Add("14:10-14:20")
                    ComboBox4.Items.Add("14:20-14:30")
                    ComboBox4.Items.Add("14:30-14:40")
                    ComboBox4.Items.Add("14:40-14:50")
                    ComboBox4.Items.Add("14:50-15:00")
                    ComboBox4.Items.Add("15:00-15:10")
                    ComboBox4.Items.Add("15:10-15:20")
                    ComboBox4.Items.Add("15:20-15:30")
                    ComboBox4.Items.Add("15:30-15:40")
                    ComboBox4.Items.Add("15:40-15:50")
                    ComboBox4.Items.Add("15:50-16:00")
                    ComboBox4.Items.Add("16:00-16:10")
                    ComboBox4.Items.Add("16:10-16:20")
                    ComboBox4.Items.Add("16:20-16:30")
                    ComboBox4.Items.Add("16:30-16:40")
                    ComboBox4.Items.Add("16:40-16:50")
                    ComboBox4.Items.Add("16:50-17:00")

            End Select
        End If
        ' If already a doctor has been selected then change the time slots available according to that
        If ComboBox2.Text <> "" Then
            changeSlotList(ComboBox2.Text)
        End If
    End Sub

    ' Changing the doctor list according to the chosen date considering the OPD list
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If ComboBox1.Text <> "" And DateTimePicker1.Text <> "" Then
            ComboBox2.Enabled = True
        End If
        If ComboBox1.Text = "" Then
            Exit Sub
        End If
        ' If no doctor is free then displaying a sorry message
        If Not changeDoctorList(ComboBox1.SelectedItem) Then
            ComboBox2.Enabled = False
            MessageBox.Show("No doctors available for the selected date,please change the date", "Sorry")
            Submit.Enabled = False
        Else
            Submit.Enabled = True
            ComboBox2.Items.Insert(0, "Any Doctor")
        End If
        'DateTimePicker1.MinDate = Now.Date()

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

        ' DateTimePicker2.MaxDate = Now.Date()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        '  ComboBox2.Enabled = True

        'Dim str As New List(Of String)()
        'Dim temp2 As String = ComboBox2.SelectedItem
        'Dim temp4 As String = ComboBox4.SelectedItem
        'If ComboBox2.Text <> "" And ComboBox2.Text <> "Any Doctor" Then
        '    If SearchConflict(DateTimePicker1.Text, ComboBox4.Text, ComboBox2.SelectedItem) Then
        '        ComboBox2.Text = ""
        '        ' ComboBox2.Items.Clear()
        '    End If
        'End If
        'changeDoctorList(ComboBox1.Text)
        'ComboBox2.Items.Insert(0, "Any Doctor")
        'For Each doc In ComboBox2.Items
        '    If doc = "Any Doctor" Then
        '        Continue For
        '    End If
        '    If SearchConflict(DateTimePicker1.Text, ComboBox4.Text, doc) Then
        '        str.Add(doc)
        '    End If
        'Next
        'For Each doc In str
        '    ComboBox2.Items.Remove(doc)
        'Next
        'If ComboBox2.Items.Count = 1 Then
        '    ComboBox2.Enabled = False
        '    MessageBox.Show("No doctor available in the chosen time slot", "Sorry")
        '    ' Submit.Enabled = False
        '    'Else
        '    '    ComboBox2.Enabled = True
        '    '    Submit.Enabled = True
        'End If
        'If Not SearchConflict(DateTimePicker1.Text, ComboBox4.Text, temp2) Then
        '    ComboBox2.SelectedItem = temp2
        'End If
        'ComboBox4.SelectedItem = temp4
        'If Not changeDoctorList(ComboBox1.SelectedItem) Then
        '    ComboBox2.Enabled = False
        '    MessageBox.Show("No doctors available for the selected date,please change the date", "Sorry")
        '    Submit.Enabled = False
        'Else
        '    For Each doc In ComboBox2.Items
        '        If doc = "Any Doctor" Then
        '            Continue For
        '        End If
        '        If SearchConflict(DateTimePicker1.Text, ComboBox4.Text, doc) Then
        '            str.Add(doc)
        '        End If
        '    Next
        '    For Each doc In str
        '        ComboBox2.Items.Remove(doc)
        '    Next
        '    If ComboBox2.Items.Count <= 1 Then
        '        ''ComboBox2.Enabled = False
        '        'MessageBox.Show("No doctors available for the selected date,please change the date", "Sorry")
        '        'Submit.Enabled = False
        '    Else
        '        Submit.Enabled = True
        '        ComboBox2.Items.Insert(0, "Any Doctor")
        '    End If
        '    If temp <> "" And temp <> "Any Doctor" And Not SearchConflict(DateTimePicker1.Text, ComboBox4.Text, temp) Then
        '        ComboBox2.SelectedItem = temp
        '    End If
        '    ComboBox4.SelectedItem = temp4
        'End If
    End Sub


End Class
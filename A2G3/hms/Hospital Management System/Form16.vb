Imports System.Data.OleDb
Imports System.IO
Public Class Form16
    Dim conn As New OleDbConnection
    Private Sub Form23_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        conn.ConnectionString = connectionstring
    End Sub
    Function Search(field As String, input As String) As Boolean
        Dim flag As Boolean = False
        Try
            conn.Open()
            Dim query As String = "Select * From Appointment_Database where " & field & " like '" & input & "'"
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

    Function SearchConflict(selected_date As Date, time As String, doctor As String) As Boolean
        Dim flag As Boolean = False
        Try
            conn.Open()
            Dim query As String = "Select * From Appointment_Database where Date_of_appointment like '" & selected_date & "' and Time_Slot like '" & time & "' and Doctor_Name like '" & doctor & "'"
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

    Function Anytime_available(selected_date As Date, doctor As String) As String
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
        Dim time As String
        For i As Integer = 9 To 16
            If i = 13 Then
                Continue For
            End If
            time = i & ":00-" & i & ":10"
            If Not SearchConflict(selected_date, time, doctor) Then
                ComboBox4.SelectedItem = i & ":00-" & i & ":10"
                '  Console.WriteLine(ComboBox4.SelectedItem)
                Return ComboBox4.SelectedItem
            End If
            For j As Integer = 10 To 40 Step 10
                time = i & ":" & j & "-" & i & ":" & j + 10
                If Not SearchConflict(selected_date, time, doctor) Then
                    ComboBox4.SelectedItem = i & ":" & j & "-" & i & ":" & j + 10
                    Return ComboBox4.SelectedItem
                End If
            Next
            time = i & ":50-" & i + 1 & ":00"
            If Not SearchConflict(selected_date, time, doctor) Then
                ComboBox4.SelectedItem = i & ":50-" & i + 1 & ":00"
                Return ComboBox4.SelectedItem
            End If
        Next
        Return ""
    End Function

    Function changeDoctorList(dep As String) As String
        Try
            conn.Open()
            Dim query As String = "Select * From Doctor_Database where Department like '" & dep & "'"
            Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While (reader.Read())
                ' MessageBox.Show(reader.GetString(3).ToString)
                ComboBox2.Items.Add(reader.GetString(1))
            End While
            reader.Close()
            cmd.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Function
    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        ' If Patient_ID.Text = "" Or Patient_Name.Text = "" Then

        ' Exception Handling is left
        ' Change Min and max date
        ' check doctor availability
        TextBox1.Text = TextBox1.Text.Trim()
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or DateTimePicker1.Text = "" Or TextBox1.Text = "" Or ComboBox3.Text = "" Or TextBox2.Text = "" Or ComboBox5.Text = "" Or DateTimePicker2.Text = "" Then
            MessageBox.Show("Can't leave any field empty", "Empty Field")
            Exit Sub
        End If
        Dim nam As String = TextBox1.Text
        If nam.Length > 50 Then
            MessageBox.Show("Too long name")
            Exit Sub
        Else

            For i As Integer = 0 To nam.Length - 1
                Console.WriteLine(nam(i))
                If (Asc(nam(i)) >= Asc("A") And Asc(nam(i)) <= Asc("Z")) Or (Asc(nam(i)) >= Asc("a") And Asc(nam(i)) <= Asc("z")) Then
                    Continue For
                ElseIf i < nam.Length - 1 Then
                    If nam(i) = " " And nam(i + 1) = " " Then
                        MessageBox.Show("Patient Name can not contain digit or any special characters")
                        Exit Sub
                    End If

                Else
                    MessageBox.Show("Patient Name can not contain digit or any special characters")
                    Exit Sub
                End If
            Next
        End If
        'TextBox3.Text = TextBox3.Text.Trim()
        'If TextBox3.Text.Length > 3 Or TextBox3.Text.Contains(",") Or TextBox3.Text.Contains(".") Or TextBox3.Text.Contains("(") Or TextBox3.Text.Contains("-") Or TextBox3.Text.Contains(" ") Or Not IsNumeric(TextBox3.Text) Or TextBox3.Text.Contains("+") Then
        '    MessageBox.Show("Enter valid age", "Invalid Input")
        '    Exit Sub
        'ElseIf CType(TextBox3.Text, Integer) > 150 Then
        '    MessageBox.Show("Enter valid age", "Invalid Input")
        '    Exit Sub
        'End If
        If TextBox2.Text.Length <> 10 Or TextBox2.Text.Contains(",") Or TextBox2.Text.Contains(".") Or TextBox2.Text.Contains("(") Or TextBox2.Text.Contains("-") Or TextBox2.Text.Contains(" ") Or Not IsNumeric(TextBox2.Text) Or TextBox2.Text.Contains("+") Then
            MessageBox.Show("Enter valid 10-digit mobile number without +91 or 0 in the beginning", "Invalid Input")
            Exit Sub
        End If

        If ComboBox3.Text <> "Anytime" And ComboBox4.Text = "" Then
            MessageBox.Show("Can't leave time field empty", "Empty Field")
        ElseIf Search("Patient_Name", TextBox1.Text) Then
            MessageBox.Show("Already exists")
        ElseIf ComboBox4.Text <> "" And SearchConflict(DateTimePicker1.Text, ComboBox4.Text, ComboBox2.Text) Then
            MessageBox.Show("The selected doctor is not available at the chosen time slot.Please select another time or doctor")
        Else
            If ComboBox3.Text = "Anytime" Then
                ComboBox4.Enabled = True
                If ComboBox2.SelectedItem = "Any Doctor" Then
                    For i As Integer = 1 To ComboBox2.Items.Count - 1
                        ComboBox2.SelectedIndex = i
                        If Anytime_available(DateTimePicker1.Text, ComboBox2.SelectedItem) <> "" Then
                            Exit For
                        End If
                    Next
                    ComboBox2.SelectedItem = "Any Doctor"
                Else
                    Anytime_available(DateTimePicker1.Text, ComboBox2.SelectedItem)
                End If

            ElseIf ComboBox2.SelectedItem = "Any Doctor" Then
                For i As Integer = 1 To ComboBox2.Items.Count - 1
                    ComboBox2.SelectedIndex = i
                    If Not SearchConflict(DateTimePicker1.Text, ComboBox4.Text, ComboBox2.SelectedItem) Then
                        Exit For
                    End If
                Next
                ComboBox2.SelectedItem = "Any Doctor"
            End If
            Dim dep As String = CType(ComboBox1.Text, String)
            Dim predoc As String = CType(ComboBox2.Text, String)
            Dim predate As String = CType(DateTimePicker1.Text, String)
            Dim name As String = CType(TextBox1.Text, String)
            Dim pretime As String = CType(ComboBox4.Text, String)
            Dim number As String = CType(TextBox2.Text, String)
            Dim age As String = CType(DateTimePicker2.Text, String)
            Dim gender As String = CType(ComboBox5.Text, String)

            conn.Open()
            Dim insertString As String = "INSERT INTO Appointment_Database([Patient_Name],[DOB],[Gender],[Department],[Doctor_Name],[Date_of_appointment],[Time_Slot],[Mobile_Number]) VALUES('" & name & "','" & age & "','" & gender & "','" & dep & "','" & predoc & "','" & predate & "','" & pretime & "','" & number & "')"
            Dim cmd As OleDbCommand = New OleDbCommand(insertString, conn)
            cmd.Parameters.Add(New OleDbParameter("Patient_Name", CType(name, String)))
            cmd.Parameters.Add(New OleDbParameter("DOB", CType(age, String)))
            cmd.Parameters.Add(New OleDbParameter("Gender", CType(gender, String)))
            cmd.Parameters.Add(New OleDbParameter("Department", CType(dep, String)))
            cmd.Parameters.Add(New OleDbParameter("Doctor_Name", CType(predoc, String)))
            cmd.Parameters.Add(New OleDbParameter("Date_of_appointment", CType(predate, String)))
            cmd.Parameters.Add(New OleDbParameter("Time_Slot", CType(pretime, String)))
            cmd.Parameters.Add(New OleDbParameter("Mobile_Number", CType(number, String)))
            Me.Hide()
            Try
                cmd.ExecuteNonQuery()
                cmd.CommandText = "SELECT @@IDENTITY"
                MessageBox.Show("Patient_ID" & cmd.ExecuteScalar + 1000, "Successfully Added")
                conn.Close()

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Me.Hide()
        Form12.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' MessageBox.Show(SearchDoctor(ComboBox1.SelectedItem))
        If ComboBox1.Text <> "" Then
            ComboBox2.Enabled = True
        End If
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("Any Doctor")
        changeDoctorList(ComboBox1.SelectedItem)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ComboBox4.Items.Clear()
        If ComboBox3.Text = "Anytime" Then
            ComboBox4.Enabled = False

        ElseIf ComboBox3.Text <> "" Then
            ComboBox4.Enabled = True
            ComboBox4.Items.Add("Any time")
            Select Case ComboBox3.Text
                Case "Morning"
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
                Case "Afternoon"
                    ComboBox4.Items.Add("12:00-12:10")
                    ComboBox4.Items.Add("12:10-12:20")
                    ComboBox4.Items.Add("12:20-12:30")
                    ComboBox4.Items.Add("12:30-12:40")
                    ComboBox4.Items.Add("12:40-12:50")
                    ComboBox4.Items.Add("12:50-13:00")
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
                Case "Evening"
                    ComboBox4.Items.Add("16:00-16:10")
                    ComboBox4.Items.Add("16:10-16:20")
                    ComboBox4.Items.Add("16:20-16:30")
                    ComboBox4.Items.Add("16:30-16:40")
                    ComboBox4.Items.Add("16:40-16:50")
                    ComboBox4.Items.Add("16:50-17:00")
            End Select
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker1.MinDate = Now.Date()
        DateTimePicker1.MaxDate = Now.Date().AddDays(7)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

        DateTimePicker2.MaxDate = Now.Date()
    End Sub
End Class
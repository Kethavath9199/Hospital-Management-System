Imports System.Data.OleDb
Imports System.IO

Public Class Form32
    Dim con As OleDbConnection = New OleDbConnection
    Private Sub bil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        con.ConnectionString = connectionstring
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles add.Click
        If num.Text = "" Or nam.Text = "" Then
            MessageBox.Show("Bill no and customer name can't be left empty")
            Exit Sub
        End If
        If phone.Text.Length <> 10 Or phone.Text.Contains(",") Or phone.Text.Contains(".") Or phone.Text.Contains("(") Or phone.Text.Contains("-") Or phone.Text.Contains(" ") Or Not IsNumeric(phone.Text) Or phone.Text.Contains("+") Then
            MessageBox.Show("Enter valid 10-digit mobile number without +91 or 0 in the beginning", "Invalid Input")
            Exit Sub
        End If
        list.Items.Clear()
        list.Visible = True
        list.Items.Add("Bill Number: " & num.Text & "")
        list.Items.Add("Costumer name: " & nam.Text & "")
        list.Items.Add("City:  " & city.Text & "")
        list.Items.Add("Contact No.:  " & phone.Text & "")
        list.Items.Add("Date:  " & dat.Value & "")
        list.Items.Add("")
        list.Items.Add("")
        list.Items.Add("Medicine Name     MRP     Quantity     Total value")
        list.Items.Add("")

        con.Open()

        Dim count As Integer = 0
        Dim cmd As OleDbCommand = New OleDbCommand


        cmd.Parameters.Add(cmd.CreateParameter).ParameterName = "Bill Number"
        cmd.Parameters.Item("Bill Number").Value = num.Text()
        cmd.Parameters.Add(cmd.CreateParameter).ParameterName = "Costumer Name"
        cmd.Parameters.Item("Costumer Name").Value = nam.Text
        cmd.Parameters.Add(cmd.CreateParameter).ParameterName = "Prescriptions"
        cmd.Parameters.Item("Prescriptions").Value = ""
        cmd.Parameters.Add(cmd.CreateParameter).ParameterName = "Total Amount"
        cmd.Parameters.Item("Total Amount").Value = "0"

        Try
            cmd.CommandText = "INSERT INTO Billing_DataBase (bill,name,phone,amount) VALUES ('" & num.Text() & "','" & nam.Text() & "','" & phone.Text & "',0 )"
            cmd.CommandType = CommandType.Text
            cmd.Connection = con

            cmd.ExecuteNonQuery()
            cmd.Dispose()

            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            num.Clear()

            con.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub gen_Click(sender As Object, e As EventArgs) Handles gen.Click

        Dim C As Integer
        list.Items.Clear()
        'num.Clear()
        'nam.Clear()
        'phone.Clear()
        'city.Clear()
        'id.Clear()
        'total.Clear()
        'quantit.Clear()
        'na.Clear()

        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand
        cmd.CommandText = "Select COUNT(*)  FROM  Billing_DataBase "
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        C = cmd.ExecuteScalar
        num.Text = C + 1


        con.Close()


    End Sub

    Private Sub list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ad.Click
        Dim C As Integer = 0
        Dim rate As Double
        Dim amount As Double
        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand
        Try
            cmd.CommandText = "Select quantity  FROM Pharmacy_DataBase where Eid='" & id.Text & "'And name='" & na.Text & "'"
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            C = cmd.ExecuteScalar


            If (C >= quantit.Text) Then
                cmd.CommandText = "Select rate  FROM  Pharmacy_DataBase where Eid='" & id.Text & "'And name='" & na.Text & "'"
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                rate = cmd.ExecuteScalar

                amount = rate * CDbl(quantit.Text)
                total.ReadOnly = False
                total.Text = CDbl(total.Text) + amount
                total.ReadOnly = True





                list.Items.Add("'" & na.Text & "'               '" & rate & "'          '" & quantit.Text & "'          '" & amount & "'")
               


                Dim count As Integer = CInt(quantit.Text)
                cmd.CommandText = "UPDATE   Pharmacy_DataBase SET quantity =quantity-'" & count & "'  where  ( name='" & na.Text & "' And Eid = '" & id.Text & "' )"
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                quantit.Clear()
                na.Clear()
                id.Clear()

            Else
                MessageBox.Show("Not proper quantity of medicines There are only '" & C & "' piece Left")
            End If
        Catch
            MsgBox("Something is missing")
        End Try
        con.Close()
    End Sub

    Private Sub complete_Click(sender As Object, e As EventArgs) Handles complete.Click
        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand
        cmd.CommandText = "UPDATE   Billing_DataBase SET amount ='" & total.Text & "'  where  (  bill = '" & num.Text & "' )"
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        list.Items.Add("")
        list.Items.Add("")
        list.Items.Add("                                                   Total Amount  '" & total.Text & "' ")
        na.Clear()
        id.Clear()
        quantit.Clear()

        total.Text = 0
        con.Close()
    End Sub



    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class
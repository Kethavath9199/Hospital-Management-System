Imports System.Data.OleDb
Imports System.IO
Public Class Form33
    Dim connection As New OleDbConnection
    Private Sub Form33_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"

        connection.ConnectionString = connectionstring
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles add_item.Click
        Dim id As String = eid.Text()
        Dim i As Integer = 0
        If Not (Len(id) = 7) Then
            If MessageBox.Show("Eid is not Properly Defined", "Eid Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
                Me.Close()
            Else
                eid.Text = ""
                Exit Sub
            End If
            Exit Sub
        End If



        For i = 0 To Len(id) - 1

            If i < 3 And (Asc(id(i)) < Asc("a") Or Asc("z") < Asc(id(i))) Then
                If MessageBox.Show("Eid should contain 3 name characters", "Eid Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
                    Me.Close()
                    Exit Sub
                Else
                    eid.Text = ""
                    Exit Sub
                End If
            End If
            If i > 2 And (Asc(id(i)) > Asc("9") Or Asc("0") > Asc(id(i))) Then
                If MessageBox.Show("Eid should contain last 4 number characters", "Inappropriate Primary value", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Cancel Then
                    Me.Close()
                    Exit Sub
                Else
                    eid.Text = ""
                    Exit Sub
                End If
            End If

        Next



        Dim cmd As OleDbCommand = New OleDbCommand

        connection.Open()

        cmd.Parameters.Add(cmd.CreateParameter).ParameterName = "name"
        cmd.Parameters.Item("name").Value = nam.Text()
        cmd.Parameters.Add(cmd.CreateParameter).ParameterName = "Eid"
        cmd.Parameters.Item("Eid").Value = eid.Text()
        cmd.Parameters.Add(cmd.CreateParameter).ParameterName = "rate"
        cmd.Parameters.Item("rate").Value = rate.Text()
        cmd.Parameters.Add(cmd.CreateParameter).ParameterName = "quantity"
        cmd.Parameters.Item("quantity").Value = quantity.Text()
        cmd.Parameters.Add(cmd.CreateParameter).ParameterName = "expiry"
        cmd.Parameters.Item("expiry").Value = dat.Text()
        Try
            cmd.CommandText = "INSERT INTO Pharmacy_DataBase (Eid,name,rate,quantity,expiry) VALUES ('" & eid.Text() & "','" & nam.Text() & "','" & rate.Text() & "','" & quantity.Text() & "','" & dat.Text() & "');"
            cmd.CommandType = CommandType.Text
            cmd.Connection = connection

            cmd.ExecuteNonQuery()
            cmd.Dispose()

            connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            eid.Clear()
            connection.Close()
            Exit Sub
        End Try

        MessageBox.Show("Successful Addition Of data", "Done")
        eid.Clear()
        nam.Clear()
        rate.Clear()
        quantity.Clear()
    End Sub

    Private Sub clear_Click(sender As Object, e As EventArgs) Handles clear.Click
        eid.Clear()
        nam.Clear()
        rate.Clear()
        quantity.Clear()

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
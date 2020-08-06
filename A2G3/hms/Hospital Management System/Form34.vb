Imports System.Data.OleDb
Imports System.IO

Public Class Form34
    Dim connection As New OleDbConnection

    Private Sub upd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"
        connection.ConnectionString = connectionstring
    End Sub

    Private Sub update_Click(sender As Object, e As EventArgs) Handles upda.Click
        connection.Open()

        Dim count As Integer = quantity.Text
        Dim cmd As OleDbCommand = New OleDbCommand
        Dim cmmd As OleDbCommand = New OleDbCommand
        Dim cm As OleDbCommand = New OleDbCommand

        cmd.CommandText = "Select COUNT(*) FROM Pharmacy_DataBase where  name='" & input.Text() & "' And Eid = '" & id.Text() & "' "
        cmd.CommandType = CommandType.Text
        cmd.Connection = connection

        cmmd.CommandText = "Select quantity FROM Pharmacy_DataBase where name='" & input.Text() & "' And Eid = '" & id.Text() & "' "
        cmmd.CommandType = CommandType.Text
        cmmd.Connection = connection

        cm.CommandText = "UPDATE  Pharmacy_DataBase SET quantity =quantity+'" & count & "'  where  ( name='" & input.Text() & "' And Eid = '" & id.Text() & "' )"
        cm.CommandType = CommandType.Text
        cm.Connection = connection
        If cmd.ExecuteScalar <> 0 Then

            ' MessageBox.Show("Your Medicine '" & input.Text() & "' is Present with quantity of '" & count & "' in data", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.None)
            cm.ExecuteNonQuery()
            cm.Dispose()
            MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.None)
        Else
            If MessageBox.Show("Invalid Combination Of name and Eid or they may be not present in the data", "Invalid Input", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
                Me.Close()
                Exit Sub
            Else
                id.Text = ""
                input.Text = ""
            End If
        End If
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        connection.Close()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        id.Clear()
        input.Clear()
        rate.Clear()
        quantity.Clear()
    End Sub
End Class
Imports System.Data.OleDb
Imports System.IO

Public Class Form35
    Dim con As New OleDbConnection

    Function availability()
        FlowLayoutPanel2.Controls.Clear()
        con.Open()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        If ComboBox1.Text = "NAME" Then
            da = New OleDbDataAdapter("Select * from Pharmacy_DataBase where name like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        Else

            da = New OleDbDataAdapter("Select * from Pharmacy_DataBase where Eid like '%" & TextBox1.Text & "%' ", con)
            da.Fill(dt)
        End If

        For Each row As DataRow In dt.Rows
            Dim newpatient As New Datarow_list
            For Each column As DataColumn In dt.Columns

                If column.ColumnName = "name" Then
                    newpatient.Text = newpatient.Text & "              NAME   :   " & row(column).ToString
                End If
                If column.ColumnName = "Eid" Then
                    newpatient.Text = "     Eid   :   " & row(column).ToString
                End If
                If column.ColumnName = "quantity" Then
                    newpatient.Text = newpatient.Text & "              Quantity   :   " & row(column).ToString
                End If

            Next
            FlowLayoutPanel2.Controls.Add(newpatient)
        Next

        con.Close()
    End Function

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ESTABLISHING THE CONNECTION STRING JUST AFTER THE FORM IS LOADED
        Dim path As String = Directory.GetCurrentDirectory
        path = Directory.GetParent(path).ToString
        path = Directory.GetParent(path).ToString
        Dim connectionstring As String = "provider=microsoft.ACE.OLEDB.12.0 ; data source = " & path & "\hms_Database.accdb"
        con.ConnectionString = connectionstring
        availability()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Clear()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        availability()
    End Sub
End Class
Public Class Datarow_list
    Inherits Button

    Public Sub New()
        AutoSize = False
        Dock = DockStyle.Top
        BackColor = Color.AliceBlue
        FlatStyle = Windows.Forms.FlatStyle.Flat
        FlatAppearance.BorderSize = 0
        Margin = New Padding(4, 4, 4, 0)
        Size = New Size(450, 30)
        TextAlign = ContentAlignment.MiddleLeft

    End Sub

    Private Sub When_clicked() Handles Me.Click

    End Sub
End Class
Public Class Form31


    Private Sub med_MouseHover(sender As Object, e As EventArgs) Handles med.MouseHover
        strip.Show(med, 0, med.Height)
    End Sub

    Private Sub Bill_Click(sender As Object, e As EventArgs) Handles Bill.Click
        Form32.Show()
    End Sub

    Private Sub Form31_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AddElementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddElementToolStripMenuItem.Click
        Form33.Show()
    End Sub

    Private Sub updateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles updateToolStripMenuItem.Click
        Form34.Show()
    End Sub

    Private Sub strip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles strip.Opening

    End Sub

    Private Sub CheckAvailabilityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckAvailabilityToolStripMenuItem.Click
        Form35.Show()
    End Sub
End Class
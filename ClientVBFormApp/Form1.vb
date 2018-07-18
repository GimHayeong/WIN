Imports ServerLib

Public Class Form1
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim a As Integer
        Dim b As Integer

        a = Convert.ToInt32(txtOp1.Text)
        b = Convert.ToInt32(txtOp2.Text)
        lblOp.Text = "+"

        txtResult.Text = IntCalc.Add(a, b)
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        Dim a As Integer
        Dim b As Integer

        a = Convert.ToInt32(txtOp1.Text)
        b = Convert.ToInt32(txtOp2.Text)
        lblOp.Text = "-"

        txtResult.Text = IntCalc.Sub(a, b)
    End Sub
End Class

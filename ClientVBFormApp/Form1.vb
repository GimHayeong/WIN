Imports CSCommonLib

'C#으로 작성된 라이브러리를 VB와 공용으로 사용하는 예
Public Class Form1
    'C#으로 작성된 라이브러리의 함수 호출
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim a As Integer
        Dim b As Integer

        a = Convert.ToInt32(txtOp1.Text)
        b = Convert.ToInt32(txtOp2.Text)
        lblOp.Text = "+"

        txtResult.Text = IntCalc.Add(a, b)
    End Sub

    'C#으로 작성된 라이브러리의 함수 호출
    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        Dim a As Integer
        Dim b As Integer

        a = Convert.ToInt32(txtOp1.Text)
        b = Convert.ToInt32(txtOp2.Text)
        lblOp.Text = "-"

        txtResult.Text = IntCalc.Sub(a, b)
    End Sub
End Class

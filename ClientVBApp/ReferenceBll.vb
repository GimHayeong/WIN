Imports CSCommonLib

'C#으로 작성된 라이브러리를 VB와 공용으로 사용하는 예
Public Class ReferenceBll
    'C#으로 작성된 라이브러리의 함수 호출
    Sub CallServerLib()
        Dim a As Integer
        Dim b As Integer
        a = 3
        b = 2

        Console.WriteLine("{0} + {1} = {2}", a, b, IntCalc.Add(a, b))
        Console.WriteLine("{0} - {1} = {2}", a, b, IntCalc.Sub(a, b))
    End Sub
End Class

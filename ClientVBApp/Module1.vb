Imports ServerLib

Module Module1

    Sub Main()
        Dim a As Integer
        Dim b As Integer
        a = 3
        b = 2

        Console.WriteLine("{0} + {1} = {2}", a, b, IntCalc.Add(a, b))
        Console.WriteLine("{0} - {1} = {2}", a, b, IntCalc.Sub(a, b))

        Console.ReadLine()
    End Sub

End Module

Module Module1

    Sub Main()
        CallBll()

        Console.ReadLine()
    End Sub

    Sub CallBll()
        Dim bll As ReferenceBll = New ReferenceBll
        bll.CallServerLib()
    End Sub

End Module

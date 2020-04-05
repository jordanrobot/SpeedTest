Imports System.Text

    Public Sub Main ()
        
        Dim test As SpeedTest = New SpeedTest()

        test.AddTest("StringAppendTest", AddressOf StringAppendTest)
        test.AddTest("StringBuilderTest", AddressOf StringBuilderTest)
        test.Iterations = 50
        test.RunTests()
        test.ShowResultsInDialog()

    End Sub

    Public Sub StringAppendTest()
        Dim x As String = "a"

        For i=0 to 1000
            x = x & i.toString
        Next i

    End Sub

    Public Sub StringBuilderTest()
        Dim x As StringBuilder = New StringBuilder
        
        For i=0 to 1000
            x.Append(i.toString)
        Next i
        Dim result As String
        result = x.ToString()

    End Sub

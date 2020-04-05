'</CollectorHeader>
Imports System.Text

Module SpeedTestTemplateHeader '<CollectorPrepend>'</CollectorPrepend>
    Public Sub Main ()
        
        Dim test As SpeedTest = New SpeedTest()

        test.AddTest("StringAppendTest", AddressOf TestOne)
        test.AddTest("StringBuilderTest", AddressOf TestTwo)
        test.Iterations = 50
        test.RunTests()
        test.ShowResultsInDialog()

    End Sub

    Public Sub TestOne()
 
    End Sub

    Public Sub TestTwo()

    End Sub

    End Module '<CollectorPrepend>'</CollectorPrepend>
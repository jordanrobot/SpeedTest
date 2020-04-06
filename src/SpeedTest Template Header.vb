'</CollectorHeader>
'### SpeedTest ###
'
'https://github.com/jordanrobot/SpeedTest
'MIT license

Module SpeedTestMain '<CollectorPrepend>'</CollectorPrepend>
    Public Sub Main ()
        
        Dim test As SpeedTest = New SpeedTest()

        test.AddTest("Test One", AddressOf TestOne)
        test.AddTest("Test Two", AddressOf TestTwo)
        test.Iterations = 500
        test.RunTests()
        test.ShowResultsInDialog()

    End Sub

    Public Sub TestOne()
        'Your code here!
    End Sub

    Public Sub TestTwo()
        'Your code here!
    End Sub

End Module '<CollectorPrepend>'</CollectorPrepend>
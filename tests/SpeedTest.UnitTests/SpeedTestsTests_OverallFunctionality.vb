Imports System.Text
Imports NUnit.Framework
Imports SpeedTest

'Namespace SpeedTest.UnitTests
    <TestFixture>
    Public Class SpeedTestsTestsOverallFunctionality

        <SetUp>
        Public Sub Setup()
        End Sub

        <Test>
        Public Sub SpeedTestOverall ()
        
            Dim test As SpeedTest = New SpeedTest()

            test.AddTest("StringAppendTest", (AddressOf StringAppendTest))
            test.AddTest("StringBuilderTest", (AddressOf StringBuilderTest))
            test.Iterations = 50
            test.RunTests()
            
            Assert.AreNotEqual(test.GetResults(),"What")
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

    End Class

'End Namespace
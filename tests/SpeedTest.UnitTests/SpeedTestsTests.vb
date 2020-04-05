Imports NUnit.Framework
Imports SpeedTest

'Namespace SpeedTest.UnitTests
    <TestFixture>
    Public Class SpeedTestsTests

        <SetUp>
        Public Sub Setup()
            Dim tempTest As SpeedTest = New SpeedTest()
            tempTest.AddTest("Message", AddressOf TwiddleOurThumbs)
        End Sub

        <Test>
        Public Sub SpeedTest_Results_IterationsIsNotBlank()
            Dim tempTest As SpeedTest = New SpeedTest()
            tempTest.AddTest("Message", AddressOf TwiddleOurThumbs)

            Assert.AreNotEqual(tempTest.Iterations, "")
        End Sub

        <Test>
        Public Sub SpeedTest_Results_IterationsIsChangeable()
            Dim tempTest As SpeedTest = New SpeedTest()
            tempTest.AddTest("Message", AddressOf TwiddleOurThumbs)
            tempTest.Iterations = 200

            Assert.AreEqual(tempTest.Iterations, 200)
        End Sub

        <Test>
        Public Sub SpeedTest_Results_ResultsAreBlankByDefault()
            Dim tempTest As SpeedTest = New SpeedTest()
            tempTest.AddTest("Message", AddressOf TwiddleOurThumbs)

            Assert.AreEqual(tempTest.GetResults, "")
        End Sub

        <Test>
        Public Sub SpeedTest_Results_ResultsAreNotBlankAfterRunTests()
            Dim tempTest As SpeedTest = New SpeedTest()
            tempTest.AddTest("Message", AddressOf TwiddleOurThumbs)
            tempTest.Iterations = 50
            tempTest.RunTests()

            Assert.AreNotEqual(tempTest.GetResults, "")
        End Sub

        Public Sub TwiddleOurThumbs()
            Dim x As String = ""
            x = x & "This "
            x = x & "is "
            x = x & "a "
            x = x & "filler "
            x = x & "sub."
        End Sub

    End Class

'End Namespace
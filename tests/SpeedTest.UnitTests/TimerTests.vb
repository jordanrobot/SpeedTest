Imports NUnit.Framework
Imports Timer

'Namespace Timer.UnitTests
    <TestFixture>
    Public Class TimerTest

        <SetUp>
        Public Sub Setup()

        End Sub

        <Test>
        Public Sub Timer_Results_IsNotBlank()
            Dim tempTimer As Timer = New Timer("Message")
            tempTimer.StartTimer()
            System.Threading.Thread.Sleep(15)
            tempTimer.StopTimer()

            Assert.AreNotEqual(tempTimer.Results, "")
        End Sub


    End Class

'End Namespace
'### SpeedTest ###
'
'https://github.com/jordanrobot/SpeedTest
'MIT license

'SpeedTest Sample
'
'This sample tests the performance difference between appending a string
' and using the StringBuilder class.  I've added comments to help explain
' how this works...

'This imports is only added because we're using the StringBuilder class
' in the below tests.  it is not required for the SpeedTest tool itself.
Imports System.Text

'This is the entry point of the program, this is one of three subroutines
' you can edit.
    Public Sub Main ()
        
        Dim test As SpeedTest = New SpeedTest()

        'Here we add a test to run at a later date.  The parameters
        ' consists of a string that will print in the results, and a
        ' the name of a subroutine to run.  This subroutine cannot
        ' return a value (function) or take input paramters at this
        ' time.  You can add as few or many tests as you'd like.
        test.AddTest("StringAppendTest", AddressOf StringAppendTest)
        test.AddTest("StringBuilderTest", AddressOf StringBuilderTest)
        
        'Here you can change the number of times each test is run.
        test.Iterations = 5000

        'This will run the speed tests in the order that they were
        ' added.
        test.RunTests()

        'This method will output the speed test times in a dialogue
        'box
        test.ShowResultsInDialog()

        'Alternatively, you can get the results as a string value
        ' like so.
        Dim result As String
        result = test.GetResults

    End Sub

    'Here we create the first subroutine that is run in a speed test.
    ' Again, this method cannot accept parameters or return a value
    ' at this time.  Future support may be added for that.
    Public Sub StringAppendTest()
        Dim x As String = "a"

        For i=0 to 1000
            x = x & i.toString
        Next i

    End Sub

    'Here we create the second subroutine that is run in a speed test.
    ' The same rules apply as stated for the first test subroutine.
    Public Sub StringBuilderTest()
        Dim x As StringBuilder = New StringBuilder
        
        For i=0 to 1000
            x.Append(i.toString)
        Next i
        Dim result As String
        result = x.ToString()

    End Sub

'And that's it!  Everything below is the boilerplate code that actually
' runs the tests.  If  you're curious, please look through it.

Public Class SpeedTest

    Public Delegate Sub CodeToExecute()
    Public Property Iterations As Integer = 1
    Private _results As String = ""
    Private _timers As Dictionary(Of Timer, CodeToExecute) = New Dictionary(Of Timer,CodeToExecute)

    Public Sub New()
    End Sub

    Public Sub AddTest(message As String, ByVal code As CodeToExecute)
        
        _timers.Add(New Timer(message), code)

    End Sub

    Public Sub RunTests()

        For Each timer As KeyValuePair(Of Timer, CodeToExecute) in _timers

           GC.WaitForPendingFinalizers
           GC.Collect

           timer.Key.StartTimer()
           For i = 0 To Iterations
               timer.Value.Invoke()
           Next i
           timer.Key.StopTimer()

           AppendResults(timer.Key.GetResults)
       Next timer
    End Sub

    Public Sub ShowResultsInDialog()
        System.Windows.Forms.Messagebox.Show(_results)
    End Sub

    Public Function GetResults() As String
        Return _results
    End Function

    Private Sub AppendResults(value As String)
        _results = _results & vbLf & value
    End Sub

End Class

Public Class Timer

    Private _stopwatch As Stopwatch = New Stopwatch()
    Private _timespan As TimeSpan
    Private _totalTime As String
    Private _message As String = ""
    Private _result As String = "Speed test has not been run."

    Public Sub New()
    End Sub

    Public Sub New(value As String)
        me._message = value
    End Sub

    Public Sub StartTimer()
        _stopwatch.Start()
    End Sub

    Public Sub StopTimer()
        _stopwatch.Stop()
        _timespan = _stopwatch.Elapsed
        _result = String.Format("{0:00}.{1:000} seconds", (_timespan.Hours * 3600) + (_timespan.Minutes*60) + _timespan.Seconds, _timespan.Milliseconds)
    End Sub

    Public Function GetResults() As String
        Return me._message & " Total Time: " & _result
    End Function

    Public Function GetMessage() As String
        Return me._message
    End Function
End Class
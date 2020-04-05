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
        _result = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", _timespan.Hours, _timespan.Minutes, _timespan.Seconds, _timespan.Milliseconds / 10)
    End Sub

    Public Function Results() As String
        Return me._message & " Total Time: " & _result
    End Function

End Class
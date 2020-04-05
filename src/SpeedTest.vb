Imports System.Windows.Forms

Public Class SpeedTest

    Public Property Iterations As Integer = 1
    Private _timers As List(Of Timer) = New List(Of Timer)
    Private _results As String = ""

    Public Sub New()
    End Sub

    Public Sub NewTimer(message As String)
        _timers.Add(New Timer(message))
    End Sub

    Public Sub RunTests()
       For Each _timer in _timers
           _timer.StartTimer()
           For i = 0 To Iterations
                'Execute user code here
               Dim x As Double
               x = (34452/12343)*323^(2/12)
           Next i
           _timer.StopTimer()

           AppendResults(_timer.Results)
       Next _timer
    End Sub

    Public Sub ShowResultsInDialog()
        Messagebox.Show(_results)
    End Sub

    Public Function Results() As String
        Return _results
    End Function

    Private Sub AppendResults(value As String)
        _results = _results & vbLf & value
    End Sub
End Class

'###   Performance Test: Test AddGroup with try/catch and looping to evaulate speed   ###'

Public Sub Main()

	Dim i As integer = 0
	Dim upperBound As Integer = 100
	Dim temp As string
	Dim group as CustomParameterGroup
	Dim groupName As String
	Dim paramGroups As CustomParameterGroups

	paramGroups = GetDocumentMembers

	Dim timerA As Timer = new Timer("try/catch")
	timerA.StartTimer()
		For i = 0 To upperBound
				
				groupName = "test" & i
		
				AddGroup(GroupName, paramGroups, group)
		Next i
	timerA.StopTimer()
	
	
	Dim timerB As Timer = new Timer("loop")
	timerB.StartTimer()
		For i = 0 To upperBound

				groupName = "zest" & i
			If DoesGroupExist(groupName, paramGroups) = false Then
				AddGroup2(groupName, paramGroups)
			End If
	
		Next i
	timerB.StopTimer()
	
	Dim timerC As Timer = new Timer("loop")
	timerC.StartTimer()
		For i = 0 To upperBound

				groupName = "crest" & i
			If DoesGroupExist2(groupName, paramGroups, group) = false Then
				AddGroup2(groupName, paramGroups)
			End If
	
		Next i
	timerC.StopTimer()

	msgbox(timerA.Value & vbLf & timerB.Value  & vbLf & timerC.Value )

End Sub


	Private Function GetDocumentMembers() As CustomParameterGroups
		Dim doc As Inventor.document = ThisDoc.Document
		Dim oParams As Parameters

		Select Case doc.DocumentType
			Case kPartDocumentObject, kAssemblyDocumentObject
				oParams = doc.ComponentDefinition.Parameters
			Case kDrawingDocumentObject
				oParams = doc.Parameters
			Case Else
				Throw New NotImplementedException
		End Select
		return oParams.CustomParameterGroups
	End Function


Private Function DoesGroupExist(value As String, paramGroups As Inventor.CustomParameterGroups) As Boolean
dim group As Inventor.CustomParameterGroup
	for each group in paramGroups
		if group.DisplayName = value Then
			return true
		end If
	next
	return false
End Function

Private Sub AddGroup2(groupName as String, paramGroups As Inventor.CustomParameterGroups)
	paramGroups.Add(groupName, groupName)
End Sub

Public Sub AddGroup(groupName As String, paramGroups As Inventor.CustomParameterGroups, group As Inventor.CustomParameterGroup)
	Try
		group = paramGroups.Item(groupName)
	Catch ex As ArgumentException
		group = paramGroups.Add(groupName, groupName)
	End Try
End Sub

Private Function DoesGroupExist2(value As String, paramGroups As Inventor.CustomParameterGroups, group As Inventor.CustomParameterGroup) As Boolean
	Try
		group = paramGroups.Item(groupName)
		return true
	Catch ex As ArgumentException
		return false
	End Try
End Function



Public Class Timer 'jordanrobot

    Private _totalTimer As Stopwatch = New Stopwatch()
    Private _totalTs As TimeSpan
    Private _totalTime As String
    Public Message As String = ""

    Public Sub New()
    End Sub

    Public Sub New(value As String)
        me.Message = value
    End Sub

    Public Sub StartTimer()
        _totalTimer.Start()
    End Sub

    Public Sub StopTimer()
        _totalTimer.Stop()
        _totalTs = _totalTimer.Elapsed
        _totalTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", _totalTs.Hours, _totalTs.Minutes, _totalTs.Seconds, _totalTs.Milliseconds / 10)
    End Sub

    Public Function Value() As String
        Return me.Message & " Total Time: " & _totalTime.ToString
    End Function

End Class
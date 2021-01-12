Imports SpeechLib
Module TTS
    Dim SpeakVoice As New SpeechLib.SpVoice
    Dim SpeakVoiceWordBook As New SpeechLib.SpVoice
    Dim DefaultVoice As Integer = 0
    Public Speaking As Boolean = False
    Public SpeakingWordBook As Boolean = False
    Public pause As Boolean = False
    Public pauseWordBook As Boolean = False

    Function GetTTSVoice() As ArrayList
        Dim x As New SpeechLib.SpVoice
        Dim arrVoices As SpeechLib.ISpeechObjectTokens = x.GetVoices
        Dim arrLst As New ArrayList
        For i As Integer = 0 To arrVoices.Count - 1
            arrLst.Add(arrVoices.Item(i).GetDescription)
        Next

        x = Nothing
        arrVoices = Nothing
        Return arrLst
    End Function

    Public Sub Replay(Optional ByRef mode As String = Nothing)
        If mode = Nothing Then
            pause = False
            SpeakVoice.Resume()
        ElseIf mode = "WordBook" Then
            pauseWordBook = False
            SpeakVoiceWordBook.Resume()
        End If
    End Sub

    Public Sub PauseAndPlay(Optional ByRef mode As String = Nothing)
        If pause = False And mode = Nothing Then
            pause = True
            SpeakVoice.Pause()
        ElseIf pause = False And mode = "WordBook" Then
            pauseWordBook = True
            SpeakVoiceWordBook.Pause()
        Else
            Replay(mode)
        End If

    End Sub

    Public Sub SetDefaultVoice(ByRef num As Integer)
        DefaultVoice = num
    End Sub

    Public Sub SpeechText(ByRef text As String, Optional ByRef optionvalue As Integer = 3, Optional ByRef mode As String = Nothing)
        If mode = Nothing Then
            SpeakVoice.Speak(text, optionvalue)
        ElseIf mode = "WordBook" Then
            SpeakVoiceWordBook.Speak(text, optionvalue)
        End If
    End Sub

    Function GetStatus(Optional ByRef mode As String = Nothing) As Boolean
        If mode = Nothing Then
            If SpeakVoice.Status.RunningState = SpeechLib.SpeechRunState.SRSEDone Then
                Return True
            End If
        ElseIf mode = "WordBook" Then
            If SpeakVoiceWordBook.Status.RunningState = SpeechLib.SpeechRunState.SRSEDone Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Sub SetTTSVoiceRate(Optional ByVal num As Integer = 0, Optional ByRef mode As String = Nothing)
        If mode = Nothing Then
            SpeakVoice.Rate = num
        ElseIf mode = "WordBook" Then
            SpeakVoiceWordBook.Rate = num
        End If
    End Sub


    Public Sub SetTTSVoice(ByVal num As Integer, Optional ByRef mode As String = Nothing)
        If num = Nothing Then
            num = DefaultVoice
        End If

        If mode = Nothing Then
            SpeakVoice.Voice = SpeakVoice.GetVoices.Item(num)
        ElseIf mode = "WordBook" Then
            SpeakVoiceWordBook.Voice = SpeakVoice.GetVoices.Item(num)
        End If
    End Sub

    Function TooltipTextSort(ByRef text As String)
        Return text.Replace(".", "").Replace("!", "").Replace(",", "")
    End Function
End Module
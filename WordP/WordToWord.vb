Imports System.IO
Public Class WordToWord
    Dim ProgramEnd As Boolean = False
    Dim Path As String = ""

    Private Sub WordToWord_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ProgramEnd = True
    End Sub

    Private Sub WordToWord_Load(sender As Object, e As EventArgs) Handles Me.Load
        ReadEEDic()
        ReadEKDic()

        Voice_List.DataSource = GetTTSVoice()
        If Voice_List.Items.Count = 0 Then
            MsgBox("설치된 TTS엔진이 없습니다.")
        End If

        If Voice_List.Items.Count <= 1 Then
            Voice_List.Enabled = False
        End If

        typeofdic.Items.Add("EngKor")
        typeofdic.Items.Add("EngEng")

        typeofdic.SelectedItem = "EngKor"
    End Sub

    Private Sub OpenFile_Btn_Click(sender As Object, e As EventArgs) Handles OpenFile_Btn.Click
        Dim file As String
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            file = OpenFileDialog.FileName
        Else
            Exit Sub
        End If

        OpenFile_Btn.Enabled = False
        All_Read_Btn.Enabled = False
        TrackBar_TTS.Enabled = False
        Stop_TTS.Enabled = False
        Save.Enabled = False
        typeofdic.Enabled = False
        WordSort.Enabled = False
        positionshow.Enabled = False
        Exshow.Enabled = False
        All_unselect.Enabled = False
        All_select.Enabled = False

        FileRead(file)

        wordlist.Items.Clear()
        positionlist.Items.Clear()

        For i = 0 To Index.Count - 1
            Dim temp As New ListViewItem
            temp.Text = Index(i).Word.spell

            If Index(i).Word.meaning = "검색결과를 찾을수 없습니다." Or Index(i).Word.meaning = "" Then
                temp.ForeColor = Color.Red
                temp.Group = wordlist.Groups(1)
            Else
                temp.ForeColor = Color.Black
                temp.Group = wordlist.Groups(0)
            End If

            wordlist.Items.Add(temp)

            temp = Nothing
        Next

        Path = OpenFileDialog.FileName.Replace(OpenFileDialog.SafeFileName, "")

        OpenFile_Btn.Enabled = True
        All_Read_Btn.Enabled = True
        TrackBar_TTS.Enabled = True
        Stop_TTS.Enabled = True
        Save.Enabled = True
        typeofdic.Enabled = True
        WordSort.Enabled = True
        positionshow.Enabled = True
        Exshow.Enabled = True
        All_unselect.Enabled = True
        All_select.Enabled = True

        file = Nothing
    End Sub

    Private Sub wordlist_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles wordlist.MouseDoubleClick
        SetTTSVoice(0, "WordBook")
        If Not wordlist.SelectedItems.Count = 0 Then
            SpeechText(wordlist.SelectedItems.Item(0).SubItems(0).Text, 3, "WordBook")
        End If
    End Sub

    Private Sub wordlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles wordlist.SelectedIndexChanged
        positionlist.Items.Clear()
        If Not wordlist.SelectedItems.Count = 0 Then
            For I = 0 To Index.Count - 1
                If Index(I).Word.spell = wordlist.SelectedItems.Item(0).SubItems(0).Text Then
                    Dim newWord As Word = SearchWordFuntion(wordlist.SelectedItems.Item(0).SubItems(0).Text, typeofdic.SelectedItem)
                    Dim List As List(Of Position) = Index(I).Position
                    Dim nwi As New Word_index
                    nwi.Word = newWord
                    nwi.Position = List

                    Index(I) = nwi

                    meaning.Text = newWord.meaning

                    Dim find As Boolean = False
                    For j = 0 To WordBook.Count - 1
                        If WordBook(j).spell = newWord.spell Then
                            find = True
                            Exit For
                        End If
                    Next

                    If Not find Then
                        WordBook.Add(newWord)
                    End If

                    find = Nothing
                    newWord = Nothing

                    nwi = Nothing
                    List = Nothing


                    For j = 0 To Index(I).Position.Count - 1
                        Dim temp As Position = Index(I).Position(j)
                        positionlist.Items.Add("Chap " & temp.Cp + 1 & ", Page " & temp.P + 1 & ", Par " & temp.Par + 1 & ", Sen " & temp.Sen + 1 & ", " & Contents(temp.Cp).page(temp.P).paragraph(temp.Par).sentance(temp.Sen).English)
                        temp = Nothing
                    Next

                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles SearchWord_btn.Click
        Dim str As String = SearchWord.Text

        Dim newWord As Word = SearchWordFuntion(str, typeofdic.SelectedItem)

        meaning.Text = newWord.meaning
        positionlist.Items.Clear()

        Dim find As Boolean = False
        For j = 0 To WordBook.Count - 1
            If WordBook(j).spell = str Then
                find = True
                Exit For
            End If
        Next

        If Not find Then
            WordBook.Add(newWord)
        End If

        find = Nothing
        newWord = Nothing
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Voice_List.SelectedIndexChanged
        SetDefaultVoice(Voice_List.SelectedIndex)
        SetTTSVoice(Nothing, "WordBook")
    End Sub

    Private Sub typeofdic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles typeofdic.SelectedIndexChanged
        If Not wordlist.SelectedItems.Count = 0 Then
            For I = 0 To Index.Count - 1
                If Index(I).word.spell = wordlist.SelectedItems.Item(0).SubItems(0).Text Then
                    Dim newWord As Word = SearchWordFuntion(wordlist.SelectedItems.Item(0).SubItems(0).Text, typeofdic.SelectedItem)
                    Dim List As List(Of Position) = Index(I).Position
                    Dim nwi As New Word_index
                    nwi.Word = newWord
                    nwi.Position = List

                    meaning.Text = newWord.meaning

                    Index(I) = nwi

                    newWord = Nothing
                    List = Nothing
                    nwi = Nothing
                    Exit Sub
                End If
            Next
        End If

    End Sub

    Private Sub All_select_Click(sender As Object, e As EventArgs) Handles All_select.Click
        For i = 0 To wordlist.Items.Count - 1
            wordlist.Items(i).Checked = True
        Next
    End Sub

    Private Sub All_unselect_Click(sender As Object, e As EventArgs) Handles All_unselect.Click
        For i = 0 To wordlist.Items.Count - 1
            wordlist.Items(i).Checked = False
        Next
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Dim filename As String = Path & "\" & Format(Now, "yyyy년 MM월 dd일") & "_saveword.txt"

        For i = 0 To wordlist.Items.Count - 1
            If wordlist.Items(i).Checked = True Then
                For j = 0 To Index.Count - 1
                    If Index(j).word.spell = wordlist.Items(i).SubItems(0).Text Then
                        Dim temp As String = Index(j).word.meaning
                        If temp = "검색결과를 찾을수 없습니다." Then
                            temp = ""
                        End If
                        File.AppendAllText(filename, Index(j).word.spell & " : " & temp & vbCrLf, System.Text.Encoding.Default)

                        For k = 0 To Index(j).Position.Count - 1
                            Dim tempT As String = vbTab

                            If Exshow.Checked = True Then
                                If Not tempT.Equals(vbTab) Then
                                    tempT += " : "
                                End If
                            End If

                            If Not tempT.Equals(vbTab) Then
                                File.AppendAllText(filename, tempT & vbCrLf, System.Text.Encoding.Default)
                            End If

                            tempT = Nothing
                        Next

                        temp = Nothing
                    End If
                Next
            End If

            System.Windows.Forms.Application.DoEvents()
        Next

        MsgBox("저장 완료")
    End Sub

    Private Sub All_Read_Btn_Click(sender As Object, e As EventArgs) Handles All_Read_Btn.Click
        If (All_Read_Btn.Text = "Read  ▶") Then
            All_Read_Btn.Text = "Read  ||"
        Else
            All_Read_Btn.Text = "Read  ▶"
        End If

        If Not SpeakingWordBook Then
            All_Read_Btn.Text = "Read  ||"
            SpeakingWordBook = True
            For i = 0 To wordlist.Groups.Count - 1
                For j = 0 To wordlist.Groups(i).Items.Count - 1
                    Dim sw As New Stopwatch
                    Dim time As Single = 0
                    sw.Start()
                    Dim saveColor As Color = wordlist.Groups(i).Items(j).ForeColor

                    wordlist.Groups(i).Items(j).Selected = True
                    wordlist.Select()

                    If i + 11 < wordlist.Groups(i).Items.Count - 1 Then
                        wordlist.Groups(i).Items(j + 11).EnsureVisible()
                    Else
                        'wordlist.Groups(i).Items(wordlist.Items.Count - 1).EnsureVisible()
                    End If

                    wordlist.Groups(i).Items(j).ForeColor = Color.Blue

                    For k = 0 To RepeatNum.Value
                        sw.Start()
                        If ProgramEnd = True Then
                            Exit Sub
                        End If

                        SpeechText(wordlist.Groups(i).Items(j).Text, 3, "WordBook")

                        Do Until GetStatus("WordBook") = True
                            If ProgramEnd = True Then
                                sw = Nothing
                                time = Nothing
                                saveColor = Nothing

                                Exit Sub
                            End If

                            If SpeakingWordBook = False Then
                                SpeechText(vbNullString, 2, "WordBook")
                                wordlist.Groups(i).Items(j).ForeColor = saveColor

                                sw = Nothing
                                time = Nothing
                                saveColor = Nothing

                                Exit Sub
                            End If
                            System.Windows.Forms.Application.DoEvents()
                        Loop

                        sw.Stop()
                        time = sw.ElapsedMilliseconds

                        sw.Restart()
                        Do Until sw.ElapsedMilliseconds > time
                            If ProgramEnd = True Then
                                sw = Nothing
                                time = Nothing
                                saveColor = Nothing
                                Exit Sub
                            End If

                            If SpeakingWordBook = False Then
                                SpeechText(vbNullString, 2, "WordBook")
                                wordlist.Groups(i).Items(j).ForeColor = saveColor
                                sw = Nothing
                                time = Nothing
                                saveColor = Nothing

                                Exit Sub
                            End If
                            System.Windows.Forms.Application.DoEvents()
                        Loop
                        sw.Stop()
                    Next

                    If Shadowing.Checked = True Then
                        sw.Restart()
                        Do Until sw.ElapsedMilliseconds > 1000 * ShadowingSEC.Value
                            If ProgramEnd = True Then
                                sw = Nothing
                                time = Nothing
                                saveColor = Nothing
                                Exit Sub
                            End If

                            If SpeakingWordBook = False Then
                                SpeechText(vbNullString, 2, "WordBook")
                                wordlist.Groups(i).Items(j).ForeColor = saveColor
                                sw = Nothing
                                time = Nothing
                                saveColor = Nothing

                                Exit Sub
                            End If
                            System.Windows.Forms.Application.DoEvents()
                        Loop
                        sw.Stop()

                    End If
                    wordlist.Groups(i).Items(j).ForeColor = saveColor

                    sw = Nothing
                    time = Nothing
                    saveColor = Nothing

                    wordlist.Groups(i).Items(j).Selected = False
                Next
            Next
        Else
            PauseAndPlay("WordBook")
        End If

    End Sub

    Private Sub Stop_TTS_Click(sender As Object, e As EventArgs) Handles Stop_TTS.Click
        SpeakingWordBook = False
    End Sub

    Private Sub positionlist_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles positionlist.MouseDoubleClick
        If Not positionlist.SelectedIndex = -1 Then
            Dim temps As String = positionlist.SelectedItem
            temps = Mid(temps, InStr(temps, "Sen ") + Len("Sent "))
            temps = Mid(temps, InStr(temps, ", ") + Len(", "))
            SpeechText(temps, 3, "WordBook")

            temps = Nothing
        End If
    End Sub

    Private Sub TrackBar_TTS_Scroll(sender As Object, e As EventArgs) Handles TrackBar_TTS.Scroll
        SetTTSVoiceRate(TrackBar_TTS.Value,)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim fileName As String = SaveFileDialog.FileName.ToString
            Dim tempE As String() = fileName.Split(".")
            Dim ext = tempE(tempE.Length - 1)
            tempE = Nothing

            For i = 0 To WordBook.Count - 1
                Dim temp As String = WordBook(i).meaning
                If temp = "검색결과를 찾을수 없습니다." Then
                    temp = ""
                End If

                File.AppendAllText(fileName, WordBook(i).spell & vbCrLf, System.Text.Encoding.Default)
                File.AppendAllText(fileName.Replace(ext, "") & "_meaning." & ext, WordBook(i).spell & " : " & temp & vbCrLf, System.Text.Encoding.Default)

                temp = Nothing
            Next

            ext = Nothing
            fileName = Nothing
        End If
    End Sub

    Private Sub SearchWord_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchWord.KeyDown
        If e.KeyValue = Keys.Enter Then
            Dim str As String = SearchWord.Text

            Dim newWord As Word = SearchWordFuntion(str, typeofdic.SelectedItem)

            meaning.Text = newWord.meaning
            positionlist.Items.Clear()

            Dim find As Boolean = False
            For j = 0 To WordBook.Count - 1
                If WordBook(j).spell = str Then
                    find = True
                    Exit For
                End If
            Next

            If Not find Then
                WordBook.Add(newWord)
            End If

            str = Nothing
            find = Nothing
            newWord = Nothing
        End If
    End Sub

    Private Sub WordSort_CheckedChanged(sender As Object, e As EventArgs) Handles WordSort.CheckedChanged
        If WordSort.Checked = True Then
            wordlist.Sorting = SortOrder.Ascending
        Else
            wordlist.Sorting = SortOrder.None
        End If

        wordlist.Items.Clear()
        positionlist.Items.Clear()

        For i = 0 To Index.Count - 1
            Dim temp As New ListViewItem
            temp.Text = Index(i).Word.spell

            If Index(i).Word.meaning = "검색결과를 찾을수 없습니다." Then
                temp.ForeColor = Color.Red
                temp.Group = wordlist.Groups(1)
            Else
                temp.ForeColor = Color.Black
                temp.Group = wordlist.Groups(0)
            End If

            wordlist.Items.Add(temp)

            temp = Nothing
        Next
    End Sub
End Class

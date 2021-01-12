Imports System.Text.RegularExpressions

Module Dic
    Public WordBook As New List(Of Word)
    Structure Word
        Dim spell As String
        Dim meaning As String
    End Structure

    Public EngKorDic As New List(Of Word)
    Public EngEngDic As New List(Of Word)

    Structure Initail_Index
        Dim Initail As Char
        Dim StartLine As Integer
    End Structure

    Dim Initail_EK_index_list As New List(Of Initail_Index)
    Dim Initail_EE_index_list As New List(Of Initail_Index)

    Function ReadEKDic(Optional ByRef name As String = "Naver+Concise") As Boolean
        Dim strLine As String
        Dim Filenum As Integer = (9 * Rnd()) + 1

        Dim Path As String = My.Computer.FileSystem.CurrentDirectory
        If InStr(Path, "\bin\Debug") > 0 Then
            Path = Replace(Path, "\bin\Debug", "")
        End If

        Try
            FileOpen(Filenum, Path & "\DicDB\" & name & " 영한사전.txt", OpenMode.Input)
        Catch ex As Exception
            Path = Nothing
            strLine = Nothing
            Filenum = Nothing
            Return False
        End Try

        Path = Nothing

        Dim line As Integer = 0
        Do While Not EOF(Filenum)
            strLine = LineInput(Filenum)
            Dim tempW As New Word
            Dim tempP As Integer = InStr(strLine, " = ")
            tempW.spell = Mid(strLine, 1, tempP).ToLower().Trim()

            Dim tempI As New Initail_Index
            Dim find As Boolean = False
            tempI.Initail = tempW.spell(0)

            For i = 0 To Initail_EK_index_list.Count - 1
                If tempI.Initail = Initail_EK_index_list(i).Initail Then
                    find = True
                    Exit For
                End If
            Next

            If find Then
                find = Nothing
                tempI = Nothing
            Else
                tempI.StartLine = line
                Initail_EK_index_list.Add(tempI)

                find = Nothing
                tempI = Nothing
            End If

            tempW.meaning = Mid(strLine, tempP + Len(" = "))

            'tempW.meaning = tempW.meaning.Replace("<B>", "").Replace("</B>", "").Replace("<br />", vbCrLf).Replace("<b>", "").Replace("</b>", "").Replace("<font color=""#FF0000"">", "").Replace("<font color=""#008800"">", "").Replace("</font>", "")
            tempW.meaning = Regex.Replace(tempW.meaning.Replace("<br />", vbCrLf), "<(\/)?([a-zA-Z]*)(\s[a-zA-Z]*=[^>]*)?(\s)*(\/)?>", "")
            tempW.meaning = Regex.Replace(tempW.meaning, "〔.*.〕", "")

            If EngKorDic.Count > 0 Then
                If tempW.spell = EngKorDic(EngKorDic.Count - 1).spell Then
                    Dim tempW1 As Word = EngKorDic(EngKorDic.Count - 1)
                    tempW1.meaning += vbCrLf & tempW.meaning
                    EngKorDic.RemoveAt(EngKorDic.Count - 1)
                    tempW = tempW1
                    tempW1 = Nothing
                End If
            Else
                line += 1
            End If

            EngKorDic.Add(tempW)

            tempP = Nothing
            tempW = Nothing
        Loop

        FileClose(Filenum)

        strLine = Nothing
        Filenum = Nothing
        line = Nothing

        Return True
    End Function

    Function ReadEEDic() As Boolean
        Dim strLine As String
        Dim Filenum As Integer = (9 * Rnd()) + 1

        Dim Path As String = My.Computer.FileSystem.CurrentDirectory
        If InStr(Path, "\bin\Debug") > 0 Then
            Path = Replace(Path, "\bin\Debug", "")
        End If

        Try
            FileOpen(Filenum, Path & "\DicDB\WordNetEnglish.txt", OpenMode.Input)
        Catch ex As Exception
            Path = Nothing
            strLine = Nothing
            Filenum = Nothing
            Return False
        End Try

        Dim line As Integer = 0
        Do While Not EOF(Filenum)
            strLine = LineInput(Filenum)
            Dim tempW As New Word
            Dim tempP As Integer = InStr(strLine, " = ")
            tempW.spell = Mid(strLine, 1, tempP).ToLower().Trim()

            Dim tempI As New Initail_Index
            Dim find As Boolean = False
            tempI.Initail = tempW.spell(0)

            For i = 0 To Initail_EE_index_list.Count - 1
                If tempI.Initail = Initail_EE_index_list(i).Initail Then
                    find = True
                    Exit For
                End If
            Next

            If find Then
                find = Nothing
                tempI = Nothing
            Else
                tempI.StartLine = line
                Initail_EE_index_list.Add(tempI)

                find = Nothing
                tempI = Nothing
            End If

            tempW.meaning = Mid(strLine, tempP + Len(" = "))

            tempW.meaning = tempW.meaning.Replace("<B>", "").Replace("</B>", "").Replace("<br />", vbCrLf).Replace("<b>", "").Replace("</b>", "").Replace("<font color=""#FF0000"">", "").Replace("<font color=""#008800"">", "").Replace("</font>", "").Replace(";", vbCrLf)

            If EngEngDic.Count > 0 Then
                If tempW.spell = EngEngDic(EngEngDic.Count - 1).spell Then
                    Dim tempW1 As Word = EngEngDic(EngEngDic.Count - 1)
                    tempW1.meaning += vbCrLf & tempW.meaning
                    EngEngDic.RemoveAt(EngEngDic.Count - 1)
                    tempW = tempW1
                    tempW1 = Nothing
                End If
            Else
                line += 1
            End If

            EngEngDic.Add(tempW)

            tempP = Nothing
            tempW = Nothing
        Loop

        FileClose(Filenum)

        strLine = Nothing
        Filenum = Nothing
        line = Nothing

        Return True
    End Function

    Public Function SearchWordFuntion(ByRef spell As String, Optional ByRef mode As String = "EngKor") As Word
        Dim result As New Word
        Dim Startline As Integer = 0

        If mode = "EngKor" Then
            For i = 0 To Initail_EK_index_list.Count - 1
                If spell(0) = Initail_EK_index_list(i).Initail Then
                    Startline = Initail_EK_index_list(i).StartLine
                    Exit For
                End If
            Next

            For j = Startline To EngKorDic.Count - 1
                If EngKorDic(j).spell = spell Then
                    result = EngKorDic(j)
                    Exit For
                End If
            Next
        ElseIf mode = "EngEng" Then
            For i = 0 To Initail_EE_index_list.Count - 1
                If spell(0) = Initail_EE_index_list(i).Initail Then
                    Startline = Initail_EE_index_list(i).StartLine
                    Exit For
                End If
            Next

            For j = Startline To EngKorDic.Count - 1
                If EngEngDic(j).spell = spell Then
                    result = EngEngDic(j)
                    Exit For
                End If
            Next
        End If

        Startline = Nothing

        Return result
    End Function
End Module

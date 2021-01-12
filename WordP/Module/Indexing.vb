Imports System.Text.RegularExpressions

Module Indexing
    Structure Position
        Dim Cp As Integer
        Dim P As Integer
        Dim Par As Integer
        Dim Sen As Integer
    End Structure

    Structure Word_index
        Dim Word As Dic.Word
        Dim Position As List(Of Position)
    End Structure

    Public Index As New List(Of Word_index)

    Public Sub Indexinitialization()
        Index.Clear()
    End Sub

    Public Sub IndexingWord(ByRef Word As String, ByRef Cp As Integer, ByRef P As Integer, ByRef Par As Integer, ByRef Sen As Integer)
        Dim Find As Boolean = False
        Dim temps As String = Word

        temps = Regex.Replace(Word, "[^a-zA-Z가-힣]", "", RegexOptions.Singleline)
        temps = Replace(temps, vbTab, "")

        If temps = Nothing Or temps = vbNullString Then
            Exit Sub
        End If

        Try
            temps = temps.ToLower()
        Catch ex As Exception

        End Try

        Find = findlist(temps, Cp, P, Par, Sen)

        If (Find = False) Then
            Dim temp As New Word_index
            Dim tempw As New Word

            tempw.spell = temps
            tempw.meaning = "검색결과를 찾을수 없습니다."

            If WordToWord.typeofdic.SelectedItem = "EngKor" Then
                For i = 0 To EngKorDic.Count - 1
                    If EngKorDic(i).spell = temps Then
                        tempw = EngKorDic(i)
                        Exit For
                    End If
                Next
            ElseIf WordToWord.typeofdic.SelectedItem = "EngEng" Then
                For i = 0 To EngEngDic.Count - 1
                    If EngEngDic(i).spell = temps Then
                        tempw = EngEngDic(i)
                        Exit For
                    End If
                Next
            End If

            temp.Word = tempw

            Dim tempP As New Position
            tempP.Cp = Cp
            tempP.P = P
            tempP.Par = Par
            tempP.Sen = Sen

            Dim tempL As New List(Of Position)
            tempL.Add(tempP)

            temp.Position = tempL

            Index.Add(temp)

            temp = Nothing
            tempL = Nothing
            tempP = Nothing
            tempw = Nothing
        End If

        temps = Nothing
        Find = Nothing
    End Sub

    Function findlist(ByRef a As String, ByRef Cp As Integer, ByRef P As Integer, ByRef Par As Integer, ByRef Sen As Integer) As Boolean
        Dim Find As Boolean = False

        For i = 0 To Index.Count - 1
            If Index(i).Word.spell = a Then
                Dim tempP As New Position
                tempP.Cp = Cp
                tempP.P = P
                tempP.Par = Par
                tempP.Sen = Sen

                Dim Find2 As Boolean = False
                For j = 0 To Index(i).Position.Count - 1
                    If Index(i).Position(j).Equals(tempP) Then
                        Find2 = True
                        Exit For
                    End If
                Next

                If Not Find2 Then
                    Index(i).Position.Add(tempP)
                End If
                Find2 = Nothing
                Return True
            End If
        Next
        Return False
    End Function
End Module

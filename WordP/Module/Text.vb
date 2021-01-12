Imports MSWORDP = Microsoft.Office.Interop.Word
Imports System.IO

Module Text
    Structure Sentence
        Dim English As String
        Dim Korean As String
        Dim Japaness As String
        Dim Chiness As String
    End Structure

    Structure Paragraph
        Dim sentance As List(Of Sentence)
    End Structure

    Structure Page
        Dim paragraph As List(Of Paragraph)
    End Structure

    Structure Chapter
        Dim page As List(Of Page)
    End Structure

    Public Contents As New List(Of Chapter)

    Dim ChapName As New List(Of String)

    Dim ChapViewPosition As Integer
    Dim PageViewPosition As Integer
    Dim ParViewPosition As Integer
    Dim SenViewPosition As Integer
    Dim NowViewPosition As Integer = 1

    Dim TextViewModeA As New Integer
    Dim TextViewModeB As New Integer

    Dim ClassificationTextMode As String
    Dim TextTitle As String = ""
    Dim ErrorIgnore As Boolean = False

    Private Sub initialization()
        Contents.Clear()
        ChapName.Clear()

        SenViewPosition = 0
        ParViewPosition = 0
        PageViewPosition = 0
        ChapViewPosition = 0
    End Sub

    Function GetTextViewModeA() As Integer
        Return TextViewModeA
    End Function

    Function GetTextViewModeB() As Integer
        Return TextViewModeB
    End Function

    Public Sub SetTextViewModeA(ByRef num As Integer)
        TextViewModeA = num
    End Sub

    Public Sub SetTextViewModeB(ByRef num As Integer)
        TextViewModeB = num
    End Sub

    Function GetChapViewPosition() As Integer
        Return ChapViewPosition
    End Function

    Function GetPageViewPosition() As Integer
        Return PageViewPosition
    End Function

    Function GetParViewPosition() As Integer
        Return ParViewPosition
    End Function

    Function GetSenViewPosition() As Integer
        Return SenViewPosition
    End Function

    Public Sub SetChapViewPosition(ByRef num As Integer)
        ChapViewPosition = num
    End Sub

    Public Sub SetPageViewPosition(ByRef num As Integer)
        PageViewPosition = num
    End Sub

    Public Sub SetParViewPosition(ByRef num As Integer)
        ParViewPosition = num
    End Sub

    Public Sub SetSenViewPosition(ByRef num As Integer)
        SenViewPosition = num
    End Sub

    Function GetChapNameCount() As Integer
        Return ChapName.Count - 1
    End Function

    Function GetChapName(ByRef num As Integer) As String
        Return ChapName(num)
    End Function

    Function TextPrintFuntion(ByRef A As Integer, ByRef B As Integer, ByRef CP As Integer, ByRef P As Integer, ByRef Par As Integer, ByRef Sen As Integer) As String
        Dim temptxt As String = ""

        If B = 0 Then
            If A = 0 Then
                temptxt = FullText()
            ElseIf A = 1 Then
                temptxt = FullText("ENKR")
            ElseIf A = 2 Then
                temptxt = FullText("KREN")
            End If
        ElseIf B = 1 Then
            If A = 0 Then
                temptxt = ChapterText(CP)
            ElseIf A = 1 Then
                temptxt = ChapterText(CP, "ENKR")
            ElseIf A = 2 Then
                temptxt = ChapterText(CP, "KREN")
            End If
        ElseIf B = 2 Then
            If A = 0 Then
                temptxt = PageText(CP, P)
            ElseIf A = 1 Then
                temptxt = PageText(CP, P, "ENKR")
            ElseIf A = 2 Then
                temptxt = PageText(CP, P, "KREN")
            End If
        ElseIf B = 3 Then
            If A = 0 Then
                temptxt = ParText(CP, P, Par)
            ElseIf A = 1 Then
                temptxt = ParText(CP, P, Par, "ENKR")
            ElseIf A = 2 Then
                temptxt = ParText(CP, P, Par, "KREN")
            End If
        ElseIf B = 4 Then
            If A = 0 Then
                temptxt = SenText(CP, P, Par, Sen)
            ElseIf A = 1 Then
                temptxt = SenText(CP, P, Par, Sen, "ENKR")
            ElseIf A = 2 Then
                temptxt = SenText(CP, P, Par, Sen, "KREN")
            End If
        End If

        Return temptxt
    End Function

    Function CheckNull(ByRef temptxt As String) As String
        Dim NullStr = Strings.Trim(Replace(Replace(Replace(temptxt, " ", ""), vbTab, ""), vbCrLf, ""))

        If NullStr = " " Or NullStr = "" Or NullStr = vbNullString Then
            Return vbNullString
        End If

        NullStr = Nothing

        Return temptxt
    End Function


    Function FullText(Optional ByRef mode As String = "EN")
        Dim temptxt As String = ""
        For a = 0 To Contents.Count - 1
            Try
                temptxt += ChapName(a) & vbCrLf & vbCrLf
            Catch ex As Exception

            End Try
            temptxt += ChapterText(a, mode) & vbCrLf
        Next

        Return CheckNull(temptxt)
    End Function

    Function ChapterText(ByRef Cp As Integer, Optional ByRef mode As String = "EN")
        Dim temptxt As String = ""
        If Cp > Contents.Count - 1 Then
            Cp = Contents.Count - 1
        End If

        Try
            For b = 0 To Contents(Cp).page.Count - 1
                temptxt += PageText(Cp, b, mode) & vbCrLf
            Next
        Catch ex As Exception

        End Try

        Return CheckNull(temptxt)
    End Function

    Function PageText(ByRef Cp As Integer, ByRef P As Integer, Optional ByRef mode As String = "EN")
        Dim temptxt As String = ""

        Try
            For c = 0 To Contents(Cp).page(P).paragraph.Count - 1
                temptxt += ParText(Cp, P, c, mode)
            Next
        Catch ex As Exception

        End Try

        Return CheckNull(temptxt)
    End Function

    Function ParText(ByRef Cp As Integer, ByRef P As Integer, ByRef Par As Integer, Optional ByRef mode As String = "EN")
        Dim temptxt As String = ""

        Try
            For d = 0 To Contents(Cp).page(P).paragraph(Par).sentance.Count - 1
                temptxt += SenText(Cp, P, Par, d, mode)
            Next
        Catch ex As Exception

        End Try

        Return CheckNull(temptxt)
    End Function

    Function SenText(ByRef CP As Integer, ByRef P As Integer, ByRef Par As Integer, ByRef Sen As Integer, Optional ByRef mode As String = "EN")
        Dim temptxt As String = ""
        Try
            If mode = "EN" Then
                temptxt += Contents(CP).page(P).paragraph(Par).sentance(Sen).English & vbCrLf
            ElseIf mode = "ENKR" Then
                temptxt += Contents(CP).page(P).paragraph(Par).sentance(Sen).English & vbCrLf & Contents(CP).page(P).paragraph(Par).sentance(Sen).Korean & vbCrLf
            ElseIf mode = "KREN" Then
                temptxt += Contents(CP).page(P).paragraph(Par).sentance(Sen).Korean & vbCrLf & Contents(CP).page(P).paragraph(Par).sentance(Sen).English & vbCrLf
            End If
        Catch ex As Exception

        End Try


        Return temptxt
    End Function

    'Public Sub EmphasisChapter(ByRef RichTextBox As RichTextBox, Optional ByRef B As Integer = 0)
    '    RichTextBox.Select(0, RichTextBox.TextLength)
    '    RichTextBox.SelectionFont = New Font("굴림", GetFontSize())
    '    RichTextBox.SelectionColor = Color.Black

    '    If B = 0 Then
    '        For i = 0 To GetChapNameCount()
    '            If Not ChapName(i) = vbNullString Then
    '                Dim currentFont As System.Drawing.Font = RichTextBox.SelectionFont
    '                Dim newFontStyle As System.Drawing.FontStyle = FontStyle.Bold

    '                Try
    '                    RichTextBox.Select(RichTextBox.Find(ChapName(i)), ChapName(i).Length())
    '                    RichTextBox.SelectionFont = New Font(currentFont.FontFamily, GetFontSize() + 3, newFontStyle)
    '                    RichTextBox.SelectionColor = Color.Blue
    '                Catch ex As Exception

    '                End Try
    '            End If
    '        Next
    '    End If

    '    RichTextBox.Select(0, 0)
    'End Sub

    Function checknextpage() As Boolean
        If TextViewModeB = 0 Then
            Return False
        ElseIf TextViewModeB = 1 Then
            If Contents.Count - 1 = ChapViewPosition Then
                Return False
            End If
        ElseIf TextViewModeB = 2 Then
            If Contents(ChapViewPosition).page.Count - 1 = PageViewPosition Then
                If Contents.Count - 2 < ChapViewPosition Then
                    Return False
                End If
            End If
        ElseIf TextViewModeB = 3 Then
            If Contents(ChapViewPosition).page(PageViewPosition).paragraph.Count - 1 = ParViewPosition Then
                If Contents(ChapViewPosition).page.Count - 1 = PageViewPosition Then
                    If Contents.Count - 1 = ChapViewPosition Then
                        Return False
                    End If
                End If
            End If
        ElseIf TextViewModeB = 4 Then
            If Contents(ChapViewPosition).page(PageViewPosition).paragraph(ParViewPosition).sentance.Count - 1 = SenViewPosition Then
                If Contents(ChapViewPosition).page(PageViewPosition).paragraph.Count - 1 = ParViewPosition Then
                    If Contents(ChapViewPosition).page.Count - 1 = PageViewPosition Then
                        If Contents.Count - 1 = ChapViewPosition Then
                            Return False
                        End If
                    End If
                End If
            End If
        End If

        Return True
    End Function

    Function checkbackpage() As Boolean
        If TextViewModeB = 0 Then
            Return False
        ElseIf TextViewModeB = 1 Then
            If ChapViewPosition < 1 Then
                Return False
            End If
        ElseIf TextViewModeB = 2 Then
            If PageViewPosition < 1 Then
                If ChapViewPosition < 1 Then
                    Return False
                End If
            End If
        ElseIf TextViewModeB = 3 Then
            If ParViewPosition < 1 Then
                If PageViewPosition < 1 Then
                    If ChapViewPosition < 1 Then
                        Return False
                    End If
                End If
            End If
        ElseIf TextViewModeB = 4 Then
            If SenViewPosition < 1 Then
                If ParViewPosition < 1 Then
                    If PageViewPosition < 1 Then
                        If ChapViewPosition < 1 Then
                            Return False
                        End If
                    End If
                End If
            End If
        End If

        Return True
    End Function

    Public Sub NowPageNumberPrint()
        NowViewPosition = CalNowNumber(TextViewModeA, TextViewModeB, ChapViewPosition, PageViewPosition, ParViewPosition, SenViewPosition)
    End Sub

    Function CalNowNumber(ByRef A As Integer, ByRef B As Integer, ByRef Cp As Integer, ByRef Pp As Integer, ByRef Pp2 As Integer, ByRef Sp As Integer) As Integer
        Dim num As Integer = 0

        If B = 0 Then
            num = 1
        Else
            If B = 1 Then
                num = Cp + 1
            ElseIf B = 2 Then
                For i = 0 To Cp
                    If i = Cp Then
                        For j = 0 To Pp
                            num += 1
                        Next
                    Else
                        num += Contents(i).page.Count
                    End If
                Next
            ElseIf B = 3 Then
                For i = 0 To Cp
                    If i = Cp Then
                        For j = 0 To Pp
                            If j = Pp Then
                                For k = 0 To Pp2
                                    num += 1
                                Next
                            Else
                                num += Contents(i).page(j).paragraph.Count
                            End If
                        Next
                    Else
                        For j = 0 To Contents(i).page.Count - 1
                            num += Contents(i).page(j).paragraph.Count
                        Next
                    End If
                Next
            ElseIf B = 4 Then
                For i = 0 To Cp
                    If i = Cp Then
                        For j = 0 To Pp
                            If j = Pp Then
                                For k = 0 To Pp2
                                    If k = Pp2 Then
                                        For o = 0 To Sp
                                            num += 1
                                        Next
                                    Else
                                        num += Contents(i).page(j).paragraph(k).sentance.Count
                                    End If
                                Next
                            Else
                                For k = 0 To Contents(i).page(j).paragraph.Count - 1
                                    num += Contents(i).page(j).paragraph(k).sentance.Count
                                Next
                            End If
                        Next
                    Else
                        For j = 0 To Contents(i).page.Count - 1
                            For k = 0 To Contents(i).page(j).paragraph.Count - 1
                                num += Contents(i).page(j).paragraph(k).sentance.Count
                            Next
                        Next
                    End If
                Next
            End If
        End If
        Return num
    End Function

    Public Sub BackContents()
        Speaking = False

        If TextViewModeB = 1 Then
            If Not ChapViewPosition > 0 Then
                ChapViewPosition = 0
            Else
                ChapViewPosition -= 1
            End If
        ElseIf TextViewModeB = 2 Then
            If PageViewPosition > 0 Then
                PageViewPosition -= 1
            Else
                If (ChapViewPosition > 0) Then
                    ChapViewPosition -= 1
                    PageViewPosition = Contents(ChapViewPosition).page.Count - 1
                End If
            End If
        ElseIf TextViewModeB = 3 Then
            If ParViewPosition > 0 Then
                ParViewPosition -= 1
            Else
                If PageViewPosition > 0 Then
                    PageViewPosition -= 1
                    ParViewPosition = Contents(ChapViewPosition).page(PageViewPosition).paragraph.Count - 1
                Else
                    If ChapViewPosition > 0 Then
                        ChapViewPosition -= 1
                        PageViewPosition = Contents(ChapViewPosition).page.Count - 1
                        ParViewPosition = Contents(ChapViewPosition).page(PageViewPosition).paragraph.Count - 1
                    End If
                End If
            End If
        ElseIf TextViewModeB = 4 Then
            If SenViewPosition > 0 Then
                SenViewPosition -= 1
            Else
                If ParViewPosition > 0 Then
                    ParViewPosition -= 1
                    SenViewPosition = Contents(ChapViewPosition).page(PageViewPosition).paragraph(ParViewPosition).sentance.Count - 1
                Else
                    If PageViewPosition > 0 Then
                        PageViewPosition -= 1
                        ParViewPosition = Contents(ChapViewPosition).page(PageViewPosition).paragraph.Count - 1
                        SenViewPosition = Contents(ChapViewPosition).page(PageViewPosition).paragraph(ParViewPosition).sentance.Count - 1
                    Else
                        If ChapViewPosition > 0 Then
                            ChapViewPosition -= 1
                            PageViewPosition = Contents(ChapViewPosition).page.Count - 1
                            ParViewPosition = Contents(ChapViewPosition).page(PageViewPosition).paragraph.Count - 1
                            SenViewPosition = Contents(ChapViewPosition).page(PageViewPosition).paragraph(ParViewPosition).sentance.Count - 1
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub NextContents()
        Speaking = False

        If TextViewModeB = 1 Then
            ChapViewPosition += 1
        ElseIf TextViewModeB = 2 Then
            If Contents(ChapViewPosition).page.Count - 1 = PageViewPosition Then
                ChapViewPosition += 1
                PageViewPosition = 0
            Else
                PageViewPosition += 1
            End If
        ElseIf TextViewModeB = 3 Then
            If Not Contents(ChapViewPosition).page(PageViewPosition).paragraph.Count - 1 = ParViewPosition Then
                ParViewPosition += 1
            Else
                If Not Contents(ChapViewPosition).page.Count - 1 = PageViewPosition Then
                    PageViewPosition += 1
                    ParViewPosition = 0
                Else
                    ChapViewPosition += 1
                    PageViewPosition = 0
                    ParViewPosition = 0
                End If
            End If
        ElseIf TextViewModeB = 4 Then
            If Not Contents(ChapViewPosition).page(PageViewPosition).paragraph(ParViewPosition).sentance.Count - 1 = SenViewPosition Then
                SenViewPosition += 1
            Else
                If Not Contents(ChapViewPosition).page(PageViewPosition).paragraph.Count - 1 = ParViewPosition Then
                    ParViewPosition += 1
                    SenViewPosition = 0
                Else
                    If Not Contents(ChapViewPosition).page.Count - 1 = PageViewPosition Then
                        PageViewPosition += 1
                        ParViewPosition = 0
                        SenViewPosition = 0
                    Else
                        ChapViewPosition += 1
                        PageViewPosition = 0
                        ParViewPosition = 0
                        SenViewPosition = 0
                    End If
                End If
            End If
        End If
    End Sub

    Function DistinguishLanguage(ByRef str As String)
        Dim Result As String = "Unknown"

        Dim EnglishCapitalFirst As Single = Asc("A")
        Dim EnglishCapitalLast As Single = Asc("Z")

        Dim EnglishSmallFirst As Single = Asc("a")
        Dim EnglishSmallLast As Single = Asc("z")

        Dim KoreanCombinationFirst As Single = Asc("가")
        Dim KoreanCombinationLast As Single = Asc("힝")

        Dim KoreanCAPTCHAFirst As Single = Asc("ㄱ")
        Dim KoreanCAPTCHALast As Single = Asc("ㅣ")

        Dim JapaneseHiraganaFirst As Single = Asc("あ")
        Dim JapaneseHiraganaLast As Single = Asc("ん")

        Dim JapaneseKatakanaFirst As Single = Asc("ア")
        Dim JapaneseKatakanaLast As Single = Asc("ン")

        Dim CountArry(4) As Integer

        'CountArry(0) = English
        'CountArry(1) = Korean
        'CountArry(2) = Japanese
        'CountArry(3) = Unknown

        Dim max(2) As Integer

        'max(0) = Max Value
        'max(1) = Max Variable

        For i = 0 To str.Length - 1
            Dim ascnum As Single = Asc(str.Chars(i))

            If KoreanCAPTCHAFirst <= ascnum And ascnum <= KoreanCAPTCHALast Then
                CountArry(1) += 1
                'MsgBox(str.Chars(i) & ", " & ascnum & ", 한국어 자음, 모음")
            ElseIf JapaneseHiraganaFirst <= ascnum And ascnum <= JapaneseHiraganaFirst Then
                CountArry(2) += 1
                'MsgBox(str.Chars(i) & ", " & Asc(str.Chars(i)) & ", 일본어 히라가나")
            ElseIf JapaneseKatakanaFirst <= ascnum And ascnum <= JapaneseKatakanaLast Then
                CountArry(2) += 1
                'MsgBox(str.Chars(i) & ", " & Asc(str.Chars(i)) & ", 일본어 카타카나")
            ElseIf KoreanCombinationFirst <= ascnum And ascnum <= KoreanCombinationLast Then
                CountArry(1) += 1
                'MsgBox(str.Chars(i) & ", " & Asc(str.Chars(i)) & ", 한국어 조합문자")
            ElseIf Asc(0) <= ascnum And ascnum <= Asc(9) Then
                'CountArry(3) += 1
                'MsgBox(str.Chars(i) & ", " & Asc(str.Chars(i)) & ", 숫자")
            ElseIf EnglishCapitalFirst <= ascnum And ascnum <= EnglishCapitalLast Then
                CountArry(0) += 1
                'MsgBox(str.Chars(i) & ", " & Asc(str.Chars(i)) & ", 영어 대문자")
            ElseIf EnglishSmallFirst <= ascnum And ascnum <= EnglishSmallLast Then
                CountArry(0) += 1
                'MsgBox(str.Chars(i) & ", " & Asc(str.Chars(i)) & ", 영어 소문자")
            Else
                CountArry(3) += 1
                'MsgBox(str.Chars(i) & ", " & Asc(str.Chars(i)) & ", 알수 없음")
            End If
        Next

        max(0) = 0
        max(1) = CountArry(0)

        For i = 0 To UBound(CountArry)
            If max(1) < CountArry(i) Then
                max(0) = i
                max(1) = CountArry(i)
            End If
        Next

        If max(0) = 0 Then
            Result = "English"
        ElseIf max(0) = 1 Then
            Result = "Korean"
        ElseIf max(0) = 2 Then
            Result = "Japanese"
        End If

        EnglishCapitalFirst = Nothing
        EnglishCapitalLast = Nothing
        KoreanCAPTCHAFirst = Nothing
        KoreanCAPTCHALast = Nothing
        JapaneseHiraganaFirst = Nothing
        JapaneseHiraganaLast = Nothing
        JapaneseKatakanaFirst = Nothing
        JapaneseKatakanaLast = Nothing
        CountArry = Nothing
        max = Nothing

        Return Result
    End Function

    Public Sub FileRead(ByRef OpenFile As String, Optional ByRef EngView As RadioButton = Nothing, Optional ByRef JpnView As RadioButton = Nothing, Optional ByVal ChaView As RadioButton = Nothing)
        initialization()
        Indexinitialization()
        ErrorIgnore = False

        Dim tempE As String() = OpenFile.Split(".")
        Dim ext = tempE(tempE.Length - 1)
        tempE = Nothing

        If ext.ToLower = "docx" Or ext.ToLower = "doc" Then
            Dim oWord As New MSWORDP.Application
            Dim oDoc As New MSWORDP.Document

            oWord.Visible = False
            oDoc = oWord.Documents.Open(OpenFile, ReadOnly:=True)

            Dim nCP As New Chapter
            nCP.page = New List(Of Page)

            For i = 1 To oDoc.Sections.Count
                Dim nPg As New Page
                nPg.paragraph = New List(Of Paragraph)

                For j = 1 To oDoc.Sections(i).Range.Paragraphs.Count
                    Dim nPr As New Paragraph
                    nPr.sentance = New List(Of Sentence)

                    For k = 1 To oDoc.Sections(i).Range.Paragraphs(j).Range.Sentences.Count
                        Dim nS As New Sentence
                        nS.English = oDoc.Sections(i).Range.Paragraphs(j).Range.Sentences(k).Text
                        nS.Korean = ""
                        nS.Chiness = ""
                        nS.Japaness = ""

                        nPr.sentance.Add(nS)
                        nS = Nothing
                    Next

                    nPg.paragraph.Add(nPr)
                    nPr = Nothing
                Next

                nCP.page.Add(nPg)
                nPg = Nothing
            Next

            Contents.Add(nCP)
            TextTitle = oDoc.Name

            nCP = Nothing

            oDoc.Close()
            oWord.Quit()

            oDoc = Nothing
            oWord = Nothing

            For i = 0 To Contents(0).page.Count - 1
                For j = 0 To Contents(0).page(i).paragraph.Count - 1
                    For k = 0 To Contents(0).page(i).paragraph(j).sentance.Count - 1
                        Dim str As String() = Split(Contents(0).page(i).paragraph(j).sentance(k).English)

                        For l = 0 To str.Length - 1
                            IndexingWord(str(l), 0, i, j, k)
                        Next

                        str = Nothing
                    Next
                Next
            Next

        Else
            Dim strLine As String
            Dim RMF As Boolean = False

            Dim Filenum As Integer = (9 * Rnd()) + 1
            Try
                FileOpen(Filenum, OpenFile, OpenMode.Input)
            Catch ex As Exception
                MsgBox(ex.ToString())
                Exit Sub
            End Try

            TextTitle = "ReadText"

            Dim ParBool As Boolean = False

            Do While Not EOF(Filenum)
                strLine = LineInput(Filenum)
                If InStr(strLine, "This is RMEB.") = 1 Then
                    RMF = True
                ElseIf InStr(strLine, "<Language>") = 1 And RMF Then
                    ClassificationTextMode = Replace(strLine, "<Language>", "")
                ElseIf InStr(strLine, "<Title>") = 1 And RMF Then
                    TextTitle = Replace(strLine, "<Title>", "")
                ElseIf InStr(strLine, "<Chapter>") = 1 And RMF Then
                    ChapName.Add(Replace(strLine, "<Chapter>", ""))
                    Dim temp As New Chapter
                    temp.page = New List(Of Page)
                    Contents.Add(temp)

                    ParBool = False
                    temp = Nothing
                ElseIf InStr(strLine, "<Page>") = 1 And RMF Then
                    Dim temp As New Page
                    Dim tempCpN As Integer = Contents.Count - 1

                    temp.paragraph = New List(Of Paragraph)
                    Contents(tempCpN).page.Add(temp)
                    ParBool = False

                    temp = Nothing
                    tempCpN = Nothing
                ElseIf Strings.Trim(strLine) = "" And RMF Then
                    If Not ParBool Then
                        Dim temp As New Paragraph
                        Dim tempCpN As Integer = Contents.Count - 1
                        Dim tempPN As Integer = Contents(tempCpN).page.Count - 1

                        temp.sentance = New List(Of Sentence)

                        Contents(tempCpN).page(tempPN).paragraph.Add(temp)
                        ParBool = True

                        tempPN = Nothing
                        tempCpN = Nothing
                        temp = Nothing
                    End If
                ElseIf RMF Then
                    ParBool = False

                    Dim tempCpN As Integer = Contents.Count - 1
                    Dim tempPN As Integer = Contents(tempCpN).page.Count - 1
                    Dim tempParN As Integer = Contents(tempCpN).page(tempPN).paragraph.Count

                    If tempParN = 0 Then
                        Dim tempPar As New Paragraph
                        tempPar.sentance = New List(Of Sentence)
                        Contents(tempCpN).page(tempPN).paragraph.Add(tempPar)

                        tempPar = Nothing
                    End If

                    tempParN = Contents(tempCpN).page(tempPN).paragraph.Count - 1

                    Dim tempS As New Sentence
                    If ClassificationTextMode = "EN" Then
                        tempS.English = strLine
                        tempS.Korean = ""
                        tempS.Japaness = ""
                        tempS.Chiness = ""
                    ElseIf ClassificationTextMode = "ENKR" Then
                        tempS.English = strLine
                        strLine = LineInput(Filenum)
                        tempS.Korean = strLine
                        tempS.Japaness = ""
                        tempS.Chiness = ""
                    End If

                    Contents(tempCpN).page(tempPN).paragraph(tempParN).sentance.Add(tempS)
                    System.Windows.Forms.Application.DoEvents()

                    Dim tempSenN As Integer = Contents(tempCpN).page(tempPN).paragraph(tempParN).sentance.Count - 1
                    Dim tempStr As String()

                    tempStr = Split(tempS.English)

                    For i = 0 To UBound(tempStr) - 1
                        IndexingWord(tempStr(i), tempCpN, tempPN, tempParN, tempSenN)
                    Next

                    tempCpN = Nothing
                    tempParN = Nothing
                    tempPN = Nothing
                    tempS = Nothing
                    tempSenN = Nothing
                    tempStr = Nothing
                Else
                    If Not ErrorIgnore Then
                        If MsgBox(OpenFile & vbCrLf & "이 파일은 지원하지 않는 파일입니다. 읽을땐 오류를 발생시킬수 있습니다. 계속 하시겠습니까?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                            ErrorIgnore = True
                            ClassificationTextMode = "EN"
                        Else
                            FileClose(Filenum)
                            Exit Sub
                        End If
                    End If

                    Dim tempCpN As Integer = Contents.Count - 1

                    If tempCpN = -1 Then
                        Dim tempCP As New Chapter
                        tempCP.page = New List(Of Page)
                        Contents.Add(tempCP)
                        tempCpN = Contents.Count - 1

                        tempCP = Nothing
                    End If

                    Dim tempPGN As Integer = Contents(tempCpN).page.Count - 1

                    If tempPGN = -1 Then
                        Dim tempPG As New Page
                        tempPG.paragraph = New List(Of Paragraph)
                        Contents(tempCpN).page.Add(tempPG)
                        tempPGN = Contents(tempCpN).page.Count - 1

                        tempPG = Nothing
                    End If

                    Dim tempParN As Integer = Contents(tempCpN).page(tempPGN).paragraph.Count - 1

                    If tempParN = -1 Then
                        Dim tempPar As New Paragraph
                        tempPar.sentance = New List(Of Sentence)
                        Contents(tempCpN).page(tempPGN).paragraph.Add(tempPar)
                        tempParN = Contents(tempCpN).page(tempPGN).paragraph.Count - 1

                        tempPar = Nothing
                    End If

                    Dim tempSen As New Sentence
                    tempSen.English = strLine
                    tempSen.Korean = ""
                    tempSen.Chiness = ""
                    tempSen.Japaness = ""

                    Contents(tempCpN).page(tempPGN).paragraph(tempParN).sentance.Add(tempSen)

                    Dim tempSenN As Integer = Contents(tempCpN).page(tempPGN).paragraph(tempParN).sentance.Count - 1
                    Dim tempStr As String()

                    tempStr = Split(tempSen.English)

                    For i = 0 To UBound(tempStr)
                        If DistinguishLanguage(tempSen.English) = "English" Then
                            IndexingWord(tempStr(i), tempCpN, tempPGN, tempParN, tempSenN)
                        End If

                    Next

                    tempCpN = Nothing
                    tempParN = Nothing
                    tempPGN = Nothing
                    tempSen = Nothing
                    tempSenN = Nothing
                    tempStr = Nothing
                End If
            Loop
            strLine = Nothing
            RMF = Nothing
            ParBool = Nothing

            FileClose(Filenum)
            Filenum = Nothing
        End If

        ext = Nothing

        For temp1 = Contents.Count - 1 To 0 Step -1
            For temp2 = Contents(temp1).page.Count - 1 To 0 Step -1
                For temp3 = Contents(temp1).page(temp2).paragraph.Count - 1 To 0 Step -1
                    If Contents(temp1).page(temp2).paragraph(temp3).sentance.Count = 0 Then
                        Contents(temp1).page(temp2).paragraph.RemoveAt(temp3)
                    End If
                Next

                If Contents(temp1).page(temp2).paragraph.Count = 0 Then
                    Contents(temp1).page.RemoveAt(temp2)
                End If
            Next

            If Contents(temp1).page.Count = 0 Then
                Contents.RemoveAt(temp1)
            End If
        Next

        For temp1 = Index.Count - 1 To 0
            If Index(temp1).Word.spell.Trim.Replace(" ", "") = "" Or vbNullString Or vbTab Then
                Index.RemoveAt(temp1)
            End If
        Next

        ChapViewPosition = 0
        PageViewPosition = 0
        ParViewPosition = 0
        SenViewPosition = 0

    End Sub
End Module
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WordToWord
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Meaning Exist", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Meaning None", System.Windows.Forms.HorizontalAlignment.Left)
        Me.All_unselect = New System.Windows.Forms.Button()
        Me.Stop_TTS = New System.Windows.Forms.Button()
        Me.TrackBar_TTS = New System.Windows.Forms.TrackBar()
        Me.no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.wordlist = New System.Windows.Forms.ListView()
        Me.positionshow = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.All_select = New System.Windows.Forms.Button()
        Me.All_Read_Btn = New System.Windows.Forms.Button()
        Me.OpenFile_Btn = New System.Windows.Forms.Button()
        Me.typeofdic = New System.Windows.Forms.ComboBox()
        Me.WordSort = New System.Windows.Forms.CheckBox()
        Me.Save = New System.Windows.Forms.Button()
        Me.meaning_ = New System.Windows.Forms.Label()
        Me.positionlist = New System.Windows.Forms.ListBox()
        Me.Exshow = New System.Windows.Forms.CheckBox()
        Me.SearchWord = New System.Windows.Forms.TextBox()
        Me.SearchWord_btn = New System.Windows.Forms.Button()
        Me.Voice_List = New System.Windows.Forms.ComboBox()
        Me.meaning = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RepeatNum = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Shadowing = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.ShadowingSEC = New System.Windows.Forms.NumericUpDown()
        CType(Me.TrackBar_TTS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.RepeatNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShadowingSEC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'All_unselect
        '
        Me.All_unselect.Location = New System.Drawing.Point(144, 9)
        Me.All_unselect.Name = "All_unselect"
        Me.All_unselect.Size = New System.Drawing.Size(107, 20)
        Me.All_unselect.TabIndex = 39
        Me.All_unselect.Text = "모두 선택 해제"
        Me.All_unselect.UseVisualStyleBackColor = True
        '
        'Stop_TTS
        '
        Me.Stop_TTS.Location = New System.Drawing.Point(190, 20)
        Me.Stop_TTS.Name = "Stop_TTS"
        Me.Stop_TTS.Size = New System.Drawing.Size(32, 23)
        Me.Stop_TTS.TabIndex = 37
        Me.Stop_TTS.Text = "□"
        Me.Stop_TTS.UseVisualStyleBackColor = True
        '
        'TrackBar_TTS
        '
        Me.TrackBar_TTS.AutoSize = False
        Me.TrackBar_TTS.LargeChange = 1
        Me.TrackBar_TTS.Location = New System.Drawing.Point(68, 51)
        Me.TrackBar_TTS.Maximum = 5
        Me.TrackBar_TTS.Minimum = -5
        Me.TrackBar_TTS.Name = "TrackBar_TTS"
        Me.TrackBar_TTS.Size = New System.Drawing.Size(154, 18)
        Me.TrackBar_TTS.TabIndex = 35
        '
        'no
        '
        Me.no.Text = "Word"
        Me.no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.no.Width = 135
        '
        'wordlist
        '
        Me.wordlist.CheckBoxes = True
        Me.wordlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.no})
        ListViewGroup3.Header = "Meaning Exist"
        ListViewGroup3.Name = "Meaning Exist"
        ListViewGroup4.Header = "Meaning None"
        ListViewGroup4.Name = "Meaning None"
        Me.wordlist.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup3, ListViewGroup4})
        Me.wordlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.wordlist.Location = New System.Drawing.Point(14, 35)
        Me.wordlist.MultiSelect = False
        Me.wordlist.Name = "wordlist"
        Me.wordlist.Size = New System.Drawing.Size(236, 359)
        Me.wordlist.TabIndex = 34
        Me.wordlist.UseCompatibleStateImageBehavior = False
        Me.wordlist.View = System.Windows.Forms.View.Details
        '
        'positionshow
        '
        Me.positionshow.AutoSize = True
        Me.positionshow.Checked = True
        Me.positionshow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.positionshow.Location = New System.Drawing.Point(95, 400)
        Me.positionshow.Name = "positionshow"
        Me.positionshow.Size = New System.Drawing.Size(72, 16)
        Me.positionshow.TabIndex = 33
        Me.positionshow.Text = "위치표시"
        Me.positionshow.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        Me.OpenFileDialog.Filter = "Microsoft Word 파일|*.doc;*.docx"
        '
        'All_select
        '
        Me.All_select.Location = New System.Drawing.Point(13, 9)
        Me.All_select.Name = "All_select"
        Me.All_select.Size = New System.Drawing.Size(120, 20)
        Me.All_select.TabIndex = 38
        Me.All_select.Text = "모두 선택"
        Me.All_select.UseVisualStyleBackColor = True
        '
        'All_Read_Btn
        '
        Me.All_Read_Btn.Location = New System.Drawing.Point(6, 20)
        Me.All_Read_Btn.Name = "All_Read_Btn"
        Me.All_Read_Btn.Size = New System.Drawing.Size(85, 25)
        Me.All_Read_Btn.TabIndex = 30
        Me.All_Read_Btn.Text = "Read  ▶"
        Me.All_Read_Btn.UseVisualStyleBackColor = True
        '
        'OpenFile_Btn
        '
        Me.OpenFile_Btn.Location = New System.Drawing.Point(14, 422)
        Me.OpenFile_Btn.Name = "OpenFile_Btn"
        Me.OpenFile_Btn.Size = New System.Drawing.Size(112, 25)
        Me.OpenFile_Btn.TabIndex = 29
        Me.OpenFile_Btn.Text = "Open"
        Me.OpenFile_Btn.UseVisualStyleBackColor = True
        '
        'typeofdic
        '
        Me.typeofdic.FormattingEnabled = True
        Me.typeofdic.Location = New System.Drawing.Point(341, 560)
        Me.typeofdic.Name = "typeofdic"
        Me.typeofdic.Size = New System.Drawing.Size(105, 20)
        Me.typeofdic.TabIndex = 26
        '
        'WordSort
        '
        Me.WordSort.AutoSize = True
        Me.WordSort.Location = New System.Drawing.Point(14, 400)
        Me.WordSort.Name = "WordSort"
        Me.WordSort.Size = New System.Drawing.Size(80, 16)
        Me.WordSort.TabIndex = 25
        Me.WordSort.Text = "Word 정렬"
        Me.WordSort.UseVisualStyleBackColor = True
        '
        'Save
        '
        Me.Save.Location = New System.Drawing.Point(132, 422)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(118, 25)
        Me.Save.TabIndex = 24
        Me.Save.Text = "Save"
        Me.Save.UseVisualStyleBackColor = True
        '
        'meaning_
        '
        Me.meaning_.AutoSize = True
        Me.meaning_.Location = New System.Drawing.Point(267, 13)
        Me.meaning_.Name = "meaning_"
        Me.meaning_.Size = New System.Drawing.Size(25, 12)
        Me.meaning_.TabIndex = 23
        Me.meaning_.Text = "뜻 :"
        '
        'positionlist
        '
        Me.positionlist.FormattingEnabled = True
        Me.positionlist.HorizontalScrollbar = True
        Me.positionlist.ItemHeight = 12
        Me.positionlist.Location = New System.Drawing.Point(269, 427)
        Me.positionlist.Name = "positionlist"
        Me.positionlist.Size = New System.Drawing.Size(547, 124)
        Me.positionlist.TabIndex = 22
        '
        'Exshow
        '
        Me.Exshow.AutoSize = True
        Me.Exshow.Checked = True
        Me.Exshow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Exshow.Location = New System.Drawing.Point(168, 400)
        Me.Exshow.Name = "Exshow"
        Me.Exshow.Size = New System.Drawing.Size(72, 16)
        Me.Exshow.TabIndex = 32
        Me.Exshow.Text = "예문표시"
        Me.Exshow.UseVisualStyleBackColor = True
        '
        'SearchWord
        '
        Me.SearchWord.Location = New System.Drawing.Point(452, 560)
        Me.SearchWord.Name = "SearchWord"
        Me.SearchWord.Size = New System.Drawing.Size(157, 21)
        Me.SearchWord.TabIndex = 40
        '
        'SearchWord_btn
        '
        Me.SearchWord_btn.Location = New System.Drawing.Point(615, 560)
        Me.SearchWord_btn.Name = "SearchWord_btn"
        Me.SearchWord_btn.Size = New System.Drawing.Size(80, 23)
        Me.SearchWord_btn.TabIndex = 41
        Me.SearchWord_btn.Text = "Search"
        Me.SearchWord_btn.UseVisualStyleBackColor = True
        '
        'Voice_List
        '
        Me.Voice_List.FormattingEnabled = True
        Me.Voice_List.Location = New System.Drawing.Point(77, 115)
        Me.Voice_List.Name = "Voice_List"
        Me.Voice_List.Size = New System.Drawing.Size(145, 20)
        Me.Voice_List.TabIndex = 43
        '
        'meaning
        '
        Me.meaning.BackColor = System.Drawing.Color.White
        Me.meaning.Location = New System.Drawing.Point(269, 32)
        Me.meaning.Name = "meaning"
        Me.meaning.ReadOnly = True
        Me.meaning.Size = New System.Drawing.Size(547, 362)
        Me.meaning.TabIndex = 44
        Me.meaning.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(267, 412)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "위치 및 포함 예제문장"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(266, 563)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "사전 검색 : "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(439, 697)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(170, 21)
        Me.TextBox1.TabIndex = 40
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ShadowingSEC)
        Me.GroupBox1.Controls.Add(Me.RepeatNum)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Shadowing)
        Me.GroupBox1.Controls.Add(Me.TrackBar_TTS)
        Me.GroupBox1.Controls.Add(Me.All_Read_Btn)
        Me.GroupBox1.Controls.Add(Me.Voice_List)
        Me.GroupBox1.Controls.Add(Me.Stop_TTS)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 453)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(237, 136)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "읽기"
        '
        'RepeatNum
        '
        Me.RepeatNum.Location = New System.Drawing.Point(78, 84)
        Me.RepeatNum.Name = "RepeatNum"
        Me.RepeatNum.Size = New System.Drawing.Size(34, 21)
        Me.RepeatNum.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(117, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 12)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "새도잉구간 :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "반복 횟수 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "속도 조절 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "엔진 선택 :"
        '
        'Shadowing
        '
        Me.Shadowing.AutoSize = True
        Me.Shadowing.Location = New System.Drawing.Point(97, 25)
        Me.Shadowing.Name = "Shadowing"
        Me.Shadowing.Size = New System.Drawing.Size(87, 16)
        Me.Shadowing.TabIndex = 44
        Me.Shadowing.Text = "Shadowing"
        Me.Shadowing.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(701, 560)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 23)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "찾아본 단어 저장"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.Filter = "Text 파일|*.txt"
        '
        'ShadowingSEC
        '
        Me.ShadowingSEC.Location = New System.Drawing.Point(190, 84)
        Me.ShadowingSEC.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.ShadowingSEC.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ShadowingSEC.Name = "ShadowingSEC"
        Me.ShadowingSEC.Size = New System.Drawing.Size(34, 21)
        Me.ShadowingSEC.TabIndex = 46
        Me.ShadowingSEC.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'WordToWord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 592)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.meaning)
        Me.Controls.Add(Me.SearchWord_btn)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.SearchWord)
        Me.Controls.Add(Me.All_unselect)
        Me.Controls.Add(Me.wordlist)
        Me.Controls.Add(Me.positionshow)
        Me.Controls.Add(Me.Exshow)
        Me.Controls.Add(Me.All_select)
        Me.Controls.Add(Me.OpenFile_Btn)
        Me.Controls.Add(Me.typeofdic)
        Me.Controls.Add(Me.WordSort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Save)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.meaning_)
        Me.Controls.Add(Me.positionlist)
        Me.Name = "WordToWord"
        Me.Text = "Word Book"
        CType(Me.TrackBar_TTS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.RepeatNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShadowingSEC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents All_unselect As System.Windows.Forms.Button
    Friend WithEvents Stop_TTS As System.Windows.Forms.Button
    Friend WithEvents TrackBar_TTS As System.Windows.Forms.TrackBar
    Friend WithEvents no As System.Windows.Forms.ColumnHeader
    Friend WithEvents wordlist As System.Windows.Forms.ListView
    Friend WithEvents positionshow As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents All_select As System.Windows.Forms.Button
    Friend WithEvents All_Read_Btn As System.Windows.Forms.Button
    Friend WithEvents OpenFile_Btn As System.Windows.Forms.Button
    Friend WithEvents typeofdic As System.Windows.Forms.ComboBox
    Friend WithEvents WordSort As System.Windows.Forms.CheckBox
    Friend WithEvents Save As System.Windows.Forms.Button
    Friend WithEvents meaning_ As System.Windows.Forms.Label
    Friend WithEvents positionlist As System.Windows.Forms.ListBox
    Friend WithEvents Exshow As System.Windows.Forms.CheckBox
    Friend WithEvents SearchWord As System.Windows.Forms.TextBox
    Friend WithEvents SearchWord_btn As System.Windows.Forms.Button
    Friend WithEvents Voice_List As System.Windows.Forms.ComboBox
    Friend WithEvents meaning As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Shadowing As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents RepeatNum As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ShadowingSEC As System.Windows.Forms.NumericUpDown

End Class

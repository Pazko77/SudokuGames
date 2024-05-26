Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Public Class StatsUser
    Private name As String
    Private level As String
    Private time As String
    Private Score As String
    Private Sub Stats_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim filePath As String = "User.txt"
        Dim maxWidthName As Integer = 0
        Dim maxWidthLevel As Integer = 0
        Dim maxWidthTimeScore As Integer = 0


        Dim lines As String() = File.ReadAllLines(filePath)
        For Each line As String In lines
            Dim parts As String() = line.Split(","c)
            Select Case parts.Length
                Case 1
                    name = parts(0).Trim()

                Case 4
                    name = parts(0).Trim()
                    level = parts(1).Trim()
                    time = parts(2).Trim()
                    Score = parts(3).Trim()

            End Select

            ListBox1.Items.Add($"Name: {name}")
            ListBox3.Items.Add($"Level: {level}")
            ListBox2.Items.Add($"Time: {time}, Score: {Score}")

        Next

        For Each item As String In ListBox1.Items
            Dim itemWidthName As Integer = TextRenderer.MeasureText(item, ListBox1.Font).Width
            If itemWidthName > maxWidthName Then
                maxWidthName = itemWidthName
            End If
        Next

        For Each item As String In ListBox3.Items
            Dim itemWidthLevel As Integer = TextRenderer.MeasureText(item, ListBox3.Font).Width
            If itemWidthLevel > maxWidthLevel Then
                maxWidthLevel = itemWidthLevel
            End If
        Next

        For Each item As String In ListBox2.Items
            Dim itemWidth As Integer = TextRenderer.MeasureText(item, ListBox2.Font).Width
            If itemWidth > maxWidthTimeScore Then
                maxWidthTimeScore = itemWidth
            End If
        Next
        ListBox1.Width = maxWidthName + SystemInformation.VerticalScrollBarWidth
        ListBox3.Width = maxWidthLevel + SystemInformation.VerticalScrollBarWidth
        ListBox2.Width = maxWidthTimeScore + SystemInformation.VerticalScrollBarWidth

        Dim X As Integer = 47
        Dim Y As Integer = 75

        ListBox1.Location = New Point(X, Y)
        ListBox3.Location = New Point(ListBox1.Left + ListBox1.Width + 30, Y)
        ListBox2.Location = New Point(ListBox3.Left + ListBox3.Width + 30, Y)


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class
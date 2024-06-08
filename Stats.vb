Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Public Class StatsUser
    Dim filePath As String = "User.txt"
    Dim buttonclick As Boolean = True

    Dim allPlayers As New List(Of (Name As String, Level As String, Time As Integer, Score As String, NbPartie As String, TempsTotal As String))

    Private Sub Stats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("All")
        ComboBox1.Items.Add("Easy")
        ComboBox1.Items.Add("Normal")
        ComboBox1.Items.Add("Hard")
        ComboBox1.SelectedIndex = 0

        Dim maxWidthListBox1 As Integer = 0

        Dim lines As String() = File.ReadAllLines(filePath)

        For Each line As String In lines
            Dim parts As String() = line.Split(","c)
            If parts.Length = 6 Then
                Dim name As String = parts(0).Trim()
                Dim level As String = parts(1).Trim()
                Dim time As Integer = parts(2).Trim()
                Dim score As String = parts(3).Trim()
                Dim nbPartie As String = parts(4).Trim()
                Dim tempstotal As String = parts(5).Trim()

                allPlayers.Add((name, level, time, score, nbPartie, tempstotal))
                ComboBox2.Items.Add(name)
            End If
        Next

        DisplayPlayers("All")

        For Each item As String In ListBox1.Items
            Dim itemWidth As Integer = TextRenderer.MeasureText(item, ListBox1.Font).Width
            If itemWidth > maxWidthListBox1 Then
                maxWidthListBox1 = itemWidth
            End If
        Next

        ListBox1.Width = maxWidthListBox1 + SystemInformation.VerticalScrollBarWidth
        ListBox1.Location = New Point((Width / 2) - (ListBox1.Width / 2), (Height / 2) - (ListBox1.Height / 2))
        Button2.Location = New Point(Button1.Right + 10, Button1.Top)
        Button2.Height = Button1.Height
        Label1.Top = Button1.Top
        ComboBox1.Location = New Point(Label1.Left, Button1.Bottom)
        Label2.Location = New Point(Label1.Right + 150, Label1.Top)
        ComboBox2.Location = New Point(Label2.Left, Button2.Bottom)
        Button3.Location = New Point(ComboBox2.Right + 50, ComboBox2.Top)
    End Sub

    Private Sub DisplayPlayers(level As String)
        ListBox1.Items.Clear()
        For Each player In allPlayers
            If level = "All" OrElse player.Level.Equals(level, StringComparison.OrdinalIgnoreCase) Then
                ListBox1.Items.Add($"Nom: {player.Name}        Difficulte: {player.Level}           Meilleur Temps: {convertir_en_date(player.Time).ToString("mm:ss")}          Score: {player.Score}          Nombre de partie: {player.NbPartie}         Temps total: {convertir_en_date(player.TempsTotal).ToString("HH:mm:ss")}")
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Sorted = Not ListBox1.Sorted
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MenuJeu.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        DisplayPlayers(ComboBox1.SelectedItem.ToString())
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim lines As String() = File.ReadAllLines(filePath)
        Dim stats As List(Of String) = New List(Of String)(lines)
        Dim ligneIndex As Integer = getIndex(ComboBox2.Text, lines, stats)
        Dim ligne As String = lines(ligneIndex)
        Dim parts As String() = ligne.Split(","c)
        Dim name As String = parts(0).Trim()
        Dim level As String = parts(1).Trim()
        Dim time As String = parts(2).Trim()
        Dim score As String = parts(3).Trim()
        Dim nbPartie As String = parts(4).Trim()
        Dim tempstotal As String = parts(5).Trim()
        MsgBox($"Nom:  {name}   {vbCrLf}Difficulte:  {level}{vbCrLf}Meilleur Temps:  {convertir_en_date(time).ToString(("HH:mm:ss"))}{vbCrLf}Score:  {score}{vbCrLf}Nombre de partie:  {nbPartie}{vbCrLf}Temps total:  {tempstotal}")
    End Sub

    Private Function convertir_en_date(temps As Integer) As DateTime
        Dim s As TimeSpan = TimeSpan.FromSeconds(temps)
        Dim best As DateTime = New DateTime(s.Ticks)
        Return best
    End Function
End Class
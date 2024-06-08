Imports System.IO
Public Class MenuJeu
    Dim keyorder() As Object = {Keys.B, Keys.U, Keys.T, Keys.D1}

    Dim index As Integer = 0
    Dim sequence() As Boolean = {False, False, False, False}
    Private filePath As String = "User.txt"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("Erreur, entre un nom pour jouer")
        Else
            Form1.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub MenuJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Dim height As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim width As Integer = Screen.PrimaryScreen.Bounds.Width
        Me.Height = height
        Me.Width = width
        Panel1.Location = New Point(width / 2 - Panel1.Width / 2, height / 2 - Panel1.Height / 2)
        Button5.Location = New Point(width - Button5.Width - 10, 0 + 10)
        Button2.Location = New Point(10, 10)

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show("Are u sure？", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            MsgBox("See u next time!")
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        StatsUser.Show()
    End Sub
    Private Sub MenuJeu_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If Index < 3 And sequence(Index) = False And e.KeyCode = keyorder(Index) Then
            sequence(Index) = True
            Index += 1
        ElseIf Index = 3 And e.KeyCode = keyorder(Index) Then
            Credit.Show()
            Me.Hide()
        Else
            Index = 0
            For i As Integer = 0 To sequence.Length - 1
                sequence(i) = False
            Next
        End If
    End Sub
End Class
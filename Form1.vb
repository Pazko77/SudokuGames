Public Class Form1
    Private Sub Button_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click, Button2.Click, Button3.Click
        SudokuGames.Timer1.Start()
        SudokuGames.Show()
        If sender Is Button1 Then
            SudokuGames.UpdateValue(31)
        ElseIf sender Is Button2 Then
            SudokuGames.UpdateValue(53)
        ElseIf sender Is Button3 Then
            SudokuGames.UpdateValue(60)
        End If

        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MenuJeu.Show()
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim height As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim width As Integer = Screen.PrimaryScreen.Bounds.Width
        MsgBox(height & " " & width)
        Me.Height = height
        Me.Width = width
        For Each Button As Button In Me.Controls
            Button.BackgroundImage = My.Resources.button
        Next

    End Sub
End Class
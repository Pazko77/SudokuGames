Public Class Form1

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MenuJeu.Show()
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SudokuGames.UpdateValue(31, "Easy")
        SudokuGames.Show()
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SudokuGames.UpdateValue(53, "Normal")
        SudokuGames.Show()
        Me.Close()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SudokuGames.UpdateValue(60, "Hard")
        SudokuGames.Show()
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim height As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim width As Integer = Screen.PrimaryScreen.Bounds.Width
        Me.Height = height
        Me.Width = width
        For Each Button As Button In Me.Controls
            Button.BackgroundImage = My.Resources.button
        Next

    End Sub
End Class
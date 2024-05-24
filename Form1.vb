Public Class Form1
    Private Sub Button_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click, Button2.Click, Button3.Click
        SudokuGames.Timer1.Start()
        SudokuGames.Show()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SudokuGames.UpdateValue(31)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SudokuGames.UpdateValue(53)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SudokuGames.UpdateValue(60)
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
Public Class SudokuGames
    Private Sub SudokuGames_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cellule(8, 8) As Button
        Const SIZE As Integer = 30
        Const offset As Integer = 2
        Dim X, Y, offsetX, offsetY As Integer
        Panel1.Height = 295
        Panel1.Width = 295
        For Y = 0 To 8
            offsetY = offset
            If Y >= 3 And Y <= 5 Then
                offsetY = offsetY + 10
            Else
                If Y >= 6 Then
                    offsetY = offsetY + 20
                End If
            End If
            For X = 0 To 8
                offsetX = offset
                If X >= 3 And X <= 5 Then
                    offsetX = offsetX + 10
                Else
                    If X >= 6 Then
                        offsetX = offsetX + 20
                    End If
                End If
                cellule(X, Y) = New Button
                cellule(X, Y).Location = New Point((X * SIZE) + offsetX, (Y * SIZE) + offsetY)
                cellule(X, Y).Height = SIZE
                cellule(X, Y).Width = SIZE
                cellule(X, Y).BackColor = Color.White
                cellule(X, Y).Tag = Y & X
                cellule(X, Y).Text = Y & X
                AddHandler cellule(X, Y).Click, AddressOf button_click
                Panel1.Controls.Add(cellule(X, Y))
            Next
        Next
        MsgBox(Panel1.Width & Panel1.Height)
    End Sub

    Private Sub button_click(sender As Object, e As EventArgs)
        MsgBox(sender.tag)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Panel1.BackColor = Color.Gray
    End Sub
End Class

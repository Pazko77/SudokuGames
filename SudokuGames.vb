Imports System.Windows.Forms.VisualStyles

Public Class SudokuGames
    Dim plateau As Integer()() = creerPlateau()
    Dim solution As Integer()() = RetireNombresSudoku(plateau, 40)
    Private Sub SudokuGames_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grille()
    End Sub

    Function grille()
        Dim cellule(8, 8) As TextBox
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
                cellule(X, Y) = New TextBox
                cellule(X, Y).Location = New Point((X * SIZE) + offsetX, (Y * SIZE) + offsetY)
                cellule(X, Y).Multiline = True
                cellule(X, Y).TextAlign = HorizontalAlignment.Center
                'cellule(X, Y).TextAlign = VerticalAlignment.Center
                cellule(X, Y).Height = SIZE
                cellule(X, Y).Width = SIZE
                cellule(X, Y).BackColor = Color.White
                cellule(X, Y).Tag = Y & X
                cellule(X, Y).Text = Y & X
                AddHandler cellule(X, Y).TextChanged, AddressOf textbox_change
                Panel1.Controls.Add(cellule(X, Y))
            Next
        Next
    End Function

    Private Sub textbox_change(sender As Object, e As EventArgs)
        MsgBox(sender.tag)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Panel1.BackColor = Color.Gray
    End Sub
End Class

Imports System.Threading

Public Class SudokuGames
    Private seconds As Integer = 60
    Private minutes As Integer = 6
    Private hours As Integer = 0
    Dim cellule(8, 8) As TextBox
    Const SIZE As Integer = 30
    Const offset As Integer = 2
    Private difficulte As Integer
    Private SudokuBoard_Correction As Integer()()
    Private sudokuBoard As Integer()() = creerPlateau()
    Private score As Integer = 0
    Private HP As Integer = 3
    Public Sub UpdateValue(newValue As Integer)

        difficulte = newValue
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SudokuBoard_Correction = DeepCopy(sudokuBoard)
        sudokuBoard = RetireNombresSudoku(sudokuBoard, difficulte)
        For Each row As Integer() In SudokuBoard_Correction
            Console.WriteLine(String.Join(" ", row))
        Next


        Dim X, Y, offsetX, offsetY As Integer
        Panel1.Height = 295
        Panel1.Width = 295
        For Y = 0 To 8
            offsetY = offset
            If Y >= 3 And Y <= 5 Then
                offsetY = offsetY + 10
            ElseIf Y >= 6 Then
                offsetY = offsetY + 20
            End If
            For X = 0 To 8
                offsetX = offset
                If X >= 3 And X <= 5 Then
                    offsetX = offsetX + 10
                ElseIf X >= 6 Then
                    offsetX = offsetX + 20
                End If
                cellule(X, Y) = New TextBox
                cellule(X, Y).Location = New Point((X * SIZE) + offsetX, (Y * SIZE) + offsetY)
                cellule(X, Y).Height = SIZE
                cellule(X, Y).Width = SIZE
                cellule(X, Y).BackColor = Color.White
                cellule(X, Y).Tag = New Point(X, Y)
                cellule(X, Y).Text = If(sudokuBoard(Y)(X) = 0, "", sudokuBoard(Y)(X).ToString())
                AddHandler cellule(X, Y).TextChanged, AddressOf textBox_TextChanged
                AddHandler cellule(X, Y).KeyPress, AddressOf TextBox_KeyPress
                Panel1.Controls.Add(cellule(X, Y))
            Next
        Next
        Label3.Text = MenuJeu.ComboBox1.Text
        Timer1.Start()
    End Sub

    Private Function creerPlateau() As Integer()()
        Dim plateau(8)() As Integer
        For i As Integer = 0 To 8
            plateau(i) = New Integer(8) {}
        Next
        GenereSolution(plateau)
        Return plateau
    End Function

    Private Function estValide(ByVal plateau As Integer()(), ByVal row As Integer, ByVal col As Integer, ByVal num As Integer) As Boolean
        If plateau(row).Contains(num) Then
            Return False
        End If

        If [Enumerable].Contains([Enumerable].Select(plateau, Function(i) i(col)), num) Then
            Return False
        End If

        Dim startRow As Integer = 3 * (row \ 3)
        Dim startCol As Integer = 3 * (col \ 3)
        Dim square As Integer() = [Enumerable].SelectMany(plateau.Skip(startRow).Take(3), Function(i) i.Skip(startCol).Take(3)).ToArray()
        If square.Contains(num) Then
            Return False
        End If

        Return True
    End Function

    Private Function GenereSolution(ByRef board As Integer()()) As Boolean
        Dim row As Integer
        Dim col As Integer
        Randomize()
        For row = 0 To 8
            For col = 0 To 8
                If board(row)(col) = 0 Then
                    Dim num As Integer
                    Dim numList As New List(Of Integer)
                    For num = 1 To 9
                        numList.Add(num)
                    Next
                    numList = numList.OrderBy(Function(x) Rnd()).ToList()
                    For Each num In numList
                        If estValide(board, row, col, num) Then
                            board(row)(col) = num
                            If GenereSolution(board) Then
                                Return True
                            End If
                            board(row)(col) = 0
                        End If
                    Next
                    Return False
                End If
            Next
        Next
        Return True

    End Function

    Public Function RetireNombresSudoku(ByVal grille As Integer()(), ByVal nbARetirer As Integer) As Integer()()
        Dim rand As New Random()
        Dim removed As Integer = 0
        While removed < nbARetirer
            Dim x As Integer = rand.Next(0, 9)
            Dim y As Integer = rand.Next(0, 9)
            If grille(x)(y) <> 0 Then
                grille(x)(y) = 0
                removed += 1
            End If
        End While
        Return grille
    End Function

    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

        Dim textBox As TextBox = DirectCast(sender, TextBox)
        Dim currentValue As Integer
        If Integer.TryParse(textBox.Text & e.KeyChar, currentValue) Then
            If currentValue < 1 OrElse currentValue > 9 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub textBox_TextChanged(sender As Object, e As EventArgs)
        Dim textBox As TextBox = DirectCast(sender, TextBox)
        Dim position As Point = DirectCast(textBox.Tag, Point)
        Dim X As Integer = position.X
        Dim Y As Integer = position.Y

        Dim currentValue As Integer
        If Integer.TryParse(textBox.Text, currentValue) Then
            If Check_reponse(X, Y, currentValue) = False Then
                textBox.ForeColor = Color.Red
                HP -= 1
                Actualiser_HP(HP)
            Else
                textBox.ForeColor = Color.Black
                Calculer_afficher_Point(X, Y)

            End If
        End If

        CheckIfGameFinished()
    End Sub

    Private Sub CheckIfGameFinished()
        For Each tb As TextBox In cellule
            If String.IsNullOrEmpty(tb.Text) Then
                Exit Sub
            End If
        Next
        Timer1.Stop()
        Thread.Sleep(2000)
        Me.Hide()
        MenuJeu.Enregistrer_score(Label3.Text, minutes, seconds, score)
        GG.Show()
    End Sub

    Private Sub Calculer_afficher_Point(Y As Integer, X As Integer)
        Dim countY As Integer = 0
        Dim countX As Integer = 0

        For i = 0 To 8
            If sudokuBoard(i)(X) = 0 Then
                countY += 1
            End If
            If sudokuBoard(Y)(i) = 0 Then
                countX += 1
            End If
        Next
        If countX > countY Then
            score += countX * (seconds + minutes * 60)
        Else
            score += countY * (seconds + minutes * 60)
        End If
        Label6.Text = score
    End Sub

    Private Function Check_reponse(X As Integer, Y As Integer, valeur As Integer)
        If SudokuBoard_Correction(Y)(X) <> valeur Then
            Return False
        End If
        Return True
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        seconds -= 1
        If seconds <= 0 Then
            seconds = 59
            minutes -= 1
        End If
        If minutes = 0 And seconds <= 0 Then
            Me.Hide()
            MessageBox.Show("You failed")
        End If
        Label1.Text = String.Format("{0:D2}:{1:D2}", minutes, seconds)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As DialogResult = MessageBox.Show("Abandonner cette partie et retour dans le menu ?", "Give up", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
            MenuJeu.Show()
        End If
    End Sub

    Private Function DeepCopy(Of T)(ByVal source As T()()) As T()()
        Dim result As T()() = New T(source.Length - 1)() {}
        For i As Integer = 0 To source.Length - 1
            result(i) = CType(source(i).Clone(), T())
        Next
        Return result
    End Function

    Private Sub Actualiser_HP(HP As Integer)
        Select Case HP
            Case 2
                PictureBox1.Visible = False
            Case 1
                PictureBox1.Visible = False
                PictureBox4.Visible = False
            Case 0
                PictureBox1.Visible = False
                PictureBox2.Visible = False
                PictureBox4.Visible = False
                Thread.Sleep(2000)
                Form2.Show()
                Me.Hide()

        End Select
    End Sub

End Class

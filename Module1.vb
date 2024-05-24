Module Module1

    Public Function estValide(ByVal plateau As Integer()(), ByVal row As Integer, ByVal col As Integer, ByVal num As Integer) As Boolean
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

    Function GenereSolution(ByRef board As Integer()()) As Boolean
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

    Function creerPlateau() As Integer()()
        Dim plateau(8)() As Integer
        For i As Integer = 0 To 8
            plateau(i) = New Integer(8) {}
        Next
        GenereSolution(plateau)
        Return plateau
    End Function
    Public Function RetireNombresSudoku(ByVal grille As Integer()(), ByVal nbARetirer As Integer) As Integer()()
        Dim rand As New Random()
        For i As Integer = 1 To nbARetirer
            Dim x As Integer = rand.Next(0, 9)
            Dim y As Integer = rand.Next(0, 9)
            If grille(x)(y) <> 0 Then
                grille(x)(y) = 0
            End If
        Next
        Return grille
    End Function
    Sub Main()
        Application.Run(SudokuGames)
        Dim sudokuBoard As Integer()() = creerPlateau()
        For Each row As Integer() In sudokuBoard
            Console.WriteLine(String.Join(" ", row))
        Next
        Console.WriteLine("\n\n")
        sudokuBoard = RetireNombresSudoku(sudokuBoard, 40)
        For Each row As Integer() In sudokuBoard
            Console.WriteLine(String.Join(" ", row))
        Next

    End Sub
End Module

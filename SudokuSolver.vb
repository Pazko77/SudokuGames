Imports System
Imports System.Collections.Generic

Module SudokuSolver
    Function IsValid(ByVal board As Integer(,), ByVal row As Integer, ByVal col As Integer, ByVal num As Integer) As Boolean
        ' V¨¦rifier la ligne
        If board(row, _).Contains(num) Then
            Return False
        End If

        ' V¨¦rifier la colonne
        If [Enumerable].Any(board.GetColumn(col), Function(x) x = num) Then
            Return False
        End If

        ' V¨¦rifier le carr¨¦ 3x3
        Dim startRow As Integer = 3 * (row \ 3)
        Dim startCol As Integer = 3 * (col \ 3)
        Dim square As List(Of Integer) = New List(Of Integer)()
        For i As Integer = startRow To startRow + 2
            For j As Integer = startCol To startCol + 2
                square.Add(board(i, j))
            Next
        Next
        If square.Contains(num) Then
            Return False
        End If

        Return True
    End Function

    Function SolveSudoku(ByVal board As Integer(,)) As Boolean
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                If board(row, col) = 0 Then
                    Dim numbers As List(Of Integer) = New List(Of Integer)(1 To 9)
                    numbers.Shuffle()
                    For Each num As Integer In numbers
                        If IsValid(board, row, col, num) Then
                            board(row, col) = num
                            If SolveSudoku(board) Then
                                Return True
                            End If
                            board(row, col) = 0
                        End If
                    Next
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Function CreateSudokuBoard() As Integer(,)
        Dim board As Integer(,) = New Integer(8, 8) {}
        SolveSudoku(board)
        Return board
    End Function

    Sub Main()
        Dim sudokuBoard As Integer(,) = CreateSudokuBoard()
        For Each row As Integer() In sudokuBoard
            Console.WriteLine(String.Join(" ", row))
        Next
    End Sub
End Module


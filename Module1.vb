Imports System.IO
Module Module1
    Dim filePath As String = "User.txt"
    Sub Main()
        If Not File.Exists(filePath) Then
            File.Create(filePath).Dispose()
        End If
        Dim lines As String() = File.ReadAllLines(filePath)
        For Each line As String In lines

            Dim parts As String() = line.Split(","c)
            If parts.Length = 6 Then
                MenuJeu.ComboBox1.Items.Add(parts(0))
            End If

        Next
        Application.Run(MenuJeu)
    End Sub

    Public Function getIndex(name As String, lignes As String(), stats As List(Of String))
        Dim ligne As Integer = -1
        For i As Integer = 0 To stats.Count - 1
            Dim parts As String() = stats(i).Split(","c)
            If parts(0).Trim() = name Then
                ligne = i
                Exit For
            End If
        Next
        Return ligne
    End Function

    Public Sub Enregistrer_score(name As String, score As Integer, level As String, tempsjouer As Integer, Perdu As Boolean)
        Dim lines As String() = File.ReadAllLines(filePath)
        Dim stats As List(Of String) = New List(Of String)(lines)
        Dim ligne As Integer = getIndex(name, lines, stats)

        If ligne <> -1 Then

            Dim parts As String() = stats(ligne).Split(","c)
            Dim MeilleurTemps As Integer = Integer.Parse(parts(2))
            Dim nbPartie As Integer = Integer.Parse(parts(4).Trim())
            Dim NewtotalTemps As Integer = Integer.Parse(parts(5).Trim())
            nbPartie += 1
            NewtotalTemps += tempsjouer
            If Perdu Then
                stats(ligne) = $"{name},{parts(1).Trim()},{parts(2).Trim()},{parts(3).Trim()},{nbPartie},{NewtotalTemps}"
            ElseIf tempsjouer > MeilleurTemps Then
                stats(ligne) = $"{name},{level},{tempsjouer},{score},{nbPartie},{NewtotalTemps}"
            Else
                stats(ligne) = $"{name},{level},{MeilleurTemps},{score},{nbPartie},{NewtotalTemps}"
            End If
        Else If Perdu Then
            stats.Add($"{name},{level},{0},{0},{1},{tempsjouer}")
        Else
            stats.Add($"{name},{level},{tempsjouer},{score},{1},{tempsjouer}")
        End If

        File.WriteAllLines(filePath, stats.ToArray())
    End Sub

End Module
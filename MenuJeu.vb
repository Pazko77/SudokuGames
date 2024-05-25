Imports System.IO
Public Class MenuJeu
    Dim autoCompleteCollection As New AutoCompleteStringCollection()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("Erreur, entre un nom pour jouer")
        Else
            SaveComboBoxText(ComboBox1.Text)
            Form1.Show()

        End If
        Me.Hide()
    End Sub

    Private Sub Afficher_Les_Noms(filePath As String)
        Using reader As New StreamReader(filePath)
            Dim line As String
            While Not reader.EndOfStream
                line = reader.ReadLine()
                ComboBox1.Items.Add(line)
            End While

        End Using

    End Sub

    Private Sub Ajouter_Items_Combobox1()
        For Each item As Object In ComboBox1.Items
            autoCompleteCollection.Add(item.ToString())
        Next
        ComboBox1.AutoCompleteCustomSource = autoCompleteCollection
    End Sub

    Private Sub Ajouter_Items_Combobox1(Nouveau As String)
        autoCompleteCollection.Add(Nouveau.ToString)
    End Sub
    Private Sub SaveComboBoxText(text As String)
        Dim filePath As String = "User.txt"
        Dim exists As Boolean = False

        If IO.File.Exists(filePath) Then
            Dim lines As String() = IO.File.ReadAllLines(filePath)
            For Each line As String In lines
                If line = text Then
                    exists = True
                    Exit For
                End If
            Next
        End If

        If Not exists Then
            GenerateTextFile(filePath, text)
            ComboBox1.Items.Add(text)
            autoCompleteCollection.Add(text.ToString())
        End If

    End Sub

    Private Sub GenerateTextFile(filePath As String, content As String)
        Using writer As New StreamWriter(filePath, append:=True)
            writer.WriteLine(content)
        End Using
    End Sub

    Private Sub MenuJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim height As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim width As Integer = Screen.PrimaryScreen.Bounds.Width
        Me.Height = height
        Me.Width = width
        Panel1.Location = New Point(width / 2 - Panel1.Width / 2, height / 2 - Panel1.Height / 2)

        Dim filePath As String = "User.txt"
        Afficher_Les_Noms(filePath)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show("Are u sure？", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
            MsgBox("See u next time!")
        End If
    End Sub

End Class
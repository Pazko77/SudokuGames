Imports System.IO
Public Class MenuJeu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("Erreur, entre un nom pour jouer")
        Else
            SaveComboBoxText(ComboBox1.Text)
            Form1.Show()
            Me.Hide()

        End If
    End Sub

    Private Sub SaveComboBoxText(text As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("User.txt", True)
        file.WriteLine(text)
        file.Close()
    End Sub

    Private Sub MenuJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim height As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim width As Integer = Screen.PrimaryScreen.Bounds.Width
        Me.Height = height
        Me.Width = width
        Panel1.Location = New Point(width / 2 - Panel1.Width / 2, height / 2 - Panel1.Height / 2)

        Dim filePath As String = "User.txt"

        If File.Exists(filePath) Then
            Using reader As New StreamReader(filePath)
                Dim line As String
                While Not reader.EndOfStream
                    line = reader.ReadLine()
                    ComboBox1.Items.Add(line)
                End While
            End Using
            Dim autoCompleteCollection As New AutoCompleteStringCollection()
            For Each item As Object In ComboBox1.Items
                autoCompleteCollection.Add(item.ToString())
            Next
            ComboBox1.AutoCompleteCustomSource = autoCompleteCollection
        End If

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

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class
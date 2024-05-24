Public Class MenuJeu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("Erreur, entre un nom pour jouer")
        Else
            Form1.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub MenuJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim height As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim width As Integer = Screen.PrimaryScreen.Bounds.Width
        MsgBox(height & " " & width)
        Me.Height = height
        Me.Width = width
        Panel1.Location = New Point(width / 2 - Panel1.Width / 2, height / 2 - Panel1.Height / 2)


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
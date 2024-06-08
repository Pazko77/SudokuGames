Imports System.Drawing.Text
Imports System.Reflection.Emit

Public Class Credit
    Const pas As Integer = 15
    Private Sub Credit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        Dim height As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim width As Integer = Screen.PrimaryScreen.Bounds.Width
        Button1.Location = New Point(20, 20)
        PictureBox1.Location = New Point(width / 3, height / 2 - PictureBox1.Height / 2)
        PictureBox2.Location = New Point(2 * width / 3, height / 2 - PictureBox2.Height / 2)
        Label1.ForeColor = Color.White
        Label1.Text = "Credit"
        Label1.Location = New Point(width / 2 - Label1.Width / 2, 50)
    End Sub

    Private Sub Credit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Dim X1 As Integer = PictureBox1.Left
        Dim Y1 As Integer = PictureBox1.Top
        Select Case UCase(e.KeyChar)
            Case "Q"
                X1 -= pas
            Case "D"
                X1 += pas
            Case "Z"
                Y1 -= pas
            Case "S"
                Y1 += pas
        End Select
        PictureBox1.Location = New Point(X1, Y1)
    End Sub

    Private Sub Credit_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim X2 As Integer = PictureBox2.Left
        Dim Y2 As Integer = PictureBox2.Top
        Select Case e.KeyCode
            Case Keys.J
                X2 -= pas
            Case Keys.L
                X2 += pas
            Case Keys.I
                Y2 -= pas
            Case Keys.K
                Y2 += pas
        End Select
        PictureBox2.Location = New Point(X2, Y2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        MenuJeu.Show()
    End Sub
End Class
Public Class Form2

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        If keyData = Keys.D Or keyData = Keys.Right Then 'walk right

            If PictureBox1.Location.X - (DeltaX) <= -550 Then
                PictureBox1.Location = New Point(-550, PictureBox1.Location.Y)
            Else
                PictureBox1.Location = New Point(PictureBox1.Location.X - (DeltaX), PictureBox1.Location.Y)
            End If

            Return True


        End If


        If keyData = Keys.A Or keyData = Keys.Left Then 'walk left

            If PictureBox1.Location.X + (DeltaX) > 0 Then
                PictureBox1.Location = New Point(0, PictureBox1.Location.Y)
            Else
                PictureBox1.Location = New Point(PictureBox1.Location.X + (DeltaX), PictureBox1.Location.Y)
            End If


            Return True

        End If

    End Function




    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PictureBox1.Location = New Point(StartPosx, StartPosy)


    End Sub


    Public Function AddSpriteTransWhite(ByRef mypict As Bitmap, ByVal sprite As Bitmap, ByVal xpos As Integer, ByVal ypos As Integer) As Bitmap

        Dim MyColor As Color
        Dim lx, ly, i As Integer
        Dim rect As RectangleF

        'pixfmt = sprite.GetPixelFormatSize()
        rect = sprite.GetBounds(GraphicsUnit.Pixel)
        lx = rect.Width
        ly = rect.Height
        'sprite.MakeTransparent()
        For x = 0 To lx - 1
            For y = 0 To ly - 1
                MyColor = sprite.GetPixel(x, y)
                If MyColor.R = 255 And MyColor.B = 255 And MyColor.G = 255 Then
                    i = 1
                    'nothing
                Else
                    mypict.SetPixel(xpos + x, ypos + y, MyColor)
                End If
            Next
        Next

        Return mypict

    End Function


    Public Function AddSpriteTransBlack(ByRef mypict As Bitmap, ByVal sprite As Bitmap, ByVal xpos As Integer, ByVal ypos As Integer) As Bitmap

        Dim MyColor As Color
        Dim lx, ly, i As Integer
        Dim px, py As Integer
        Dim rect1, rect2 As RectangleF

        Try

            rect1 = sprite.GetBounds(GraphicsUnit.Pixel)
            lx = rect1.Width
            ly = rect1.Height
            rect2 = mypict.GetBounds(GraphicsUnit.Pixel)
            px = rect2.Width
            py = rect2.Height
            If lx + xpos > px Then
                MsgBox("Width from picture " + sprite.Tag + " to big")
            End If
            If ly + ypos > py Then
                MsgBox("Height from picture " + sprite.Tag + " to big")
            End If

            For x = 0 To lx - 1
                For y = 0 To ly - 1
                    MyColor = sprite.GetPixel(x, y)
                    If MyColor.R = 0 And MyColor.B = 0 And MyColor.G = 0 Then
                        i = 1
                        'nothing
                    Else
                        mypict.SetPixel(xpos + x, ypos + y, MyColor)
                    End If
                Next
            Next

            Return mypict

        Catch ex As Exception

            Return mypict

        End Try


    End Function

    Public Function AddSprite(ByRef mypict As Bitmap, ByVal sprite As Bitmap, ByVal xpos As Integer, ByVal ypos As Integer) As Bitmap
        Dim MyColor As Color
        Dim lx, ly As Integer
        Dim px, py As Integer
        Dim rect1, rect2 As RectangleF

        Try
            rect1 = sprite.GetBounds(GraphicsUnit.Pixel)
            lx = rect1.Width
            ly = rect1.Height
            rect2 = mypict.GetBounds(GraphicsUnit.Pixel)
            px = rect2.Width
            py = rect2.Height

            If lx + xpos > px Then
                MsgBox("Width from picture " + sprite.Tag + " to big")
            End If
            If ly + ypos > py Then
                MsgBox("Height from picture " + sprite.Tag + " to big")
            End If

            For x = 0 To lx - 1
                For y = 0 To ly - 1
                    MyColor = sprite.GetPixel(x, y)
                    mypict.SetPixel(xpos + x, ypos + y, MyColor)
                Next
            Next

            Return mypict

        Catch ex As Exception

            Return mypict

        End Try

    End Function





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim bmp As Bitmap

        bmp = PictureBox1.Image

        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-right-001.bmp") '+ ActorName + ".bmp")
        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PictureBox1.Image = bmp




    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



    End Sub
End Class
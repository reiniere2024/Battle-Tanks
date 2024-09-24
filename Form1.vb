Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class Form1
    Private objRandom As New System.Random(CType(System.DateTime.Now.Ticks Mod System.Int32.MaxValue, Integer))
    Private TempobjRandom As New System.Random(CType(System.DateTime.Now.Ticks Mod System.Int32.MaxValue, Integer))


    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'detect up arrow key
        Dim py, bx, by As Integer

        If keyData = Keys.Space Or keyData = Keys.F Then

            FiringGoingOn = True
            Timer2.Start()

            Return True

        End If

        If keyData = Keys.W Or keyData = Keys.Up Then

            If CanonActive = True Then
                If CanonCurNr < 8 Then
                    CanonCurNr = CanonCurNr + 1
                    Me.ShowTank(CanonCurNr)

                    CurrentPosX = CurrentPosX
                    CurrentPosY = CurrentPosY + CurrentPosYDeltaY
                    Me.WriteCurrentPosition()

                Else
                    CanonCurNr = CanonCurNr + 1
                    If CanonCurNr = 29 Then
                        CanonActive = False
                    Else
                        Me.ShowTank(0)
                        CurrentPosX = CurrentPosX
                        CurrentPosY = CurrentPosY + CurrentPosYDeltaY
                        Me.WriteCurrentPosition()

                    End If

                End If
                TextBox2.Text = CanonPosx

            End If

            TextBox1.Text = BulletPosx
            TextBox4.Text = CanonCurNr.ToString()

            Return True
        End If

        If keyData = Keys.S Or keyData = Keys.Down Then

            If CanonActive = True Then
                If CanonCurNr > 1 And CanonCurNr <= 9 Then
                    CanonCurNr = CanonCurNr - 1
                    Me.ShowTank(CanonCurNr)

                    CurrentPosX = CurrentPosX
                    CurrentPosY = CurrentPosY - CurrentPosYDeltaY
                    Me.WriteCurrentPosition()

                ElseIf CanonCurNr > 9 Then
                    CanonCurNr = CanonCurNr - 1
                    Me.ShowTank(0)

                    CurrentPosX = CurrentPosX
                    CurrentPosY = CurrentPosY - CurrentPosYDeltaY
                    Me.WriteCurrentPosition()

                ElseIf CanonCurNr = 1 Then
                    CanonCurNr = 0
                    Me.ShowTank(0)

                    CurrentPosX = CurrentPosX
                    CurrentPosY = CurrentPosY - CurrentPosYDeltaY
                    Me.WriteCurrentPosition()

                End If
                TextBox2.Text = CanonPosx

            End If

            TextBox1.Text = BulletPosx
            TextBox4.Text = CanonCurNr.ToString()

            Return True

        End If


        If keyData = Keys.D Or keyData = Keys.Right Then 'walk right

            'If FiringGoingOn = True Then
            '    Return True
            'End If

            CurPosx = CurPosx + DeltaX
            CurPosy = CurPosy
            CurrentPosX = CurrentPosX - CurrentPosXDeltaX
            CurrentPosY = CurrentPosY
            Me.WriteCurrentPosition()



            BulletPosx = BulletPosx + DeltaX

            If CurPosx >= PosxMax Then
                CurPosx = 0
                BulletPosx = BulletPosxLeft
                Panel1.AutoScrollPosition = New Drawing.Point((CurPosx), (CurPosy))
            Else
                Panel1.AutoScrollPosition = New Drawing.Point((CurPosx), (CurPosy))
            End If

            TextBox1.Text = BulletPosx
            TextBox2.Text = CanonPosx

            TextBox4.Text = CanonCurNr.ToString()


            Return True
        End If

        If keyData = Keys.A Or keyData = Keys.Left Then 'walk left

            'If FiringGoingOn = True Then
            '    Return True
            'End If

            CurPosx = CurPosx - DeltaX
            CurPosy = CurPosy
            CurrentPosX = CurrentPosX + CurrentPosXDeltaX
            CurrentPosY = CurrentPosY
            Me.WriteCurrentPosition()



            BulletPosx = BulletPosx - DeltaX

            If CurPosx < 0 Then
                CurPosx = PosxMax
                BulletPosx = BulletPosxRight
            End If
            Panel1.AutoScrollPosition = New Drawing.Point((CurPosx), (CurPosy))

            TextBox1.Text = BulletPosx
            TextBox2.Text = CanonPosx
            TextBox4.Text = CanonCurNr.ToString()

            Return True
        End If

    End Function



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BattlePlace = PB1.Image.Clone()
        Radar = PBRadar.Image.Clone()

        Panel1.AutoScroll = True
        PB1.SizeMode = PictureBoxSizeMode.AutoSize
        Panel1.AutoScrollPosition = New Drawing.Point(StartPosx, StartPosy)

        Dim bm As New Bitmap(ImageCopyW, ImageCopyH)
        Using gr As Graphics = Graphics.FromImage(bm)
            Dim src_rect As New Rectangle(CanonPosx, CanonPosy, ImageCopyW, ImageCopyH)
            Dim dst_rect As New Rectangle(0, 0, ImageCopyW, ImageCopyH)

            gr.DrawImage(PB1.Image, dst_rect, src_rect, GraphicsUnit.Pixel)
        End Using
        PictureBox1.Image = bm


        TextBox1.Text = BulletPosx
        TextBox2.Text = CanonPosx
        TextBox3.Text = BulletPosx

        Timer1.Start()


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

        'Dim bmp As Bitmap

        'CP02.Visible = False
        'bmp = PB1.Image
        'Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-001-0.bmp") '+ ActorName + ".bmp")
        'bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)
        'PB1.Image = bmp

        'CP02.Visible = True

        TimerTanks.Start()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim bmp As Bitmap

        bmp = BattlePlace.Clone()

        'Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-001-30.bmp") '+ ActorName + ".bmp")
        'Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-001-0.bmp") '+ ActorName + ".bmp")
        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-003-0.bmp") '+ ActorName + ".bmp")


        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PB1.Image = bmp
        CanonCurNr = 3
        CanonActive = True



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim bmp As Bitmap

        bmp = BattlePlace.Clone()

        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-004-0.bmp") '+ ActorName + ".bmp")
        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PB1.Image = bmp
        CanonCurNr = 4
        CanonActive = True



    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim bmp As Bitmap


        bmp = BattlePlace.Clone()
        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-002-0.bmp") '+ ActorName + ".bmp")
        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PB1.Image = bmp
        CanonCurNr = 2
        CanonActive = True


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim bmp As Bitmap


        bmp = BattlePlace.Clone()

        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-005-0.bmp") '+ ActorName + ".bmp")
        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PB1.Image = bmp
        CanonCurNr = 5
        CanonActive = True


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim bmp As Bitmap


        bmp = BattlePlace.Clone()

        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-006-0.bmp") '+ ActorName + ".bmp")
        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PB1.Image = bmp
        CanonCurNr = 6
        CanonActive = True

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim bmp As Bitmap


        bmp = BattlePlace.Clone()

        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-007-0.bmp") '+ ActorName + ".bmp")
        'Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-007-0B.bmp") '+ ActorName + ".bmp")


        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PB1.Image = bmp
        CanonCurNr = 7
        CanonActive = True



    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        Dim bmp As Bitmap


        bmp = BattlePlace.Clone()

        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-010-0.bmp") '+ ActorName + ".bmp")



        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PB1.Image = bmp




    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        Dim bmp As Bitmap


        bmp = BattlePlace.Clone()

        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-008-0.bmp") '+ ActorName + ".bmp")
        'Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-007-0B.bmp") '+ ActorName + ".bmp")


        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PB1.Image = bmp
        CanonCurNr = 8
        CanonActive = True



    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        Dim bmp As Bitmap


        bmp = BattlePlace.Clone()

        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-009-0.bmp") '+ ActorName + ".bmp")


        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)

        PB1.Image = bmp



    End Sub

    Private Sub ClearEnBullets()

        'restore image without actor
        Dim bm1 As New Bitmap(ImageCopyW, ImageCopyH)
        Dim bmp As Bitmap

        bmp = BattlePlace.Clone()
        bm1 = PictureBox1.Image.Clone()

        bmp = Me.AddSpriteTransWhite(bmp, bm1, CanonPosx, CanonPosy)
        PB1.Image = bmp

        'draw tank
        If CanonActive = True Then
            Me.ShowTank(CanonCurNr)
        End If


    End Sub

    Private Sub ClearBullets()

        'restore image without actor
        Dim bm1 As New Bitmap(ImageCopyW, ImageCopyH)
        Dim bmp As Bitmap

        bmp = BattlePlace.Clone()
        'Check if Tank still exists !!!
        bm1 = PictureBox1.Image.Clone()

        'If CanonActive = True Then
        '    bm1 = PictureBox2.Image.Clone()
        'Else
        '    bm1 = PictureBox1.Image.Clone()
        'End If

        bmp = Me.AddSpriteTransWhite(bmp, bm1, CanonPosx, CanonPosy)
        PB1.Image = bmp

        'draw tank
        If CanonActive = True Then
            Me.ShowTank(CanonCurNr)
        End If



    End Sub


    Private Sub ShowEnBullet(ByVal bulletnr As Integer)

        Me.DrawEnBullet(bulletnr)

    End Sub


    Private Sub ShowTank(ByVal tanknr As Integer)

        'restore image without actor
        Dim bm1 As New Bitmap(ImageCopyW, ImageCopyH)
        Dim bmp As Bitmap

        bmp = BattlePlace.Clone()
        bm1 = PictureBox1.Image.Clone()

        bmp = Me.AddSpriteTransWhite(bmp, bm1, CanonPosx, CanonPosy)
        PB1.Image = bmp

        If tanknr > 0 And tanknr <= 8 Then
            Me.DrawTank(tanknr)
        End If


    End Sub

    Private Sub DrawEnBullet(ByVal bulletnr As Integer)

        Dim bulletname As String
        Dim bmp As Bitmap

        Dim graph As Graphics
        Dim rectsquare As Rectangle
        Dim graphpath As New Drawing2D.GraphicsPath
        Dim brushsquare As Drawing2D.PathGradientBrush

        If bulletnr > 0 Then
            BulletEnW = BulletEnW + BulletDeltaEnW
        Else
            BulletEnW = BulletEnW + 2
        End If
        graph = Graphics.FromHwnd(PB1.Handle)
        'rectsquare = New Rectangle(BulletEnPosx + BulletDeltaX, BulletEnPosy, BulletEnW, BulletEnW)
        rectsquare = New Rectangle(BulletEnPosx + BulletDelta, BulletEnPosy, BulletEnW, BulletEnW)

        'graphpath.AddEllipse(rectsquare)
        graphpath.AddRectangle(rectsquare)

        brushsquare = New Drawing2D.PathGradientBrush(graphpath)
        brushsquare.CenterColor = Color.FromArgb(255, 0, 255, 0)
        brushsquare.SurroundColors = New Color() {Color.FromArgb(255, 0, 150, 0)}
        graph.FillPath(brushsquare, graphpath)


    End Sub


    Private Sub DrawTank(ByVal tanknr As Integer)
        Dim tankname As String
        Dim bmp As Bitmap

        bmp = BattlePlace.Clone()
        If tanknr < 10 Then
            tankname = "\Tanks\Tank-00" + tanknr.ToString() + "-0.bmp"
        Else
            tankname = "\Tanks\Tank-0" + tanknr.ToString() + "-0.bmp"
        End If

        If tanknr < 9 Then
            Canon = Bitmap.FromFile(CurDir() + tankname) '+ ActorName + ".bmp")
            bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)
            PB1.Image = bmp
        End If


    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerTanks.Tick

        Select Case TankNr

            Case 1
                Me.ShowTank(1)
            Case 2
                Me.ShowTank(2)
            Case 3
                Me.ShowTank(3)
            Case 4
                Me.ShowTank(4)
            Case 5
                Me.ShowTank(5)
            Case 6
                Me.ShowTank(6)
            Case 7
                Me.ShowTank(7)
            Case 8
                Me.ShowTank(8)
            Case 9
                Me.ShowTank(9)
            Case 10
                Me.ShowTank(10)

        End Select

        Tanknr = Tanknr + 1

        If Tanknr = 9 Then
            Tanknr = 1
            TimerTanks.Stop()

        End If

    End Sub

    Private Sub ShowBullet(ByVal bulletnr As Integer)

        Me.DrawBullet(bulletnr)

    End Sub

    Private Sub DrawBullet(ByVal bulletnr As Integer)
        Dim bulletname As String
        Dim bmp As Bitmap
        Dim width As Integer

        Dim graph As Graphics
        Dim rectsquare As Rectangle
        Dim graphpath As New Drawing2D.GraphicsPath
        Dim brushsquare As Drawing2D.PathGradientBrush

        If bulletnr > 0 Then
            width = BulletW - (BulletDeltaW * (5 - bulletnr))
            If width = 0 Then
                width = 2
            End If
            BulletW = BulletW '- BulletDeltaW
        Else
            width = 2
            'BulletW = BulletW - 2
        End If

        graph = Graphics.FromHwnd(PB1.Handle)
        'rectsquare = New Rectangle(BulletPosx + BulletDeltaX, BulletPosy, BulletW, BulletW)
        'rectsquare = New Rectangle(BulletPosx + BulletDeltaX, BulletPosy, width, width)
        rectsquare = New Rectangle(BulletActualPosx, BulletPosy, width, width)

        graphpath.AddEllipse(rectsquare)
        brushsquare = New Drawing2D.PathGradientBrush(graphpath)
        brushsquare.CenterColor = Color.FromArgb(255, 0, 255, 0)
        brushsquare.SurroundColors = New Color() {Color.FromArgb(255, 0, 150, 0)}
        graph.FillPath(brushsquare, graphpath)

    End Sub



    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim px, py As Integer


        Select Case Bulletnr

            Case 1
                BulletActualPosx = BulletPosx
                Me.ShowBullet(4)
            Case 2
                'BulletPosx = BulletPosx '+ BulletDeltaX1
                BulletPosy = BulletPosy - BulletDeltaY1
                Me.ShowBullet(3)

            Case 3
                'BulletPosx = BulletPosx '+ BulletDeltaX1
                BulletPosy = BulletPosy - BulletDeltaY
                Me.ShowBullet(2)

            Case 4
                'BulletPosx = BulletPosx '+ BulletDeltaX
                BulletPosy = BulletPosy - BulletDeltaY
                Me.ShowBullet(1)

            Case 5
                'BulletPosx = BulletPosx '+ BulletDeltaX
                BulletPosy = BulletPosy - BulletDeltaY
                Me.ShowBullet(0)

                'Case 7
                '    Me.ShowBullet(7)
                'Case 8
                '    Me.ShowBullet(8)
                'Case 9
                '    Me.ShowBullet(9)
                'Case 10
                '    Me.ShowBullet(10)

        End Select

        Bulletnr = Bulletnr + 1

        If Bulletnr = 6 Then
            'check raken
            If CanonActive = True Then
                If BulletActualPosx >= CanonPosx - 10 And BulletActualPosx <= CanonPosx + Canon.Width Then
                    'remove cannon (niet nodig)
                    'Me.RemoveCannon()
                    CurrentScore = CurrentScore + 1000
                    Label1.Text = CurrentScore.ToString()
                    CanonActive = False
                    Timer4.Stop()

                    'Timer1.Stop()

                End If

            End If
            Bulletnr = 1
            BulletPosy = 390
            Timer2.Stop()
            Me.ClearBullets()
            FiringGoingOn = False
        End If


    End Sub


    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        FiringGoingOn = True
        Timer2.Start()


    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

        Dim graph As Graphics
        Dim rectsquare As Rectangle
        Dim graphpath As New Drawing2D.GraphicsPath
        Dim brushsquare As Drawing2D.PathGradientBrush

        graph = Graphics.FromHwnd(PB1.Handle)
        rectsquare = New Rectangle(BulletPosx, BulletPosy, 20, 20)

        graphpath.AddEllipse(rectsquare)
        brushsquare = New Drawing2D.PathGradientBrush(graphpath)
        brushsquare.CenterColor = Color.FromArgb(255, 0, 255, 0)
        brushsquare.SurroundColors = New Color() {Color.FromArgb(255, 0, 150, 0)}
        graph.FillPath(brushsquare, graphpath)


    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click

        Dim graph As Graphics
        Dim lingradient As Drawing2D.LinearGradientBrush

        graph = Graphics.FromHwnd(PB1.Handle)

        lingradient = New Drawing2D.LinearGradientBrush(New Point(150, 240), New Point(200, 200), Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 0, 255))
        'graph.FillRectangle(lingradient, 150, 200, 40, 40)
        graph.FillEllipse(lingradient, 150, 200, 40, 40)





    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click

        Dim bmp As Bitmap

        bmp = BattlePlace.Clone()
        Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-001-0.bmp") '+ ActorName + ".bmp")
        bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)
        PB1.Image = bmp

        BattlePlaceCanon = PB1.Image.Clone()
        Dim bm As New Bitmap(ImageCopyW, ImageCopyH)
        Using gr As Graphics = Graphics.FromImage(bm)
            Dim src_rect As New Rectangle(CanonPosx, CanonPosy, ImageCopyW, ImageCopyH)
            Dim dst_rect As New Rectangle(0, 0, ImageCopyW, ImageCopyH)

            gr.DrawImage(PB1.Image, dst_rect, src_rect, GraphicsUnit.Pixel)
        End Using
        PictureBox2.Image = bm

        CanonCurNr = 1
        CanonActive = True


    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        Dim px, py As Integer

        Select Case BulletEnNr

            Case 1
                Me.ShowEnBullet(4)

            Case 2

                BulletEnPosx = BulletEnPosx '+ BulletDeltaX
                BulletEnPosy = BulletEnPosy + BulletDeltaY
                Me.ShowEnBullet(3)

            Case 3
                BulletEnPosx = BulletEnPosx '+ BulletDeltaX
                BulletEnPosy = BulletEnPosy + BulletDeltaY
                Me.ShowEnBullet(2)

            Case 4
                BulletEnPosx = BulletEnPosx '+ BulletDeltaX
                BulletEnPosy = BulletEnPosy + BulletDeltaY
                Me.ShowEnBullet(1)

            Case 5
                BulletEnPosx = BulletEnPosx '+ BulletDeltaX
                BulletEnPosy = BulletEnPosy + BulletDeltaY1
                Me.ShowEnBullet(0)

                'Case 7
                '    Me.ShowBullet(7)
                'Case 8
                '    Me.ShowBullet(8)
                'Case 9
                '    Me.ShowBullet(9)
                'Case 10
                '    Me.ShowBullet(10)

        End Select

        BulletEnNr = BulletEnNr + 1

        If BulletEnNr = 6 Then
            'Check if User is hit !
            If CanonCurNr > 0 And CanonCurNr < 9 Then
                If BulletEnPosx >= BulletPosx - BulletEnReach And BulletEnPosx <= BulletPosx + BulletEnReach Then
                    CurrentLives = CurrentLives - 1
                    Select Case CurrentLives

                        Case 2
                            PBT3.Visible = False
                            PBT2.Visible = True

                        Case 1
                            PBT2.Visible = False
                            PBT1.Visible = True

                        Case 0
                            MsgBox("You are Dead! Game has ended! ")
                            Me.Close()

                    End Select

                End If
            End If

            BulletEnNr = 1
            BulletEnPosy = 240
            BulletEnW = 4
            Timer3.Stop()

            Me.ClearEnBullets()

        End If




    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click

        Timer3.Start()


    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim bmp As Bitmap
        Dim r1, r2 As Integer

        If CanonActive = False Then
            bmp = BattlePlace.Clone()
            Canon = Bitmap.FromFile(CurDir() + "\Tanks\Tank-001-0.bmp") '+ ActorName + ".bmp")

            r1 = objRandom.Next(-600, 600)
            r2 = objRandom.Next(1, 2)
            If r2 = 2 Then
                r2 = -1
            End If

            'r1 = -600
            CurrentPosX = (37 * (600 + r1)) / 1200
            CurrentPosY = 10
            Me.WriteCurrentPosition()

            CanonPosx = BulletPosx + r1
            CanonPosy = 235
            bmp = Me.AddSpriteTransBlack(bmp, Canon, CanonPosx, CanonPosy)
            PB1.Image = bmp

            BattlePlaceCanon = PB1.Image.Clone()
            Dim bm As New Bitmap(ImageCopyW, ImageCopyH)
            Using gr As Graphics = Graphics.FromImage(bm)
                Dim src_rect As New Rectangle(CanonPosx, CanonPosy, ImageCopyW, ImageCopyH)
                Dim dst_rect As New Rectangle(0, 0, ImageCopyW, ImageCopyH)

                gr.DrawImage(PB1.Image, dst_rect, src_rect, GraphicsUnit.Pixel)
            End Using
            PictureBox2.Image = bm

            CanonCurNr = 1
            CanonActive = True
            Timer1.Interval = 2300
            Timer4.Start()


        Else
            'fire bullets

            If CanonCurNr > 0 And CanonCurNr <= 8 Then
                BulletEnPosx = CanonPosx + (BulletEnExtra(CanonCurNr - 1))
                BulletEnPosy = CanonPosy + (BulletEnYExtra(CanonCurNr - 1))
                Timer3.Start()
            End If


        End If

    End Sub

    Private Sub WriteCurrentPosition()

        Dim x, x2, y, y2 As Integer
        Dim bmp1, bmp2 As Bitmap

        Try

            x = CurrentPosX * 2
            y = CurrentPosY * 2
            bmp1 = Radar.Clone()
            For i = 1 To 2
                For j = 1 To 2
                    bmp1.SetPixel(x, y, Color.White)
                    x = x + 1
                Next
                x = CurrentPosX * 2
                y = y + 1
            Next
            PBRadar.Image = bmp1


        Catch ex As Exception

            'MsgBox(ex.Message)

        End Try


    End Sub


    Private Sub Panel1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Panel1.Scroll


        CurPosx = e.NewValue
        Panel1.AutoScrollPosition = New Drawing.Point((CurPosx), (CurPosy))
        BulletPosx = CurPosx + DeltaXPanel




    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick

        If CanonPosx >= BulletPosx + DeltaCanonX - 10 Then

            BulletDeltaX = BulletDeltaX1 * -1
            CanonPosx = CanonPosx - DeltaCanonX
            Me.ShowTank(CanonCurNr)
            CurrentPosX = CurrentPosX - CurrentPosXDeltaX
            CurrentPosY = CurrentPosY
            Me.WriteCurrentPosition()


        ElseIf CanonPosx <= BulletPosx - DeltaCanonX + 10 Then

            BulletDeltaX = BulletDeltaX1
            CanonPosx = CanonPosx + DeltaCanonX
            Me.ShowTank(CanonCurNr)
            CurrentPosX = CurrentPosX + CurrentPosXDeltaX
            CurrentPosY = CurrentPosY
            Me.WriteCurrentPosition()

        Else
            BulletDeltaX = 0

        End If

    End Sub

    Private Sub PB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB1.Click

    End Sub
End Class

Module Globals

    Public CurrentPosX As Integer
    Public CurrentPosY As Integer
    Public CurrentPosXDeltaX As Integer = 1
    Public CurrentPosYDeltaY As Integer = 1


    Public LastPosX As Integer = 0
    Public lastPosY As Integer = 0


    Public BulletEnReach As Integer = 30
    Public CurrentScore As Integer = 1000
    Public CurrentLives As Integer = 3
    Public FiringGoingOn As Boolean = False
    Public BattlePlace As Bitmap
    Public BattlePlaceCanon As Bitmap

    Public StartPosx As Integer = 2000
    Public StartPosy As Integer = 0
    Public CurPosx As Integer = 2000
    Public CurPosy As Integer = 0
    Public DeltaX As Integer = 30
    Public DeltaCanonX As Integer = 40
    Public DeltaXPanel As Integer = 568 '520

    Public Bulletnr As Integer = 1
    Public BulletPosx As Integer = 2568 '2520
    Public BulletActualPosx As Integer = 2568 '2520
    Public BulletPosxCopy As Integer = 2510 '2510
    Public BulletEnExtra() As Integer = {10, 20, 30, 50, 70, 90, 110, 140, 90, 100}
    'Public BulletEnExtra() As Integer = {10, 20, 30, 50, 70, 90, 110, 140, !90, 100}
    Public BulletEnYExtra() As Integer = {0, 5, 10, 15, 20, 30, 35, 45, 50, 60}


    Public BulletPosxRight As Integer = 4648 '4600 '4590
    Public BulletPosxLeft As Integer = 568 '520

    Public BulletPosy As Integer = 390

    Public BulletDeltaW As Integer = 4
    Public BulletW As Integer = 24
    Public CanonPosx As Integer = 2400
    Public CanonPosy As Integer = 235 '230



    Public CanonCurNr As Integer = 1
    Public CanonActive As Boolean = False

    Public BulletEnNr As Integer = 1
    Public BulletEnPosx As Integer = 2400
    Public BulletEnPosy As Integer = 240
    Public BulletDeltaEnW As Integer = 3
    Public BulletEnW As Integer = 4

    Public Canon As Bitmap
    Public Under As Bitmap
    Public Above As Bitmap
    Public Bullet As Bitmap
    Public Radar As Bitmap

    Public BulletDelta As Integer = 4

    Public BulletDeltaX As Integer = 8
    Public BulletDeltaX1 As Integer = 8
    Public BulletDeltaX2 As Integer = 12
    Public BulletDeltaX3 As Integer = 16


    Public BulletDeltaY As Integer = 34
    Public BulletDeltaY1 As Integer = 44


    Public Tanknr As Integer = 1
    Public CurrentTanknr As Integer = 1


    Public UnderPosx As Integer = 900
    Public UnderPosy As Integer = 400 '200

    Public AbovePosx As Integer = 900
    Public AbovePosy As Integer = 10

    Public ImageCopyW As Integer = 360
    Public ImageCopyH As Integer = 220

    Public Tank1 As Bitmap

    Public TankPosx As Integer = 590
    Public TankPosy As Integer = 600


    Public PosxMax As Integer = 4080

    Public StartRadarx As Integer = 162
    Public StartRadary As Integer = 20

    Public EndRadarx As Integer = 1294
    Public EndRadary As Integer = 20

    Public CurRadarx As Integer = 750
    Public CurRadary As Integer = 20


    Public CurCanonAbovex As Integer = 450
    Public CurCanonAbovey As Integer = 3

    Public CurCanonUnderx As Integer = 450
    Public CurCanonUndery As Integer = 400

    Public StartCanonAbovex As Integer = -150
    Public StartCanonUnderx As Integer = -150

    Public EndCanonAbovex As Integer = 1000
    Public EndCanonUnderx As Integer = 1000






End Module

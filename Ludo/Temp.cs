// // RED Home
//                 if (x <= 5 && y <= 5)
//                 {
//                     square.ColorState = ColorState.RED;
//                     if (x >= 2 && x <= 3 && y >= 2 && x <= 3)
//                     {
//                         square.IsHome = true;
//                     }
//                 }

//                 // GREEN Home
//                 else if (x <= 5 && y >= 9)
//                 {
//                     square.ColorState = ColorState.GREEN;
//                     if (x >= 2 && x <= 3 && y >= 11 && y <= 12)
//                     {
//                         square.IsHome = true;
//                     }
//                 }

//                 // BLUE Home
//                 else if (x >= 9 && y <= 5)
//                 {
//                     square.ColorState = ColorState.BLUE;
//                     if (x >= 12 && x <= 13 && y >= 2 && y <= 3)
//                     {
//                         square.IsHome = true;
//                     }
//                 }

//                 // YELLOW Home
//                 else if (x >= 9 && y >= 9)
//                 {
//                     square.ColorState = ColorState.YELLOW;

//                     if (x >= 12 && x <= 13 && y >= 11 && y <= 12)
//                     {
//                         square.IsHome = true;
//                     }
//                 }

//                 // Finish
//                 else if (x >= 6 && x <= 8 && y >= 6 && y <= 8)
//                 {
//                     square.ColorState = ColorState.GRAY;
//                     if (x == 6 && y == 7)
//                     {
//                         square.ColorState = ColorState.GREEN;
//                         square.IsFinish = true;
//                     }

//                     if (x == 7 && y == 8)
//                     {
//                         square.ColorState = ColorState.YELLOW;
//                         square.IsFinish = true;
//                     }
//                     if (x == 8 && y == 7)
//                     {
//                         square.ColorState = ColorState.BLUE;
//                         square.IsFinish = true;
//                     }
//                     if (x == 7 && y == 6)
//                     {
//                         square.ColorState = ColorState.RED;
//                         square.IsFinish = true;
//                     }
//                 }
//                 else
//                 {
//                     square.ColorState = ColorState.WHITE;
//                     square.IsPath = true;
//                 }

//                 //Safe Zone
//                 //Start
//                 if (x == 13 && y == 6)
//                 {
//                     square.ColorState = ColorState.BLUE;
//                     square.IsStart = true;
//                     square.IsSafeZone = true;
//                 }
//                 if (x == 6 && y == 1)
//                 {
//                     square.ColorState = ColorState.RED;
//                     square.IsStart = true;
//                     square.IsSafeZone = true;
//                 }
//                 if (x == 1 && y == 8)
//                 {
//                     square.ColorState = ColorState.GREEN;
//                     square.IsStart = true;
//                     square.IsSafeZone = true;
//                 }
//                 if (x == 8 && y == 13)
//                 {
//                     square.ColorState = ColorState.YELLOW;
//                     square.IsStart = true;
//                     square.IsSafeZone = true;
//                 }
//                 if (x >= 1 && x <= 5 && y == 7)
//                 {
//                     square.ColorState = ColorState.GREEN;
//                     square.IsStart = true;
//                     square.IsSafeZone = true;
//                 }
//                 if (x >= 9 && x <= 13 && y == 7)
//                 {
//                     square.ColorState = ColorState.BLUE;
//                 }
//                 if (x == 7 && y >= 1 && y <= 5)
//                 {
//                     square.ColorState = ColorState.RED;
//                 }
//                 if (x == 7 && y >= 9 && y <= 13)
//                 {
//                     square.ColorState = ColorState.YELLOW;
//                 }

//                 // Safe Zone *
//                 if (x == 8 && y == 2)
//                 {
//                     square.IsSafeZone = true;
//                 }

//                 if (x == 2 && y == 6)
//                 {
//                     square.IsSafeZone = true;
//                 }

//                 if (x == 6 && y == 12)
//                 {
//                     square.IsSafeZone = true;
//                 }

//                 if (x == 12 && y == 8)
//                 {
//                     square.IsSafeZone = true;
//                 }

//                 // Arrow Entry
//                 if (x == 0 && y == 7)
//                 {
//                     square.ColorState = ColorState.GREEN;
//                     square.IsArrowEntry = true;
//                 }
//                 if (x == 7 && y == 0)
//                 {
//                     square.ColorState = ColorState.RED;
//                     square.IsArrowEntry = true;
//                 }
//                 if (x == 7 && y == 14)
//                 {
//                     square.ColorState = ColorState.YELLOW;
//                     square.IsArrowEntry = true;
//                 }
//                 if (x == 14 && y == 7)
//                 {
//                     square.ColorState = ColorState.BLUE;
//                     square.IsArrowEntry = true;
//                 }

//                 // Player Piece
//                 foreach (Player player in players)
//                 {
//                     foreach (Piece piece in player.PlayerPieces!)
//                     {
//                         if (piece.Position.X == x && piece.Position.Y == y)
//                         {
//                             square.Pieces.Add(piece);
//                         }
//                     }
//                 }
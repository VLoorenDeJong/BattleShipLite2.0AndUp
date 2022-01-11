using BattleShipLite2._0Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShipLite2._0;
using BattleShipLite2._0Library;

namespace BattleShipLite2._0.UserComunications
{
    public static class AppComunication
    {
        public static void ShowWelcomeMessage(string gameTitle)
        {
             "           *                                       *       *       ".CWLColor(ConsoleColor.White);
            $"{ GetSpacingWithSubtractecStringLenght(gameTitle, 40) } {gameTitle}".CWLColor(ConsoleColor.Cyan);
             "                                                                   ".CWLColor(ConsoleColor.White);
             "                 *                                                 ".CWLColor(ConsoleColor.White);
             "                             *                           *         ".CWLColor(ConsoleColor.White);
             "                                                                   ".CWLColor(ConsoleColor.White);
             "        |)  @-                                     -@  (|          ".CWLColor(ConsoleColor.Red);
             "   <---------->                                   <---------->     ".CWLColor(ConsoleColor.DarkGray);
             "~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~  ".CWLColor(ConsoleColor.DarkBlue);
             "                                                                   ".CWLColor(ConsoleColor.White);
             "The changes are:                                                   ".CWLColor(ConsoleColor.Gray);
             "- Completely redesigned from the ground up                         ".CWLColor(ConsoleColor.DarkGray);
             "- See where your ships are placed                                  ".CWLColor(ConsoleColor.DarkGray);
             "- Computer player has been added                                   ".CWLColor(ConsoleColor.DarkGray);
             "- During the game both fields are visible                          ".CWLColor(ConsoleColor.DarkGray);
             "- Added comentary                                                  ".CWLColor(ConsoleColor.DarkGray);
             "- Winner screen is improved                                        ".CWLColor(ConsoleColor.DarkGray);
             "- No Usercomunication from library                                 ".CWLColor(ConsoleColor.DarkGray);
             "- Preformance improvements                                         ".CWLColor(ConsoleColor.DarkGray);
             "                                                                   ".CWLColor(ConsoleColor.DarkGray);
             "                                                                   ".CWLColor(ConsoleColor.DarkGray);
             "                     press <Enter> to start                        ".CWLColor(ConsoleColor.Cyan);
             "                                                                   ".CWLColor(ConsoleColor.Gray);
            Console.ReadLine();
            Console.Clear();
        }
        public static string AskForPlayerName(int counter)
        {
            string name = "";


            "Press <Enter> to confirm or continue".CWColor(ConsoleColor.Gray); " (Leave the name space empty to create a computer player)".CWLColor(ConsoleColor.DarkGray);
            Console.WriteLine();

            $"Please write the name for player { counter }: ".CWColor(ConsoleColor.White);
            
            name = Console.ReadLine();
            Console.Clear();

            return name;
        }
        public static void AskForUserToPressEnter(ConsoleColor textColor)
        {
            Console.WriteLine();
            "Press <Enter> to continue".CWLColor(textColor);
        }
        internal static bool PlaceShipOnGrid(PlayerModel player, int counter)
        {
            bool output = false;

            AppComunication.DisplayShipGrid(player);
            GridSpotModel spot = $"Please enter location for ship { counter + 1}, and confirm with pressing <Enter>".GetGridLocationFromUser(player.ShipGrid, ConsoleColor.Gray);
            output = player.PlaceShipOnGrid(spot, player);
            Console.Clear();

            return output;
        }
        internal static void ThankUserForPlacingAllShips(PlayerModel player)
        {
            AppComunication.DisplayShipGrid(player);

            Console.WriteLine();
            "Thanks for placing your ships, good luck!!".CWLColor(ConsoleColor.Gray);
            Console.WriteLine();
            AskForUserToPressEnter(ConsoleColor.DarkGray);
            Console.ReadLine();
            
            Console.Clear();
        }
        internal static void AskForShot(PlayerModel player, PlayerModel opponent)
        {
            string message = "";
            //string shotResult = "";
            string playerShotInput = "";

            if (player is AIPlayerModel aiPlayer)
            {
                message = aiPlayer.GetShotLocationCommunication(aiPlayer);
                message.CWLColor(ConsoleColor.Gray);
                aiPlayer.TakeShot(aiPlayer, opponent);
            }
            else
            {
                bool isValidShot = false;
                do
                {
                    $"{ player.Name } please enter your shot location: ".CWColor(ConsoleColor.Gray);
                    playerShotInput = Console.ReadLine();

                    (isValidShot, message, player.shot) = InputValidation.ValidateGridLocation(playerShotInput, player.ShipGrid);

                    if (isValidShot == true)
                    {
                        (isValidShot, message) = player.TakeShot(player, opponent, playerShotInput);
                        if (isValidShot == false)
                        {
                            ComunicatieShotResult(message);
                        }
                        
                    }
                    else
                    {
                        ComunicatieShotResult(message);
                    }
                } while (isValidShot == false) ;

            } 
        }
        private static void ComunicatieShotResult(string message)
        {
            Console.WriteLine();
            message.CWLColor(ConsoleColor.Gray);
            Console.WriteLine();
        }
        internal static void DisplayShotGrid(PlayerModel player1, PlayerModel player2, int round)
        {
            if (round % 2 == 0)
            {
                AppComunication.DisplayPlayerGrids(player2, player1, ConsoleColor.DarkGray, ConsoleColor.Gray);
            }
            else
            {
                AppComunication.DisplayPlayerGrids(player1, player2, ConsoleColor.Gray, ConsoleColor.DarkGray);
            }
        }
        private static void DisplayPlayerGrids(PlayerModel player1, PlayerModel player2, ConsoleColor player1TextColor, ConsoleColor player2TextColor)
        {
            Console.Clear();

            LayoutAboveGrid(player1, true, player1TextColor);
            GenerateGrid(player1.ShotGrid);

            Console.WriteLine();

            LayoutAboveGrid(player2, true, player2TextColor);
            GenerateGrid(player2.ShotGrid);

            Console.WriteLine();
            Console.WriteLine();
        }
        internal static void DisplayShipGrid(PlayerModel player)
        {
            Console.Clear();
            LayoutAboveGrid(player, false, ConsoleColor.Gray);
            GenerateGrid(player.ShipGrid);
            Console.WriteLine();
            Console.WriteLine();
        }       
        private static void GenerateGrid(List<GridSpotModel> playerGrid)
        {
            string currentRow = playerGrid[0].SpotLetter;
            int currentColumn = playerGrid[0].SpotNumber;
            int columnCounter = 1;

            foreach (var gridSpot in playerGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {

                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                    columnCounter++;
                }
                if (currentColumn == gridSpot.SpotNumber)
                {
                    $"{gridSpot.SpotLetter} ".CWColor(ConsoleColor.White);
                    $"|".CWColor(ConsoleColor.DarkBlue);
                }

                DisplaySpotStatus(gridSpot);
                
                $"|".CWColor(ConsoleColor.DarkBlue);
                               
            }
            GenerateGridNumbers(columnCounter);
            "".CWLColor(ConsoleColor.DarkGray);
        }
        private static void GenerateGridNumbers(int columnCounter)
        {
            for (int i = 0; i < columnCounter + 1; i++)
            {
                if (i == 0)
                {
                    "".PrintToScreen();
                    "    ".CWColor(ConsoleColor.Black);
                }
                else
                {
                    $"{i}   ".CWColor(ConsoleColor.White);
                }
            }
        }
        private static void DisplaySpotStatus(GridSpotModel gridSpot)
        {
            switch (gridSpot.Status)
            {
                case GridSpotEnum.Empty:
                    "~~~".CWColor(ConsoleColor.DarkCyan);
                    break;
                case GridSpotEnum.Ship:
                case GridSpotEnum.Hit:
                    "<->".CWColor(ConsoleColor.Red);
                    break;
                case GridSpotEnum.Miss:
                    @"\o/".CWColor(ConsoleColor.DarkCyan);
                    break;
                default:
                    break;
            }
        }
        internal static void DisplayShotResult(PlayerModel player1, PlayerModel player2, int round)
        {

            AppComunication.DisplayShotGrid(player1, player2, round);
            if (player1 is AIPlayerModel )
            {
                $"The shot { player1.Name } took at { player1.shot.SpotLetter }{ player1.shot.SpotNumber } was a { player1.shot.Status }".CWLColor(ConsoleColor.Gray);
                // ToDo For testing remove comment display shot result delay 
                //Thread.Sleep(1000);

                Thread.Sleep(5000);

            }
            else
            {
                $"{ player1.Name } please enter your shot location: { player1.shot.SpotLetter }{ player1.shot.SpotNumber }".CWColor(ConsoleColor.DarkGray);
                Console.WriteLine();
                Console.WriteLine();
                $"your shot { player1.shot.SpotLetter }{ player1.shot.SpotNumber } was a {player1.shot.Status}".CWLColor(ConsoleColor.Gray);

                Console.WriteLine();
                "Press <Enter> to continue".CWLColor(ConsoleColor.DarkGray);
                Console.ReadLine();
            }

        }        
        public static void LayoutAboveGrid(PlayerModel player, bool commentaryOn, ConsoleColor textColor)
        
        {
            string commentary = "";
            Console.WriteLine();
            
            
            if (commentaryOn == true)
            {
                commentary =  CommentaryModel.DisplayRandomCommentary(player, textColor);
            }
            else
            {
                commentary = $"   { player.Name}";
            }
            commentary.CWLColor(textColor);
            Console.WriteLine();

        }     
        internal static void DisplayWinnerScreen(PlayerModel winner, PlayerModel loser, int roundsPlayed)
        {

            DisplayShotGrid(loser, winner, roundsPlayed);
            CongratulateWinner(winner, loser);
            AskForUserToPressEnter(ConsoleColor.DarkGray);
            Console.ReadLine();
            Console.Clear();
            DisplayTrophy(winner);
        }
        private static void CongratulateWinner(PlayerModel winner, PlayerModel loser)
        {
            string output = "";
            Console.WriteLine();
            if (winner.ShotsTaken == 5)
            {
                output = $"{ winner.Name } won the game, { loser.Name } did not stand a chance this is a perfect score!!";
            }
            else if (winner.ShotsTaken < 10 && loser.ShipsSunk <= 2)
            {
                output = $"{ winner.Name } won the game!!! \n\n{ loser.Name } had not much of a chance sorry. \n\n{ loser.Name } only needed to find { 5 - loser.ShipsSunk } more ships to win.\n";
            }
            else if (winner.ShotsTaken < 10 && loser.ShipsSunk == 4)
            {
                output = $"{ winner.Name } won the game with only { winner.ShotsTaken } shots!!! \n\n{ loser.Name } came very close only one more ship very well done! \n\nIt was very close!\n";
            }
            else if (winner.ShotsTaken >= 15 && loser.ShipsSunk <= 3)
            {
                string hit = DetermineHitOrHits(loser.ShipsSunk); 

                output = $"{ winner.Name } won the game with { winner.ShotsTaken } shots!!!!! \n\n{ loser.Name } came close he only needed { 5 - loser.ShipsSunk } more { hit }. \n\nIt took some time but the battle was close in the end!\n";

            }
            else if (winner.ShotsTaken >= 16 && loser.ShipsSunk <= 3)
            {
                output = $"{ winner.Name } won the game with { winner.ShotsTaken } shots!!!! \n\n{ loser.Name } had not much of a chance the ships of { winner.Name } were wel hidden\n";
            }
            else
            {
                output = $"{ winner.Name } won the game, it took { winner.ShotsTaken } shots to win\n";
            }

            output.CWLColor(ConsoleColor.Gray);
        }
        private static string DetermineHitOrHits(int shipsSunk)
        {
            string output = "hits";
            if (shipsSunk == 4)
            {
                output = "hit";
            }

            return output;
        }
        public static void ExitApplication(string gameTitle)
        {
            Console.WriteLine();
            Console.WriteLine();
            $"Thanks for playing { gameTitle }".CWLColor(ConsoleColor.DarkBlue);
            AskForUserToPressEnter(ConsoleColor.DarkBlue);
            Console.ReadLine();
            
        }
        public static void DisplayTrophy(PlayerModel winner)
            {
            Console.Clear();
            string spacing = GetSpacingWithSubtractecStringLenght(winner.Name, 41);

            @"            *                       *                                  ".CWLColor(ConsoleColor.White);
            @"                                                      *                ".CWLColor(ConsoleColor.White);
            @"                  *                                                    ".CWLColor(ConsoleColor.White);
            @"  *                                                         *          ".CWLColor(ConsoleColor.White);
            @"                                    __________________               ".CWLColor(ConsoleColor.DarkGray);
            @"        @ @ ".CWColor(ConsoleColor.White);"     _______           (____   _________ |              ".CWLColor(ConsoleColor.DarkGray);
            @"   <==<".CWColor(ConsoleColor.DarkRed); "  *".CWColor(ConsoleColor.Yellow);"======(      |               |   |       | |               ".CWLColor(ConsoleColor.DarkGray);
            @"       @ @".CWColor(ConsoleColor.White);"      /      |               |   |".CWColor(ConsoleColor.DarkGray);@"\".CWColor(ConsoleColor.DarkCyan); "  ,  ".CWColor(ConsoleColor.Yellow);"/".CWColor(ConsoleColor.DarkCyan); "| |              ".CWLColor(ConsoleColor.DarkGray);
            @"               /       |               |   | ".CWColor(ConsoleColor.DarkGray);@"\ O /".CWColor(ConsoleColor.DarkCyan);" | |              ".CWLColor(ConsoleColor.DarkGray);
            @"    __________|________|_______________|   |__".CWColor(ConsoleColor.DarkGray);"|".CWColor(ConsoleColor.Cyan);"_".CWColor(ConsoleColor.DarkGray);"|".CWColor(ConsoleColor.Cyan);"__| |               ".CWLColor(ConsoleColor.DarkGray);
            @"    \                                                |              ".CWLColor(ConsoleColor.DarkGray);
            @"     \  ".CWColor(ConsoleColor.DarkGray);$"HMS { winner.Name }".CWColor(ConsoleColor.Yellow);$"{ spacing }|                                        ".CWLColor(ConsoleColor.DarkGray);
            @"      \                                              |              ".CWLColor(ConsoleColor.DarkGray);
            @"       \                                             |              ".CWLColor(ConsoleColor.DarkGray);
            @"        \ ".CWColor(ConsoleColor.DarkGray);"&&".CWColor(ConsoleColor.Blue);"                                        /               ".CWLColor(ConsoleColor.DarkGray);
            @"        &&&&&&&&".CWColor(ConsoleColor.Blue);"                                   |______          ".CWLColor(ConsoleColor.DarkGray);
            @"       &&&&&&  &&&".CWColor(ConsoleColor.Blue);"                                /|     |          ".CWLColor(ConsoleColor.DarkGray);
            @"  ~~~".CWColor(ConsoleColor.DarkBlue);"&&&&&&&".CWColor(ConsoleColor.Blue); "~~~~~".CWColor(ConsoleColor.DarkBlue); "&&&&&&".CWColor(ConsoleColor.Blue);" ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~       ".CWLColor(ConsoleColor.DarkBlue);
            @"~~~    ~~~~~      ~~~      ~~   ~    ~~~~     ~~~       ~~~    ~~~   ".CWLColor(ConsoleColor.DarkBlue);

        }
        private static string GetSpacingWithSubtractecStringLenght(string name, int defaultSpacing)
        {
            int nameLength = name.Length;

            string output = "";

            for (int i = 0; i < defaultSpacing - nameLength; i++)
            {
                output = output + " ";
            }

            return output;
        }
        public static string GetStringFromUser(this string message, ConsoleColor color)
        {

            string output = "";
            do
            {

                message.CWLColor(color);
                output = Console.ReadLine();


            } while (string.IsNullOrWhiteSpace(output));

            return output;
        }
    }
}

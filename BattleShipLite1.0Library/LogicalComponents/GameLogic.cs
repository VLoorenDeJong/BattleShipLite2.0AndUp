using BattleShipLite2._0;
using BattleShipLite2._0Library.Interfaces;
using BattleShipLite2._0Library.LogicalComponents;
using BattleShipLite2._0Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite2._0Library
{
    public class GameLogic
    {
        public static void GetShotCount(PlayerModel player)
        {
            foreach (var gridSpot in player.ShotGrid)
            {
                if (gridSpot.Status == GridSpotEnum.Hit || gridSpot.Status == GridSpotEnum.Miss)
                {
                    player.ShotsTaken++;
                }
            }
        }
        public static void InitializeGrid(List<GridSpotModel> grid)
        {
            List<string> letters = new List<string>() { "A", "B", "C", "D", "E" };
            List<int> numbers = new List<int>();
            int startNumber = 1;

            foreach (string letter in letters)
            {
                numbers.Add(startNumber);
                startNumber++;
            }

            foreach (string letter in letters)
            {
                foreach (int number in numbers)
                {
                    AddEmptyGridSpot(grid, letter, number);
                }
            }
        }
        public static string RecordPlayerShot(bool isValidShot, PlayerModel player, PlayerModel opponent)
        {
            string outputMessage = "";
            GridSpotEnum shotResult = GridSpotEnum.Empty;

            if (isValidShot == true)
            {
                (shotResult, outputMessage) = GetOpponentSpotStatus(opponent, player.shot);
                SaveShotResultToPlayershot(player, shotResult);
                PutShotResultOnPlayerShotGrid(player, isValidShot);
                WhenShotResultIsHitAddOneToPlayerShipsSunk(player, isValidShot);
            }

            return outputMessage;
        }
        private static void SaveShotResultToPlayershot(PlayerModel player, GridSpotEnum shotResult)
        {
            player.shot.Status = shotResult;
        }
        private static void WhenShotResultIsHitAddOneToPlayerShipsSunk(PlayerModel player, bool isValidShot)
        {
            if (player.shot.Status == GridSpotEnum.Hit && isValidShot == true)
            {
                GameLogic.AddOneToShipsSunk(player);
            }
        }
        private static void PutShotResultOnPlayerShotGrid(PlayerModel player, bool isValidShot)
        {

            if (isValidShot == true)
            {
                foreach (var spot in player.ShotGrid)
                {
                    if (
                        spot.SpotNumber == player.shot.SpotNumber
                        && spot.SpotLetter == player.shot.SpotLetter
                        )
                    {
                        spot.Status = player.shot.Status;
                        break;
                    }
                }
            }
        }
        internal static GridSpotModel ConvertInputToGridSpot(string userLocation)
        {
            GridSpotModel spot = new GridSpotModel();
            
            userLocation = userLocation.ToUpper();

            char[] shotArray = userLocation.ToArray();
            spot.SpotLetter = shotArray[0].ToString();
            spot.SpotNumber = int.Parse(shotArray[1].ToString());

            return spot;
        }
        public static void DetermineWinner(PlayerModel player)
        {
            if (player.ShipsSunk == 5)
            {
                player.ChangeWinnerStatus(player);
            }
        }
        private static void AddEmptyGridSpot(List<GridSpotModel> grid, string letter, int number)
        {
            GridSpotModel spot = new GridSpotModel
            {
                SpotLetter = letter,
                SpotNumber = number,
                Status = GridSpotEnum.Empty
            };

            grid.Add(spot);
        }
        internal static (bool isValidShot, string outputMessage) CheckSpotForPreviousShot (PlayerModel player)
        {
            string outputMessage = "";
            GridSpotEnum status = GridSpotEnum.Empty;
            bool isValidShot = false;

                foreach (var spot in player.ShotGrid)
                {
                    if (spot.SpotLetter == player.shot.SpotLetter &&
                        spot.SpotNumber == player.shot.SpotNumber
                        )
                    {
                        (status, isValidShot, outputMessage) = CheckSpotStatus (spot);
                        break;
                    }
                }            

            return (isValidShot, outputMessage);
        }
        private static (GridSpotEnum spotStatus, string outputMessage) GetOpponentSpotStatus(PlayerModel opponent, GridSpotModel shotSpot)
        {
            bool isValidShot = false;
            string outputMessage = "";
            GridSpotEnum outputStatus = GridSpotEnum.Empty;

            foreach (var spot in opponent.ShipGrid)
            {
                if (spot.SpotLetter == shotSpot.SpotLetter &&
                    spot.SpotNumber == shotSpot.SpotNumber
                    )
                {

                    (outputStatus, isValidShot, outputMessage) = CheckSpotStatus(spot);

                    break;
                }
            }

            return (outputStatus, outputMessage);
        }
        private static (GridSpotEnum status, bool isValidShot, string outputMessage) CheckSpotStatus (GridSpotModel spot)
        {   
            GridSpotEnum outputStatus = GridSpotEnum.Empty;
            bool isValidShot = false;
            string outputMessage = "";

            switch (spot.Status)
            {
                case GridSpotEnum.Empty:
                    outputStatus = GridSpotEnum.Miss;
                    isValidShot = true;
                    outputMessage = "MISS";
                    break;

                case GridSpotEnum.Ship:
                    outputStatus = GridSpotEnum.Hit;
                    isValidShot = true;
                    outputMessage = "HIT";
                    break;

                case GridSpotEnum.Miss:
                case GridSpotEnum.Hit:                     
                    outputMessage = $"The spot { spot.SpotLetter }{ spot.SpotNumber } has been shot before";
                    isValidShot = false;
                    break;

                default:
                    outputMessage = "!! This is wierd !!";
                    break;
            }
            return (outputStatus, isValidShot, outputMessage);
        }
        internal static void AddOneToShipsSunk(PlayerModel player)
        {
            player.ShipsSunk += 1;
        }
        public static (PlayerModel player1, PlayerModel Player2) ChangeSeats(PlayerModel player1, PlayerModel player2)
        {
            (player1, player2) = (player2, player1);

            return (player1, player2);
        }
    }
}

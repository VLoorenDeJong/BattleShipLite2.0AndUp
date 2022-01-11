using BattleShipLite2._5Library.LogicalComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite2._5Library.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public List<GridSpotModel> ShotGrid { get; set; } = new List<GridSpotModel>();
        public List<GridSpotModel> ShipGrid { get; set; } = new List<GridSpotModel>();
        public List<GridSpotModel> ShipLocations { get; set; } = new List<GridSpotModel>();
        public GridSpotModel shot { get; set; }
        public int ShotsTaken { get; set; } = 0;

        public int AmmountOfShips = 5;
        public int ShipsSunk { get; set; }
        public bool winner { get; private set; } = false;
        public (bool isValidShot, string outputMessage) TakeShot(PlayerModel player, PlayerModel opponent, string playerShotInput)
        {
            string outputMessage = "";
            bool isValidShot = false;

            (isValidShot, outputMessage) = GameLogic.CheckSpotForPreviousShot(player);

            if (isValidShot == true)
            {
                outputMessage = GameLogic.RecordPlayerShot(isValidShot, player, opponent);
            }


            return (isValidShot, outputMessage);

        }
        public void ChangeWinnerStatus(PlayerModel player)
        {
            player.winner = true;
        }
        public void PlaceShipsOnShipGrid(PlayerModel player)
        {
            int counter = 0;
            foreach (GridSpotModel shipLocation in player.ShipLocations)
            {
                foreach (GridSpotModel gridSpot in player.ShipGrid)
                {
                    if (shipLocation.SpotLetter == gridSpot.SpotLetter && shipLocation.SpotNumber == gridSpot.SpotNumber)
                    {
                        gridSpot.Status = GridSpotEnum.Ship;
                        counter ++;

                        if (counter == 5)
                        {
                            break;
                        }

                    }
                }
            }
        }
    }
}

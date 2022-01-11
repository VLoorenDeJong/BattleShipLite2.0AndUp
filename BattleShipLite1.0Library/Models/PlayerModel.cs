using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipLite2._0Library.Models;
using BattleShipLite2._0Library.Interfaces;
using BattleShipLite2._0;
using System.Threading;

namespace BattleShipLite2._0Library.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public List<GridSpotModel> ShotGrid { get; set; } = new List<GridSpotModel>();
        public List<GridSpotModel> ShipGrid { get; set; } = new List<GridSpotModel>();
        public List<GridSpotModel> ShipLocations { get; set; } = new List<GridSpotModel>();
        public GridSpotModel shot { get; set; }
        public int ShotsTaken { get; set; } = 0;

        public int AmmountOfShips  = 5;
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


            return (isValidShot,  outputMessage);

        }      
        public void ChangeWinnerStatus(PlayerModel player)
        {
            player.winner = true;
        }
        public bool PlaceShipOnGrid(GridSpotModel spot, PlayerModel player)
        {
            bool isPlaced = false;
            GridSpotModel shipSpot = spot;
            shipSpot.Status = GridSpotEnum.Empty;

            foreach (var gridSpot in player.ShipGrid)
            {
                if (shipSpot.SpotLetter == gridSpot.SpotLetter && 
                    shipSpot.SpotNumber == gridSpot.SpotNumber && 
                    shipSpot.Status == gridSpot.Status)
                {
                    // ToDo Shiplocations.add remove comment for testing
                    //player.ShipLocations.Add(spot);
                    
                    gridSpot.Status = GridSpotEnum.Ship;                     
                    isPlaced = true;
                    break;
                }
            }

            return isPlaced;
        }


    }
}

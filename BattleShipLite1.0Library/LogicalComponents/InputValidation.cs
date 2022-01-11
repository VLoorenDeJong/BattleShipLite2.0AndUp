using BattleShipLite2._0;
using BattleShipLite2._0Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite2._0Library
{
   public  class InputValidation
    {     
        public static (bool isValid, string outputMessage, GridSpotModel spot) ValidateGridLocation(string userLocation, List<GridSpotModel> grid)
        {
            GridSpotModel spot = new GridSpotModel();
            bool isValidGridSpot = false;
            string outputMessage = "";

            if (userLocation.Length == 2)
            {
                try
                {
                    spot = GameLogic.ConvertInputToGridSpot(userLocation);
                    isValidGridSpot = LookForSpotInGridList(spot, grid);

                    if (isValidGridSpot == false)
                    {
                        outputMessage = $"I am sorry { userLocation } is not a location on this grid please try again.";
                    }
                }
                catch (Exception)
                {
                    outputMessage = $"I am sorry { userLocation } is not valid a grid location has a letter and a number (Example: A1)";
                }                
            }
            else
            {
                isValidGridSpot = false;
                outputMessage = $"I am sorry { userLocation } is not valid a grid spot has a letter and a number (Example: A1)";
            }

            return (isValidGridSpot, outputMessage, spot);
        }
        private static bool LookForSpotInGridList(GridSpotModel spot, List<GridSpotModel> grid)
        {
            bool isValidGridSpot = false;

            foreach (var gridSpot in grid)
            {
                isValidGridSpot = CheckForUserLocationOnGrid(spot, gridSpot);

                if (isValidGridSpot == true)
                {
                    break;
                }
            }

            return isValidGridSpot;
        }
        private static bool CheckForUserLocationOnGrid(GridSpotModel spot, GridSpotModel gridSpot)
        {
            bool isValid = false;

            if (spot.SpotLetter == gridSpot.SpotLetter &&
                spot.SpotNumber == gridSpot.SpotNumber)
            {
                isValid = true;                
            }

            return isValid;
        }



    }
}

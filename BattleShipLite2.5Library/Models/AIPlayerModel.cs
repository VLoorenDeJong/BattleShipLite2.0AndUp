using BattleShipLite2._5Library.LogicalComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShipLite2._5Library.Models
{
    public class AIPlayerModel : PlayerModel
    {
        internal List<GridSpotModel> ShotsToTake { get; set; } = new List<GridSpotModel>();
        internal List<int> DelayTimes { get; set; } = new List<int>();
        public void TakeShot(AIPlayerModel aiPlayer, PlayerModel opponent)
        {
            string outputMessage = "";
            bool isValid = true;

            aiPlayer.RemoveShotFromShotList(aiPlayer);
            outputMessage = GameLogic.RecordPlayerShot(isValid, aiPlayer, opponent);

            // Todo For testing add comment
            Thread.Sleep(3000);
        }
        public string GetShotLocationCommunication(AIPlayerModel aiPlayer)
        {
            string outputMessage = "";

            aiPlayer.shot = aiPlayer.GenerateShotLocation(aiPlayer);
            Thread.Sleep(DeterminDelay(aiPlayer));

            outputMessage = GenerateShotMessage(aiPlayer);

            return outputMessage;
        }
        public GridSpotModel GenerateShotLocation(AIPlayerModel aiPlayer)
        {

            GridSpotModel shotLocation = aiPlayer.GetRandomLocation(aiPlayer.ShotsToTake);
            Thread.Sleep(DeterminDelay(aiPlayer));

            return shotLocation;
        }
        private int DeterminDelay(AIPlayerModel aiPlayer)
        {

            // ToDo For testing remove comment Determin random delay  
            // Full speed test
            //int delay = 1;
            // Reduced speed
            //int delay = 1000;

            int delay = 0;
            int index = 0;
            Random random = new Random();

            index = random.Next(aiPlayer.DelayTimes.Count);
            delay = (aiPlayer.DelayTimes[index]);

            return delay;
        }
        internal void RemoveShotFromShotList(AIPlayerModel aiPlayer)
        {
            aiPlayer.ShotsToTake.Remove(aiPlayer.shot);
        }
        internal void GenerateDelayTimes(AIPlayerModel aiPlayer)
        {
            int number = 500;
            for (int i = 0; i < 7; i++)
            {
                aiPlayer.DelayTimes.Add(number);
                number += 500;
            }

        }
        internal void GenerateShotLocationGrid(AIPlayerModel aiPlayer)
        {
            Random random = new Random();

            aiPlayer.ShotsToTake = aiPlayer.ShotGrid.OrderBy(x => random.Next()).ToList();

        }
        internal void PlaceShips(AIPlayerModel aiPlayer)
        {
            for (int i = 0; i < aiPlayer.AmmountOfShips; i++)
            {
                GridSpotModel randomSpot = new GridSpotModel();

                do
                {
                    randomSpot = GetRandomLocation(aiPlayer.ShipGrid);

                } while (randomSpot.Status == GridSpotEnum.Ship);

                aiPlayer.ShipLocations.Add(randomSpot);
            }
            aiPlayer.PlaceShipsOnShipGrid(aiPlayer);
        }
        internal GridSpotModel GetRandomLocation(List<GridSpotModel> gridSpots)
        {
            GridSpotModel output = new GridSpotModel();

            Random random = new Random();

            int index = random.Next(gridSpots.Count);
            output = (gridSpots[index]);

            return output;
        }
        internal void GenerateAIName(AIPlayerModel aiPlayer)
        {
            string randomName = "";
            Random random = new Random();
            List<string> names = new List<string>       {   "Larry Lunchbucket",
                                                            "Guus Geluk",
                                                            "Dr. Opjes Wybert",
                                                            "Ob Vius",
                                                            "Krystall Ball",
                                                            "Hoof Hearted",
                                                            "Jed I. Knight",
                                                            "Joelle Rollo Koster",
                                                            "Deja Viau",
                                                            "Lancelot Supersad",
                                                            "Will Tickle",
                                                            "Bear Trap",
                                                            "A. Nonimouse",
                                                            "Waldorf Astoria",
                                                            "Statler Hilton",
                                                            "I. Yellalot",
                                                            "Frosted Cupcake",
                                                            "What Does This Button Do",
                                                            "NotFunny",
                                                            "FedoraTheExplorer",
                                                            "ImageNotUploaded",
                                                            "page_not_found",
                                                            "Enter User Name Here",
                                                            "Julius Sneezer",
                                                            "Peek A. Boo",
                                                            "Shaquille Oatmeal",
                                                            "google_was_my_idea",
                                                            "N. Oboats",
                                                            "Cereal Killer",
                                                            "not_james_bond",
                                                            "Sandwich Protector",
                                                            "Scooby Dooku",
                                                            "Don’t shoot I’m on your team",
                                                            "ApocaLypstick",
                                                            "Seas The Day",
                                                            "Usain Boat",
                                                            "To Sea or Knot To Sea",
                                                            "The Codfather",
                                                            "Fishfull Thing King",
                                                            "Jack Sparrow"
                                                        };

            names = names.OrderBy(x => random.Next()).ToList();

            randomName = names.Take(1).First();

            aiPlayer.Name = randomName;
        }
        private string GenerateShotMessage(AIPlayerModel aiPlayer)
        {
            string outputMessage = "";


            outputMessage = $"{ aiPlayer.Name } will shoot at { aiPlayer.shot.SpotLetter }{ aiPlayer.shot.SpotNumber }";

            return outputMessage;
        }
    }
}

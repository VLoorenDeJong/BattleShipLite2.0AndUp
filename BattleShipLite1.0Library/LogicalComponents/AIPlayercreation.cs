using BattleShipLite2._0;
using BattleShipLite2._0Library.Interfaces;
using BattleShipLite2._0Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite2._0Library.LogicalComponents
{
    public static class AIPlayerCreation
    {
        public static AIPlayerModel GenerateAIPlayer()
        {
            AIPlayerModel aiPlayer = new AIPlayerModel();

            GameLogic.InitializeGrid(aiPlayer.ShipGrid);
            GameLogic.InitializeGrid(aiPlayer.ShotGrid);
            aiPlayer.GenerateAIName(aiPlayer);
            aiPlayer.GenerateShotLocationGrid(aiPlayer);
            aiPlayer.GenerateDelayTimes(aiPlayer);
            aiPlayer.PlaceShips(aiPlayer);

            return aiPlayer;

        }
        
        

    }
}

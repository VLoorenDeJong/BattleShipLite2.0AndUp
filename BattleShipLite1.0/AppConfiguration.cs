using BattleShipLite2._0Library;
using BattleShipLite2._0Library.LogicalComponents;
using BattleShipLite2._0Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite2._0.UserComunications
{
    class AppConfiguration
    {

        public static PlayerModel CreatePlayer(int counter)
        {
            
            string playerName = AppComunication.AskForPlayerName(counter);

            PlayerModel player = CreatePlayer(playerName);
            
            return player;
        }          
        public static (PlayerModel winner, PlayerModel loser, int rounds) StartGame(PlayerModel player1, PlayerModel player2)
        {
            PlayerModel winner = new PlayerModel();
            PlayerModel loser = new PlayerModel();

            int round = 1;
            do
            {
                AppComunication.DisplayShotGrid(player1, player2, round);
                AppComunication.AskForShot(player1, player2);
                AppComunication.DisplayShotResult(player1, player2, round);
                GameLogic.DetermineWinner(player1);
                (player1, player2) = GameLogic.ChangeSeats(player1, player2);
                
                round++;

            } while (player2.winner == false);

            winner = player2;
            loser = player1;


            return (winner, loser, round);
        }            
        public static PlayerModel CreatePlayer(string name)
        {
            PlayerModel player = new PlayerModel();

            if (string.IsNullOrWhiteSpace(name))
            {
                player = AIPlayerCreation.GenerateAIPlayer();
            }
            else
            {
                player.Name = name;
                GameLogic.InitializeGrid(player.ShipGrid);
                GameLogic.InitializeGrid(player.ShotGrid);
                PlaceShips(player);
            }

            return player;

        }
        public static void PlaceShips(PlayerModel player)
        {
            for (int i = 0; i < player.AmmountOfShips; i++)
            {
                bool shipIsPlaced = false;
                do
                {
                    shipIsPlaced = AppComunication.PlaceShipOnGrid(player, i);
                } while (shipIsPlaced == false);
                if (i == 4)
                {
                    AppComunication.ThankUserForPlacingAllShips(player);
                }
            }

        }

       

    }
}
;
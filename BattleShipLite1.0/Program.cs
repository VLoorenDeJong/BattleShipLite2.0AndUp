using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipLite2._0;
using BattleShipLite2._0.UserComunications;
using BattleShipLite2._0Library;
using BattleShipLite2._0Library.Models;




namespace BattleShipLite2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string gameTitle = "Battle Ship LT v2.2";

            AppComunication.ShowWelcomeMessage(gameTitle);
            
            PlayerModel player1 = AppConfiguration.CreatePlayer(1);
            PlayerModel player2 = AppConfiguration.CreatePlayer(2);

            (PlayerModel winner, PlayerModel loser, int roundsPlayed) = AppConfiguration.StartGame(player1, player2);

            GameLogic.GetShotCount(winner);

            AppComunication.DisplayWinnerScreen(winner, loser, roundsPlayed);

            AppComunication.ExitApplication(gameTitle);

            // Itterations
            // ToDo Make grid bigger
            // ToDo Make console beep when hit https://docs.microsoft.com/en-us/dotnet/api/system.console.beep?view=net-5.0

        }
    }
}

using BattleShipLite2._5Library.LogicalComponents;
using BattleShipLite2._5Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite2._5
{
    public static class ExtensionMethods
    {

        public static void PrintToScreen(this string message)
        {
            Console.WriteLine(message);
        }

        public static GridSpotModel GetGridLocationFromUser(this string message, List<GridSpotModel> grid, ConsoleColor textColors)
        {
            GridSpotModel outputSpot = new GridSpotModel();
            string outputMessage = "";
            bool isValidGridSpot = false;
            string userInput = "";


            do
            {
                userInput = message.GetStringFromUser(textColors);
                (isValidGridSpot, outputMessage, outputSpot) = InputValidation.ValidateGridLocation(userInput, grid);

                Console.WriteLine();
                outputMessage.CWLColor(textColors);
                Console.WriteLine();

            } while (isValidGridSpot == false);

            return outputSpot;
        }
        public static void CWLColor(this string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

        public static void CWColor(this string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
        }
    }
}

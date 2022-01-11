using BattleShipLite2._5Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite2._5Library.LogicalComponents
{
    public class CommentaryModel
    {
        public static string DisplayRandomCommentary(PlayerModel player, ConsoleColor textColor)
        {
            string outputCommentary = "";
            string comentary = "";
            string name = $"{ player.Name} ";

            if (player.ShipsSunk == 0)
            {
                comentary = GetRandomComentary(Sunk0Comentary());
            }
            else if (player.ShipsSunk > 0 && player.ShipsSunk < 5)
            {
                comentary = GetRandomComentary(Sunk1To4Comentary(player));
            }
            else if (player.ShipsSunk == 5)
            {
                comentary = GetRandomComentary(Sunk5Comentary());
            }

            outputCommentary = name + comentary;

            return outputCommentary;
        }
        private static string GetRandomComentary(List<string> comentary)
        {
            string output = "";
            comentary = comentary.OrderBy(x => Guid.NewGuid()).ToList();
            output = comentary.Take(1).First(); ;

            return output;
        }
        private static List<string> Sunk0Comentary()
        {
            List<string> comentary = new List<string>
            {
                 "keep on searching, the first ship must be on your next location",
                 "soon you will find your first ship!",
                 "what will be the first ship to find?",
                 $"there are five ships left to find!",
                 "the next location could be a hit!",
                 "let's pick the location where a ship is, you can do it!",
                 "all water, where is the fleet?",
                @"how to pick the right location from all those places? @#^&#%",
                 "is it even possible to find ships between al that empty spots?",
                 "all water, it's too much to pick just one spot!",
                 "in the next location is a ship, i am sure of it!",
                 "persistence is key, winning is possible!",
                 "is there even one ship?",
                 "ship happens!",
                 "worry less paddle more...",
                 "The sea is the same as it has been since before men ever went on it in boats. — Ernest Hemingway",
                "a ship is always safe at the shore, but that is not what it is built for. — Albert Einstein",
                 "I’m sorry, but this boat is knot for sail.",
                 "when you can not change the wind change your sails.",
                 "I like boats!",
                 "thanks for making sure we don’t sink!",
                 "keep calm and boat on.",
                 "where there's a will, there's a wave.",
                 "is not giving in to the pier pressure.",
                 "find your flow, and row, row, row.",
                 "what’s up dock?",
                 "I like big boats & I cannot lie...",
                 "float on!",
                 "there’s no place else I’d rather be, then on my boat out on the sea.",
                 "“Shells sink, dreams float. Life’s good on our boat.” — Jimmy Buffett",
                 "to the batboat!",
                 "gone fishing!"

            };

            return comentary;
        }
        private static List<string> Sunk1To4Comentary(PlayerModel player)
        {

            List<string> comentary = new List<string>
            {
                                                       $"already { NumberToText(player.ShipsSunk) } { Plural(player.ShipsSunk, "ship") } down, { NumberToText(5 - player.ShipsSunk) } to go, you can do it!",
                                                       $"already found { NumberToText(player.ShipsSunk) } { Plural(player.ShipsSunk, "ship") }, well done, on to the next one!",
                                                       $"is very determined to find the other { NumberToText(5 - player.ShipsSunk) } { Plural(5 - player.ShipsSunk, "ship") }",
                                                       $"has found { NumberToText(player.ShipsSunk) }, it will not take long to find the other { NumberToText(5 - player.ShipsSunk) } { Plural(5 - player.ShipsSunk, "ship") }",
                                                       $"has { NumberToText(5 - player.ShipsSunk) } { Plural(5 - player.ShipsSunk, "ship") } more to go, you can do it!",
                                                       $"has found { NumberToText(player.ShipsSunk) } { Plural(player.ShipsSunk, "ship") }, and it was not a lucky guess!",
                                                       $"has found { NumberToText(player.ShipsSunk) } and is on a role!",
                                                       $"strike { NumberToText(player.ShipsSunk) }, only { NumberToText(5 - player.ShipsSunk) } { Plural(5 - player.ShipsSunk, "ship") } to go!",
                                                       $"will find all the ships in a jiffy, the counter is already on { NumberToText(player.ShipsSunk) }.",
                                                       $"is already on { NumberToText(player.ShipsSunk) } { Plural(player.ShipsSunk, "ship") }, you are getting there!",
                                                       $"can smell the next { NumberToText(5 - player.ShipsSunk) }!",
                                                       $"found { NumberToText(player.ShipsSunk) } { Plural(player.ShipsSunk, "ship") }, the strategy is clear, now beware...",
                                                       $"managed to sink { NumberToText(player.ShipsSunk) } { Plural(player.ShipsSunk, "ship") }, almost there!",
                                                       $"is getting there, the counter is already on { NumberToText(player.ShipsSunk) }!",
                                                       $"bombs away and that's { NumberToText(player.ShipsSunk) }!",
                                                       $"will get there sooner than later, the counter is already on { NumberToText(player.ShipsSunk) }!",
                                                       $"the end goal is only { NumberToText(5 - player.ShipsSunk) } { Plural(5 - player.ShipsSunk, "ship") } away, you can do it!",
                                                       $"has found { NumberToText(player.ShipsSunk) } { Plural(player.ShipsSunk, "ship") } and has seen through the opponents strategy and will win this very soon!",
                                                       $"is picking them out of the water, only { NumberToText(5 - player.ShipsSunk) } left, this can be over very soon!",
                                                       $"has a nose for boats, already { NumberToText(player.ShipsSunk ) } { Plural(player.ShipsSunk, "ship") } found, this is going very well!",
                                                       $"only { NumberToText(5 - player.ShipsSunk) } { Plural(5 - player.ShipsSunk, "ship") } left, give it your best!",
                                                       $"has been preparing for this, this is not luck anymore...",
                                                       $"can smell the win, only { NumberToText(5 - player.ShipsSunk) } left!",
                                                       $"can you see through the grid? You only need to find { NumberToText(5 - player.ShipsSunk) } more { Plural(5 - player.ShipsSunk, "ship") } for the win.",
                                                       $"is really going for it, only { NumberToText(5 - player.ShipsSunk) } { Plural(5 - player.ShipsSunk, "ship") } left!",
                                                       $"is picking them one by one and has only { NumberToText(5 - player.ShipsSunk) } { Plural(5 - player.ShipsSunk, "ship") } left to find, this is remarkable!",
                                                       $"already has found { NumberToText(player.ShipsSunk) }, that's { NumberToText(player.ShipsSunk) } less { Plural(player.ShipsSunk, "spot") } to worry about!",
                                                       $"will it sink or wil it float?",
                                                       $"mystery biscuits!! Oh yeah",
                                                       "what ever floats your boat!",
                                                       "take time to coast!",
                                                       "worry less paddle more.",
                                                       "you can’t be crabby when you’re on a boat!",
                                                       "you live for the sea-nic route.",
                                                       "be an anchor in a world of waves.",
                                                       "forever in need of some vitamin sea!",
                                                       "getting salty?",
                                                       "you’re gonna need a bigger boat!",
                                                       "is not giving in to the pier pressure.",
                                                       "find your flow, and row, row, row.",
                                                       "what’s up dock?",
                                                       "I like big boats & I cannot lie...",
                                                       "gone fishing!"
            };

            return comentary;

        }
        private static List<string> Sunk5Comentary()
        {

            List<string> Comentary = new List<string> {
                                                       "is the king of the ocean and found all five!",
                                                       "has destroyed the entire fleet and now rules the seven seas!!",
                                                       "will get the reward soon, just wait for the next screen...",
                                                       "made a lot of fireworks with all those hits",
                                                       "has a clean sweep",
                                                       "was the first to find all five, well done",
                                                       "has the win!!(This time...)",
                                                       "really was playing for the win, it was relentless",
                                                       "could not be more right, found all five, well done!"
                                                        };
            return Comentary;
        }
        private static object Plural(int number, string word)
        {
            string output = word;

            if (number > 1)
            {
                output += "s";
            }

            return output;
        }
        private static string NumberToText(int number)
        {
            string output = "";

            switch (number)
            {
                case 1:
                    output = "one";
                    break;
                case 2:
                    output = "two";
                    break;

                case 3:
                    output = "three";
                    break;

                case 4:
                    output = "four";
                    break;
                case 5:
                    output = "five";
                    break;

                default:
                    output = number.ToString();
                    break;
            }
            return output;
        }
    }
}

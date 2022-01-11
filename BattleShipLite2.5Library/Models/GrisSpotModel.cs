using BattleShipLite2._5Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite2._5Library.Models
{
    public class GridSpotModel : IGridSpot
    {
        public int SpotNumber { get; set; }
        public string SpotLetter { get; set; }
        public GridSpotEnum Status { get; set; }
    }
}

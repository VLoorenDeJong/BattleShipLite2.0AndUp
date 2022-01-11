using BattleShipLite2._5Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite2._5Library.Interfaces
{    public interface IGridSpot
    {
        int SpotNumber { get; set; }
        string SpotLetter { get; set; }
        GridSpotEnum Status { get; set; }
    }
}

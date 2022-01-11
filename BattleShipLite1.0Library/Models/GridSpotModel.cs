using BattleShipLite2._0Library.Interfaces;

namespace BattleShipLite2._0
{
    public class GridSpotModel : IGridSpot
    {
        public int SpotNumber { get; set; }
        public string SpotLetter { get; set; }
        public GridSpotEnum Status { get; set; }
    }
}
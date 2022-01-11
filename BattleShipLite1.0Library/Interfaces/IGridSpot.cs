using BattleShipLite2._0;

namespace BattleShipLite2._0Library.Interfaces
{
    public interface IGridSpot
    {
        int SpotNumber { get; set; }
        string SpotLetter { get; set; }
        GridSpotEnum Status { get; set; }
    }
}

using Ecomsolutions.Core.Enum;
using Ecomsolutions.Core.Model;

namespace Ecomsolutions.Core.Interface
{
    public interface IMap
    {
        /// <summary>
        /// Max X-Y coordinates
        /// </summary>
        Coordinates MaxCoordinates { get; }
        /// <summary>
        /// Requests a navigation to the given coordinates
        /// </summary>
        NavigationResult Navigate(Position navigateTo);
        /// <summary>
        /// Checks if a position is valid for a unit to drop off / navigate
        /// </summary>
        bool CheckIfThePositionIsValid(Position position);
    }
}

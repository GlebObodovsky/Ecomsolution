using Ecomsolutions.Core.Model;

namespace Ecomsolutions.Core.Interface
{
    public interface IRobotFactoryMethod
    {
        /// <summary>
        /// Creates a robot within the scope of the passed in map with the passed position coordinates
        /// </summary>
        RobotBase GetRobot(IMap map, Position position);
    }
}

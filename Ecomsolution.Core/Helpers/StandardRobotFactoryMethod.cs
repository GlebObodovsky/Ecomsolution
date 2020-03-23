using Ecomsolutions.Core.Interface;
using Ecomsolutions.Core.Model;

namespace Ecomsolutions.Core.Helpers
{
    public class StandardRobotFactoryMethod : IRobotFactoryMethod
    {
        /// <summary>
        /// Creates a robot within the scope of the passed in map with the passed position coordinates
        /// </summary>
        public RobotBase GetRobot(IMap map, Position position)
            => new MartianRobot(map, position);
    }
}

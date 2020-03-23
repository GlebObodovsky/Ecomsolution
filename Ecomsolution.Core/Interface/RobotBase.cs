using Ecomsolutions.Core.Enum;
using Ecomsolutions.Core.Model;
using System;
using System.Text;

namespace Ecomsolutions.Core.Interface
{
    public abstract class RobotBase
    {
        protected readonly IMap _map;

        protected bool _isLost;
        protected Position _position;

        /// <summary>
        /// Defines the current robot's position on a map 
        /// </summary>
        public Position Position => _position;
        public bool IsLost => _isLost;

        /// <summary></summary>
        /// <param name="map">Map on which the robot is operating</param>
        /// <param name="commandProvider">
        /// Provider which defines a set of commands that are allowed for the constructing robot.
        /// If no provider is specified - StandardRobotCommandProvider will be used
        /// </param>
        public RobotBase(IMap map, Position position)
        {
            if (map == null)
                throw new ArgumentNullException("Robot is allowed to be constructed only in a context of a map it's operating on");

            if (position == null)
                throw new ArgumentNullException("Robot's position is a required parameter");

            if (!map.CheckIfThePositionIsValid(position))
                throw new IndexOutOfRangeException("There's no way of dropping off a robot out of the map's range");

            _position = position;
            _map = map;
        }

        public override string ToString()
        {
            var builder = new StringBuilder($"{Position.X} {Position.Y} {Position.Orientation.ToString().Substring(0, 1)}");

            if (_isLost)
                builder.Append(" LOST");

            return builder.ToString();
        }

        /// <summary>
        /// Sends the robot one step ahead
        /// </summary>
        public abstract void GoForward();

        /// <summary>
        /// Turns the robot in the specified direction
        /// </summary>
        /// <param name="side"></param>
        public abstract void Turn(Side side);
    }
}

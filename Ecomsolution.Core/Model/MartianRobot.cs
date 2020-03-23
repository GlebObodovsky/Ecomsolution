using Ecomsolutions.Core.Enum;
using Ecomsolutions.Core.Interface;

namespace Ecomsolutions.Core.Model
{
    /// <summary>
    /// Martian robot moves with only one step at a time despite that Martian gravity is lighter than the Earth gravity
    /// </summary>
    public class MartianRobot : RobotBase
    {
        /// <summary></summary>
        /// <param name="map">Map on which the robot is operating</param>
        /// <param name="commandProvider">
        /// Provider which defines a set of commands that are allowed for the constructing robot.
        /// If no provider is specified - StandardRobotCommandProvider will be used
        /// </param>
        public MartianRobot(IMap map, Position position) : base(map, position) { }

        /// <summary>
        /// Sends the robot one step ahead
        /// </summary>
        public override void GoForward()
        {
            if (_isLost)
                return;

            var changedPosition = Position.Clone();

            switch (changedPosition.Orientation)
            {
                case Orientation.North:
                    changedPosition.Y++;
                    break;
                case Orientation.East:
                    changedPosition.X++;
                    break;
                case Orientation.South:
                    changedPosition.Y--;
                    break;
                case Orientation.West:
                    changedPosition.X--;
                    break;
            }

            var result = _map.Navigate(changedPosition);

            if (result == NavigationResult.Success)
                _position = changedPosition;
            if (result == NavigationResult.Lost)
                _isLost = true;
        }

        /// <summary>
        /// Turns the robot in the specified direction
        /// </summary>
        public override void Turn(Side side)
        {
            if (_isLost)
                return;

            if (side == Side.Left)
            {
                if (Position.Orientation == 0)
                    Position.Orientation = (Orientation)3;
                else
                    Position.Orientation--;
            }
            else
            {
                if (Position.Orientation == (Orientation)3)
                    Position.Orientation = 0;
                else
                    Position.Orientation++;
            }
        }
    }
}

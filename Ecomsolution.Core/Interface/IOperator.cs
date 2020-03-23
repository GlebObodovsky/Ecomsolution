using Ecomsolutions.Core.Enum;
using Ecomsolutions.Core.Model;

namespace Ecomsolutions.Core.Interface
{
    /// <summary>
    /// An operator oughts to work with a sole robot at a time on a single map
    /// </summary>
    public interface IOperator
    {
        /// <summary>
        /// Gets the current operating robot
        /// </summary>
        RobotBase CurrentRobot { get; }

        /// <summary>
        /// Drops off a new robot on a map accordingly to the passed position coordinates and orientation
        /// </summary>
        /// <param name="x">X coordinate on a map for a new robot to be dropped off</param>
        /// <param name="y">Y coordinate on a map for a new robot to be dropped off</param>
        /// <param name="orientation">Orientation of a new robot that is about to to be dropped off</param>
        void DropOffNewRobot(int x, int y, Orientation orientation);

        /// <summary>
        /// Drops off a new robot on a map accordingly to the passed position
        /// </summary>
        /// <param name="position">Position on a map for a new robot to be dropped off</param>
        void DropOffNewRobot(Position position);

        /// <summary>
        /// Invokes a command on the current robot of the operator by it's command key
        /// </summary>
        void InvokeSoleCommandOnRobot(string commandKey);

        /// <summary>
        /// Invokes a command set on the current robot of the operator
        /// </summary>
        void InvokeCommandsOnRobot(params string[] commandKeys);

        /// <summary>
        /// Invokes a command set on the current robot of the operator
        /// </summary>
        /// <param name="commandKeys">
        /// The string that contains an array of command keys
        /// Each character is an individual command key
        /// </param>
        void InvokeCommandsOnRobot(string commandKeys);
    }
}

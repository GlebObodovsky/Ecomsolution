using Ecomsolutions.Core.Enum;
using Ecomsolutions.Core.Helpers;
using Ecomsolutions.Core.Interface;
using System;
using System.Linq;

namespace Ecomsolutions.Core.Model
{
    /// <summary>
    /// Martian operator oughts to work with a sole robot at a time on a single map
    /// </summary>
    public class MartianOperator : IOperator
    {
        private readonly IMap _map;
        private readonly IRobotCommandProvider _commandProvider;
        private readonly IRobotFactoryMethod _robotFactoryMethod;

        private RobotBase _currentRobot;

        /// <summary>
        /// Gets the current operating robot
        /// </summary>
        public RobotBase CurrentRobot => _currentRobot;

        /// <summary></summary>
        /// <param name="robotFactoryMethod">
        /// Provides a factory method that is responsible for robots creation for the operator
        /// StandardRobotFactoryMethod will be used if no IRobotFactoryMethod is specified
        /// </param>
        /// <param name="commandProvider">
        /// Provides a set of commands that are available for the operator to use on robots
        /// StandardRobotCommandProvider will be used if no IRobotCommandProvider is specified
        /// </param>
        public MartianOperator(IMap map, IRobotFactoryMethod robotFactoryMethod = null, IRobotCommandProvider commandProvider = null)
        {
            if (map == null)
                throw new ArgumentNullException("Operator is allowed to be constructed only in a context of a map it's operating with");

            _map = map;
            _robotFactoryMethod = robotFactoryMethod ?? new StandardRobotFactoryMethod();
            _commandProvider = commandProvider ?? new StandardRobotCommandProvider();
        }

        /// <summary>
        /// Drops off a new robot on a map accordingly to the passed position coordinates and orientation
        /// </summary>
        /// <param name="x">X coordinate on a map for a new robot to be dropped off</param>
        /// <param name="y">Y coordinate on a map for a new robot to be dropped off</param>
        /// <param name="orientation">Orientation of a new robot that is about to to be dropped off</param>
        public void DropOffNewRobot(int x, int y, Orientation orientation)
            => DropOffNewRobot(new Position(x, y, orientation));

        /// <summary>
        /// Drops off a new robot on a map accordingly to the passed position
        /// </summary>
        /// <param name="position"></param>
        public void DropOffNewRobot(Position position)
            => _currentRobot = _robotFactoryMethod.GetRobot(_map, position);

        /// <summary>
        /// Invokes a command on the current robot of the operator by it's command key
        /// </summary>
        public void InvokeSoleCommandOnRobot(string commandKey)
        {
            if (_currentRobot == null)
                throw new InvalidOperationException("There's no robot to operate on. Use DropOffNewRobot first.");

            var command = _commandProvider.GetCommand(commandKey);
            command?.Invoke(_currentRobot);
        }

        /// <summary>
        /// Invokes a command set on the current robot of the operator
        /// </summary>
        public void InvokeCommandsOnRobot(params string[] commandKeys)
        {
            foreach (var commandKey in commandKeys)
                InvokeSoleCommandOnRobot(commandKey);
        }

        /// <summary>
        /// Invokes a command set on the current robot of the operator
        /// </summary>
        /// <param name="commandKeys">
        /// The string that contains an array of command keys
        /// Each character is an individual command key
        /// </param>
        public void InvokeCommandsOnRobot(string commandKeys)
            => InvokeCommandsOnRobot(commandKeys.Select(k => k.ToString()).ToArray());
    }
}

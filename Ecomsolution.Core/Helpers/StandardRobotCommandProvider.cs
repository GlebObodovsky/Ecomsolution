using Ecomsolutions.Core.Enum;
using Ecomsolutions.Core.Interface;
using System;
using System.Collections.Generic;

namespace Ecomsolutions.Core.Helpers
{
    /// <summary>
    /// Provides a set of standard commands that are allowed for robots to execute
    /// These are: F (for "Go forward"), R (for "Turn right"), L (for "Turn left")
    /// </summary>
    public class StandardRobotCommandProvider : IRobotCommandProvider
    {
        private readonly Dictionary<string, Action<RobotBase>> commands;

        public StandardRobotCommandProvider()
        {
            commands = new Dictionary<string, Action<RobotBase>> 
            {
                { "F", new Action<RobotBase>(r => r.GoForward()) },
                { "R", new Action<RobotBase>(r => r.Turn(Side.Right)) },
                { "L", new Action<RobotBase>(r => r.Turn(Side.Left)) }
            };
        }

        /// <summary>
        /// Returns a command delegate by the passed in command key
        /// </summary>
        public Action<RobotBase> GetCommand(string commandKey)
        {
            if (commands.TryGetValue(commandKey, out var command))
                return command;

            throw new InvalidOperationException("There's no command corresponding to the specified command key");
        }
    }
}

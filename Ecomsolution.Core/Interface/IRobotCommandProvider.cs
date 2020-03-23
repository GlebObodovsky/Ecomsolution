using System;

namespace Ecomsolutions.Core.Interface
{
    /// <summary>
    /// Provides a set of commands that are allowed for robots to execute
    /// </summary>
    public interface IRobotCommandProvider
    {
        /// <summary>
        /// Returns a command delegate by the passed in command key
        /// </summary>
        Action<RobotBase> GetCommand(string commandKey);
    }
}

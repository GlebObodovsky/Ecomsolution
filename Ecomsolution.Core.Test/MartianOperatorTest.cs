using Ecomsolutions.Core.Interface;
using Ecomsolutions.Core.Model;
using NUnit.Framework;
using Ecomsolutions.Core.Helpers;

namespace Ecomsolution.Core.Test
{
    public class MartianOperatorTest
    {
        [Test]
        public void InvokeCommandsOnRobot_FirstCaseOutput_Valid()
        {
            // Sample Input
            // 5 3 - map
            IMap map = new MartianMap(5, 3);
            IOperator oper = new MartianOperator(map);

            // 1 1 E
            oper.DropOffNewRobot(1, 1, "E".ToOrientation());

            // RFRFRFRF
            oper.InvokeCommandsOnRobot("RFRFRFRF");

            // Sample Output
            // 1 1 E
            Assert.That(oper.CurrentRobot.ToString(), Is.EqualTo("1 1 E"));
        }

        [Test]
        public void InvokeCommandsOnRobot_SecondCaseOutput_Valid()
        {
            // Sample Input
            // 5 3 - map
            IMap map = new MartianMap(5, 3);
            IOperator oper = new MartianOperator(map);

            #region First robot
            // 1 1 E - drop off of the first robot
            oper.DropOffNewRobot(1, 1, "E".ToOrientation());
            // RFRFRFRF - commands for the first robot
            oper.InvokeCommandsOnRobot("RFRFRFRF");
            #endregion First robot

            // 3 2 N - drop off of the second robot
            oper.DropOffNewRobot(3, 2, "N".ToOrientation());
            // FRRFLLFFRRFLL - commands for the second robot
            oper.InvokeCommandsOnRobot("FRRFLLFFRRFLL");

            // Sample Output
            // 3 3 N LOST
            Assert.That(oper.CurrentRobot.ToString(), Is.EqualTo("3 3 N LOST"));
        }

        [Test]
        public void InvokeCommandsOnRobot_ThirdCaseOutput_Valid()
        {
            // Sample Input
            // 5 3 - map
            IMap map = new MartianMap(5, 3);
            IOperator oper = new MartianOperator(map);

            #region First robot
            // 1 1 E - drop off of the first robot
            oper.DropOffNewRobot(1, 1, "E".ToOrientation());
            // RFRFRFRF - commands for the first robot
            oper.InvokeCommandsOnRobot("RFRFRFRF");
            #endregion First robot

            #region Second robot
            // 3 2 N - drop off of the second robot
            oper.DropOffNewRobot(3, 2, "N".ToOrientation());
            // FRRFLLFFRRFLL - commands for the second robot
            oper.InvokeCommandsOnRobot("FRRFLLFFRRFLL");
            #endregion Second robot

            // 0 3 W - drop off of the third robot
            oper.DropOffNewRobot(0, 3, "W".ToOrientation());
            // LLFFFLFLFL - commands for the third robot
            oper.InvokeCommandsOnRobot("LLFFFLFLFL");

            // Sample Output
            // 2 3 S
            Assert.That(oper.CurrentRobot.ToString(), Is.EqualTo("2 3 S"));
        }
    }
}

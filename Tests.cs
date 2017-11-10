using NUnit.Framework;

namespace RobotCommands
{
    [TestFixture]
    public class Tests
    {
        // in the tests I need to verify the state of a robot is correct
        // however, the interface from the SDK does not allow me to
        // so I have only left comments what should be done in a real project

        [Test]
        public void TestMove()
        {
            var robot = new Robot();
            var @operator = new Operator(robot);
            Assert.That(() => @operator.SendCommand(new MoveCommand(-100)), Throws.ArgumentException);
            @operator.SendCommand(new MoveCommand(100));
            // assert the state of the robot has changed
        }

        [Test]
        public void TestTurn()
        {
            var robot = new Robot();
            var @operator = new Operator(robot);
            Assert.That(() => @operator.SendCommand(new TurnCommand(-200)), Throws.ArgumentException);
            Assert.That(() => @operator.SendCommand(new TurnCommand(200)), Throws.ArgumentException);
            @operator.SendCommand(new TurnCommand(-45));
            @operator.SendCommand(new TurnCommand(45));
            // assert the state of the robot has changed
        }

        [Test]
        public void TestBeep()
        {
            var robot = new Robot();
            var @operator = new Operator(robot);
            @operator.SendCommand(Commands.BeepCommand);
            // assert the state of the robot has changed
        }

        [Test]
        public void TestSequence()
        {
            var robot1 = new Robot();
            var @operator = new Operator(robot1);
            @operator.SendCommand(new TurnCommand(-90));
            @operator.SendCommand(new MoveCommand(50));
            @operator.SendCommand(new TurnCommand(45));
            @operator.SendCommand(new MoveCommand(25));
            // assert the state of the first robot has changed

            var robot2 = new Robot();
            @operator.Robot = robot2;
            @operator.SendStoredCommands();
            // assert the state of the second robot has changed

            @operator.SendCommand(new MoveCommand(100));
            Assert.That(() => @operator.SendCommand(new TurnCommand(200)), Throws.ArgumentException);
            var robot3 = new Robot();
            @operator.Robot = robot3;
            @operator.SendStoredCommands();
            // assert the state of the third robot has not changed since an invalid command cleared the sequence
        }
    }
}

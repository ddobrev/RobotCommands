namespace RobotCommands
{
    public class MoveCommand : ICommand
    {
        public MoveCommand(double distance)
        {
            this.distance = distance;
        }

        public void Execute(IRobot robot)
        {
            robot.Move(this.distance);
        }

        private readonly double distance;
    }
}

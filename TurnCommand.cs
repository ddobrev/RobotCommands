namespace RobotCommands
{
    public class TurnCommand : ICommand
    {
        public TurnCommand(double angle)
        {
            this.angle = angle;
        }

        public void Execute(IRobot robot)
        {
            robot.Turn(this.angle);
        }

        private readonly double angle;
    }
}

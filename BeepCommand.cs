namespace RobotCommands
{
    public class BeepCommand : ICommand
    {
        public void Execute(IRobot robot)
        {
            robot.Beep();
        }
    }
}

using System;

namespace RobotCommands
{
    public class Operator
    {
        public Operator(IRobot robot)
        {
            this.robot = robot ?? throw new ArgumentNullException(nameof(robot));
        }

        public IRobot Robot
        {
            get { return this.robot; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                if (this.robot != value)
                {
                    this.robot = value;
                    this.robotChanged = true;
                }
            }
        }

        public void SendCommand(ICommand command)
        {
            if (this.robotChanged)
            {
                // execution of new commands to a different robot starts a new sequence
                // this way we don't mix commands stored for different robots
                this.macroCommand.ClearCommands();
                this.robotChanged = false;
            }
            try
            {
                command.Execute(this.robot);
                this.macroCommand.AddCommand(command);
            }
            catch (ArgumentException)
            {
                // if an error occurs, the entire sequence is invalid
                this.macroCommand.ClearCommands();
                throw;
            }
        }

        public void SendStoredCommands()
        {
            try
            {
                this.macroCommand.Execute(this.robot);
            }
            catch (ArgumentException)
            {
                // if an error occurs, the entire sequence is invalid
                this.macroCommand.ClearCommands();
                throw;
            }
        }

        private MacroCommand macroCommand = new MacroCommand();
        private IRobot robot;
        private bool robotChanged;
    }
}

using System.Collections.Generic;
using System;

namespace RobotCommands
{
    public class MacroCommand : ICommand
    {
        public void AddCommand(ICommand command)
        {
            this.commands.Add(command);
        }

        public void ClearCommands()
        {
            commands.Clear();
        }

        public void Execute(IRobot robot)
        {
            foreach (var command in commands)
            {
                try
                {
                    command.Execute(robot);
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException("Invalid command.", command.ToString(), ex);
                }
            }
        }

        private readonly IList<ICommand> commands = new List<ICommand>();
    }
}

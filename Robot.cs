using System;

namespace RobotCommands
{
    public class Robot : IRobot
    {
        public void Move(double distance)
        {
            if (distance < 0)
            {
                throw new ArgumentException("Cannot be negative", nameof(distance));
            }
        }

        public void Turn(double angle)
        {
            if (angle < -180 || angle > 180)
            {
                const string message = "Varies between 0 and 180 for turning left and 0 and -180 for turning right.";
                throw new ArgumentException(message, nameof(angle));
            }
        }

        public void Beep()
        {
        }
    }
}

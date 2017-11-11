﻿namespace RobotCommands
{
    public interface IRobot
    {
        void Move(double distance);
        void Turn(double angle);
        void Beep();
    }
}

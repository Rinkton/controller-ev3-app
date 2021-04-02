using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using System.Windows.Forms;

namespace App
{
    static class KeyboardController
    {
        private static readonly OutputPort wheel1 = ConfigReader.GetOutputPort("wheel1-op");
        private static readonly OutputPort wheel2 = ConfigReader.GetOutputPort("wheel2-op");

        private static readonly OutputPort hanger = ConfigReader.GetOutputPort("hanger-op");

        public static async void HandleKeyboardInput()
        {
            //TODO: MATH abs with plus nan?!
            //TODO: With plus rotate with move is didn't work correctly, only with minus
            if (KeyKeeper.W && KeyKeeper.A)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel1, InfoKeeper.Speed);
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel2, InfoKeeper.Speed / 3);
            }
            else if (KeyKeeper.A && KeyKeeper.S)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel1, -InfoKeeper.Speed);
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel2, -InfoKeeper.Speed / 2);
            }
            else if (KeyKeeper.S && KeyKeeper.D)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel1, -InfoKeeper.Speed / 2);
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel2, -InfoKeeper.Speed);
            }
            else if (KeyKeeper.D && KeyKeeper.W)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel1, InfoKeeper.Speed / 3);
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel2, InfoKeeper.Speed);
            }
            else if (KeyKeeper.W)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel1, InfoKeeper.Speed);
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel2, InfoKeeper.Speed);
            }
            else if (KeyKeeper.A)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel1, -Math.Abs(InfoKeeper.Speed));
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel2, Math.Abs(InfoKeeper.Speed));
            }
            else if (KeyKeeper.S)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel1, -InfoKeeper.Speed);
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel2, -InfoKeeper.Speed);
            }
            else if (KeyKeeper.D)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel1, Math.Abs(InfoKeeper.Speed));
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel2, -Math.Abs(InfoKeeper.Speed));
            }
            else
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel1, 0);
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(wheel2, 0);
            }

            if (KeyKeeper.Add)
            {
                if (InfoKeeper.Speed < 100)
                {
                    InfoKeeper.Speed += 5;
                }
            }
            else if (KeyKeeper.Subtract)
            {
                if (InfoKeeper.Speed > -100)
                {
                    InfoKeeper.Speed -= 5;
                }
            }
            else if (KeyKeeper.Multiply)
            {
                InfoKeeper.Speed = -InfoKeeper.Speed;
            }

            if (KeyKeeper.Right)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(hanger, Math.Abs(-15));//InfoKeeper.Speed));
            }
            else if (KeyKeeper.Left)
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(hanger, Math.Abs(15));//-InfoKeeper.Speed));
            }
            else
            {
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(hanger, 0);
                await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(hanger, 0);
            }
        }
    }
}

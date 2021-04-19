using Lego.Ev3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    class MouseChecker
    {
        private MouseEventArgs previousMouse;
        private bool isStart = true;
        private OutputPort hangerX = ConfigReader.GetOutputPort("hangerX-op");
        private OutputPort hangerY = ConfigReader.GetOutputPort("hangerY-op");

        public void Main()
        {
            while (true)
            {
                while (!KeyKeeper.MouseDown)
                {
                    isStart = true;
                }
                if (isStart)
                {
                    previousMouse = new MouseEventArgs(MouseButtons.None, 0, FormKeeper.Form.Mouse.X, FormKeeper.Form.Mouse.Y, 0);
                    isStart = false;
                }
                Vector vectorMouseMoving = getVectorMouseMoving();
                renameMePlease(vectorMouseMoving);
                previousMouse = FormKeeper.Form.Mouse;
                System.Threading.Thread.Sleep(1);
            }
        }

        private Vector getVectorMouseMoving()
        {
            Vector vector = new Vector();

            vector.X = FormKeeper.Form.Mouse.X - previousMouse.X;
            vector.Y = FormKeeper.Form.Mouse.Y - previousMouse.Y;

            return vector;
        }

        private async void renameMePlease(Vector vectorMouseMoving)
        {
            //TODO: RENAAAAAAAAAMMMMMMMEEEEEEEEE MEEEEEE PLEAAAAAAAASWEEEEEE!
            if (vectorMouseMoving.X == 0 || vectorMouseMoving.Y == 0)
            {
                return;
            }

            int f = 45;

            int fx = Convert.ToInt32(f*1.5f);
            int fy = f;
            int t = 0;
            int kx = -1;
            int ky = -1;

            if (vectorMouseMoving.X < 0)
            {
                kx = 1;
            }
            else
            {
                kx = -1;
            }
            if (vectorMouseMoving.Y < 0)
            {
                ky = 1;
            }
            else
            {
                ky = -1;
            }
            int k = vectorMouseMoving.X / vectorMouseMoving.Y;
            if (Math.Abs(k) > 1)
            {
                fy = f / k;
                t = vectorMouseMoving.X / 25;
            }
            else if (Math.Abs(k) < 1)
            {
                fx = Convert.ToInt32(f*1.5f * k);
                t = vectorMouseMoving.Y / 25;
            }

            await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(hangerX, fx*kx);
            await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(hangerY, fy*ky);

            System.Threading.Thread.Sleep(Math.Abs(t));

            await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(hangerX, 0);
            await BrickKeeper.BrickObj.DirectCommand.TurnMotorAtPowerAsync(hangerY, 0);
        }
    }
}

using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public MouseEventArgs Mouse;
        TextBox speedText;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            FormKeeper.Form = this;
            var communication = new BluetoothCommunication("COM" + ConfigReader.GetInt("COM"));
            var brick = new Brick(communication);
            BrickKeeper.BrickObj = brick;
            BrickKeeper.BrickObj.BrickChanged += brickChanged;

            await BrickKeeper.BrickObj.ConnectAsync(new TimeSpan(1000));//TODO: On connect

            await BrickKeeper.BrickObj.DirectCommand.PlayToneAsync(3, 200, 300);

            this.KeyDown += new KeyEventHandler(keyIsDown);
            this.KeyUp += new KeyEventHandler(keyIsUp);

            speedText = new TextBox()
            {
                Location = new Point(80, 30),
                BackColor = System.Drawing.Color.LightGreen,
                Enabled = false
            };
            this.Controls.Add(speedText);

            await Task.Run(() => new MouseChecker().Main());

            timer.Start();
        }

        private void brickChanged(object sender, BrickChangedEventArgs e) { }

        private void timerTick(object sender, EventArgs e)
        {
            KeyboardController.HandleKeyboardInput();

            speedText.Text = "Speed: " + InfoKeeper.Speed;
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                KeyKeeper.W = true;
            }
            if (e.KeyCode == Keys.A)
            {
                KeyKeeper.A = true;
            }
            if (e.KeyCode == Keys.S)
            {
                KeyKeeper.S = true;
            }
            if (e.KeyCode == Keys.D)
            {
                KeyKeeper.D = true;
            }
            if (e.KeyCode == Keys.Add)
            {
                KeyKeeper.Add = true;
            }
            if (e.KeyCode == Keys.Subtract)
            {
                KeyKeeper.Subtract = true;
            }
            if (e.KeyCode == Keys.Multiply)
            {
                KeyKeeper.Multiply = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                KeyKeeper.Right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                KeyKeeper.Left = true;
            }
            if (e.KeyCode == Keys.L)
            {
                KeyKeeper.L = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                KeyKeeper.W = false;
            }
            if (e.KeyCode == Keys.A)
            {
                KeyKeeper.A = false;
            }
            if (e.KeyCode == Keys.S)
            {
                KeyKeeper.S = false;
            }
            if (e.KeyCode == Keys.D)
            {
                KeyKeeper.D = false;
            }
            if (e.KeyCode == Keys.Add)
            {
                KeyKeeper.Add = false;
            }
            if (e.KeyCode == Keys.Subtract)
            {
                KeyKeeper.Subtract = false;
            }
            if (e.KeyCode == Keys.Multiply)
            {
                KeyKeeper.Multiply = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                KeyKeeper.Right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                KeyKeeper.Left = false;
            }
            if (e.KeyCode == Keys.L)
            {
                KeyKeeper.L = false;
            }
        }

        public void DisplayError(string errorText)
        {
            MessageBox.Show(errorText);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Mouse = e;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            KeyKeeper.MouseDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            KeyKeeper.MouseDown = false;
        }
    }
}

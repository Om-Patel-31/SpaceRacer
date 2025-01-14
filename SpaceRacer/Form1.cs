using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceRacer
{
    public partial class Form1 : Form
    {
        // Global Variables
        int time = 60;
        int timeBarHeight = 600;

        int obstacleWidth = 10;
        int obstacleHeight = 3;

        bool upPressed = false;
        bool downPressed = false;
        bool wPressed = false;
        bool sPressed = false;

        Random randGen = new Random();

        Rectangle spaceShip1 = new Rectangle(270, 555, 20, 33);
        Rectangle spaceShip1Body = new Rectangle(275, 565, 10, 15);
        Rectangle spaceShip2 = new Rectangle(670, 555, 20, 33);
        Rectangle spaceShip2Body = new Rectangle(675, 565, 10, 15);
        Rectangle thrustOne = new Rectangle(273, 585, 15, 3);
        Rectangle thrustTwo = new Rectangle(673, 585, 15, 3);
        Rectangle timeBar;
        Rectangle timeBarOuter = new Rectangle(475, 0, 10, 600);

        //SpaceShip1 triangle points
        PointF topTrianglep1 = new PointF(280, 555);
        PointF topTrianglep2 = new PointF(290, 565);
        PointF topTrianglep3 = new PointF(270, 565);
        PointF lowTrianglep1 = new PointF(280, 570);
        PointF lowTrianglep2 = new PointF(292, 585);
        PointF lowTrianglep3 = new PointF(268, 585);

        //SpaceShip2 triangle points
        PointF topTrianglep4 = new PointF(680, 555);
        PointF topTrianglep5 = new PointF(690, 565);
        PointF topTrianglep6 = new PointF(670, 565);
        PointF lowTrianglep4 = new PointF(680, 570);
        PointF lowTrianglep5 = new PointF(692, 585);
        PointF lowTrianglep6 = new PointF(668, 585);

        List<Rectangle> obstacles = new List<Rectangle>();
        List<int> obstacleSpeeds = new List<int>();

        //Brushes
        SolidBrush spaceShipBrush = new SolidBrush(Color.White);
        Pen Pen = new Pen(Color.White);

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            if (wPressed == true)
            {
                spaceShip1.Y -= 3;
                spaceShip1Body.Y -= 3;
                topTrianglep1.Y -= 3;
                topTrianglep2.Y -= 3;
                topTrianglep3.Y -= 3;
                lowTrianglep1.Y -= 3;
                lowTrianglep2.Y -= 3;
                lowTrianglep3.Y -= 3;
                thrustOne.Y -= 3;
            }

            if (sPressed == true)
            {
                spaceShip1.Y += 3;
                spaceShip1Body.Y += 3;
                topTrianglep1.Y += 3;
                topTrianglep2.Y += 3;
                topTrianglep3.Y += 3;
                lowTrianglep1.Y += 3;
                lowTrianglep2.Y += 3;
                lowTrianglep3.Y += 3;
                thrustOne.Y += 3;
            }

            if (upPressed == true)
            {
                spaceShip2.Y -= 3;
                spaceShip2Body.Y -= 3;
                topTrianglep4.Y -= 3;
                topTrianglep5.Y -= 3;
                topTrianglep6.Y -= 3;
                lowTrianglep4.Y -= 3;
                lowTrianglep5.Y -= 3;
                lowTrianglep6.Y -= 3;
                thrustTwo.Y -= 3;
            }

            if (downPressed == true)
            {
                spaceShip2.Y += 3;
                spaceShip2Body.Y += 3;
                topTrianglep4.Y += 3;
                topTrianglep5.Y += 3;
                topTrianglep6.Y += 3;
                lowTrianglep4.Y += 3;
                lowTrianglep5.Y += 3;
                lowTrianglep6.Y += 3;
                thrustTwo.Y += 3;
            }

            int randValue = randGen.Next(1, 101);

            if (randValue < 4)
            {
                int y = randGen.Next(0, this.Width - 50);
                Rectangle obstacle = new Rectangle(0, y, obstacleWidth, obstacleHeight);
                obstacles.Add(obstacle);
                obstacleSpeeds.Add(randGen.Next(1, 6));
            }
            else if (randValue < 11)
            {
                int y = randGen.Next(0, this.Width - 50);
                Rectangle obstacle = new Rectangle(0, y, obstacleWidth, obstacleHeight);
                obstacles.Add(obstacle);
                obstacleSpeeds.Add(randGen.Next(1, 6));
            }
            else if (randValue < 17)
            {
                int y = randGen.Next(0, this.Width - 50);
                Rectangle obstacle = new Rectangle(0, y, obstacleWidth, obstacleHeight);
                obstacles.Add(obstacle);
                obstacleSpeeds.Add(randGen.Next(1, 6));
            }

            for (int i = 0; i < obstacles.Count; i++)
            {
                int x = obstacles[i].X + obstacleSpeeds[i];
                obstacles[i] = new Rectangle(x, obstacles[i].Y, obstacleWidth, obstacleHeight);
            }

            for (int i = 0; i < obstacles.Count; i++)
            {
                if (spaceShip1.IntersectsWith(obstacles[i]))
                {
                    spaceShip1 = new Rectangle(270, 555, 20, 33);
                    spaceShip1Body = new Rectangle(275, 565, 10, 15);
                    topTrianglep1 = new PointF(280, 555);
                    topTrianglep2 = new PointF(290, 565);
                    topTrianglep3 = new PointF(270, 565);
                    lowTrianglep1 = new PointF(280, 570);
                    lowTrianglep2 = new PointF(292, 585);
                    lowTrianglep3 = new PointF(268, 585);
                    thrustOne = new Rectangle(273, 585, 15, 3);

                    obstacles.RemoveAt(i);
                    obstacleSpeeds.RemoveAt(i);
                }
            }

            Refresh();
        }


        private void timeBarTimer_Tick(object sender, EventArgs e)
        {
            time-=1;
            timeBarHeight -= 5;
            outputLabel.Text = "Time: " + time;
            Refresh();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            spaceShipBrush.Color = Color.White;
            timeBar = new Rectangle(475, 0, 10, timeBarHeight);
            //body
            e.Graphics.FillRectangle(spaceShipBrush, spaceShip1Body);
            e.Graphics.FillRectangle(spaceShipBrush, spaceShip2Body);
            //top
            e.Graphics.FillPolygon(spaceShipBrush, new PointF[] { topTrianglep1, topTrianglep2, topTrianglep3});
            //bottom
            e.Graphics.FillPolygon(spaceShipBrush, new PointF[] { lowTrianglep1, lowTrianglep2, lowTrianglep3 });
            //top
            e.Graphics.FillPolygon(spaceShipBrush, new PointF[] { topTrianglep4, topTrianglep5, topTrianglep6 });
            //bottom
            e.Graphics.FillPolygon(spaceShipBrush, new PointF[] { lowTrianglep4, lowTrianglep5, lowTrianglep6 });
            //thrust1
            e.Graphics.FillRectangle(spaceShipBrush, thrustOne);
            e.Graphics.FillRectangle(spaceShipBrush, thrustTwo);
            //outer time bar
            e.Graphics.DrawRectangle(Pen, timeBarOuter);
            //time bar
            e.Graphics.FillRectangle(spaceShipBrush, timeBar);
            //obstacles (asteroidds)
            for (int i = 0; i < obstacles.Count; i++)
            {
                e.Graphics.FillEllipse(spaceShipBrush, obstacles[i]);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceRacer
{
    public partial class Form1 : Form
    {
        // Global Variables
        int time = 120;
        int timeBarHeight = 600;

        Rectangle spaceShip1 = new Rectangle(275, 10, 60, 60);
        Rectangle spaceShip1Body = new Rectangle(275, 565, 10, 15);
        Rectangle spaceShip2Body = new Rectangle(275 + 400, 565, 10, 15);
        Rectangle thrustOne = new Rectangle(273, 585, 15, 3);
        Rectangle timeBar;
        //Rectangle thrustTwo = new Rectangle(255, 550, 7, 3);
        Rectangle timeBarOuter = new Rectangle(475, 0, 10, 600);
        Rectangle difference;

        //Brushes
        SolidBrush spaceShipBrush = new SolidBrush(Color.White);
        Pen Pen = new Pen(Color.White);

        private void gameTimer_Tick(object sender, EventArgs e)
        {
        }
        
        private void timeBarTimer_Tick(object sender, EventArgs e)
        {
            //timeBarTimer.Enabled = true;
            time-=1;
            timeBarHeight -= 5;
            outputLabel.Text = "Time: " + time;
            Refresh();
        }

        public Form1()
        {
            InitializeComponent();
            difference = new Rectangle(timeBarOuter.X + spaceShip1Body.Width, spaceShip1Body.Y, timeBarOuter.X - spaceShip1Body.X - timeBarOuter.Width, 30);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            spaceShipBrush.Color = Color.White;
            timeBar = new Rectangle(475, 0, 10, timeBarHeight);
            //body
            e.Graphics.FillRectangle(spaceShipBrush, spaceShip1Body);
            e.Graphics.FillRectangle(spaceShipBrush, spaceShip2Body);
            //top
            e.Graphics.FillPolygon(spaceShipBrush, new PointF[] { new PointF(280, 555), new PointF(290, 565), new PointF(270, 565) });
            //bottom
            e.Graphics.FillPolygon(spaceShipBrush, new PointF[] { new PointF(280, 570), new PointF(292, 585), new PointF(268, 585) });
            //thrust1
            e.Graphics.FillRectangle(spaceShipBrush, thrustOne);
            //outer time bar
            e.Graphics.DrawRectangle(Pen, timeBarOuter);
            //time bar
            e.Graphics.FillRectangle(spaceShipBrush, timeBar);
            //difference
            spaceShipBrush.Color = Color.HotPink;
            e.Graphics.FillRectangle(spaceShipBrush, difference);
        }

    }
}
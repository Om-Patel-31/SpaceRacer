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
        double time = 540;

        //Rectangle spaceShip1 = new Rectangle(10, 10, 60, 60);
        Rectangle spaceShipBody = new Rectangle(250 + 25, 530, 10, 15);
        Rectangle thrustOne = new Rectangle(248 + 25, 550, 15, 3);
        Rectangle timeBar;
        //Rectangle thrustTwo = new Rectangle(255, 550, 7, 3);

        //Brushes
        SolidBrush spaceShipBrush = new SolidBrush(Color.White);

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            time -= 4.5;
        }

        public Form1()
        {
            InitializeComponent();
            timeBar = new Rectangle(475, 40, 10, Convert.ToInt32(time));
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //body
            e.Graphics.FillRectangle(spaceShipBrush, spaceShipBody);
            //top
            e.Graphics.FillPolygon(spaceShipBrush, new PointF[] { new PointF(255 + 25, 520), new PointF(265 + 25, 530), new PointF(245 + 25, 530) });
            //bottom
            e.Graphics.FillPolygon(spaceShipBrush, new PointF[] { new PointF(255 + 25, 535), new PointF(267 + 25, 550), new PointF(243 + 25, 550) });
            //thrust1
            e.Graphics.FillRectangle(spaceShipBrush, thrustOne);
            //time
            spaceShipBrush.Color = Color.Green;
            e.Graphics.FillRectangle(spaceShipBrush, timeBar);
        }
    }
}
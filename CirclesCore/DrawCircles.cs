using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CirclesCore;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;


namespace CirclesCore
{
    class DrawCircles
    {
        Random rnd = new Random();
        public int maxSize, minSize, hideTime, showTime, cliW, cliH, dia, canY, canHi, x, y;
        bool circlesDrawn = false;
        public Brush brush;
        public Graphics g;
        SolidBrush wipe = new SolidBrush(Color.Black);
        List<CircleArgs> circleArgs = new List<CircleArgs>();


        public void drawCircles() /*This gets looped to draw all different circles*/
        {
            SolidBrush wipe = new SolidBrush(Color.Black);

            g.FillRectangle(wipe, 0, 0, cliW, cliH); // Cleans canvas

            if (circlesDrawn) // To keep first runthrough not waiting with timeHidden
            {
                sleep(hideTime);
            } else
            {
                circlesDrawn = true;
            }
            

            dia = rnd.Next(minSize, maxSize);            
            x = rnd.Next((0), (cliW - dia));
            y = rnd.Next((canY), ((canY + canHi) - dia));
            g.FillEllipse(brush, x, y, dia, dia); // Draws the circle

            sleep(showTime);            

            CircleArgs drawArgs = new CircleArgs // Object that stores values 
            {
                x = this.x,
                y = this.y,
                diameter = this.dia,
            };
            circleArgs.Add(drawArgs); // Stores objects       
        }

        public void reDraw() // The afterimage
        {
            g.FillRectangle(wipe, 0, 0, cliW, cliH);
            for (int i = 0; i < circleArgs.Count; i++)
            {
                this.x = circleArgs[i].x;
                this.y = circleArgs[i].y;
                this.dia = circleArgs[i].diameter;

                g.FillEllipse(brush, x, y, dia, dia);
            }
            circleArgs.Clear();
        }
        static void sleep(int millisecondsTimeout)
        {
            System.Threading.Thread.Sleep(millisecondsTimeout);
        }
    }
}

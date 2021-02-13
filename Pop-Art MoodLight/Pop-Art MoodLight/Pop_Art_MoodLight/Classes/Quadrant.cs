using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pop_Art_MoodLight
{
    class Quadrant
    {
        // Declare Variables
        private int x;
        private int y;
        private Rectangle frame;
        private Random rnd;
        private byte r;
        private byte g;
        private byte b;
        private bool redIncreasing = true;
        private bool greenIncreasing = true;
        private bool blueIncreasing = true;
        private Color clr;
        private Vector2 vec;


        // Create Constructor 
        public Quadrant(int anX, int aY, Rectangle aFrame, Vector2 aVec, Random aRnd)
        {
            rnd = aRnd;
            setX(anX);
            setY(aY);
            setFrame(aFrame);
            setVec(aVec);
            r = Convert.ToByte(rnd.Next(256));
            g = Convert.ToByte(rnd.Next(256));
            b = Convert.ToByte(rnd.Next(256));
            updateColor();
        }

        // Setters and Getters
        public void setX(int anX)
        {
            x = anX;
        }

        public void setY(int aY)
        {
            y = aY;
        }

        public void setFrame(Rectangle aFrame)
        {
            frame = aFrame;
        }

        public void setVec(Vector2 aVec)
        {
            vec = aVec;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public Vector2 getVec()
        {
            return vec;
        }

        public Rectangle getFrame()
        {
            return frame;
        }

        public Color getClr()
        {
            return clr;
        }
        
        // update colour method
        public void updateColor()
        {
            if(r == 255)
            {
                redIncreasing = false;
            }
            else if(r == 0)
            {
                redIncreasing = true;
            }

            if (g == 255)
            {
                greenIncreasing = false;
            }
            else if (g == 0)
            {
                greenIncreasing = true;
            }

            if (b == 255)
            {
                blueIncreasing = false;
            }
            else if (b == 0)
            {
                blueIncreasing = true;
            }

            if (redIncreasing)
            {
                r++;
            }
            else
            {
                r--;
            }

            if (greenIncreasing)
            {
                g++;
            }
            else
            {
                g--;
            }

            if (blueIncreasing)
            {
                b++;
            }
            else
            {
                b--;
            }

            clr = new Color(r, g, b);
        }
    }
}

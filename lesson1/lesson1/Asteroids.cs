using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lesson1
{
    class Asteroids:BaseObject
    {
        Image asteroid1 = Properties.Resources.aster1;
        Image asteroid2 = Properties.Resources.aster2;
        public Asteroids(Point pos, Point dir, Size size, int speed):base(pos, dir, size, speed)
        {
        }

        public override void Draw()
        {
            if(rnd.Next(0,2)!=0)
                Game.Buffer.Graphics.DrawImage(asteroid1, Pos.X, Pos.Y, Size.Width, Size.Height);
            else
                Game.Buffer.Graphics.DrawImage(asteroid2, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}

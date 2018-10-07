using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lesson1
{
    class Asteroid:BaseObject
    {
        static Image asteroid1;
        //Image asteroid2 = Properties.Resources.aster2;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Asteroid(Point pos, Point dir, Size size):base(pos, dir, size)
        {
            asteroid1 = Properties.Resources.aster1;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(asteroid1, Pos.X, Pos.Y, Size.Width, Size.Height);
            // Game.Buffer.Graphics.DrawImage(asteroid2, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width)
                //Dir.X = -Dir.X;
                Pos.X = Game.Width;
            if (Pos.X > Game.Width + Size.Width)
                //Dir.X = -Dir.X;
                Pos.X = -Size.Width;

            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.Y < 0 - Size.Height)
                //Dir.Y = -Dir.Y;
                Pos.Y = Game.Height;
            if (Pos.Y > Game.Height + Size.Height)
                //Dir.Y = -Dir.Y;
                Pos.Y = -Size.Height;
        }
    }
}

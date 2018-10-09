using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject, ICloneable
    {
        Image asteroid;
        public int Power;
        //Image asteroid2 = Properties.Resources.aster2;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Asteroid(Point pos, Point dir, Size size):base(pos, dir, size)
        {
            Power = 1;
            switch (rnd.Next(1, 3))
            {
                case 1:
                    asteroid = Properties.Resources.aster1;
                    break;
                default:
                    asteroid = Properties.Resources.aster2;
                    break;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(asteroid, Pos.X, Pos.Y, Size.Width, Size.Height);
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            // создаем копию астероида
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            //Не забываем скопировать новому астероиду Power нашего астероида
            return asteroid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Planet : BaseObject
    {
        Image planetPic;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            switch (rnd.Next(1, 5))
            {                
                case 1:
                    planetPic = Properties.Resources.planet2;
                    break;
                case 2:
                    planetPic = Properties.Resources.planet3;
                    break;
                case 3:
                    planetPic = Properties.Resources.planet4;
                    break;
                default:
                    planetPic = Properties.Resources.planet1;
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(planetPic, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0 - Size.Width)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = rnd.Next(Game.Height - Size.Height/2);
                Dir.X = rnd.Next(1,5);
            }
        }
    }
}

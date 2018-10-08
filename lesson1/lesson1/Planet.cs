using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lesson1
{
    class Planet : BaseObject
    {
        Image planet;
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
                    planet = Properties.Resources.planet2;
                    break;
                case 2:
                    planet = Properties.Resources.planet3;
                    break;
                case 3:
                    planet = Properties.Resources.planet4;
                    break;
                default:
                    planet = Properties.Resources.planet1;
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(planet, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// 
        /// </summary>
        public new void Update()
        {
        }
    }
}

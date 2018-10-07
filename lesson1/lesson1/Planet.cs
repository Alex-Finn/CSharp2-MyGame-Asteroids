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
        static Image planet1;
        //Image planet2 = Properties.Resources.planet2;
        //Image planet3 = Properties.Resources.planet3;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Planet(Point pos, Point dir, Size size) : base(pos,dir,size)
        {
            planet1 = Properties.Resources.planet1;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(planet1, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0 - Size.Width)
                Pos.X = Game.Width + Size.Width;
        }
    }
}

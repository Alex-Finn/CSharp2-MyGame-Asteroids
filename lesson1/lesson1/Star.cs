using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Star : BaseObject
    {
        Image star;
       /// <summary>
       /// 
       /// </summary>
       /// <param name="pos"></param>
       /// <param name="dir"></param>
       /// <param name="size"></param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            switch (rnd.Next(1, 4))
            {
                case 1:
                    star = Properties.Resources.star1;
                    break;
                case 2:
                    star = Properties.Resources.star2;
                    break;
                default:
                    star = Properties.Resources.star3;
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            // Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            // Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);           
            Game.Buffer.Graphics.DrawImage(star, Pos.X, Pos.Y, Size.Width, Size.Height);
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
                Pos.Y = rnd.Next(Game.Height - Size.Height);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1
{
    class Star : BaseObject
    {
       // static Image star1;
       /// <summary>
       /// 
       /// </summary>
       /// <param name="pos"></param>
       /// <param name="dir"></param>
       /// <param name="size"></param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            //star1 = Properties.Resources.star1;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
             Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
             Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);           
            //Game.Buffer.Graphics.DrawImage(star1, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
                Pos.X = Game.Width + Size.Width;           
        }
    }
}

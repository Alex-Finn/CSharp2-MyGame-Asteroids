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
        Image star1 = Properties.Resources.star1;
        public Star(Point pos, Point dir, Size size, int speed) : base(pos, dir, size, speed)
        {
        }
        public override void Draw()
        {
            if (rnd.Next(0, 2) != 0)
            {
                Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
                Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            }
            else
                Game.Buffer.Graphics.DrawImage(star1, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Healer : Asteroid
    {
        public Healer(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = rnd.Next(1, 10);  
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.WhiteSmoke, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.FillEllipse(Brushes.WhiteSmoke, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X/4, Pos.Y, Size.Width /2, Size.Height);
            Game.Buffer.Graphics.FillRectangle(Brushes.OrangeRed, Pos.X + Size.Width / 5*2, Pos.Y, Size.Width/5, Size.Height);
            //Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y + Pos.Y / 4, Size.Width, Size.Height /2);
            Game.Buffer.Graphics.FillRectangle(Brushes.OrangeRed, Pos.X, Pos.Y + Size.Height /5*2, Size.Width, Size.Height/5);
            //Game.Buffer.Graphics.FillRectangle(Brushes.Tomato,,,100,100)
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;  
            Pos.Y = Pos.Y + Dir.Y;
        }
    }
}

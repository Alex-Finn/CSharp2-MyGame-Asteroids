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
        Image planet1 = Properties.Resources.planet1;
        Image planet2 = Properties.Resources.planet2;
        Image planet3 = Properties.Resources.planet3;
        public Planet(Point pos, Point dir, Size size, int speed) : base(pos,dir,size, speed)
        {
        }

        public override void Draw()
        {
            switch (rnd.Next(0, 3))
            {
                case 0:
                    Game.Buffer.Graphics.DrawImage(planet1, Pos.X, Pos.Y, Size.Width, Size.Height);
                    break;
                case 1:
                    Game.Buffer.Graphics.DrawImage(planet2, Pos.X, Pos.Y, Size.Width, Size.Height);
                    break;
                default:
                    Game.Buffer.Graphics.DrawImage(planet3, Pos.X, Pos.Y, Size.Width, Size.Height);
                    break;
            }
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

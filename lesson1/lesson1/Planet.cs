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
        Image planet1 = Image.FromFile("../../resources/planet1.png");
        Image planet2 = Image.FromFile("../../resources/planet2.png");
        Image planet3 = Image.FromFile("../../resources/planet3.png");
        public Planet(Point pos, Point dir, Size size) : base(pos,dir,size)
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

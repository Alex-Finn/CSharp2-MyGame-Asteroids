using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1
{
    class Player : BaseObject
    {
        static Image player;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Player(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            player = Properties.Resources.redtesla;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(player, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y < (Game.Height / 2) - Size.Height)
                Dir.Y = -Dir.Y;
            if (Pos.Y > (Game.Height / 2) + Size.Height)
                Dir.Y = -Dir.Y;

            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 10)
                Dir.X = -Dir.X;
            if (Pos.X > Size.Width/2)
                Dir.X = -Dir.X;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    class Player : BaseObject
    {
        public int Energy { get; set; }

        static Image playerPic;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Player(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            playerPic = Properties.Resources.redtesla;
            Energy = 100;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(playerPic, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y > Game.Height - Size.Height)
                Pos.Y = Game.Height - Size.Height;
            if (Pos.Y < 0)
                Pos.Y = 0;

            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
                Pos.X = 0;
            if (Pos.X > Game.Width - Size.Width)
                Pos.X = Game.Width - Size.Width;
        }

        internal void Up()
        {
            Pos.Y = Pos.Y - 10;
            Console.WriteLine("button Up");
        }

        internal void Down()
        {
            Pos.Y = Pos.Y + 10;
            Console.WriteLine("button Down");
        }

        internal void Left()
        {
            Pos.X = Pos.X - 10;
            Console.WriteLine("button Left");
        }

        internal void Right()
        {
            Pos.X = Pos.X + 10;
            Console.WriteLine("button Right");
        }

        public void PlayerDead()
        {
            Console.WriteLine("energy less than 1. game over");                     
        }
    }
}

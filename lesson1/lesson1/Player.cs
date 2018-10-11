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
        private int _energy = 100;
        public int Energy
        {
            get { return _energy; }
            set { _energy = value; }
        }

        private int _frags = 0;
        public int Frags
        {
            get { return _frags; }
            set { _frags = value; }
        }

        public void MinusEnergy(int value)
        {
            _energy -= value;
        }

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
            //Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y > Game.Height - Size.Height)
                Pos.Y = Game.Height - Size.Height;
            if (Pos.Y < 0)
                Pos.Y = 0;

            //Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
                Pos.X = 0;
            if (Pos.X > Game.Width - Size.Width)
                Pos.X = Game.Width - Size.Width;
        }

        internal void Up()
        {
            if (Pos.Y > 0)
            {
                Pos.Y = Pos.Y - Dir.Y;
                Console.WriteLine("button Up");
            }
        }

        internal void Down()
        {
            if (Pos.Y < Game.Height)
            {
                Pos.Y = Pos.Y + Dir.Y;
                Console.WriteLine("button Down");
            }
        }

        internal void Left()
        {
            if (Pos.X > 0)
            {
                Pos.X = Pos.X - Dir.Y;
                Console.WriteLine("button Left");
            }
        }

        internal void Right()
        {
            if (Pos.X < Game.Width)
            {
                Pos.X = Pos.X + Dir.Y;
                Console.WriteLine("button Right");
            }
        }

        public static event Message MessageDie;

        public void PlayerDead()
        {
            MessageDie?.Invoke();
            Console.WriteLine("energy less than 1. game over");                     
        }
    }
}

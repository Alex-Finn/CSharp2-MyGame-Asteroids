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

        private static int MoveX, MoveY;

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
            Pos.Y = Pos.Y + MoveY;
            if (Pos.Y > Game.Height - Size.Height)
                Pos.Y = Game.Height - Size.Height;
            if (Pos.Y < 0)
                Pos.Y = 0;

            Pos.X = Pos.X + MoveX;
            if (Pos.X < 0)
                Pos.X = 0;
            if (Pos.X > Game.Width - Size.Width)
                Pos.X = Game.Width - Size.Width;
        }

        public static void UpdateOnKeyDown(object sender, KeyEventArgs e)
        {
            int speed = 10;

            switch (e.KeyData)
            {
                case Keys.Up:
                    MoveY = -speed;
                    break;
                case Keys.Down:
                    MoveY = speed;
                    break;
                case Keys.Left:
                    MoveX = -speed;
                    break;
                case Keys.Right:
                    MoveX = speed;
                    break;
                case Keys.Space:
                    Game._bullets.Add(new Bullet(
                        new Point(Game._player.Rect.X + 10, Game._player.Rect.Y + 10),
                        new Point(50, 0),
                        new Size(20, 5)));
                    //Console.WriteLine("button Space");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method for KeyUp event
        /// </summary>
        /// <param name="e">KeyEventArgs</param>
        public static void UpdateOnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    MoveY = 0;
                    break;
                case Keys.Down:
                    MoveY = 0;
                    break;
                case Keys.Left:
                    MoveX = 0;
                    break;
                case Keys.Right:
                    MoveX = 0;
                    break;
                default:
                    break;
            }
        }
        /*
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
        }*/

        public static event Message MessageDie;

        public void PlayerDead()
        {
            MessageDie?.Invoke();
            Console.WriteLine("energy less than 1. game over");                     
        }
    }
}

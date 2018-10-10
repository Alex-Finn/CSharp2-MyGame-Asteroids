using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] _objs;
        private static List<Bullet> _bullets;
        private static Asteroid[] _asteroids;
        private static Player _player;

        public static Random rnd = new Random(0); // подсмотрел
        public static Image spacePic = Properties.Resources.space;

        public static Label energyLabel = new Label();
        
        
        static Game()
        {
             // подсмотрел
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            Timer timer = new Timer { Interval = 20 };

            timer.Start();
            timer.Tick += Timer_Tick;
            // графическое устройство для вывода графики
            Graphics g;
            // предоставляет доступ к главному буферу 
            // графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом,
            // чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            form.KeyDown += Form_KeyDown;
            //_player.Action += Player_Action;
            energyLabel.Height = 100;
            energyLabel.Width = 100;
            energyLabel.Text = "100";
            energyLabel.Left = Game.Width - 100;
            energyLabel.Top = 100;
            energyLabel.BackColor = Color.White;
            energyLabel.ForeColor = Color.Black;
            energyLabel.AutoSize = true;
            form.Controls.Add(energyLabel);
            Load(); // сам написал
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _bullets.Add(new Bullet(new Point(_player.Rect.X + 10, _player.Rect.Y + 10), new Point(50, 0), new Size(40, 10)));
                Console.WriteLine("button Space");
            }
            if (e.KeyCode == Keys.Up) _player.Up();
            if (e.KeyCode == Keys.Down) _player.Down();
            if (e.KeyCode == Keys.Left) _player.Left();
            if (e.KeyCode == Keys.Right) _player.Right();

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            //Buffer.Graphics.Clear(Color.Black); // не нужна когда есть фон
            Buffer.Graphics.DrawImage(spacePic, 0, 0, Width, Height);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            foreach (Asteroid ast in _asteroids)
            {                
                ast?.Draw();
            }
            foreach (Bullet bullet in _bullets)
            {
                bullet?.Draw();
            }
            
            _player.Draw();

            Buffer.Render();
        }   
        /// <summary>
        /// 
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[30];            
            _asteroids = new Asteroid[30];
            _bullets = new List<Bullet>(0);

            int objSize, objSpeed, objSpeed2;
            for (int i = 0; i < 26; i++)
            {
                objSize = rnd.Next(5, 10);
                objSpeed = rnd.Next(3, 15);
                _objs[i] = new Star(new Point(Game.Width + rnd.Next(Game.Width), rnd.Next(Game.Height)), new Point(objSpeed, objSpeed), new Size(objSize, objSize));
}            
            for (int i = 26; i < 30; i++)
            {
                objSize = rnd.Next(300, 600);
                objSpeed = rnd.Next(1, 3);
                _objs[i] = new Planet(new Point(Game.Width + rnd.Next(Game.Width), rnd.Next(Game.Height)), new Point(objSpeed, objSpeed), new Size(objSize, objSize));
            }
            for (int i = 0; i < _asteroids.Length; i++)
            {
                objSize = rnd.Next(30, 40);
                objSpeed = rnd.Next(-5, -3);
                objSpeed2 = rnd.Next(-1, 2);
                //if (objSpeed == 0) objSpeed = 2;
                //if (objSpeed2 == 0) objSpeed2 = 2;
                //_objs[i] = new Asteroid(new Point(rnd.Next(Game.Width), rnd.Next(Game.Height)), new Point(objSpeed, objSpeed2), new Size(objSize, objSize));
                _asteroids[i] = new Asteroid(new Point(rnd.Next(Game.Width + rnd.Next(Game.Width)), rnd.Next(Game.Height)), new Point(objSpeed, objSpeed2), new Size(objSize, objSize));
            }

            _player = new Player(new Point(10, Game.Height/2), new Point(0, 0), new Size(100, 60));

            energyLabel.Show();
            /*for (int i = 0; i < _objs.Length / 2; i++)
                _objs[i] = new Asteroid(new Point(600, i * 20), new Point(-i-2, -i-2), new Size(rnd.Next(10), rnd.Next(50)));
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
                _objs[i] = new Star(new Point(600, i * 20), new Point(-i-2, 0), new Size(rnd.Next(10), rnd.Next(50)));*/
            //for (int i = 0; i < _objs.Length / 2; i++)
            //{
            //    _objs[i] = new BaseObject(new Point(600, i*20), new Point(- i, -i), new Size(10, 10));
            //}
            //for (int i = _objs.Length / 2; i < _objs.Length; i++)
            //{
            //    _objs[i] = new Star(new Point(600, i* 2), new Point(i, 0), new Size(10, 10));
            //}

        }
        /// <summary>
        /// 
        /// </summary>
        public static void Update()
        {            
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }
            
            for(int ast = 0; ast < _asteroids.Length; ast++)
            {
                _asteroids[ast]?.Update();
                if (_asteroids[ast] != null && _asteroids[ast].Collision(_player))
                {
                    _player.Energy -= _asteroids[ast].Power;
                    energyLabel.Text = _player.Energy.ToString();
                    energyLabel.Update();
                    Console.WriteLine("asteroid hit player");
                    System.Media.SystemSounds.Beep.Play();
                    _asteroids[ast] = new Asteroid(new Point((Game.Width + rnd.Next(Game.Width)), rnd.Next(Game.Height)), new Point(rnd.Next(-5, -3), rnd.Next(-1, 2)), new Size(rnd.Next(30, 40), rnd.Next(30, 40)));
                    Console.WriteLine("created new asteroid");
                }
                    for (int i = 0; i < _bullets.Count; i++)
                {
                    if (_asteroids[ast] != null && _asteroids[ast].Collision(_bullets[i]))
                    {
                        Console.WriteLine("bullet hit asteroid");
                        System.Media.SystemSounds.Asterisk.Play();
                        _bullets.RemoveAt(i);
                        _asteroids[ast] = new Asteroid(new Point((Game.Width + rnd.Next(Game.Width)), rnd.Next(Game.Height)), new Point(rnd.Next(-5, -3), rnd.Next(-1, 2)), new Size(rnd.Next(30, 40), rnd.Next(30, 40)));
                        Console.WriteLine("created new asteroid");
                        _player.PlayerDead();
                    }
                }                
            }
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].Update();
                if (_bullets[i].Rect.X > Game.Width)
                {
                    _bullets.RemoveAt(i);
                    Console.WriteLine("bullet out of screen -> deleted");
                }

            }
            if (_player.Energy > 0)
            {

                _player.Update();
            }
            else _player.PlayerDead();
        }
    }


}

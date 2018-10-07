using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lesson1
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
        public static Random rnd; // подсмотрел
        public static Image space = Properties.Resources.space;
        static Game()
        {
            rnd = new Random(); // подсмотрел
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
            Load(); // сам написал
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
            Buffer.Graphics.DrawImage(space, 0, 0, Width, Height);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            Buffer.Render();
        }   
        /// <summary>
        /// 
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[61];

            int objSize, objSpeed, objSpeed2;
            for (int i = 0; i < 11; i++)
            {
                objSize = rnd.Next(50,121);
                objSpeed = rnd.Next(1, 10);
                _objs[i] = new Planet(new Point(Game.Width+rnd.Next(Game.Width), rnd.Next(Game.Height)), new Point(objSpeed, objSpeed), new Size(objSize, objSize));
            }
            for (int i = 11; i < 31; i++)
            {
                objSize = rnd.Next(15, 20);
                objSpeed = rnd.Next(-5, 5);
                objSpeed2 = rnd.Next(-5, 5);
                if (objSpeed == 0) objSpeed = 2;
                if (objSpeed2 == 0) objSpeed2 = 2;
                _objs[i] = new Asteroid(new Point(rnd.Next(Game.Width), rnd.Next(Game.Height)), new Point(objSpeed, objSpeed2), new Size(objSize, objSize));
            }
            for (int i = 31; i < 60; i++)
            {
                objSize = rnd.Next(2, 5);
                objSpeed = rnd.Next(3, 30);
                _objs[i] = new Star(new Point(Game.Width + rnd.Next(Game.Width), rnd.Next(Game.Height)), new Point(objSpeed, objSpeed), new Size(objSize, objSize));
            }
            _objs[60] = new Player(new Point(10, Game.Height/2), new Point(0, 5), new Size(100, 60));


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
        }
    }


}

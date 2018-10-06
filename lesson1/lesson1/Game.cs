using System;
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
        public static Image space = System.Drawing.Image.FromFile("../../resources/space.jpg");
        static Game()
        {

        }

        public static void Init(Form form)
        {
            Timer timer = new Timer { Interval = 10 };

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
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(space, 0, 0, Width, Height);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            Buffer.Render();
        }        
        public static void Load()
        {
            _objs = new BaseObject[30];
            //for (int i = 0; i < _objs.Length / 2; i++)
            //{
            //    _objs[i] = new BaseObject(new Point(600, i*20), new Point(- i, -i), new Size(10, 10));
            //}
            //for (int i = _objs.Length / 2; i < _objs.Length; i++)
            //{
            //    _objs[i] = new Star(new Point(600, i* 2), new Point(i, 0), new Size(10, 10));
            //}
            for (int i = 0; i < _objs.Length; i++)
            {                               
                if (i % 10 == 0)
                {
                    _objs[i] = new Planet(new Point(100,100), new Point(i, 10), new Size(100, 100));
                }
                else if (i % 3 == 0)
                {
                    _objs[i] = new Asteroids(new Point(100,100), new Point(i, 10), new Size(30, 30));
                }
                else
                {
                    _objs[i] = new Star(new Point(Width, (Height / (_objs.Length / 2)) * ((i - _objs.Length / 2) + 1)), new Point(i, 0), new Size(20, 20));
                }
            }
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }
        }
    }


}

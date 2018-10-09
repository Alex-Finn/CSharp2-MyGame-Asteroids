using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected static Random rnd = new Random(10);
        //protected Random rnd = new Random();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos">Переменная типа Point, задающая позицию объекта по x и y</param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        /// <summary>
        /// Абстрактный метод Draw. Переопределяется в наследниках
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Абстрактный метод Update для объектов
        /// </summary>
        public abstract void Update();

        // Так как переданный объект тоже должен будет реализовывать интерфейс ICollision
        // мы можем использовать его свойство Rect и метод IntersectsWith для
        // обнаружения пересечения с нашим объектом (а можно наоборот)
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}

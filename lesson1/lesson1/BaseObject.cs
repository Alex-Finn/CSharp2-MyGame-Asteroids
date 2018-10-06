using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lesson1
{
    abstract class  BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected float Speed;
        protected Random rnd = new Random();
        public BaseObject(Point pos, Point dir, Size size, int speed)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            Speed = speed;
        }

        public virtual void Draw()
        {
        }
        public virtual void Update()
        {
        }
    }
}

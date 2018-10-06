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
        protected Random rnd = new Random();
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
        }
        public virtual void Update()
        {
        }
    }
}

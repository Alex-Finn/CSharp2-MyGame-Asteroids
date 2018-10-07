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
        //protected Random rnd = new Random();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void Draw()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void Update()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2
{
    abstract class BaseWorker
    {        
        protected string Name { get; set; }
        protected int ID { get; set; }
        protected double Rate { get; set; }

        public abstract double AverMonthSalary { get; }

        public BaseWorker(string name, int age, double rate)
        {
            Name = name;
            Age = age;
            Rate = rate;
        }
    }
}

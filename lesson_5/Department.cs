using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5
{
    public class Department
    {
        public int Dept_Id { get; set; }
        public string Name { get; set; }

        public Department(int _id)
        {
            Dept_Id = _id;
            Name = "Department";
        }
        /// <summary>
        /// default cotr
        /// </summary>
        public Department()
        {
        }

        public override string ToString()
        {
            return $"{Name} {Dept_Id}";
        }
    }
}

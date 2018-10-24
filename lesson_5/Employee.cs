using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5
{
    public class Employee
    {
        public string Emp_Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Salary { get; set; }
        public string Emp_dept { get; set; }
        /// <summary>
        /// Cotr with parameters
        /// </summary>
        /// <param name="id">inkrement id</param>
        /// <param name="_name">name</param>
        /// <param name="_age">age</param>
        /// <param name="_salary">salary</param>
        public Employee(string id, string _name, string _age, string _salary, string department)
        {
            //MainWindow.count_emp_id++;
            Emp_Id = id;
            Name = _name;
            Age = _age;
            Salary = _salary;
            Emp_dept = department;
        }
        /// <summary>
        /// default cotr
        /// </summary>
        public Employee()
        {
            //MainWindow.count_emp_id++;
        }

        public override string ToString()
        {
            return $"ID: {Emp_Id}\nName: {Name}\nAge: {Age}\nSalary: {Salary:0}\nDepartment: {Emp_dept}";
        }
    }
}

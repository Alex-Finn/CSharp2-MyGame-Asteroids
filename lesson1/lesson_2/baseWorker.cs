using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2
{
    /// <summary>
    /// 
    /// </summary>
    abstract class BaseWorker
    {
        /// <summary>
        /// Имя работника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Идентификатор работника
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Возраст работника
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Зарплатная ставка работника, зависящая от условий по договору
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Метод, вычисляющий среднюю месячную зарплату работника
        /// </summary>
        public abstract double AverMonthSalary { get; }

        /// <summary>
        /// Конструктор базового объекта
        /// </summary>
        /// <param name="name">Имя работника</param>
        /// <param name="age">Возраст работника</param>
        /// <param name="id">Идентификатор работника</param>
        /// <param name="rate">Зарплатная ставка работника</param>
        public BaseWorker(string name, int age, int id, double rate)
        {
            Name = name;
            Age = age;
            ID = id;
            Rate = rate;
        }
    }
}

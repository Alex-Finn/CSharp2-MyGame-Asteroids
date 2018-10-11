using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2
{
    /// <summary>
    /// Класс, описывающий работник с фиксированной месячной зарплатой
    /// </summary>
    class FixPayWorker : BaseWorker
    {
        /// <summary>
        /// Конструктор объекта - работника с фиксированной оплатой труда
        /// </summary>
        /// <param name="name">Имя работника</param>
        /// <param name="age">Возраст работника</param>
        /// <param name="id">Идентификатор работника</param>
        /// <param name="rate">Зарплата работника в месяц</param>
        public FixPayWorker(string name, int age, int id, double rate):base(name,age,id,rate)
        {
        }
        /// <summary>
        /// Метод, вычисляющий среднюю месячную зарплату работника
        /// </summary>
        public override double AverMonthSalary => Rate;
    }
}

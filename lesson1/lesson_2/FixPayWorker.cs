﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2
{
    class FixPayWorker : BaseWorker
    {
        public FixPayWorker(string name, int age, double rate):base(name,age,rate)
        {
        }

        private double moneyRate;
        public override double AverMonthSalary => moneyRate;
    }
}

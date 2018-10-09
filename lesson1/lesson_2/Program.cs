using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(); 
            BaseWorker[] workerArray = new BaseWorker[10];

           
            for (int i = 0; i < workerArray.Length; i++)
            {
                int genID = rnd.Next(100, 500);
                if (genID > 200) 
                    
                    workerArray[i] = new FixPayWorker($"Name{i}", rnd.Next(18,65), genID*i+100, (rnd.NextDouble()+1)*30000);                
                else
                    workerArray[i] = new HourPayWorker($"Name{i}", rnd.Next(18, 65), genID*i+10, (rnd.NextDouble()+1)*100);
            }
                        
            foreach (BaseWorker wrkr in workerArray)
            {
                Console.WriteLine(
                    $"Name - {wrkr.Name,6} || Age - {wrkr.Age,3} || ID - {wrkr.ID,5}\n" +
                    $"MoneyRate - {wrkr.Rate} || Salary in month - {wrkr.AverMonthSalary:f0} ({wrkr.GetType().Name})\n" +
                    $"==============================================================\n");
            }

            Console.ReadKey();
        }
    }
}

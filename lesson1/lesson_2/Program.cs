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
                if (genID > 250)                
                    workerArray[i] = new FixPayWorker($"Name{i}", rnd.Next(18,65), genID);                
                else
                    workerArray[i] = new HourPayWorker($"Name{i}", rnd.Next(18, 65), genID);
            }

            foreach (BaseWorker wrkr in workerArray)
            {
                Console.WriteLine($"Name {wrkr.}");
            }

            Console.ReadKey();
        }
    }
}

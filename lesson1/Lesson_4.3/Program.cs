using System;
using System.Collections.Generic;
using System.Linq;
/*
    Дан фрагмент программы:

    ====================================================================
    Dictionary < string , int > dict = new Dictionary < string , int >()
    {
        { "four" , 4 },
        { "two" , 2 },
        { "one" , 1 },
        { "three" , 3 },
    };
    var d = dict . OrderBy ( delegate ( KeyValuePair < string , int > pair ) { return pair . Value ; });
    foreach ( var pair in d)
    {
        Console . WriteLine ( "{0} - {1}" , pair . Key , pair . Value );
    }
    ====================================================================

    а. Свернуть обращение к OrderBy с использованием лямбда-выражения $.
    b. * Развернуть обращение к OrderBy с использованием делегата Predicate<T> .
*/
namespace homework_4_3
{
    #region homework 4.3 a
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                { "four" , 4 },
                { "two" , 2 },
                { "one" , 1 },
                { "three" , 3 },
            };
            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
    #endregion

    #region homework 4.3 b  не сообразил

    // совсем не соображаю в этих делегатах



    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Dictionary<string, int> dict = new Dictionary<string, int>()
    //        {
    //            { "four" , 4 },
    //            { "two" , 2 },
    //            { "one" , 1 },
    //            { "three" , 3 },
    //        };
    //        var d = UsingPredicate(dict);
    //        foreach (var pair in d)                
    //        {
    //            Console.WriteLine($"{pair.Key} - {pair.Value}");
    //        }
    //    }
    //    //static T UsingPredicate(T dict)

    //    private static Dictionary<string, int> UsingPredicate(Dictionary<string, int> dict)
    //    {
    //        Dictionary<string, int> sorteddict = new Dictionary<string, int>();
    //        Predicate<int> sort = nextdict => dict.Values > { return ; }

    //        return sorteddict;
    //    }        
    //}
    #endregion
}

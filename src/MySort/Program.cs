using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new[] {1, 6, 23, 8, 3, 0, 45, 9, 234,-1, 7, 56, 91, 123};
            //arr.Bubble();            
            //arr.Selection();
            //arr.Insertion();
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadKey();

            //ExternalSorting.test();


            Console.WriteLine("Enter one or more lines of text (press CTRL+Z to exit):");
            var probability = new Probability();
            string line;
            do
            {
                probability.Test();
                line = Console.ReadLine();
            }while (line != null);
        }
    }
}

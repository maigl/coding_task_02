using System;
using System.Collections.Generic;

namespace coding_task_02
{
    /// <summary>
    /// 
    /// </summary>
    public class Intervall
    {
        public Int16 a;
        public Int16 b;
        
        public Intervall(Int16 a, Int16 b)
        {
            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Check if the passing interval overlaps the interval
        /// </summary>
        /// <param name="intervall"></param>
        /// <returns></returns>
        public bool InRange(Intervall intervall)
        {
            if (this.a <= intervall.b && this.b >= intervall.a) return true;
            return false;
        }
        /// <summary>
        /// Merge passing Intervall
        /// </summary>
        /// <param name="intervall"></param>
        /// <returns></returns>
        public Intervall Merge(Intervall intervall)
        {
            if (this.a < intervall.a) intervall.a = this.a;
            if (this.b > intervall.b) intervall.b = this.b;

            return intervall;
        }
        public override string ToString()
        {
            return "[" + a.ToString() + "," + b.ToString() + "]";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Intervall> intervalls = new List<Intervall>();
            intervalls.AddRange(new Intervall[] {
                new Intervall(25,30),
                new Intervall(2,19),
                new Intervall(14,23),
                new Intervall(4,8),
            });

            Console.WriteLine("Input: ");
            foreach (Intervall intervall in intervalls)
            {
                Console.Write(intervall.ToString());
            }
            Console.WriteLine("\n\n");
            Merge(intervalls);

            Console.WriteLine("Output: ");
            foreach (Intervall intervall in intervalls)
            {
                Console.Write(intervall.ToString());
            }
            Console.WriteLine("\n\n");
        }

        static public List<Intervall> Merge(List<Intervall> intervalls)
        {
            // Sort intervall (b) ascending
            intervalls.Sort((ivx, ivy) => ivx.b.CompareTo(ivy.b));

            for (int x = intervalls.Count-1; x > 0; x--)
            {
                if (intervalls[x].InRange(intervalls[x - 1]))
                {
                    intervalls[x - 1] = intervalls[x].Merge(intervalls[x - 1]);
                    intervalls.RemoveAt(x);
                }
            }
            return intervalls;
        }
    }
}

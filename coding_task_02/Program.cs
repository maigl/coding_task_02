using System;
using System.Collections.Generic;

namespace coding_task_02
{
    /// <summary>
    /// An interval represents a positiv number space between two numbers. [2,4] ~ 2,3,4
    /// </summary>
    public class Intervall
    {
        private UInt16 a;
        private UInt16 b;

        public UInt16 A
        {
            get { return a; }
            set { a = value; }
        }
        public UInt16 B
        {
            get { return b; }
            set
            {
                if (value > this.A)
                {
                    b = value;
                }
                else throw new ArgumentOutOfRangeException("B", "The end of the interval must be greater than the beginning");
            }
        }

        public Intervall(UInt16 a, UInt16 b)
        {
            this.A = a;
            this.B = b;
        }

        /// <summary>
        /// Check if the passing interval overlaps the interval
        /// </summary>
        /// <param name="intervall"></param>
        /// <returns></returns>
        public bool InRange(Intervall intervall)
        {
            if (this.A <= intervall.B && this.B >= intervall.A) return true;
            return false;
        }
        /// <summary>
        /// Merge passing intervall
        /// </summary>
        /// <param name="intervall"></param>
        /// <returns></returns>
        public Intervall Merge(Intervall intervall)
        {
            if (this.A < intervall.A) intervall.A = this.A;
            if (this.B > intervall.B) intervall.B = this.B;

            return intervall;
        }
        public override string ToString()
        {
            return "[" + A.ToString() + "," + B.ToString() + "]";
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
                new Intervall(4,8)
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
            // Sort interval (b) ascending
            intervalls.Sort((ivx, ivy) => ivx.B.CompareTo(ivy.B));

            for (int x = intervalls.Count - 1; x > 0; x--)
            {
                if (intervalls[x].InRange(intervalls[x - 1]))
                {
                    // Replace the interval with the merged overlapping interval 
                    intervalls[x - 1] = intervalls[x].Merge(intervalls[x - 1]);
                    // Remove the merged interval
                    intervalls.RemoveAt(x);
                }
            }
            return intervalls;
        }
    }
}

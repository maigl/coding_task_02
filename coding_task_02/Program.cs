using System;
using System.Collections.Generic;

namespace coding_task_02
{
    public class Intervall
    {
        Int16 a;
        Int16 b;
        
        public Intervall(Int16 a, Int16 b)
        {
            this.a = a;
            this.b = b;
        }
    }
    internal class Program
    {
        void Main(string[] args)
        {
            List<Intervall> intervalls = new List<Intervall>();
            intervalls.AddRange(new Intervall[] {
                new Intervall(25,30),
                new Intervall(2,19),
                new Intervall(14,23),
                new Intervall(4,8)
            });

            this.Merge(intervalls);
        }

        public List<Intervall> Merge(List<Intervall> intervalls)
        {

            return null;
        }
    }
}

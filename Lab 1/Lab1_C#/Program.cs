using System;
using System.Threading;

namespace Lab1_cSharp
{
    class Program
    {
        static void Main(string[] args)
        { 
            (new Program()).Start(); 
        }

        void Start()
        {
            Console.WriteLine("Enter number of threads:");
            int numThread = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter step:");
            int step = Convert.ToInt32(Console.ReadLine());

            BreakThread breakThread = new BreakThread();

            for(int i = 1; i <= numThread; i++)
            {
                new Thread(new MainThread(i, step, breakThread).CalcSum).Start();
            }
     
            new Thread(breakThread.StopThread).Start();
        }
        class MainThread
        {
            private int id;
            private int step;
            private BreakThread breakThread;
            public MainThread(int id, int step, BreakThread breakThread)
            {
                this.id = id;
                this.step = step;
                this.breakThread = breakThread;
            }
            public void CalcSum()
            {
                long sum = 0;
                long count = 0;
                do
                {
                    sum += step;
                    count++;

                } while (!breakThread.CanStop);
                Console.WriteLine("id - {0}, " +
                "the number of sequence elements used - {1}, " +
                "sum - {2}\n",
                id, count, sum);
            }
        }
        class BreakThread
        {
            private bool canStop = false;

            public bool CanStop { get => canStop; }

            public void StopThread()
            {
                Thread.Sleep(1 * 1000);
                canStop = true;
            }
        }
    }
}
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
            BreakThread breakThread = new BreakThread();

            new Thread(new MainThread(1, 2, breakThread).CalcSum).Start();
            new Thread(new MainThread(2, 3, breakThread).CalcSum).Start();
            //new Thread(new MainThread(3, 4, breakThread).CalcSum).Start();
            //new Thread(new MainThread(4, 5, breakThread).CalcSum).Start();
            //new Thread(new MainThread(5, 6, breakThread).CalcSum).Start();


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
                Thread.Sleep(10 * 1000);
                canStop = true;
            }
        }
    }
}
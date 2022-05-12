using System;
using System.Threading;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Storage size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The number of items : ");
            int needProdQuantity = Convert.ToInt32(Console.ReadLine());

            Storage st = new Storage(size);
            for (int i = 0; i < rnd.Next(5, 10); i++)
            {
                new Thread(() => Producer("Producer " + i, needProdQuantity, st)).Start();
                new Thread(() => Consumer("Consumer " + i, needProdQuantity, st)).Start();
            }
        }
        class Storage
        {
            public Semaphore access = new Semaphore(1, 1);
            public Semaphore notEmpty;
            public Semaphore notFull;

            public List<string> products = new List<string>();

            public Storage(int size)
            {
                this.notEmpty = new Semaphore(0, size);
                this.notFull = new Semaphore(size, size);
            }
        }
        static void Producer(string name, int needProdQuantity, Storage st)
        {
            for (int i = 0; i < needProdQuantity; i++)
            {
                st.notFull.WaitOne();
                st.access.WaitOne();
                Thread.Sleep(5);
                st.products.Add("Product");
                Console.WriteLine(name + " placed product. In storage: " + st.products.Count);
                st.notEmpty.Release();
                st.access.Release();
            }
        }
        static void Consumer(string name, int needProdQuantity, Storage st)
        {
            for (int i = 0; i < needProdQuantity; i++)
            {
                st.notEmpty.WaitOne();
                st.access.WaitOne();
                Thread.Sleep(5);
                st.products.RemoveAt(0);
                Console.WriteLine(name + " took product. In storage: " + st.products.Count);
                st.notFull.Release();
                st.access.Release();
            }
        }
    }
}
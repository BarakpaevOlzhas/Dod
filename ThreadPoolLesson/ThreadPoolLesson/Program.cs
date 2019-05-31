using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0;i < 20;i++)
            //{
            //    ThreadPool.QueueUserWorkItem(PrintNumbers);
            //}

            Timer timer = new Timer(PrintTime, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));

            Console.ReadLine();
            timer.Dispose();
        }

        static void PrintTime(object state )
        {
            var now = DateTime.Now;
            var currentThread = Thread.CurrentThread;

            Console.WriteLine($"Поток с Id {currentThread.ManagedThreadId} показывает время {now.ToString("hh:mm:ss")}");
        }

        static void PrintNumbers(object data)
        {
            var currentThread = Thread.CurrentThread;

            Console.WriteLine($"Поток с Id {currentThread.ManagedThreadId} начал работу");

            for (int i = 0;i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write(i + " ");
            }

            Console.WriteLine($"Поток с Id закончил { currentThread.ManagedThreadId}работу");
        }
    }
}

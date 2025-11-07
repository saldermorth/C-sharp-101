namespace Threads
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Skapa trådar
            Thread t1 = new Thread(new ThreadStart(task));
            Thread t2 = new Thread(new ThreadStart(task));
            Thread t3 = new Thread(new ThreadStart(task));


            // Starta trådar
            t1.Start();
            t2.Start();
            t3.Start();

            // Körs i huvudtråden
            Console.WriteLine("Main thread...");
        }
        public static void task()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Thread is running....");
        }
    }
}


//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

//using System;
//using System.Threading;

//class Program
//{
//    public static void Main()
//    {
//        Thread t1 = new Thread(new ThreadStart(SimpleTask));
//        Thread t2 = new Thread(new ParameterizedThreadStart(TaskWithParameter));

//        t1.Start(); // Starta t1
//        t2.Start("Hej från t2"); // Starta t2 med parameter

//        // Vänta på att t1 blir klar
//        t1.Join();

//        Console.WriteLine("t1 klar? " + !t1.IsAlive);
//        Console.WriteLine("Main thread ID: " + Thread.CurrentThread.ManagedThreadId);
//    }

//    static void SimpleTask()
//    {
//        Console.WriteLine("t1 körs. ID: " + Thread.CurrentThread.ManagedThreadId);
//        Thread.Sleep(1000); // Pausa i 1 sekund
//        Console.WriteLine("t1 avslutad.");
//    }

//    static void TaskWithParameter(object msg)
//    {
//        Console.WriteLine("t2 körs med parameter: " + msg);
//        Thread.Sleep(500);
//        Console.WriteLine("t2 avslutad. ID: " + Thread.CurrentThread.ManagedThreadId);
//    }
//}



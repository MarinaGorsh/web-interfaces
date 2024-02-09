using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Thread_1();
        Thread.Sleep(2000);
        Async_Await();
    }
    static void Thread_1()
    {
        Console.WriteLine("Thread:");
        Thread thread1 = new Thread(new ParameterizedThreadStart(DoWork));
        Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork));

        thread1.Start("Thread 1");
        thread2.Start("Thread 2");
        Console.WriteLine("The END");
    }
    static void DoWork(object threadName)
    {
        Console.WriteLine($"Thread '{threadName}' is running");
        Console.WriteLine($"Thread '{threadName}' has finished");
    }

    static void Async_Await()
    {
        Console.WriteLine("\nAsync-Await:");
        Task task1 = Task.Factory.StartNew(() => DoWork2("Task 1"));
        Task task2 = Task.Factory.StartNew(() => DoWork2("Task 2"));

        Task.WaitAll(task1, task2);
        Console.WriteLine("The END 2");
    }
    static void DoWork2(string taskName)
    {
        Console.WriteLine($"Task '{taskName}' is running");
        Console.WriteLine($"Task '{taskName}' has finished");
    }
}     

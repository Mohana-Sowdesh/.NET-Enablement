using System;
using System.Threading;
 
class Multithreading {
    static public void Main()
    {
        Thread Th1 = new Thread(work);
        Thread Th2 = new Thread(work);
        Thread Th3 = new Thread(work);
 
        Th2.Priority = ThreadPriority.Lowest;
        Th3.Priority = ThreadPriority.AboveNormal;
        Th1.Start();
        Th2.Start();
        Th3.Start();

        Console.WriteLine("The priority of Thread 1 is: {0}", Th1.Priority);
        Console.WriteLine("The priority of Thread 2 is: {0}", Th2.Priority);
        Console.WriteLine("The priority of Thread 3 is: {0}", Th3.Priority);
    }
 
    public static void work()
    {
        Thread.Sleep(1000);
    }
}

using System;
using System.Threading;
 
public class MThread {
    public void mythr()
    {
        for (int i = 0; i < 2; i++) 
        {
            Console.WriteLine("My Thread is in progress...!!");
        }
    }
}
 
public class Multithreading {
    public static void Main()
    {
        MThread obj = new MThread();
 
        // Creating and initializing thread
        // Using thread class and
        // ThreadStart constructor
        Thread t = new Thread(new ThreadStart(obj.mythr));
        t.Start();
    }
}

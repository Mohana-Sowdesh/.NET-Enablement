using System;
using System.Threading;
 
public class MXThread {
 
    // Non-static method
    public void mythr()
    {
        for (int j = 0; j < 2; j++) {
 
            Console.WriteLine("My Thread is in progress...!!");
        }
    }
}
 
// Driver Class
public class Multithreading {
 
    // Main Method
    public static void Main()
    {
        // Creating object of ExThread class
        MXThread obj = new MXThread();
 
        // Creating and initializing thread
        // Using thread class and
        // ThreadStart constructor
        Thread t = new Thread(new ThreadStart(obj.mythr));
        t.Start();
    }
}

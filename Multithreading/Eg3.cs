using System;
using System.Threading;
 
public class MyThread {
    public void mythr1()
    {
        Console.WriteLine("1st thread is Working..!!");
        Thread.Sleep(5000);
    }
 
    public void mythr2()
    {
        Console.WriteLine("2nd thread is Working..!!");
    }
}

public class ThreadExample {
    public static void Main()
    {
        MyThread obj = new MyThread();
      
        Thread t1 = new Thread(new ThreadStart(obj.mythr1));
        Thread t2 = new Thread(new ThreadStart(obj.mythr2));
        t1.Start();
 
        // Join thread
        t1.Join();
        t2.Start();
    }
}

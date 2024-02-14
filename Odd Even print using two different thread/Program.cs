namespace Odd_Even_print_using_two_different_thread
{
    internal class Program
    {
        static AutoResetEvent oddevent = new AutoResetEvent(false);
        //static AutoResetEvent evenevent = new AutoResetEvent(false);
        static int index = 1;
        static void Main(string[] args)
        {
            Thread odd = new Thread(PrintOdd);
            Thread even = new Thread(PrintEven);
            even.Start();
            odd.Start();
            
        }

        static void PrintOdd()
        {
            while (index <= 100)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} print {index++}");
                //evenevent.Set();
                oddevent.Set();
                oddevent.WaitOne();
            }
        }

        static void PrintEven()
        {
            while (index <= 100) 
            {
                //evenevent.WaitOne();
                oddevent.WaitOne();
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} print {index++}");
                oddevent.Set();
            }
        }
    }
}

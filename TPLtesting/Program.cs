using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace TPLtesting
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"C:\Projects\test.txt";

            int i = 10;

            i++;

            ReadFileAsync(filePath);

            Console.ReadLine();
        }

        public static async Task<int> ReadFileAsync(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);

            var buffer = new byte[fs.Length];

            Task<int> readTask = fs.ReadAsync(buffer, 0, buffer.Length);

            // Do some other activity
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Other activitiy finish");

            int length = await readTask;

            Console.WriteLine("Await completed");

            return length;
        }

        //static void Main(string[] args)
        //{
        //    Method();
        //    Console.WriteLine("Main Thread");
        //    Console.ReadLine();
        //}

        //public static void Method()
        //{
        //    Task.Run(new Action(LongTask));
        //    Console.WriteLine("New Thread");
        //}

        //public static void LongTask()
        //{
        //    Thread.Sleep(20000);
        //}
    }
}

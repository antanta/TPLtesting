using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLtesting
{
    class ParallelTest
    {
        static void Main(string[] args)
        {
            SimpleTest();
            return;
        }

        static void SimpleTest()
        {
            int RetCode = 0;
            Task RedistributionTask = new Task(() => RetCode = Timed_Message("Five ", 4));
            RedistributionTask.Start();
            Task AltRedistributionTask = new Task(() => RetCode = Timed_Message("Three ", 2));
            AltRedistributionTask.Start();
            Timed_Message("Main", 6);

            // wait for input before exiting
            Console.WriteLine("Press enter to finish after both [Complete] messages appear.");
            Console.ReadLine();
        }

        static void Listing1()
        {
            Task.Factory.StartNew(async () => {
                await Task.Delay(4000);
                Console.WriteLine("Hello World");

            });



            // wait for input before exiting

            Console.WriteLine("Main method complete. Press enter to finish.");

            Console.ReadLine();
        }

        static void Listing2()
        {
            // use an Action delegate and a named method

            Task task1 = new Task(new Action(printMessage));



            // use a anonymous delegate

            Task task2 = new Task(delegate {

                printMessage();

            });



            // use a lambda expression and a named method

            Task task3 = new Task(() => printMessage());



            // use a lambda expression and an anonymous method

            Task task4 = new Task(() => {

                printMessage();

            });



            task1.Start();

            task2.Start();

            task3.Start();

            task4.Start();



            // wait for input before exiting

            Console.WriteLine("Main method complete. Press enter to finish.");

            Console.ReadLine();
        }

        static void Listing3()
        {

        }

        private static int Timed_Message(String arg_Message, int arg_Interval)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Source {0} - Cycle {1} for Interval {2}", arg_Message, i, arg_Interval);
                Thread.Sleep(1000 * arg_Interval);
            }

            Console.WriteLine("{0} - Complete", arg_Message);
            return 0;
        }

        static void printMessage()
        {

            Console.WriteLine("Hello World");

        }
    }
}

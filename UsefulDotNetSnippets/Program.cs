using LinqLambdaDemo.Async_Programming;
using LinqLambdaDemo.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadsDemo;

namespace Dvinun.UsefulDotNetSnippets
{
    class Program
    {
        private static void Main(string[] args)
        {
            #region Commented Code. Uncomment to run them.

            //List<List<int>> list = Containers.Init2DList<int>(4, 4);

            //int[,] sample2DArray = Containers.Create2DArray(300, 300);
            //for (int row = 0; row < sample2DArray.GetLength(0); row++)
            //{
            //    for (int col = 0; col < sample2DArray.GetLength(1); col++)
            //    {
            //        Console.Write(sample2DArray[row, col] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //int[,] twodarrays = new int[3, 3] { { 1, 2, 3, }, { 4, 5, 6, }, { 7, 8, 9 } };

            //foreach (var item in twodarrays)
            //{
            //    Console.WriteLine(item);
            //}

            //Linq.EnumerableMethods();



            #endregion

            //StringOperations.IterateOverCommaDelimitedString();   

            //Linq_PlayersAndLeague.SomeFunction();
            //Linq_UsersAndRoles.SomeFunction();

            //Linq_ItemsAndPages.somefunction();

            // TaskAsyncAwait.SomeFunctionAsync();

            //Console.WriteLine("********************");
            //Console.WriteLine("I have asked my robot to prepare the breakfast for me. It will be ready in few mins :-) ");
            //Console.WriteLine("********************");
            //Console.Read();

            //Linq_DevsAndSkills.somefunction();

            //Dvinun.UsefulDotNetSnippets.Object_Oriented_Design.SOLID_Principles.InterfaceSegregationPrinciple.DemoRun();
            //Dvinun.UsefulDotNetSnippets.Object_Oriented_Design.BikeAndCar.Demo.Run();

            //RunSynchronousExample();
            //RunAsynchronousExample();
            //RunTaskConcurrentlyExample();
            //RunTaskConcurrentlyImprovedExample();
            //CompositionWithTasksExample();
            //AwaitTasksEfficientlyExample_WhenAll();

            Linq_NestedGroupBy.Demo();
            Console.ReadLine();
        }

        static void RunSynchronousExample()
        {
            // in this case, the main thread is blocked
            // hence, it will not respond what you type for readline
            // also console.writeline you see below is not printed
            // overall, we are blocked until the function PrepareBreakfast executed and came out
            // so, the operations are synchronous
            new SynchronousExample().PrepareBreakfast();
            Console.WriteLine("********************");
            Console.WriteLine("I have asked my robot to prepare the breakfast for me. It will be ready in few secs :-) ");
            Console.WriteLine("********************");
            Console.ReadLine();
        }

        static void RunAsynchronousExample()
        {
            // in this case, method PrepareBreakfastAsync is executed
            // in the same thread but in a different synchronizationcontext
            // so, the method 'PrepareBreakfastAsync' will not block this method 'RunAsynchronousExample'
            // instead it will come out and it executes the below three writelines and then also be 
            // responsive to any key strokes
            Task taskBf = new AsynchronousExample().PrepareBreakfastAsync();
            Console.WriteLine("********************");
            Console.WriteLine("I have asked my robot to prepare the breakfast for me. It will be ready in few secs :-) ");
            Console.WriteLine("********************");

            Console.ReadLine();
        }

        static void RunTaskConcurrentlyExample()
        {
            // For comments, see inside these methods for more explanation
            Task taskBf = new RunTaskConcurrentlyExample().PrepareBreakfastAsync();
            Console.WriteLine("********************");
            Console.WriteLine("I have asked my robot to prepare the breakfast for me. It will be ready in few secs :-) ");
            Console.WriteLine("********************");

            Console.ReadLine();
        }

        static void RunTaskConcurrentlyImprovedExample()
        {
            // For comments, see inside these methods for more explanation
            Task taskBf = new RunTaskConcurrentlyExample().PrepareBreakfastAsyncImproved();
            Console.WriteLine("********************");
            Console.WriteLine("I have asked my robot to prepare the breakfast for me. It will be ready in few secs :-) ");
            Console.WriteLine("********************");

            Console.ReadLine();
        }

        static void CompositionWithTasksExample()
        {
            // For comments, see inside these methods for more explanation
            Task taskBf = new CompositionWithTasksExample().PrepareBreakfastAsync();
            Console.WriteLine("********************");
            Console.WriteLine("I have asked my robot to prepare the breakfast for me. It will be ready in few secs :-) ");
            Console.WriteLine("********************");

            Console.ReadLine();
        }

        static void AwaitTasksEfficientlyExample_WhenAll()
        {
            // For comments, see inside these methods for more explanation
            Task taskBf = new AwaitTasksEfficientlyExample().PrepareBreakfastAsync_WhenAll();
            Console.WriteLine("********************");
            Console.WriteLine("I have asked my robot to prepare the breakfast for me. It will be ready in few secs :-) ");
            Console.WriteLine("********************");

            Console.ReadLine();
        }

        static void AwaitTasksEfficientlyExample_WhenAny()
        {
            // For comments, see inside these methods for more explanation
            Task taskBf = new AwaitTasksEfficientlyExample().PrepareBreakfastAsync_WhenAny();
            Console.WriteLine("********************");
            Console.WriteLine("I have asked my robot to prepare the breakfast for me. It will be ready in few secs :-) ");
            Console.WriteLine("********************");

            Console.ReadLine();
        }
    }
}

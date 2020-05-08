using LinqLambdaDemo.Async_Programming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinqLambdaDemo.Async_Programming
{
    public class SynchronousExample
    {
        Coffee PourCoffee()
        { 
            Console.WriteLine("pouring coffee");
            return new Coffee();
        }

        Egg FryEgg()
        {
            Console.WriteLine("frying egg");
            Thread.Sleep(3000);
            return new Egg();
        }

        Bacon FryBacon()
        {
            Console.WriteLine("frying bacon");
            Thread.Sleep(2000);
            return new Bacon();
        }

        Toast ToastBread()
        {
            Console.WriteLine("preparing toast");
            Thread.Sleep(4000);
            return new Toast();
        }

        void ApplyButter(Toast toast) => Console.WriteLine("applying butter to toast");
        void ApplyJam(Toast toast) => Console.WriteLine("applying jam to toast");
        Juice PourOJ()
        {
            Console.WriteLine("preparing juice");
            Thread.Sleep(2000);
            return new Juice();
        }

        public void PrepareBreakfast()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Egg eggs = FryEgg();
            Console.WriteLine("eggs are ready");
            Bacon bacon = FryBacon();
            Console.WriteLine("bacon is ready");
            Toast toast = ToastBread();
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }
    }

    public class AsynchronousExample
    {
        private Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private async Task<Egg> FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }

        private async Task<Bacon> FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("flipping a slice of bacon");
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");
            return new Bacon();
        }

        private async Task<Toast> ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("Putting a slice of bread in the toaster");
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }

        void ApplyButter(Toast toast) => Console.WriteLine("applying butter to toast");
        void ApplyJam(Toast toast) => Console.WriteLine("applying jam to toast");
        Juice PourOJ()
        {
            Console.WriteLine("preparing juice");
            return new Juice();
        }

        /*
        This code doesn't block while the eggs or the bacon are cooking. 
        This code won't start any other tasks though. You'd still put the toast in the toaster and stare at it until it pops. 
        But at least, you'd respond to anyone that wanted your attention. In a restaurant where multiple orders are placed, 
        the cook could start another breakfast while the first is cooking.
        Now, the thread working on the breakfast isn't blocked while awaiting any started task that hasn't yet finished. 
        For some applications, this change is all that's needed. 
        A GUI application still responds to the user with just this change. 
        However, for this scenario, you want more. You don't want each of the component tasks to be executed sequentially. 
        It's better to start each of the component tasks before awaiting the previous task's completion.
        */
        public async Task PrepareBreakfastAsync()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Console.WriteLine();

            Egg eggs = await FryEggs(2);
            Console.WriteLine("eggs are ready");
            Console.WriteLine();

            Bacon bacon = await FryBacon(3);
            Console.WriteLine("bacon is ready");
            Console.WriteLine();

            Toast toast = await ToastBread(4);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            Console.WriteLine();

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine();

            Console.WriteLine("Breakfast is ready!");
        }
    }

    public class RunTaskConcurrentlyExample
    {
        private Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private async Task<Egg> FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }

        private async Task<Bacon> FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("flipping a slice of bacon");
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");
            return new Bacon();
        }

        private async Task<Toast> ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("Putting a slice of bread in the toaster");
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }

        void ApplyButter(Toast toast) => Console.WriteLine("applying butter to toast");
        void ApplyJam(Toast toast) => Console.WriteLine("applying jam to toast");
        Juice PourOJ()
        {
            Console.WriteLine("preparing juice");
            return new Juice();
        }

        // Here, there is not much difference to our previous implementation
        // in AsynchronousExample. Because, we are still doing things sequentially
        // by awaiting on eggtask, bacontask, toastTask.
        // But the improvement here is that we are starting the task immediately
        // by just calling them immediately by assigning to Task. Ex: Task<Egg> eggsTask = FryEggs(2);
        // But we are still stopping them to execute concurrently by awaiting them right after 
        // invoking the task. 
        // So, to improve this further, we can remove the await inbetween the lines and put them
        // at the end. See next method PrepareBreakfastAsyncImproved for more efficient one.
        public async Task PrepareBreakfastAsync()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Console.WriteLine();

            Task<Egg> eggsTask = FryEggs(2);
            Console.WriteLine("awaiting eggs task");
            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready");
            Console.WriteLine();
            
            Task<Bacon> baconTask = FryBacon(3);
            Console.WriteLine("awaiting bacon task");
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");
            Console.WriteLine();
            
            Task<Toast> toastTask = ToastBread(2);
            Console.WriteLine("awaiting toast task");
            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            Console.WriteLine();
            
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine();

            Console.WriteLine("Breakfast is ready!");
            Console.WriteLine();
        }

        // Here, we execute all the tasks concurrently and wait at the end.
        // This will truly make the behavior parallel in nature.
        // But please keep in mind, this is not multi-threading.
        // Its just that these tasks runs in parallel in single thread only
        // but in different synchronization context I believe.
        // As you can see here, we are running tasks FryEggs, FryBacon, ToastBread in parallel
        // Then you await for them RIGHT WHEN YOU WANT TO READ THE RESULT OF TASK.
        // So, keep in mind that you use await in the place when you really need the result.
        // So, the biggest advantage here is you let all those tasks run in parallel and only
        // care when you want to read the result of the task.
        public async Task PrepareBreakfastAsyncImproved()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Console.WriteLine();

            Task<Egg> eggsTask = FryEggs(2);
            Task<Bacon> baconTask = FryBacon(3);
            Task<Toast> toastTask = ToastBread(2);
            Console.WriteLine("awaiting toastTask");
            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            Console.WriteLine();

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine();

            Console.WriteLine("awaiting eggsTask");
            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready");
            Console.WriteLine();

            Console.WriteLine("awaiting baconTask");
            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");
            Console.WriteLine();

            Console.WriteLine("Breakfast is ready!");
        }
    }

    public class CompositionWithTasksExample
    {
        private Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private async Task<Egg> FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }

        private async Task<Bacon> FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("flipping a slice of bacon");
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");
            return new Bacon();
        }

        private async Task<Toast> ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("Putting a slice of bread in the toaster");
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }

        void ApplyButter(Toast toast) => Console.WriteLine("applying butter to toast");
        void ApplyJam(Toast toast) => Console.WriteLine("applying jam to toast");
        Juice PourOJ()
        {
            Console.WriteLine("preparing juice");
            return new Juice();
        }


        // IMPORTANT NOTE ON ASYNCHRONOUS OPERATIONS
        // The composition of an asynchronous operation followed by synchronous work is an asynchronous operation. 
        // Stated another way, if any portion of an operation is asynchronous, the entire operation is asynchronous.
        public async Task PrepareBreakfastAsync()
        {

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Console.WriteLine();

            var eggsTask = FryEggs(2);
            var baconTask = FryBacon(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            Console.WriteLine("awaiting eggsTask");
            var eggs = await eggsTask;
            Console.WriteLine("eggs are ready");
            Console.WriteLine();

            Console.WriteLine("awaiting baconTask");
            var bacon = await baconTask;
            Console.WriteLine("bacon is ready");
            Console.WriteLine();
            var toast = await toastTask;

            Console.WriteLine("toast is ready");
            Console.WriteLine();

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine();

            Console.WriteLine("Breakfast is ready!");

            async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            {
                Console.WriteLine("awaiting ToastBread");
                var toast1 = await ToastBread(number);
                ApplyButter(toast1);
                ApplyJam(toast1);
                return toast1;
            }
        }

    }

    public class AwaitTasksEfficientlyExample
    {
        private Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private async Task<Egg> FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }

        private async Task<Bacon> FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("flipping a slice of bacon");
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");
            return new Bacon();
        }

        private async Task<Toast> ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("Putting a slice of bread in the toaster");
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }

        void ApplyButter(Toast toast) => Console.WriteLine("applying butter to toast");
        void ApplyJam(Toast toast) => Console.WriteLine("applying jam to toast");
        Juice PourOJ()
        {
            Console.WriteLine("preparing juice");
            return new Juice();
        }

        // Execute all tasks in parallel.
        public async Task PrepareBreakfastAsync_WhenAll()
        {
            var eggsTask = FryEggs(2);
            var baconTask = FryBacon(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            await Task.WhenAll(eggsTask, baconTask, toastTask);
            Console.WriteLine("eggs are ready");
            Console.WriteLine("bacon is ready");
            Console.WriteLine("toast is ready");
            Console.WriteLine("Breakfast is ready!");

            async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            {
                Console.WriteLine("awaiting ToastBread");
                var toast1 = await ToastBread(number);
                ApplyButter(toast1);
                ApplyJam(toast1);
                return toast1;
            }
        }

        // Execute all tasks in parallel. And peek the status of tasks on the fly.
        public async Task PrepareBreakfastAsync_WhenAny()
        {

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            var eggsTask = FryEggs(2);
            var baconTask = FryBacon(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var allTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finished == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finished == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                allTasks.Remove(finished);
            }
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

            async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            {
                var toast = await ToastBread(number);
                ApplyButter(toast);
                ApplyJam(toast);
                return toast;
            }
        }

    }

}

using System;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace LearningDotNet
{
    public class TestAsync
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TestAsync));

        public void MyTest()
        {
            //fun1();
            //fun2();
            fun3();
        }

        public void fun1()
        {
            Logger.Info("main thread started");

            Task.Run(() => { Thread.Sleep(1000); Logger.Info("Task1 started"); });

            Task t1 = Task.Run(() => { Thread.Sleep(1000); Logger.Info("Task1"); });
            //Task started a background thread. We have to use wait in main thread.
            Task task = Task.Run(() => { Thread.Sleep(50000); Logger.Info("Task2"); });


            for (int i = 0; i < 100; i++)
            {
                int a = i;
                Task.Run(() =>
                    {
                        Logger.Info("task started " + a); Thread.Sleep(2 * 1000);
                    }
                );
            }
            task.Wait();
            t1.Wait();

            Logger.Info("main thread end");
        }

        void fun2()
        {
            Logger.Info("main started");
            var task = Task<string>.Run(() => { Thread.Sleep(1000); return "aaa"; });
            Logger.Info("result is "+task.Result);
            Logger.Info("main end");

            Logger.Info("Task.Factory.Scheduler "+Task.Factory.Scheduler);
            Logger.Info("maximum concurrency level "+Task.Factory.Scheduler.MaximumConcurrencyLevel);
        }

        public void fun3()
        {
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) => {
                        CustomData data = obj as CustomData;
                        if (data == null)
                            return;

                        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                    },
                    new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
            foreach (var task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                if (data != null)
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                        data.Name, data.CreationTime, data.ThreadNum);
            }
        }

        class CustomData
        {
            public long CreationTime;
            public int Name;
            public int ThreadNum;
        }

        public void fun99()
        {
            Logger.Info("step 1");
            
            //Fun1Async();

            var task = Fun1Async();

            Logger.Info("step 1.1 " + DateTime.Now);

            Task.Delay(3000);
            Logger.Info("step 1.2 " + DateTime.Now);
            Task.WaitAll(task);

   //         Fun3();
            Logger.Info("step 2");

            var s = Func3();
            Console.Out.WriteLine(s.Result);
        }

        private async Task Fun1Async()
        {
            try
            {
                throw new Exception("this is a test");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
            Logger.Info("Fun1Async step 1");
            int a = await Fun2Async();
            Logger.Info("Fun1Async "+a);
        }

        private async Task<int> Fun2Async()
        {
            //await Thread.Sleep(3000);
            Logger.Info("Fun2Async step 1.2");
            await Task.Delay(2000);
            return 3;
        }

        private async Task<string> Func3()
        {
            string a = await Fun3Async();
            return a;
        }

        private async Task<string> Fun3Async()
        {
            //await Thread.Sleep(3000);
            Logger.Info("Fun3Async step 1.3");
            await Task.Delay(2000);
            return "this is a string";
        }

        public void Fun3()
        {
            var a = MyMethodAsync(); //Task started for Execution and immediately goes to Line 19 of the code. Cursor will come back as soon as await operator is met       
            Logger.Info("Cursor Moved to Next Line Without Waiting for MyMethodAsync() completion");
            Logger.Info("Now Waiting for Task to be Finished");
            Task.WaitAll(a); //Now Waiting      
            Logger.Info("Exiting CommandLine");
        }

        public async Task MyMethodAsync()
        {
            Task<int> longRunningTask = LongRunningOperation();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here
            Logger.Info("Independent Works of now executes in MyMethodAsync()");
            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            Logger.Info("Result of LongRunningOperation() is " + result);
        }

        public static async Task<int> LongRunningOperation() // assume we return an int from this long running operation 
        {
            Logger.Info("LongRunningOperation() Started");
            await Task.Delay(2000); // 2 second delay
            Logger.Info("LongRunningOperation() Finished after 2 Seconds");
            return 1;
        }

        /*
        public void Fun4()
        {
            Logger.Info(DateTime.Now);

            // This block takes 1 second to run because all
            // 5 tasks are running simultaneously
            {
                Task a = Task.Delay(1000);
                Task b = Task.Delay(1000);
                var c = Task.Delay(1000);
                var d = Task.Delay(1000);
                var e = Task.Delay(1000);

                await a;
                await a;
                await b;
                await c;
                await d;
                await e;
            }

            Logger.Info(DateTime.Now);

            // This block takes 5 seconds to run because each "await"
            // pauses the program until the task finishes
            {
                await Task.Delay(1000);
                await Task.Delay(1000);
                await Task.Delay(1000);
                await Task.Delay(1000);
                await Task.Delay(1000);
            }
            Logger.Info(DateTime.Now);
        }
        */
    }
}
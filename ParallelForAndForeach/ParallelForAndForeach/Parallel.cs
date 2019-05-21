using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForAndForeach
{
    public class Parallel
    {
        /// <summary>
        /// Invokes given action, passing arguments fromInclusive - toExclusive on multiple threads.C:\Users\User\Desktop\homeworks\ParallelLoops\ParallelForAndForeach\ParallelForAndForeach\Parallel.cs
        /// </summary>
        /// <param name="fromInclusive"> Start index </param>
        /// <param name="toExclusive"> End index </param>
        /// <param name="body"> Delegate that is invoked once per iteration.</param>
        public static void ParallelFor(int fromInclusive, int toExclusive, Action<int> body)
        {
            int size = 4; // Bigger size should reduce lock waiting time
            int threadCount = Environment.ProcessorCount; // Number of process() threads
            int index = fromInclusive - size;
            var locker = new object();  // Locker object shared by all the process() delegates

            // Processing function takes next chunk and processes it using action            
            Action process = delegate
             {
                while (true)
                {
                    int start = 0;
                    lock (locker)
                    {                       
                        index += size;
                        start = index;
                    }
                    
                    for (int i = start; i < start + size; i++)
                    {
                        if (i >= toExclusive)
                        {
                            return;
                        }

                        body(i);
                    }
                }
            };

            // Launch process() threads           
            IAsyncResult[] asyncResults = new IAsyncResult[threadCount]; 
            for (int i = 0; i < threadCount; ++i)
            {
                asyncResults[i] = process.BeginInvoke(null, null);
            }

            // Wait for all threads to complete
            for (int i = 0; i < threadCount; ++i)
            {
                process.EndInvoke(asyncResults[i]);
            }
        }

        /// <summary>
        /// Executes a foreach operation on an IEnumerable in which iterations may run in parallel.
        /// </summary>
        /// <typeparam name="TSource"> The type of the data in the source </typeparam>
        /// <param name="source"> Enumerable data source </param>
        /// <param name="body"> The delegate that is invoked once per iteration</param>
        public static void ParallelForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source argument is null");
            }

            if (body == null)
            {
                throw new ArgumentNullException("Body argument is null");
            }

            var resetEvents = new List<ManualResetEvent>();

            foreach (var item in source)
            {
                var events = new ManualResetEvent(false); 
                ThreadPool.QueueUserWorkItem((i) =>
                {
                    body((TSource)i);
                    events.Set(); 
                }, item);
                resetEvents.Add(events);
            }

            foreach (var reset in resetEvents)
                reset.WaitOne(); 
        }

        /// <summary>
        /// Executes a foreach operation to interact with other iterations.
        /// </summary>
        /// <typeparam name="TSource"> The type of the data in the source</typeparam>
        /// <param name="source">  Enumerable data source </param>
        /// <param name="parallelOptions"> Sets the maximum number of concurrent operations used by this method</param>
        /// <param name="body"> The delegate that is invoked once per iteration </param>
        public static void ParallelForEachWithOptions<TSource>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Action<TSource> body)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source argument is null");
            }

            if (body == null)
            {
                throw new ArgumentNullException("Body argument is null");
            }

            var resetEvents = new List<ManualResetEvent>();
            
            foreach (var item in source)
            {
                var events = new ManualResetEvent(false);
                
                ThreadPool.QueueUserWorkItem((i) =>
                {
                    ThreadPool.SetMaxThreads(parallelOptions.MaxDegreeOfParallelism, parallelOptions.MaxDegreeOfParallelism);
                    body((TSource)i);
                    events.Set();
                }, item);
                resetEvents.Add(events);
            }

            foreach (var reset in resetEvents)
                reset.WaitOne();

        }
    }
}

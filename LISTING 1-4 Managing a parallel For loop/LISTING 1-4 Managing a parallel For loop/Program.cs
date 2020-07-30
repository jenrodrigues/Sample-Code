using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_4_Managing_a_parallel_For_loop
{
    class Program
    {
        //
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item); 
        }

        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 500).ToArray();


            //ParallelLoopResult type can be used on For() and ForEach() methods to determine 
            //whether or not a parallel loop has successfully completed.
            
            //ParallelLoopState type allows the code to control the iteration process 
            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
            {
                if (i == 200)
                    loopState.Break(); //Small difference from Stop()

                WorkOnItem(items[i]);
                j++;

            });

            Console.WriteLine("Completed: " + result.IsCompleted);//checking the loop final result
            Console.WriteLine("Items: " + result.LowestBreakIteration);
            
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using IterateOverQueueTests.TestCases;

namespace IterateOverQueueTests
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numIterations = 1000000;
            var taskDuration = 100;
            
            var timer = new Stopwatch();
            
            var testCases = new List<ITestCase>
            {
                new ListAndForeach(),
                new ListAndLinqForEach(),
                new ListAndForLoop(),
                new ListAndForLoopAndPool(),
            };
            
            Console.WriteLine($"{numIterations} iterations with tasks that last {taskDuration} cycles");

            for (var i = 0; i < testCases.Count; i++)
            {
                Thread.Sleep(2);
                var test = testCases[i];
                Console.Write($"Test: {testCases[i].GetType().Name}");
                timer.Start();
                for(var j=0; j<numIterations; j++)
                    test.RunIteration(taskDuration);
                timer.Stop();
                Console.WriteLine($"  -  {timer.Elapsed} elapsed\n");
                timer.Reset();                
            }
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    static void Main(string[] args)
    {
        // Set up conveyor for variant N
        var conveyor = new CachedDataConveyor<IEnumerable<IEnumerable<int>>, object> {
            Source = new IntArrayFromFileDataSource("input.txt"),
            Handlers = new IDataHandler<IEnumerable<IEnumerable<int>>, object>[] {
                new NestedDataHandler<IEnumerable<IEnumerable<int>>, Tuple<int, int>, object> (
                    new IntArraySizeCalculator(), 
                    (sizeTuple)=> String.Format("{0} {1}", sizeTuple.Item1, sizeTuple.Item2)
                ),
                new NestedDataHandler<IEnumerable<IEnumerable<int>>, long, object> (
                    new IntArrayProductCalculator(),
                    (product)=> product
                )
            }, 
            Sink = new FileDataSink("output20.log")
        };
        
        // First run for variant N
        conveyor.Run();

        // Set up conveyor for variant N-1: Calculate sum of positive items of array.
        conveyor.Handlers[1] = new FunctionalDataHandler<IEnumerable<IEnumerable<int>>, object> (
            (data)=> {
                long sum = 0;
                foreach (var line in data) {
                    foreach (var number in line) {
                        if (number > 0) sum += number;
                    }
                }
                return sum;
            }
        );
        conveyor.Sink = new FileDataSink("output19.log");

        // Run for variant N-1
        conveyor.Run();

        // Set up conveyor for variant N+1: Calculate mean of negative items of array.
        conveyor.Handlers[1] = new FunctionalDataHandler<IEnumerable<IEnumerable<int>>, object> (
            (data)=> {
                long sum = 0, count = 0;
                foreach (var line in data) {
                    foreach (var number in line) {
                        if (number < 0) {
                            sum += number;
                            ++count;
                        }
                    }
                }
                return sum / count;
            }
        );
        conveyor.Sink = new FileDataSink("output21.log");

        // Run for variant N+1
        conveyor.Run();

        Console.Write("\nDone. Press [ENTER] to exit. \n");
        Console.ReadLine();
    }
}

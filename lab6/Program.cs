using System;
using System.Collections.Generic;

class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    static void Main(string[] args)
    {
        var conveyor1 = new DataConveyor<IEnumerable<IEnumerable<int>>, object> {
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
            Sink = new FileDataSink("output1.log")
        };
        
        conveyor1.Run();
    }
}

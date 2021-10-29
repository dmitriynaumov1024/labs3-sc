using System;
using System.Collections.Generic;

class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    static void Main(string[] args)
    {
        IDataSource<IEnumerable<IEnumerable<int>>> 
            dataSource = new IntArrayFromFileDataSource("input.txt");
        IDataHandler<IEnumerable<IEnumerable<int>>, long>
            dataHandler = new IntArrayProductCalculator();
        IDataHandler<IEnumerable<IEnumerable<int>>, Tuple<int, int>>
            dataSizeHandler = new IntArraySizeCalculator();

        IDataSink<object> 
            dataSink = new FileDataSink("output.txt");

        Tuple<int, int> size = dataSizeHandler.Handle(dataSource.Data);
        long result = dataHandler.Handle(dataSource.Data);

        dataSink.Put(size.Item1, size.Item2);
        dataSink.Put(result);
        dataSink.Flush();
    }
}

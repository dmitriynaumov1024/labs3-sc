using System;
using System.Collections.Generic;

class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    static void Main(string[] args)
    {
        // Declare DataConveyor
        DataConveyor<Table<int>, object> conveyor;

        // Set up conveyor for variant N-1
        conveyor = new DataConveyor<Table<int>, object> {
            Source = DataSources.DefaultSource,
            Handlers = new [] {
                DataHandlers.TableSizeCalculator,
                DataHandlers.SumOfPositivesCalculator
            },
            Sink = new FileDataSink ("output19.log")
        };
        
        // First run for variant N-1
        conveyor.Run();

        // Set up conveyor for variant N
        conveyor.Handlers[1] = DataHandlers.ProdOfNegativesCalculator;
        conveyor.Sink = new FileDataSink ("output20.log");

        // Run for variant N
        conveyor.Run();

        // Set up for N+1
        conveyor.Handlers[1] = DataHandlers.MeanOfNegativesCalculator;
        conveyor.Sink = new FileDataSink ("output21.log");

        // Run for variant N+1
        conveyor.Run();

        Console.Write("\nDone. Press [ENTER] to exit. \n");
        Console.ReadLine();
    }
}

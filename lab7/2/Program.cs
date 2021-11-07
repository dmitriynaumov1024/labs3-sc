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
        conveyor = DataConveyor.Build (
            DataSources.DefaultSource,
            new[] {
                DataHandlers.TableSizeCalculator,
                DataHandlers.SumOfPositivesCalculator
            },
            new FileDataSink ("output19.log")
        );
        
        // First run for variant N-1
        conveyor.Run();

        // Set up conveyor for variant N
        conveyor = DataConveyor.Build (
            DataSources.DefaultSource,
            new[] {
                DataHandlers.TableSizeCalculator,
                DataHandlers.ProdOfNegativesCalculator
            },
            new FileDataSink ("output20.log")
        );

        // Run for variant N
        conveyor.Run();

        // Set up for N+1
        conveyor = DataConveyor.Build (
            DataSources.DefaultSource,
            new[] {
                DataHandlers.TableSizeCalculator,
                DataHandlers.MeanOfNegativesCalculator
            },
            new FileDataSink ("output21.log")
        );

        // Run for variant N+1
        conveyor.Run();

        Console.Write("\nDone. Press [ENTER] to exit. \n");
        Console.ReadLine();
    }
}

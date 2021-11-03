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
        conveyor = DataConveyor.Build (new Factory19());
        
        // First run for variant N-1
        conveyor.Run();

        // Set up conveyor for variant N
        conveyor = DataConveyor.Build (new Factory20());

        // Run for variant N
        conveyor.Run();

        // Set up for N+1
        conveyor = DataConveyor.Build (new Factory21());

        // Run for variant N+1
        conveyor.Run();

        Console.Write("\nDone. Press [ENTER] to exit. \n");
        Console.ReadLine();
    }
}

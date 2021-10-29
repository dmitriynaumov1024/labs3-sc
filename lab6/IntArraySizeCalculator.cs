using System;
using System.Collections.Generic;

class IntArraySizeCalculator: IDataHandler<IEnumerable<IEnumerable<int>>, Tuple<int, int>>
{
    /// <summary>
    /// Returns new Tuple where:
    ///   Item1 is number of rows,
    ///   Item2 is number of columns
    /// in given 2d int collection.
    /// </summary>
    public Tuple<int, int> Handle(IEnumerable<IEnumerable<int>> data)
    {
        int rows = 0, columns = 0;
        foreach (var line in data) {
            if (rows == 0) foreach (var number in line) ++columns;
            ++rows;
        }
        return new Tuple<int, int>(rows, columns);
    }
}

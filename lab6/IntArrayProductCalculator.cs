using System;
using System.Collections.Generic;

class IntArrayProductCalculator: IDataHandler<IEnumerable<IEnumerable<int>>, long>
{
    public long Handle(IEnumerable<IEnumerable<int>> data)
    {
        long result = 1;
        foreach (var line in data) {
            foreach (var number in line) {
                if (number < 0) {
                    result *= (long)number;
                }
            }
        }
        return result;
    }
}

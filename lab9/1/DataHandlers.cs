using System;

static class DataHandlers {
    public static readonly IDataHandler<Table<int>, object> 
        TableSizeCalculator = new FunctionalDataHandler<Table<int>, object> (
            (data)=> {
                int rows = 0, columns = 0;
                foreach (var line in data) {
                    if (rows == 0) foreach (var number in line) ++columns;
                    ++rows;
                }
                return String.Format("{0} {1} ", rows, columns);
            }
        );

    public static readonly IDataHandler<Table<int>, object> 
        ProdOfNegativesCalculator = new FunctionalDataHandler<Table<int>, object> (
            (data)=> {
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
        );

    public static readonly IDataHandler<Table<int>, object> 
        SumOfPositivesCalculator = new FunctionalDataHandler<Table<int>, object> (
            (data)=> {
                long result = 0;
                foreach (var line in data) {
                    foreach (var number in line) {
                        if (number > 0) {
                            result += number;
                        }
                    }
                }
                return result;
            }
        );

    public static readonly IDataHandler<Table<int>, object> 
        MeanOfNegativesCalculator = new FunctionalDataHandler<Table<int>, object> (
            (data)=> {
                long sum = 0, count = 0;
                foreach (var line in data) {
                    foreach (var number in line) {
                        if (number < 0) {
                            sum += (long)number;
                            ++count;
                        }
                    }
                }
                return sum / count;
            }
        );
}

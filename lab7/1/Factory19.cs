using System;

class Factory19: IConveyorPartFactory<Table<int>, object>
{
    public IDataSource<Table<int>> GetSource()
    {
        return DataSources.DefaultSource;
    }

    public IDataHandler<Table<int>, object>[] GetHandlers()
    {
        return new[] {
            DataHandlers.TableSizeCalculator,
            DataHandlers.SumOfPositivesCalculator
        };
    }

    public IDataSink<object> GetSink()
    {
        return new FileDataSink ("output19.log");
    }
}

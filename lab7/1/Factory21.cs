using System;

class Factory21: IConveyorPartFactory<Table<int>, object>
{
    public IDataSource<Table<int>> GetSource()
    {
        return DataSources.DefaultSource;
    }

    public IDataHandler<Table<int>, object>[] GetHandlers()
    {
        return new[] {
            DataHandlers.TableSizeCalculator,
            DataHandlers.MeanOfNegativesCalculator
        };
    }

    public IDataSink<object> GetSink()
    {
        return new FileDataSink ("output21.log");
    }
}

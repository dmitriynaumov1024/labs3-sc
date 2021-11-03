using System;

class Factory20: IConveyorPartFactory<Table<int>, object>
{
    public IDataSource<Table<int>> GetSource()
    {
        return DataSources.DefaultSource;
    }

    public IDataHandler<Table<int>, object>[] GetHandlers()
    {
        return new[] {
            DataHandlers.TableSizeCalculator,
            DataHandlers.ProdOfNegativesCalculator
        };
    }

    public IDataSink<object> GetSink()
    {
        return new FileDataSink ("output20.log");
    }
}

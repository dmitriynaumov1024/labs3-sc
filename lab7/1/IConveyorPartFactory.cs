using System;

interface IConveyorPartFactory<TInput, TOutput>
{
    IDataSource<TInput> GetSource();
    IDataHandler<TInput, TOutput>[] GetHandlers();
    IDataSink<TOutput> GetSink();
}

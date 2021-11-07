using System;

/// <summary>
/// Data conveyor provides a single entry point to do all work with data:
/// - Take data from the source,
/// - Pass it through several handlers,
/// - Put results into the sink.
/// All parts of the conveyor can be replaced and conveyor can be reused 
/// many times. This type of conveyor doesn't cache any data. To avoid 
/// unnecessary repetitions, use CachedDataConveyor instead.
/// </summary>
class DataConveyor<TInput, TOutput>
{
    public IDataSource<TInput> Source;
    public IDataHandler<TInput, TOutput>[] Handlers;
    public IDataSink<TOutput> Sink;
    
    public DataConveyor (){ }

    public DataConveyor (
        IDataSource<TInput> source, 
        IDataHandler<TInput, TOutput> handler,
        IDataSink<TOutput> sink)
    { 
        this.Source = source;
        this.Handlers = new IDataHandler<TInput, TOutput>[] { handler };
        this.Sink = sink;
    }

    public void Run()
    {
        foreach (var handler in this.Handlers){
            TOutput outputPortion = handler.Handle (Source.Data);
            this.Sink.Put (outputPortion);
        }
        this.Sink.Flush();
    }
}

class DataConveyor 
{
    /// <summary>
    /// This is a prototype user.
    /// </summary>
    public static DataConveyor<TInput, TOutput> 
        Build<TInput, TOutput> (
            IDataSource<TInput> source, 
            IDataHandler<TInput, TOutput>[] handlers,
            IDataSink<TOutput> sink
        )
    {
        var handlersCopy = new IDataHandler<TInput, TOutput>[handlers.Length];
        for (int i=0; i<handlers.Length; i++) {
            handlersCopy[i] = handlers[i].Clone();
        }
        return new DataConveyor<TInput, TOutput> {
            Source = source,
            Handlers = handlersCopy,
            Sink = sink
        };
    }
}

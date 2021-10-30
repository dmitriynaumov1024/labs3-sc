using System;

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

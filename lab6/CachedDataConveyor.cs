using System;

/// <summary>
/// This data conveyor provides the same interface as its base type, but
/// allows using cached data. Correct results are guaranteed if and only if
/// immutable data handlers are used. Cache is automatically discarded when 
/// you replace data source or one of data handlers.
/// </summary>
class CachedDataConveyor<TInput, TOutput>: DataConveyor<TInput, TOutput>
{
    private TOutput[] dataHandlerCaches;
    private object dataSourceHash;
    private object[] dataHandlerHashes;
    private IDataHandler<TInput, TOutput>[] handlers;

    public CachedDataConveyor (){ }

    public CachedDataConveyor (
        IDataSource<TInput> source, 
        IDataHandler<TInput, TOutput> handler,
        IDataSink<TOutput> sink)
    { 
        this.Source = source;
        this.Handlers = new IDataHandler<TInput, TOutput>[] { handler };
        this.Sink = sink;
    }

    public override IDataHandler<TInput, TOutput>[] Handlers 
    {
        get {
            return this.handlers;
        }
        set {
            this.handlers = value;
            int newLength = value.Length;
            this.dataHandlerCaches = new TOutput[newLength];
            this.dataHandlerHashes = new object[newLength];
            this.dataSourceHash = null;
        }
    }

    public override void Run()
    {
        Console.Write("[debug]: Running... \n");
        object dataSourceHashCode = this.Source.Data.GetHashCode();
        for (int i = 0; i < this.handlers.Length; i++) {
            object handlerHashCode = this.handlers[i].GetHashCode();
            bool cacheAvailable = 
                dataSourceHashCode.Equals(this.dataSourceHash) && 
                handlerHashCode.Equals(this.dataHandlerHashes[i]);
            TOutput outputPortion;
            if (cacheAvailable){
                Console.Write("[debug]: We're using cached value. \n");
                outputPortion = dataHandlerCaches[i];
            }
            else {
                Console.Write("[debug]: We're calculating everything again. \n");
                outputPortion = this.handlers[i].Handle(this.Source.Data);
                this.dataHandlerHashes[i] = handlerHashCode;
                this.dataHandlerCaches[i] = outputPortion;
            }
            this.Sink.Put(outputPortion);
        }
        this.dataSourceHash = dataSourceHashCode;
        this.Sink.Flush();
    }

    /// <summary>
    /// Discard all cache.
    /// </summary>
    public void DiscardCache()
    {
        this.dataSourceHash = null;
        for (int i = 0; i < this.dataHandlerHashes.Length; i++) {
            this.dataHandlerHashes[i] = null;
        }
    }

    /// <summary>
    /// Forget hash code of given data source / handler
    /// and therefore discard the cache.
    /// </summary>
    public void DiscardCache(object item)
    {
        if (item == this.Source) {
            this.dataSourceHash = null;
        }
        
        for (int i = 0; i < this.handlers.Length; i++) {
            if (item == this.handlers[i]) {
                this.dataHandlerHashes[i] = null;
            }
        }
    }
}

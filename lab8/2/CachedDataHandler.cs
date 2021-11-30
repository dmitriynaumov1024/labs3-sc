using System;

class CachedDataHandler<TInput, TOutput>: IDataHandler<TInput, TOutput> 
where TOutput: class
{
    private IDataHandler<TInput, TOutput> handler;
    private TOutput resultCopy;
    private object inputHash;

    public CachedDataHandler (IDataHandler<TInput, TOutput> source)
    {
        this.handler = source;
        this.inputHash = null;
    }

    public TOutput Handle (TInput data)
    {
        object hash = data.GetHashCode();
        if (this.inputHash != hash) {
            this.inputHash = hash;
            this.resultCopy = this.handler.Handle(data);
        }
        return this.resultCopy;
    }
}

static class CachedDataHandler 
{
    public static CachedDataHandler<TIn, TOut> 
        Cached<TIn, TOut> (this IDataHandler<TIn, TOut> handler) 
        where TOut: class
    {
        return new CachedDataHandler<TIn, TOut>(handler);
    }
}

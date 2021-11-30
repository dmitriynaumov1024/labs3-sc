using System;

class FunctionalDataHandler<TInput, TOutput>: IDataHandler<TInput, TOutput>
{
    private Func<TInput, TOutput> handler;

    public FunctionalDataHandler (Func<TInput, TOutput> handler)
    {
        this.handler = handler;
    }

    public TOutput Handle (TInput data)
    {
        return this.handler(data);
    }

    public IDataHandler<TInput, TOutput> Clone ()
    {
        return new FunctionalDataHandler<TInput, TOutput>(this.handler);
    }
}

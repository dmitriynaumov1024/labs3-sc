using System;

class NestedDataHandler<TInput, TIntermediate, TOutput>: IDataHandler<TInput, TOutput>
{
    public IDataHandler<TInput, TIntermediate> NestedHandler;
    public Func<TIntermediate, TOutput> TransformFunction;
    
    public NestedDataHandler (
        IDataHandler<TInput, TIntermediate> nestedHandler,
        Func<TIntermediate, TOutput> transformFunction)
    {
        this.NestedHandler = nestedHandler;
        this.TransformFunction = transformFunction;
    }

    public TOutput Handle (TInput data)
    {
        return this.TransformFunction(this.NestedHandler.Handle(data));
    }
}

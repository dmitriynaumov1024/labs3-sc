using System;

interface IDataHandler<TInput, TOutput>
{
    TOutput Handle (TInput data);
}

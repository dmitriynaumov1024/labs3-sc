using System;

interface IDataHandler<in TInput, out TOutput>
{
    TOutput Handle (TInput data);
}

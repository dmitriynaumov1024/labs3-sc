using System;

interface IDataSource<T>
{
    T Data { get; }
}

using System;

interface IDataSink<T>
{
    void Put (T data);
    void Put (params T[] data);
    void Flush ();
}

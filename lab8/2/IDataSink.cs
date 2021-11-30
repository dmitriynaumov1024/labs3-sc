using System;

interface IDataSink<in T>
{
    void Put (T data);
    void Put (params T[] data);
    void Flush ();
}

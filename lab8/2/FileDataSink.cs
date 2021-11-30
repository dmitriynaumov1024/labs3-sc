using System;
using System.IO;

class FileDataSink: IDataSink<object>
{
    private StreamWriter writer;

    public void Put (object data)
    {
        writer.Write ("{0}\r\n", data);
    }

    public void Put (params object[] data)
    {
        foreach (object item in data) writer.Write ("{0} ", item);
        writer.Write("\r\n");
    }

    public void Flush ()
    {
        writer.Flush();
    }

    public FileDataSink (string filePath)
    {
        this.writer = File.CreateText (filePath);
    }
}

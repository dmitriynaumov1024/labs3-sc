using System;

static class DataSources 
{
    public static readonly IDataSource<Table<int>>
        DefaultSource = new IntTableFromFileDataSource ("input.txt");
}

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class IntTableFromFileDataSource: IDataSource<Table<int>>
{
    static char[] whitespaceOrTab = new[]{ ' ', '\t' };
    static StringSplitOptions noEmptyEntries = StringSplitOptions.RemoveEmptyEntries;

    private Table<int> data;

    public IntTableFromFileDataSource (string fileName)
    {
        var tempdata = new List<List<int>>();
        string[] inputData = File.ReadAllLines(fileName);
        foreach (string line in inputData){
            var currentList = new List<int>();
            foreach (string s in line.Split(whitespaceOrTab, noEmptyEntries)){
                currentList.Add(int.Parse(s));
            }
            tempdata.Add(currentList);
        }
        this.data = (Table<int>)tempdata;
    }

    public Table<int> Data {
        get {
            return this.data;
        }
    }
}

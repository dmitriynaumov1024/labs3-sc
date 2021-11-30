using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// An auxillary type to replace long 'IEnumerable IEnumerable T' name.
/// </summary>
class Table<T>: IEnumerable<List<T>>
{
    private List<List<T>> data;

    private Table () { }

    public Table (List<List<T>> source)
    {
        this.data = new List<List<T>>();
        foreach (List<T> line in source) {
            var linecopy = new List<T>();
            foreach (T item in line) {
                linecopy.Add (item);
            }
            this.data.Add (linecopy);
        }
    }

    IEnumerator<List<T>> IEnumerable<List<T>>.GetEnumerator ()
    {
        return this.data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator ()
    {
        return this.data.GetEnumerator();
    }

    public static explicit operator Table<T>(List<List<T>> source)
    {
        var result = new Table<T>();
        result.data = source;
        return result;
    }
}

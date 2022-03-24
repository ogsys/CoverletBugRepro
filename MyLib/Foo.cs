using System;
using System.Data.SqlClient;

namespace MyLib;

public static class Foo
{
    public static void Bar(SortOrder order = SortOrder.Ascending)
    {
        Console.WriteLine(order);
    }
}

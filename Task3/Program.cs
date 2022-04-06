using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Table<string>(4, 4);
            var rules = new Rules();
            rules.FillTable(t, new string[] {"rock", "scessors", "paper"});
            t.ShowTable();



        }
    }
}

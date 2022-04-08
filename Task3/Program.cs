using System;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arg = new string[] {"1", "2", "3", "4", "5", "3", "5"};
            DoChecks(args);
            var t = new Table<string>(args.Length + 1, args.Length + 1);
            var rules = new Rules();
            rules.FillTable(t, args);
            t.ShowTable();

        }

        private static void ShowMenu(string[] args)
        {

        }

        private static void DoChecks(string[] args)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException("The amount of arguments has to be >= 3. For example: 1 2 3 4 5 6 7 ", nameof(args));
            }

            if (IsEven(args.Length))
            {
                throw new ArgumentException("The amount of arguments is not even, but it has to be. For example: 1 2 3 4 5", nameof(args));
            }

            if (args.Distinct().Count() != args.Length)
            {
                throw new ArgumentException("There are repeating elements through arguments (all arguments have to be unique). For example: rock scissors paper", nameof(args));
            }
           
        }

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}

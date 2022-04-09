using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            DoChecks(args);
            var table = new Table<string>(args.Length + 1, args.Length + 1);
            var rules = new Rules();
            rules.FillTable(table, args);
            var hash = new Hash();
            string command;
            int computerMove;
            while (true)
            {
                computerMove = ComputerMove(args);
                hash.CalculateHMAC(args[computerMove]);
                Console.WriteLine("HMAC:");
                Console.WriteLine(hash.HMAC);
                ShowMenu(args);
                Console.WriteLine("Enter your move:");
                command = Console.ReadLine();
                if (command == "?")
                {
                    table.ShowTable();
                    continue;
                }
                else if(command == "0") break;
                else
                {
                    int yourMove = int.Parse(command);
                    Console.WriteLine("Your move: {0}", args[yourMove - 1]);
                    int result = rules.Fight(yourMove - 1, computerMove, args);
                    Console.WriteLine("Computers move: {0}", args[computerMove]);
                    if (result == 1) Console.WriteLine("You win!");
                    else if (result == -1) Console.WriteLine("You lost...");
                    else Console.WriteLine("Draw.");
                    Console.WriteLine("HMAC key:");
                    Console.WriteLine(hash.Key);
                }
            }
        }

        private static int ComputerMove(string[] args)
        {
            var rnd = new Random();
            int i = rnd.Next(args.Length);
            return i;
        }

        private static void ShowMenu(string[] args)
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("{0} - {1}", i+1, args[i]);
            }

            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        private static void DoChecks(string[] args)
        {
            var ExceptionList = new List<Exception>();
            if (args.Length < 3)
            {
                ExceptionList.Add(new ArgumentException("The amount of arguments has to be >= 3. For example: 1 2 3 4 5 6 7 "));
            }

            if (IsEven(args.Length))
            {
                ExceptionList.Add(new ArgumentException("The amount of arguments is not even, but it has to be. For example: 1 2 3 4 5"));
            }

            if (args.Distinct().Count() != args.Length)
            {
                ExceptionList.Add(new ArgumentException("There are repeating elements through arguments (all arguments have to be unique). For example: rock scissors paper"));
            }

            if (ExceptionList.Any())
            {
                foreach (var exception in ExceptionList)
                {
                    Console.WriteLine(exception.Message);   
                }

                System.Environment.Exit(0);
            }
        }

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Table
    {
        private string[,] table;
        private string[] args;
        public int X { get; private set; }
        public int Y { get; private set; }
        public Table(string[] args)
        {
            table = new string[args.Length + 1, args.Length + 1];
            X = args.Length + 1;
            this.args = args;
            this.FillTable();
        }

        public void Insert(int x, int y, string value)
        {
            table[x, y] = value;
        }

        private void FillTable()
        {
            for(int i = 1, j = 0; i < table.GetLength(0); i++, j++)
            {
                table[0, i] = args[j];
                table[i, 0] = args[j];
            }

            for(int i = 1; i < table.GetLength(0); i++)
            {
                for(int j = 1; j < table.GetLength(1); j++)
                {
                    switch (Win(i - 1,j - 1))
                    {
                        case 1:
                            table[i, j] = "Win";
                            break;
                        case 0:
                            table[i, j] = "Draw";
                            break;
                        case -1:
                            table[i, j] = "Lose";
                            break;
                    }
                }
            }
        }

        private int Win(int ind1, int ind2)
        {
            int len = (args.Length - 1) / 2;
            if(ind1 < ind2)
            {
                if(ind1 + len >= ind2)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
                
            }
            else if(ind1 > ind2)
            {
                if(ind1 + len  >= args.Length)
                {
                    int delta = ind1 + len - args.Length;
                    if(delta >= ind2)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else return -1; 
            }

            return 0;
        }

        public void ShowTable()
        {
            for(int i = 0; i < table.GetLength(0); i++)
            {
                for(int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write("{0, -12}|", table[i, j]);
                }

                Console.Write("\n");
            }
        }
    }
}












/*class Table
    {
        private string[,] table;
        private string[] args;
        public int X { get; private set; }
        public Table(string[] args)
        {
            table = new string[args.Length + 1, args.Length + 1];
            X = args
            this.args = args;
            this.FillTable();
        }

        private void FillTable()
        {
            for(int i = 1, j = 0; i < table.GetLength(0); i++, j++)
            {
                table[0, i] = args[j];
                table[i, 0] = args[j];
            }

            for(int i = 1; i < table.GetLength(0); i++)
            {
                for(int j = 1; j < table.GetLength(1); j++)
                {
                    switch (Win(i - 1,j - 1))
                    {
                        case 1:
                            table[i, j] = "Win";
                            break;
                        case 0:
                            table[i, j] = "Draw";
                            break;
                        case -1:
                            table[i, j] = "Lose";
                            break;
                    }
                }
            }
        }

        private int Win(int ind1, int ind2)
        {
            int len = (args.Length - 1) / 2;
            if(ind1 < ind2)
            {
                if(ind1 + len >= ind2)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
                
            }
            else if(ind1 > ind2)
            {
                if(ind1 + len  >= args.Length)
                {
                    int delta = ind1 + len - args.Length;
                    if(delta >= ind2)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else return -1; 
            }

            return 0;
        }

        public void ShowTable()
        {
            for(int i = 0; i < table.GetLength(0); i++)
            {
                for(int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write("{0, -12}|", table[i, j]);
                }

                Console.Write("\n");
            }
        }
    }*/

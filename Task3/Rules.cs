namespace Task3
{
    class Rules
    {
        public void FillTable(Table<string> table, string[] args)
        {
            for (int i = 1, j = 0; i < table.X; i++, j++)
            {
                table.Insert(0, i, args[j]);
                table.Insert(i, 0, args[j]);
            }

            for (int i = 1; i < table.Y; i++)
            {
                for (int j = 1; j < table.X; j++)
                {
                    switch (this.Fight(j - 1, i - 1, args))
                    {
                        case 1:
                            table.Insert(j,i,"Win");
                            break;
                        case 0:
                            table.Insert(j, i, "Draw");
                            break;
                        case -1:
                            table.Insert(j, i, "Lose");
                            break;
                    }
                }
            }
        }

        public int Fight(int ind1, int ind2, string[] args)
        {
            int len = (args.Length - 1) / 2;
            if (ind1 < ind2)
            {
                if (ind1 + len >= ind2)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }
            else if (ind1 > ind2)
            {
                if (ind1 + len >= args.Length)
                {
                    int delta = ind1 + len - args.Length;
                    if (delta >= ind2)
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
    }
}
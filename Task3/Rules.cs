namespace Task3
{
    public class Rules
    {
        
        private void FillTable(Table table)
        {
            for (int i = 1, j = 0; i < table.GetLength(0); i++, j++)
            {
                table[0, i] = args[j];
                table[i, 0] = args[j];
            }

            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    switch (Win(i - 1, j - 1))
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

        public int GetRules(int ind1, int ind2, int length)
        {
                int len = (length - 1) / 2;
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
                    if (ind1 + len >= length)
                    {
                        int delta = ind1 + len - length;
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
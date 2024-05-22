using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using static Sapper.MainWindow;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Sapper
{
    public class MineGenerator
    {
        public TextBlock Score;

        public MineGenerator(ref TextBlock score) 
        { 
            Score = score;
        }



        public void plantMines(int mines, int FieldSize, int[,] Field)
        {
            int currentMines = 0;
            var random = new Random();

            while (currentMines < mines)
            {
                Field[random.Next(0, 10), random.Next(0, 10)] = 9;
                currentMines++;
            }

            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    if (Field[i, j] == 9)
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            for (int y = -1; y <= 1; y++)
                            {
                                if (x == 0 && y == 0)
                                {
                                    continue;
                                }

                                int ni = i + x;
                                int nj = j + y;

                                if (ni >= 0 && ni < FieldSize && nj >= 0 && nj < FieldSize && Field[ni, nj] != 9)
                                {
                                    Field[ni, nj]++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

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
        public void plantMines(int mines, int FieldSizeX, int FieldSizeY, int[,] Field)
        {
            int currentMines = 0;
            var random = new Random();

            while (currentMines < mines)
            {
                Field[random.Next(0, FieldSizeX), random.Next(0, FieldSizeY)] = 9;
                currentMines++;
            }

            for (int i = 0; i < FieldSizeX; i++)
            {
                for (int j = 0; j < FieldSizeY; j++)
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

                                if (ni >= 0 && ni < FieldSizeX && nj >= 0 && nj < FieldSizeY && Field[ni, nj] != 9)
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

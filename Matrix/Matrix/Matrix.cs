using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int[,] Matrices { get; set; }

        public Matrix(int rows,int columns)
        {
            Rows = rows;
            Columns = columns;
            Random random = new Random();
            Matrices = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Matrices[i, j] = random.Next(10, 100);
                }
            }
        }
             
    }
}

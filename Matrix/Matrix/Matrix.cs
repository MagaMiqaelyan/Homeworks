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
        public int[,] MatixContant { get; set; }
        
        public Matrix(int rows,int columns)
        {
            Rows = rows;
            Columns = columns;
            Random random = new Random();
            MatixContant = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    MatixContant[i, j] = random.Next(10, 100);
                }
            }
        }

        /// <summary>
        /// Creating matrix[i,j] index 
        /// </summary>
        /// <param name="i">Matrix row</param>
        /// <param name="j">Matrix column</param>
        /// <returns></returns>
        public int this[int i, int j]
        {
            get
            {
                return MatixContant[i, j];
            }
            set
            {
                this.MatixContant[i, j] = value;
            }
        }            

        /// <summary>
        /// Creating matrix copy that other methods can't mutilate our matrix
        /// </summary>
        /// <param name="source">Our matrix</param>
        /// <param name="copy">Copy matrix</param>
        public void Copy(Matrix source, Matrix copy)
        {
            for (int i = 0; i < source.Rows; i++)
            {
                for (int j = 0; j < source.Columns; j++)
                {
                    copy[i, j] = source[i, j];
                }
            }
        }

        /// <summary>
        /// Method that print our matrix 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="rows">Matrix row</param>
        /// <param name="columns">Matrix column</param>
        public void Print(Matrix result, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Count two matrix summary
        /// </summary>
        /// <param name="matrix1">First matrix</param>
        /// <param name="matrix2">Second matrix</param>
        public void Add(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            Print(result, matrix1.Rows, matrix1.Columns);
        }

        /// <summary>
        /// Count two matrix multiplication
        /// </summary>
        /// <param name="matrix1">First matrix</param>
        /// <param name="matrix2">Second matrix</param>
        public void Multiplication(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            Print(result, matrix1.Columns, matrix1.Columns);
        }

        /// <summary>
        /// Multiply the number with the matrix
        /// </summary>
        /// <param name="scalar">Number</param>
        /// <param name="matrix">Matrix</param>
        /// <returns></returns>
        public Matrix ScalarMul(int scalar, Matrix matrix)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Columns);
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    result.MatixContant[i, j] = scalar * matrix.MatixContant[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Count matrix determinant
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="n">Size matrix</param>
        /// <returns></returns>
        public double Determinant(Matrix matrix, int n)
        {
            double det = 0;
            Matrix Copy = new Matrix(n, n);
            if (n == 2)
            {
                return ((matrix[0, 0] * matrix[1, 1]) - (matrix[1, 0] * matrix[0, 1]));
            }
            else
            {
                for (int k = 0; k < n; k++)
                {
                    int ci = 0;
                    for (int i = 1; i < n; i++)
                    {
                        int cj = 0;
                        for (int j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            Copy[ci, cj] = matrix[i, j];
                            cj++;
                        }
                        ci++;
                    }
                    det = det + (Math.Pow(-1, k) * matrix[0, k] * Determinant(Copy, n - 1));
                }
            }
            return det;
        }

        /// <summary>
        /// Count matrix inverse
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="n">Size matrix</param>
        /// <returns></returns>
        public Matrix Inverse(Matrix matrix, int n)
        {
            return ScalarMul(Convert.ToInt32(1 / Determinant(matrix, n)), Transpose(matrix));
        }

        /// <summary>
        /// Count matrix transpose
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <returns></returns>
        public Matrix Transpose(Matrix matrix)
        {
            Matrix transpose = matrix;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = i + 1; j < matrix.Columns; j++)
                {
                    int temp = transpose[i, j];
                    transpose[i, j] = transpose[j, i];
                    transpose[j, i] = temp;
                }
            }
            return transpose;
        }

        /// <summary>
        /// Check if the matrix is orthogonal
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool Orthogonal(Matrix matrix, int n)
        {
            Matrix m1 = Inverse(matrix, n);
            Matrix m2 = Transpose(matrix);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m1[i, j] != m2[i, j])
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Find the maximum element in the matrix
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <returns></returns>
        public int MaxElement(Matrix matrix)
        {
            int max = matrix.MatixContant[0, 0];
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;

        }

        /// <summary>
        /// Find the minimum element in the matrix
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <returns></returns>
        public int MinElement(Matrix matrix)
        {
            int min = matrix.MatixContant[0, 0];
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                    }
                }
            }
            return min;
        }

     }
}

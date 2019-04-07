using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class OperationsWithMatrix
    {
        public void Copy(Matrix source, Matrix copy)
        {
            for (int i = 0; i < source.Rows; i++)
            {
                for (int j = 0; j < source.Columns; j++)
                {
                    copy.Matrices[i, j] = source.Matrices[i, j];
                }
            }
        }
        public void Print(Matrix result, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(result.Matrices[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void Add(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1.Rows,matrix1.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result.Matrices[i, j] = matrix1.Matrices[i, j] + matrix2.Matrices[i, j];
                }
            }
            Print(result, matrix1.Rows, matrix1.Columns);
        }
        public void Multiplication(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    result.Matrices[i, j] = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        result.Matrices[i, j] += matrix1.Matrices[i, k] * matrix2.Matrices[k, j];
                    }
                }
            }
            Print(result, matrix1.Columns, matrix1.Columns);
        }
        public Matrix ScalarMul(int scalar, Matrix matrix)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Columns);
            for (int i = 0; i <matrix.Rows ; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    result.Matrices[i, j] = scalar * matrix.Matrices[i, j];
                }
            }
            return result;
        }
        public double Determinant(Matrix matrix, int n)
        {
            double det = 0;
            Matrix Copy = new Matrix(n, n);
            if (n == 2)
            {
                return ((matrix.Matrices[0, 0] * matrix.Matrices[1, 1]) - (matrix.Matrices[1, 0] * matrix.Matrices[0, 1]));
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
                            Copy.Matrices[ci, cj] = matrix.Matrices[i, j];
                            cj++;
                        }
                        ci++;
                    }
                    det = det + (Math.Pow(-1, k) * matrix.Matrices[0, k] * Determinant(Copy, n-1));
                }
            }
            return det;
        }
        public Matrix Inverse(Matrix matrix, int n)
        {
            return ScalarMul(Convert.ToInt32(1 / Determinant(matrix, n)), Transpose(matrix));
        }
        public Matrix Transpose(Matrix matrix)
        {
            Matrix transpose = matrix;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = i + 1; j < matrix.Columns; j++)
                {
                    int temp = transpose.Matrices[i, j];
                    transpose.Matrices[i, j] = transpose.Matrices[j, i];
                    transpose.Matrices[j, i] = temp;
                }
            }
            return transpose;
        }
        public bool Orthogonal(Matrix matrix, int n)
        {
            Matrix m1 = Inverse(matrix, n);
            Matrix m2 = Transpose(matrix);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m1.Matrices[i, j] != m2.Matrices[i, j])
                        return false;
                }
            }
            return true;
        }
        public int MaxElement(Matrix matrix)
        {
            int max = matrix.Matrices[0, 0];
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (max < matrix.Matrices[i, j]) 
                    {
                        max = matrix.Matrices[i, j];
                    }
                }
            }
            return max;

        }
        public int MinElement(Matrix matrix)
        {
            int min = matrix.Matrices[0, 0];
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (min > matrix.Matrices[i, j])
                    {
                        min = matrix.Matrices[i, j];
                    }
                }
            }
            return min;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the size of the first matrix");
            int rows1 = Convert.ToInt32(Console.ReadLine());
            int columns1 = Convert.ToInt32(Console.ReadLine());
            Matrix matrix1 = new Matrix(rows1, columns1);

            {
                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix1.Columns; j++)
                    {
                        Console.Write(matrix1.Matrices[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Please enter the size of the second matrix");
            int rows2 = Convert.ToInt32(Console.ReadLine());
            int columns2 = Convert.ToInt32(Console.ReadLine());
            Matrix matrix2 = new Matrix(rows2, columns2);
            {
                for (int i = 0; i < matrix2.Rows; i++)
                {
                    for (int j = 0; j < matrix2.Columns; j++)
                    {
                        Console.Write(matrix2.Matrices[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            var Op = new OperationsWithMatrix();
            Matrix copy = new Matrix(rows1, columns1);

            if (matrix1.Rows == matrix2.Rows && matrix1.Columns == matrix2.Columns)
            {
                Console.WriteLine("\nAddition");
                Op.Add(matrix1, matrix2);
            }
            else
                Console.WriteLine("\nMatrix addition not possible");

            if (matrix1.Columns == matrix2.Rows)
            {
                Console.WriteLine("\nMultiplication");
                Op.Multiplication(matrix1, matrix2);
            }
            else
                Console.WriteLine("\nMatrix multiplication not possible");

            Console.Write("\nEnter the scalar ");
            int scalar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Scalar Multiplication");
            Op.Copy(matrix1, copy);
            Op.ScalarMul(scalar, copy);
            Op.Print(copy, copy.Rows, copy.Columns);

            if (rows1 == columns1)
            {
                Console.WriteLine("\nInverse matrix ");
                Op.Copy(matrix1, copy);
                Op.Inverse(copy, rows1);
                Op.Print(copy, copy.Rows, copy.Rows);
            }
            else
                Console.WriteLine("\nMatrix inverstion not possible");

            Console.WriteLine("\nTranspose matrix ");
            Op.Copy(matrix1, copy);
            Op.Transpose(copy);
            Op.Print(copy, copy.Rows,copy.Columns);

            if (rows1 == columns1) 
            {
                Op.Copy(matrix1, copy);
                if (Op.Orthogonal(copy, rows1))
                    Console.WriteLine("\nMatrix is orthogonal ");
                else Console.WriteLine("\nMatrix isn't orthogonal");
            }

            Console.WriteLine("\nMax element is "+ Op.MaxElement(matrix1));
            Console.WriteLine("Min element is " + Op.MinElement(matrix1));
        }
    }
}

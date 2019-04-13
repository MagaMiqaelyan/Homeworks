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
            Matrix matrix1 = new Matrix(rows1, columns1); // Creating first matrix
            matrix1.Print(matrix1, rows1, columns1);

            Console.WriteLine("Please enter the size of the second matrix");
            int rows2 = Convert.ToInt32(Console.ReadLine());
            int columns2 = Convert.ToInt32(Console.ReadLine());
            Matrix matrix2 = new Matrix(rows2, columns2); // Creating second matrix        
            matrix2.Print(matrix2, rows2, columns1);
            
            Matrix copy = new Matrix(rows1, columns1);

            if (matrix1.Rows == matrix2.Rows && matrix1.Columns == matrix2.Columns) // Check if it is possible to add
            {
                Console.WriteLine("\nAddition");
                matrix1.Add(matrix1, matrix2);
            }
            else
                Console.WriteLine("\nMatrix addition not possible");

            if (matrix1.Columns == matrix2.Rows) // Check if it is possible to multiply
            {
                Console.WriteLine("\nMultiplication");
                matrix1.Multiplication(matrix1, matrix2);
            }
            else
                Console.WriteLine("\nMatrix multiplication not possible");

            Console.Write("\nEnter the scalar ");
            int scalar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Scalar Multiplication");
            matrix1.Copy(matrix1, copy);  
            matrix1.ScalarMul(scalar, copy); 
            matrix1.Print(copy, copy.Rows, copy.Columns);

            if (rows1 == columns1) // Check if it is possible inverstion
            {
                Console.WriteLine("\nInverse matrix ");
                matrix1.Copy(matrix1, copy);
                matrix1.Inverse(copy, rows1);
                matrix1.Print(copy, copy.Rows, copy.Rows);
            }
            else
                Console.WriteLine("\nMatrix inverstion not possible");

            Console.WriteLine("\nTranspose matrix ");
            matrix1.Copy(matrix1, copy);
            matrix1.Transpose(copy);
            matrix1.Print(copy, copy.Rows,copy.Columns);

            if (rows1 == columns1) // Check if it is a square matrix
            {
                matrix1.Copy(matrix1, copy);
                if (matrix1.Orthogonal(copy, rows1))
                    Console.WriteLine("\nMatrix is orthogonal ");
                else Console.WriteLine("\nMatrix isn't orthogonal");
            }

            Console.WriteLine("\nMax element is "+ matrix1.MaxElement(matrix1));
            Console.WriteLine("Min element is " + matrix1.MinElement(matrix1));
        }
    }
}

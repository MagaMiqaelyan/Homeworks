using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local);" +
                     "Initial Catalog=AdventureWorks_Final;" +
                     "Integrated Security=true";
            #region Example1          

            // Provide the query string with a parameter place holder.
            string queryString = "select * from Production.Product " +
                                "where ProductLine = 'S' and DaysToManufacture < @days " +
                                "Order by DaysToManufacture";

            // Specify the parameter value.
            int paramValue = 5;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@days", paramValue);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            #endregion
            Console.WriteLine();
            #region Example2
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT JobTitle, Count(JobTitle) as Title FROM HumanResources.Employee GROUP BY JobTitle;" +
                  "SELECT Name, ProductNumber FROM Production.Product",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    Console.WriteLine("\t{0}\t{1}", reader.GetName(0),
                        reader.GetName(1));

                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0],
                            reader[1]);
                    }
                    reader.NextResult();
                }
            }
            #endregion
            Console.WriteLine();
            #region Example3
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM Sales.SalesOrderDetail",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                DataTable schemaTable = reader.GetSchemaTable();

                foreach (DataRow row in schemaTable.Rows)
                {
                    foreach (DataColumn column in schemaTable.Columns)
                    {
                        Console.WriteLine(String.Format("{0} = {1}",
                           column.ColumnName, row[column]));
                    }
                    Console.WriteLine();
                }
            }
            #endregion
            
        }
    }
}

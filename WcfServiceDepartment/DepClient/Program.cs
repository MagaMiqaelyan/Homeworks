using System;
using System.Collections.Generic;
using WcfServiceDepartment;

namespace DepClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceDep client = new ServiceDep();
            List<Department> dep = client.GetDeparmentNames("Research and Development");
            if (dep.Count == 0)
            {
                Console.WriteLine("Something is wrong");
            }
            else
            {
                foreach (var item in dep)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.DepartmentId, item.Name, item.GroupName);
                }
            }
            //Department department = new Department()
            //{
            //    DepartmentId = 17,
            //    Name = "Finance",
            //    GroupName = "Sales and Marketing"
            //};
            //Console.WriteLine(client.InsertDeparment(department));
            Console.ReadKey();
        }
    }
}

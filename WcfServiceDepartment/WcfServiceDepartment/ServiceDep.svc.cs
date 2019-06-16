using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WcfServiceDepartment
{   
    public class ServiceDep : IServiceDep
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source = (local);" +
                     "Initial Catalog=AdventureWorks_Final;" +
                     "Integrated Security=true");
        
        public List<Department> GetDeparmentNames(string groupName)
        {
            List<Department> departments = new List<Department>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from HumanResources.Department where GroupName=@Name", sqlConnection);
            cmd.Parameters.AddWithValue("@Name", groupName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Department departmentInfo = new Department();
                    departmentInfo.DepartmentId = Convert.ToInt32(dt.Rows[i]["DepartmentId"]);
                    departmentInfo.Name = dt.Rows[i]["Name"].ToString();
                    departmentInfo.GroupName = dt.Rows[i]["GroupName"].ToString();
                    departments.Add(departmentInfo);
                }
            }
            sqlConnection.Close();
            return departments;
        }

        //public string InsertDeparment(Department department)
        //{
        //    string message = "";
        //    sqlConnection.Open();
        //    SqlCommand cmd = new SqlCommand("insert into HumanResources.Department(DepartmentId, Name, GroupName) values(@DepId, @Name, @GroupName)", sqlConnection);
        //    cmd.Parameters.AddWithValue("@DepId", department.DepartmentId);
        //    cmd.Parameters.AddWithValue("@Name", department.Name);
        //    cmd.Parameters.AddWithValue("@GroupName", department.GroupName);
        //    int result = cmd.ExecuteNonQuery();
        //    if (result == 1)
        //    {
        //        message = "Inserted successfully";
        //    }
        //    else
        //    {
        //        message = "Not inserted ";
        //    }
        //    sqlConnection.Close();
        //    return message;
        //}
    }
}    


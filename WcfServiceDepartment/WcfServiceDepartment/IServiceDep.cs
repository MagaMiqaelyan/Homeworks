using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceDepartment
{   
    [ServiceContract]
    public interface IServiceDep
    {
        [OperationContract]
        List<Department> GetDeparmentNames(string groupName);
        //string InsertDeparment(Department department);

    }
        
    [DataContract]
    public class Department
    {        
        [DataMember]
        public int DepartmentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string GroupName { get; set; }
    }
}

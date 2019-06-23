using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Linq;

namespace Customers
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        string Test(string s);
        [OperationContract]
        void XmlMethod(XElement xml);
        [OperationContract]
        CustomModel TestCustomModel(CustomModel inputModel);
    }

    [DataContract]
    public class CustomModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}

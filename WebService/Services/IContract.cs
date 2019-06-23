using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        string GetMessage(string msg);
    }
}

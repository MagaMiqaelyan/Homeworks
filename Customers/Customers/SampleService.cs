using System;
using System.Xml.Linq;

namespace Customers
{
    public class SampleService : ISampleService
    {
        public string Test(string s)
        {
            Console.WriteLine("Test Method Executed!");
            return s;
        }

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }

        public CustomModel TestCustomModel(CustomModel customModel)
        {
            return customModel;
        }
    }
}

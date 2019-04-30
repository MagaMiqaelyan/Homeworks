using System;
using System.Reflection;

namespace MyClone
{
    abstract class BaseObject : ICloneable
    {                   
        public object Clone()
        {
            var CopiedObject = Activator.CreateInstance(this.GetType());  //An instance of this specific type.
            FieldInfo[] fields = CopiedObject.GetType().GetFields(); // Get all fields.
            foreach (var field in fields)
            {
                if (field != null) 
                {
                    field.SetValue(CopiedObject, field.GetValue(this));
                }
            }
            return CopiedObject;            
        }
    }

     class Person : BaseObject
     {
        public string firstname;
        public string lastname;
        public int age;       
        public double weight;
        public double height;      
     }
    class Employee : BaseObject
    {
        public string name;
        public int salary;
        public int salarybonus;
        public int salaryday;
    }
}

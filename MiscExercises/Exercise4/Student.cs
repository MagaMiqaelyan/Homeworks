using System;
using System.Collections.Generic;

namespace Exercise4
{
    class Student
    {
        public string Name { get; set; }
        public int Id { get; private set; }
        public Dictionary<string, int> TestScors = new Dictionary<string, int>();

        public Student(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
       public void AddTestResult(string x, int y)
       {
            TestScors.Add(x, y);
       }
    }
}

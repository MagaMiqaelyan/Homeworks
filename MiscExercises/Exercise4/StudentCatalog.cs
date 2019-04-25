using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class StudentCatalog
    {
        public Dictionary<int, Student> Catalog = new Dictionary<int, Student>();

        /// <summary>
        /// Add a single student to the catalog. 
        /// </summary>       
        public void AddStudent(Student aStudent)
        {
            Catalog.Add(aStudent.Id, aStudent);
        }

        /// <summary>         
        /// Given an id, return the student with that id.       
        /// If no student exists with the given id, return null.       
        /// </summary>       
        public Student GetStudent(int id)
        {
            if(Catalog.ContainsKey(id))
            {
                return Catalog[id];
            }
            else return null;
        }

        /// <summary>
        /// Given an id, return the score average for the student with that id.         
        /// If no student exists with the given id, return -1.   
        /// </summary>
        public double GetAverageForStudent(int id)
        {
            int average = 0;
                     
            if (Catalog.ContainsKey(id))
            {
                foreach (var item in Catalog[id].TestScors.Keys)
                {
                    average += Catalog[id].TestScors[item];
                }
                return average / Catalog[id].TestScors.Count;
            }            
            
            return -1;
        }
        /// <summary>         
        /// Returns the total test score average for ALL students in the catalog.         
        /// Note that only students with a "real" score average (i.e. NOT -1) should        
        /// be included in the calculation of the average.         
        /// </summary>       
        public double GetTotalAverage()
        {
            var avg = new List<double>();
            foreach (int students in Catalog.Keys)
            {
                if (GetAverageForStudent(students) != -1)
                {
                    avg.Add(GetAverageForStudent(students));
                }
            }
            return avg.Average();
        }
        /// <summary>         
        /// Get top three students who have the highest average score.         
        /// If no student returns empty list.         
        /// </summary>         
        public List<Student> GetTopThreeStudents()
        {
            var HighestScoreStudents = new List<Student>();
            var avg = new Dictionary<double, Student>();

            foreach (int students in Catalog.Keys)
            {
                if (GetAverageForStudent(students) != -1)
                {
                    avg.Add(GetAverageForStudent(students), Catalog[students]);
                }
            }
            avg.OrderBy(x => x.Key);
            for (double i = 0; i < 3; ++i)
            {
                HighestScoreStudents.Add(avg[i]);
            }
            for (int i = 0; i < HighestScoreStudents.Count; i++)
            {
                Console.WriteLine(HighestScoreStudents[i]);
            }
        
            return HighestScoreStudents;
        }

    }
}

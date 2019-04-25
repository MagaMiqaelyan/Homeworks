using System;
using System.Collections.Generic;
using System.Media;

namespace Exercise1
{
    class OnlineAttendance
    {
        public event Action<string> BannedName;
        private List<string> Names { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public OnlineAttendance()
        {            
        }
       
        /// <summary>
        /// Users input their name and it check if names are banned for the organization.
        /// </summary>
        public void Conditions()
        {
            var random = new Random();           
            Names = new List<string>();

            for (int i = 0; ; i++)
            {
                Console.WriteLine("Please input your name ");
                Names.Add(Console.ReadLine());

                if(BannedName != null && (Names[i] == "Jack" || Names[i] == "Steven" || Names[i] == "Mathew"))
                {
                    this.BannedName(Names[i]);
                    SystemSounds.Beep.Play();                   
                }
                else Console.WriteLine("Welcome to {0}", Names[i]);
            }
        }
    }
}

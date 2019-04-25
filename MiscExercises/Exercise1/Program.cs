using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new OnlineAttendance();
            user.BannedName += User_BannedName;
            user.Conditions();

        }

        private static void User_BannedName(string obj)
        {
            Console.WriteLine("User name is banned");
        }

    }
}
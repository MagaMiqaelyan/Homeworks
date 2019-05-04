namespace Enumerators
{
    public class University
    {
        public string Name { get; set; }
        public string Place { get; set; }

        public University(string Name, string Country)
        {         
            this.Name = Name;
            this.Place = Country;
        }
    }   
}

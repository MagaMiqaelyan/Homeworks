using System.Collections.Generic;

namespace Exercise3
{
    /// <summary>
    /// Class represents an airpor
    /// </summary>
    public class Airport
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Size { get; set; }
        public AirportSize AirportSize { get; set; }

    }
    public enum AirportSize
    {
        Small = 0,
        Medium = 1,
        Large = 2,
        Mega = 3,
        SuperMega = 4
    };    
}

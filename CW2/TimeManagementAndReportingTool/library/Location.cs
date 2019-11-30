using System;

namespace library
{
    public class Location
    {
        private readonly int Id;
        private string Name { get; set; }
        private string AddressLine1 { get; set; }
        private string AddressLine2 { get; set; }
        private string City { get; set; }
        private string PostCode { get; set; }
        private string Country { get; set; }

        public Location(string Name, string AddressLine1, string AddressLine2, string City, string PostCode, string Country)
        {
            this.Name = Name;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.City = City;
            this.PostCode = PostCode;
            this.Country = Country;
        }

        public void GetLocation(int Id)
        {
            DAC dac = new DAC();  
        }
    }
}

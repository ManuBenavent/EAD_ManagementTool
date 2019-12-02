using System;

namespace library
{
    public class Location
    {
        private int _Id;
        public int Id { get { return _Id; } }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        private readonly DAC ddbb;
        internal string SQLCreateString { 
            get {
                return "('" + Name + "','" + AddressLine1 + "','" + AddressLine2 + "','" + City + "','" + PostCode + "','" + Country + "')";
            }
        }
        internal string SQLGetString { 
            get {
                return "Location WHERE Name='" + Name + "' and AddrLine1='" + AddressLine1 + "' and AddrLine2='" + AddressLine2
                    + "' and City='" + City + "' and Postcode='" + PostCode + "' and Country='" + Country + "'";
            } 
        }
        internal string SQLUpdateString { 
            get { 
                return "Location set Name = '" + Name + "',AddrLine1 = '" + AddressLine1 + "',AddrLine2='" + AddressLine2
                        + "',City='" + City + "',Postcode='" + PostCode + "',Country='" + Country + "'";
            } 
        }
        public Location(string Name, string AddressLine1, string AddressLine2, string City, string PostCode, string Country)
        {
            this.Name = Name;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.City = City;
            this.PostCode = PostCode;
            this.Country = Country;
            this.ddbb = new DAC();
        }

        public void Create()
        {
            ddbb.Create(this);
            _Id = ddbb.GetId(this);
        }

        public void Update()
        {
            ddbb.Update(this);
        }

        public void Delete()
        {
            ddbb.Delete(this);
        }
    }
}

using System;

namespace library
{
    public class Location : ISQLAccess
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
        public string SQLCreateString { 
            get {
                return "('" + Name + "','" + AddressLine1 + "','" + AddressLine2 + "','" + City + "','" + PostCode + "','" + Country + "')";
            }
        }
        public string SQLGetString { 
            get {
                return "Location WHERE Name='" + Name + "' and AddrLine1='" + AddressLine1 + "' and AddrLine2='" + AddressLine2
                    + "' and City='" + City + "' and Postcode='" + PostCode + "' and Country='" + Country + "'";
            } 
        }
        public string SQLUpdateString { 
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

        public Location()
        {
            this.Name = null;
            this.AddressLine1 = null;
            this.AddressLine2 = null;
            this.City = null;
            this.PostCode = null;
            this.Country = null;
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

        public bool IsNull()
        {
            return Name == null && AddressLine1 == null && AddressLine2 == null && City == null && Country == null && PostCode == null;
        }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   _Id == location._Id &&
                   Id == location.Id &&
                   Name == location.Name &&
                   AddressLine1 == location.AddressLine1 &&
                   AddressLine2 == location.AddressLine2 &&
                   City == location.City &&
                   PostCode == location.PostCode &&
                   Country == location.Country;
        }
    }
}

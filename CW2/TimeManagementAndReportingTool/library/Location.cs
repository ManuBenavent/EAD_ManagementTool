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
        DAC_Location dac;

        public Location()
        {
            this.dac = new DAC_Location();
        }

        public Location(string Name, string AddressLine1, string AddressLine2, string City, string PostCode, string Country)
        {
            this.Name = Name;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.City = City;
            this.PostCode = PostCode;
            this.Country = Country;
            this.dac = new DAC_Location();
        }

        /// <summary>
        /// Insert this instance.
        /// </summary>
        /// <returns>The insert.</returns>
        public bool Insert()
        {
            return dac.Create(this);
        }

        public bool Update()
        {
            return dac.Update(this);
        }

        public bool Delete()
        {
            return dac.Delete(this);
        }

        public void Read(int Id)
        {
            this._Id = Id;
            dac.Read(this);
        }
    }
}

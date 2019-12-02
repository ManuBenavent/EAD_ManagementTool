using System;
using System.Collections.Generic;
using System.Data;

namespace library
{
    public class Contact
    {
        private int _Id;
        public int Id { get { return _Id; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        private readonly DAC ddbb;
        internal string SQLCreateString { 
            get {
                return "('" + FirstName + "','" + LastName + "','" + Email + "','" + Phone + "')"; 
            } 
        }
        internal string SQLGetString { 
            get{ 
                return "Contact WHERE FirstName='" + FirstName + "' and LastName='" + LastName + "' and Email='" + Email + "' and Phone='" + Phone+"'"; 
            } 
        }
        internal string SQLUpdateString { 
            get{ 
                return "Contact set FirstName='" + FirstName + "', LastName='" + LastName + "', Email='" + Email + "', Phone='" + Phone + "'"; 
            } 
        }
        public Contact () {
            this._Id = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            ddbb = new DAC();
        }
        
        public Contact ( string FirstName, string LastName, string Email, string Phone ) {
            this._Id = -1;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            ddbb = new DAC();
        }
        
        public void Create() {
            ddbb.Create(this);
            _Id = ddbb.GetId(this);
        }
        
        public void Update() {
            ddbb.Update(this);
        }
        
        public void Delete() {
            ddbb.Delete(this);
        }
        
        public DataTable ListContacts()
        {
            return ddbb.ListContacts();
        }

        /*public static void read (int Id) {
            this.Id = Id;
            ddbb.readContact(this); //TODO review so DRY is applied
        }
        
        public static List<Contact> read () {
            return ddbb.readContacts();
        }*/
            
    }
}

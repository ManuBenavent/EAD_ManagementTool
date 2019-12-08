using library.exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace library
{
    public class Contact : ISQLAccess
    {
        private int _Id;
        public int Id { get { return _Id; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        private readonly DAC ddbb;
        public string SQLCreateString { 
            get {
                return "('" + FirstName + "','" + LastName + "','" + Email + "','" + Phone + "')"; 
            } 
        }
        public string SQLGetString { 
            get{ 
                return "Contact WHERE FirstName='" + FirstName + "' and LastName='" + LastName + "' and Email='" + Email + "' and Phone='" + Phone+"'"; 
            } 
        }
        public string SQLUpdateString { 
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
            try
            {
                _Id = ddbb.GetId(this);
            }catch(DDBBException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public Contact(int Id,  string FirstName, string LastName, string Email, string Phone)
        {
            this._Id = Id;
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
            return ddbb.ContactsIntoTable();
        }
        
        public static List<Contact> Read () {
            DAC dac = new DAC();
            return dac.ListContacts();
        }

        public override bool Equals(object obj)
        {
            return obj is Contact contact &&
                   _Id == contact._Id &&
                   Id == contact.Id &&
                   FirstName == contact.FirstName &&
                   LastName == contact.LastName &&
                   Email == contact.Email &&
                   Phone == contact.Phone;
        }
    }
}

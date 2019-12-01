using System;
using System.Collections.Generic;

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
        private DAC ddbb;
        public string SQLString { get { return "('" + FirstName + "','" + LastName + "','" + Email + "','" + Phone + "')"; } }
        public Contact () {
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
        }
        
        /*public void update() {
            ddbb.Update(this);
        }
        
        public void delete() {
            ddbb.delete(this);
        }
        
        public static void read (int Id) {
            this.Id = Id;
            ddbb.readContact(this); //TODO review so DRY is applied
        }
        
        public static List<Contact> read () {
            return ddbb.readContacts();
        }*/
            
    }
}

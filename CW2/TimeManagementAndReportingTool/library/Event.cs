using System;
using System.Collections.Generic;

namespace library
{
    public abstract class Event {
        private int _Id;
        public int Id { get { return _Id; } }
        public string Name { get; set; }
        public bool Recurring { get; set; }
        public abstract string SQLCreateString { get; }
        public abstract string SQLUpdateString { get; }
        public abstract string SQLGetString { get; }
        private DAC ddbb;
        
        public Event (string Name, bool Recurring)
        {
            this.Name = Name;
            this.Recurring = Recurring;
            ddbb = new DAC();
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

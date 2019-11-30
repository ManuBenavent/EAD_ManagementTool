using System;
using System.Collections.Generic;

namespace library
{
    public abstract class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Recurring { get; set; }
        DAC ddbb;
        
        public Event (string Name, bool Recurring)
        {
            this.Name = Name;
            this.Recurring = Recurring;
            ddbb = new DAC();
        }
        
        /*public static List<Event> read ()
        {
            return ddbb.readEvent();
        }*/
         
          
    }
}

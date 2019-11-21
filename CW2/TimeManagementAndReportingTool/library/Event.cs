using System;

namespace library
{
    public abstract class Location
    {
        public string Name { get; set; }
        public bool Recurring { get; set; }
        DAC ddbb;
        
        public Event (string Name, bool Recurring)
        {
            this.Name = Name;
            this.Recurring = Recurring;
            ddbb = new DAC();
        }
        
        public static List<Event> read ()
        {
            return ddbb.readEvent();
        }
         
          
    }
}

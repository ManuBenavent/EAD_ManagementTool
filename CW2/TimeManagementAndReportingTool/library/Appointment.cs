using System;

namespace library
{
    public class Appointment : Event
    {
        public Appointment (string Name, bool Recurring) : base (Name, Recurring)
        {
        }
        
        public void create() // TODO DRY
        {
        }
        
        public void update()
        {
        }
        
        public void delete()
        {
        }
        
        public void read(int Id)
        {
        }
        
    }
}

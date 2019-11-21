using System;

namespace library
{
    public class Appointment : Event
    {
        public Appointment (string Name, bool Recurring)
        {
            super( Name, Recurring );
        }
        
        public void create() // TODO DRY
        {
            super.ddbb.create(this); 
        }
        
        public void update()
        {
            ddbb.update(this);
        }
        
        public void delete()
        {
            ddbb.delete(this);
        }
        
        public void read(int Id)
        {
            super.Id = Id;
            super.ddbb.read(this);
        }
        
    }
}

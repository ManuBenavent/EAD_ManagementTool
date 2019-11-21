using System;

namespace library
{
    public class Lecture : Event
    {
        public string Lecturer { get; set; }
        
        public Lecture(string Name, bool Recurring, string Lecturer)
        {
            super( Name, Recurring );
            this.Lecturer = Lecturer;
        }
        
        public void create() //TODO if it defined at event but called as Lecture, what type of instance is it considered? Apply DRY
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

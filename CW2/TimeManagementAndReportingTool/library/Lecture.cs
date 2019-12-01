using System;

namespace library
{
    public class Lecture : Event
    {
        public string Lecturer { get; set; }
        
        public Lecture(string Name, bool Recurring, string Lecturer) : base(Name, Recurring)
        {
            this.Lecturer = Lecturer;
        }
        
        public void create() //TODO if it defined at event but called as Lecture, what type of instance is it considered? Apply DRY
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
     */   
    }
}

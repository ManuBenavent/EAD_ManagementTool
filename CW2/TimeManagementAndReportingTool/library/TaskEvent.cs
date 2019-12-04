using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class TaskEvent : EventClass
    {
        public override string SQLCreateString { 
            get { 
                return "('" + base.Name + "','" + base.Recurring + "','" + Finished + "','" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "','" + (location == null ? "NULL" : location.Id.ToString()) + "')"; 
            } 
        }
        public override string SQLGetString { 
            get { 
                return "Task WHERE Name = '" + Name + "' and Recurring='"+Recurring + "' and Finished='" + Finished + "' and Date='" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "' and FK_Location=" + (location == null ? "NULL" : location.Id.ToString());
            } 
        }
        public override string SQLUpdateString { 
            get { 
                return "Task Set Name='" + Name + "', Recurring='" + Recurring + "', Finished='" + Finished + "', Date='" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "', FK_Location=" + (location == null ? "NULL" : location.Id.ToString());
            } 
        }
        public bool Finished { get; set; }
        public TaskEvent(string Name, bool Recurring, bool Finished, DateTime Date) : base(Name, Recurring, Date)
        {
            this.Finished = Finished; 
        }

        internal TaskEvent(int Id, string Name, bool Recurring, bool Finished, DateTime Date) : base(Id, Name, Recurring, Date)
        {
            this.Finished = Finished;
        }

        public TaskEvent(int Id) : base(Id) { }
    }
}

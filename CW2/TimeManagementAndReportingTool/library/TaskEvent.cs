using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class TaskEvent : EventClass
    {
        internal override string SQLCreateString { 
            get { 
                return "('" + base.Name + "','" + base.Recurring + "','" + Finished + "','" + Date + "')"; 
            } 
        }
        internal override string SQLGetString { 
            get { 
                return "Task WHERE Name = '" + Name + "' and Recurring='"+Recurring + "' and Finished='" + Finished + "' and Date='" + Date+ "'"; 
            } 
        }
        internal override string SQLUpdateString { 
            get { 
                return "Task Set Name='" + Name + "', Recurring='" + Recurring + "', Finished='" + Finished + "', Date='" + Date + "'";
            } 
        }
        public bool Finished { get; set; }
        public TaskEvent(string Name, bool Recurring, bool Finished) : base(Name, Recurring)
        {
            this.Finished = Finished; 
        }
    }
}

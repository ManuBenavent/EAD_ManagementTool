using System;
using System.Collections.Generic;

namespace library
{
    public abstract class EventClass {
        /// <summary>
        /// DDBB row Id.
        /// </summary>
        private int _Id;
        /// <summary>
        /// Id getter.
        /// </summary>
        public int Id { get { return _Id; } }
        /// <summary>
        /// Name of the event.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Recurring property: true if there are equal events in future dates.
        /// </summary>
        public bool Recurring { get; set; }
        /// <summary>
        /// String used for inserting the values of the object into the DDBB.
        /// </summary>
        internal abstract string SQLCreateString { get; }
        /// <summary>
        /// Date and time of the event.
        /// </summary>
        public DateTime Date { get; set; }
        public string DateTimeString { 
            get 
            {
                return Date.Day + "/" + Date.Month + "/" + Date.Year + "-" + Date.Hour + ":" + Date.Minute;
            } 
        }
        /// <summary>
        /// String used for updating the values of the object in the DDBB.
        /// </summary>
        internal abstract string SQLUpdateString { get; }
        /// <summary>
        /// String used as getter for the Id in the SQL statements.
        /// </summary>
        internal abstract string SQLGetString { get; }
        /// <summary>
        /// Data Access Component object.
        /// </summary>
        private readonly DAC ddbb;
        /// <summary>
        /// Constructor: creates a new event. Since the class is abstract is called from subclasses.
        /// </summary>
        /// <param name="Name">Name of the event.</param>
        /// <param name="Recurring">True if the event is recurring.</param>
        public EventClass (string Name, bool Recurring, DateTime Date)
        {
            this.Name = Name;
            this.Recurring = Recurring;
            this.Date = Date;
            ddbb = new DAC();
        }

        public EventClass(int Id)
        {
            this._Id = Id;
            ddbb = new DAC();
            ddbb.ReadEvent(this);
        }

        /// <summary>
        /// Creates a new event in the DDBB.
        /// </summary>
        public void Create()
        {
            ddbb.Create(this);
            _Id = ddbb.GetId(this);
        }
        /// <summary>
        /// Updates the current event in the DDBB.
        /// </summary>
        public void Update()
        {
            ddbb.Update(this);
        }
        /// <summary>
        /// Deletes the current event in the DDBB.
        /// </summary>
        public void Delete()
        {
            ddbb.Delete(this);
        }
        
        public static List<EventClass> ListWeekEvents()
        {
            DAC dac = new DAC();
            return dac.ListWeekEvents("Date>='2019/12/02 00:00:00' and Date<='2019/12/08 23:59:59'");
        }
    }
}

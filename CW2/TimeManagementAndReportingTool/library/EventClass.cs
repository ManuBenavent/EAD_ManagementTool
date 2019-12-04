using library.exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace library
{
    public abstract class EventClass : ISQLAccess {
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
        public abstract string SQLCreateString { get; }

        public DateTime Date { get; set; }
        public string DateTimeString { 
            get 
            {
                return Date.Day + "/" + Date.Month + "/" + Date.Year + "-" + Date.Hour + ":" + Date.Minute;
            } 
        }

        public abstract string SQLUpdateString { get; }

        public abstract string SQLGetString { get; }
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
            try
            {
                _Id = ddbb.GetId(this);
            }
            catch (DDBBException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        internal EventClass(int Id, string Name, bool Recurring, DateTime Date)
        {
            this._Id = Id;
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
        
        public static List<EventClass> ListWeekEvents(int ChangeWeek)
        {
            DAC dac = new DAC();
            int diff = ((int)DateTime.Now.DayOfWeek - (int)DayOfWeek.Monday) % 7;
            DateTime initial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            initial = initial.Subtract(new TimeSpan(diff,0,0,0));
            initial = initial.Add(new TimeSpan(ChangeWeek * 7, 0, 0, 0));
            DateTime end = initial.Add(new TimeSpan(6, 23, 59, 59));
            return dac.ListWeekEvents("Date>='" + initial.ToString("yyyy/MM/dd HH:mm:ss") + "' and Date<='" + end.ToString("yyyy/MM/dd HH:mm:ss") + "'");
        }
    }
}

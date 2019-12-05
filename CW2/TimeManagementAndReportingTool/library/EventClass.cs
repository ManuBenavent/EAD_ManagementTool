using library.exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        public Location location { get; set; }

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
            /*try
            {
                _Id = ddbb.GetId(this);
            }
            catch (DDBBException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }*/
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
            return dac.ListEvents("Date>='" + initial.ToString("yyyy/MM/dd HH:mm:ss") + "' and Date<='" + end.ToString("yyyy/MM/dd HH:mm:ss") + "'");
        }

        public static int CompareByDate(EventClass event1, EventClass event2)
        {
            if (event1.Date > event2.Date)
                return 1;
            else if (event1.Date < event2.Date)
                return -1;
            return 0;
        }

        public static List<double> TimeUsageReport(out double slope, out double intercept)
        {
            DAC dac = new DAC();
            DateTime initial = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
            string datesRange = "Date>='" + initial.ToString("yyyy/MM/dd HH:mm:ss") + "' and Date<='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'";
            List<EventClass> events = dac.ListEvents(datesRange);
            if (events.Count == 0)
                throw new NoDataException();

            var dictionary = new Dictionary<DateTime, int>();
            var dates = new List<DateTime>();
            for(int i = 0; i < 30; i++)
            {
                DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                dateTime = dateTime.Subtract(new TimeSpan(i, 0, 0, 0));
                int diff = ((int)dateTime.DayOfWeek - (int)DayOfWeek.Monday) % 7;
                dateTime = dateTime.Subtract(new TimeSpan(diff, 0, 0, 0));
                if (!dates.Contains(dateTime))
                {
                    dates.Add(dateTime);
                    dictionary.Add(dateTime, 0);
                }
            }
            foreach(EventClass e in events)
            {
                int diff = ((int)e.Date.DayOfWeek - (int)DayOfWeek.Monday) % 7;
                DateTime FirstDayOfWeek = new DateTime(e.Date.Year, e.Date.Month, e.Date.Day, 0, 0, 0);
                FirstDayOfWeek = FirstDayOfWeek.Subtract(new TimeSpan(diff, 0, 0, 0));
                int aux = dictionary[FirstDayOfWeek];
                dictionary.Remove(FirstDayOfWeek);
                dictionary.Add(FirstDayOfWeek, aux + 1);

            }
            dates.Sort();
            List<double> results = new List<double>();
            double[] xValues = new double[dictionary.Count];
            for(int i = 0; i < dictionary.Count; i++)
            {
                xValues[i] = i;
            }
            double[] yValues = new double[dictionary.Count];
            for(int i = 0; i < dictionary.Count; i++)
            {
                yValues[i] = dictionary[dates[i]];
                results.Add(dictionary[dates[i]]);
            }
            
            double rSquared;
            LinearRegression(xValues, yValues, out rSquared, out intercept, out slope);

            return results;

        }

        private static void LinearRegression(double[] xVals, double[] yVals, out double rSquared, out double yIntercept, out double slope)
        {
            if (xVals.Length != yVals.Length)
            {
                throw new Exception("Input values should be with the same length.");
            }

            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double sumCodeviates = 0;

            for (var i = 0; i < xVals.Length; i++)
            {
                var x = xVals[i];
                var y = yVals[i];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }

            var count = xVals.Length;
            var ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            var ssY = sumOfYSq - ((sumOfY * sumOfY) / count);

            var rNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            var rDenom = (count * sumOfXSq - (sumOfX * sumOfX)) * (count * sumOfYSq - (sumOfY * sumOfY));
            var sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
            var dblR = rNumerator / Math.Sqrt(rDenom);

            rSquared = dblR * dblR;
            yIntercept = meanY - ((sCo / ssX) * meanX);
            slope = sCo / ssX;
        }

        public static List<EventClass> ListComingEvents()
        {
            DAC dac = new DAC();
            DateTime dateTime = DateTime.Now.Add(new TimeSpan(30, 0, 0, 0));
            return dac.ListEvents("Date>='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "' and Date<='" + dateTime.ToString("yyyy/MM/dd HH:mm:ss") + "'");
        }
    }
}

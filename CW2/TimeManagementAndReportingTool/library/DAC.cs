using System;
using System.Configuration;
using System.Collections.Generic;
using library.exceptions;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace library
{
    internal class DAC
    {
        /// <summary>
        /// Conection string for the DDBB.
        /// </summary>
        private string constring;

        /// <summary>
        /// Constructor for DAC objects. Initializes the conection string.
        /// </summary>
        public DAC()
        {
            constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        /// <summary>
        /// Creates a new entry of the given object in the DDBB.
        /// </summary>
        /// <param name="obj">The object to be inserted in the DDBB</param>
        public void Create(object obj)
        {
            string VALUES;
            string TABLE;
            switch (obj)
            {
                case Contact cont:
                    TABLE = "Contact (FirstName, LastName, Email, Phone)";
                    VALUES = cont.SQLCreateString;
                    break;
                case Location loc:
                    TABLE = "Location (Name, AddrLine1, AddrLine2, City, Postcode, Country)";
                    VALUES = loc.SQLCreateString;
                    break;
                case Appointment ap:
                    TABLE = "Appointment (Name, Recurring, Date, FK_Location)";
                    VALUES = ap.SQLCreateString;
                    break;
                case Lecture lec:
                    TABLE = "Lecture (Name, Recurring, Lecturer, Date, FK_Location)";
                    VALUES = lec.SQLCreateString;
                    break;
                case TaskEvent task:
                    TABLE = "Task (Name, Recurring, Finished, Date, FK_Location)";
                    VALUES = task.SQLCreateString;
                    break;
                case Tutorial tut:
                    TABLE = "Tutorial (Name, Recurring, Lecturer, Lab, Date, FK_Location)";
                    VALUES = tut.SQLCreateString;
                    break;
                default:
                    throw new DDBBException("Create");
            }
            string sql_statement = "INSERT INTO " + TABLE + " VALUES " + VALUES;
            SQLNonQuery(sql_statement);
            Task t = Task.Run(() =>
            {
                GetId(obj);
            });
            try
            {
                t.Wait();
            }
            catch (AggregateException) { }
            
        }

        /// <summary>
        /// Gets the Id for a set of values.
        /// </summary>
        /// <param name="obj">The set of values.</param>
        /// <returns>The id.</returns>
        public int GetId(object obj)
        {
            string TABLE;
            switch (obj)
            {
                case Contact cont:
                    TABLE = cont.SQLGetString;
                    break;
                case Location loc:
                    TABLE = loc.SQLGetString;
                    break;
                case Appointment ap:
                    TABLE = ap.SQLGetString;
                    break;
                case Lecture lec:
                    TABLE = lec.SQLGetString;
                    break;
                case TaskEvent task:
                    TABLE = task.SQLGetString;
                    break;
                case Tutorial tut:
                    TABLE = tut.SQLGetString;
                    break;
                default:
                    throw new DDBBException("GetId");
            }
            string statement = "SELECT Id FROM " + TABLE;
            int Id = -1;
            Task t = Task.Run(() =>
            {
                SqlConnection c = null;
                try
                {
                    c = new SqlConnection(constring);
                    c.Open();
                    SqlCommand com = new SqlCommand(statement, c);
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        Id = int.Parse(reader["Id"].ToString());
                    }

                    reader.Close();
                    if (Id == -1)
                        throw new DDBBException("GetId: Id not found");
                }
                catch (SqlException ex)
                {
                    throw new DDBBException("GetId: " + ex.Message);
                }
                finally
                {
                    c.Close();
                }
            });
            try
            {
                t.Wait();
            }
            catch (AggregateException ex)
            {
                throw new DDBBException("GetId " + ex.Message);
            }
            return Id;
        }

        /// <summary>
        /// Deletes the specified object from the DDBB.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void Delete(Object obj)
        {
            string TABLE;
            int Id = -1;
            switch (obj)
            {
                case Contact cont:
                    TABLE = "Contact";
                    Id = cont.Id;
                    break;
                case Location loc:
                    TABLE = "Location";
                    Id = loc.Id;
                    break;
                case Appointment ap:
                    TABLE = "Appointment";
                    Id = ap.Id;
                    break;
                case Lecture lec:
                    TABLE = "Lecture";
                    Id = lec.Id;
                    break;
                case TaskEvent task:
                    TABLE = "Task";
                    Id = task.Id;
                    break;
                case Tutorial tut:
                    TABLE = "Tutorial";
                    Id = tut.Id;
                    break;
                default:
                    throw new DDBBException("Delete");
            }
            string statement = "Delete from " + TABLE + " where Id=" + Id;
            SQLNonQuery(statement);
        }

        /// <summary>
        /// Updates the specified object in the DDBB.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void Update(object obj)
        {
            string TABLE;
            int Id;
            switch (obj)
            {
                case Contact cont:
                    TABLE = cont.SQLUpdateString;
                    Id = cont.Id;
                    break;
                case Location loc:
                    TABLE = loc.SQLUpdateString;
                    Id = loc.Id;
                    break;
                case Appointment ap:
                    TABLE = ap.SQLUpdateString;
                    Id = ap.Id;
                    break;
                case Lecture lec:
                    TABLE = lec.SQLUpdateString;
                    Id = lec.Id;
                    break;
                case TaskEvent task:
                    TABLE = task.SQLUpdateString;
                    Id = task.Id;
                    break;
                case Tutorial tut:
                    TABLE = tut.SQLUpdateString;
                    Id = tut.Id;
                    break;
                default:
                    throw new DDBBException("Update");
            }
            string statement = "Update " + TABLE + " where Id=" + Id;
            SQLNonQuery(statement);
        }

        /// <summary>
        /// Performs a non query SQL statement.
        /// </summary>
        /// <param name="statement">The SQL statement to be performed.</param>
        private void SQLNonQuery(string statement)
        {
            Task task = Task.Run(() =>
            {
                SqlConnection c = null;
                try
                {
                    c = new SqlConnection(constring);
                    c.Open();

                    SqlCommand com = new SqlCommand(statement, c);

                    if (com.ExecuteNonQuery() == 0)
                        throw new DDBBException("SQLNonQuery: Rows affected = 0");
                }
                catch (SqlException ex)
                {
                    throw new DDBBException("SQLNonQuery " + ex.Message);
                }
                finally
                {
                    c.Close();
                }
            });
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                throw new DDBBException("SQLNonQuery " + ex.Message);
            }
        }

        public DataTable ListContacts()
        {
            
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            Task task = Task.Run(() =>
            {
                SqlConnection c = new SqlConnection(constring);
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("select FirstName, LastName, Email, Phone from Contact", c);
                    da.Fill(table);
                }
                catch (SqlException ex)
                {
                    throw new DDBBException("ListContacts " + ex.Message);
                }
                finally
                {
                    c.Close();
                }
            });
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                throw new DDBBException("SQLNonQuery " + ex.Message);
            }
            return table;

        }

        public List<EventClass> ListEvents(string DatesRange)
        {
            List<EventClass> events = new List<EventClass>();
            Task t = Task.Run(() =>
            {
                SqlConnection c = null;
                try
                {
                    c = new SqlConnection(constring);
                    c.Open();
                    for (int i=0; i<4; i++)
                    {
                        string table;
                        if (i == 0)
                            table = "Id, Name, Recurring, Date from Appointment";
                        else if (i == 1)
                            table = "Id, Name, Recurring, Date, Finished from Task";
                        else if (i == 2)
                            table = "Id, Name, Recurring, Date, Lecturer from Lecture";
                        else
                            table = "Id, Name, Recurring, Date, Lecturer, Lab from Tutorial";
                        string query = "Select " + table + " where " + DatesRange;
                        SqlCommand com = new SqlCommand(query, c);
                        SqlDataReader da = com.ExecuteReader();
                        while (da.Read())
                        {
                            int Id = Int32.Parse(da["Id"].ToString());
                            string Name = da["Name"].ToString();
                            bool Recurring = Boolean.Parse(da["Recurring"].ToString());
                            DateTime Date = DateTime.Parse(da["Date"].ToString());
                            switch (i)
                            {
                                case 0:
                                    events.Add(new Appointment(Id, Name, Recurring, Date));
                                    break;

                                case 1:
                                    bool Finished = Boolean.Parse(da["Finished"].ToString());
                                    events.Add(new TaskEvent(Id, Name, Recurring, Finished, Date));
                                    break;

                                case 2:
                                    string Lecturer = da["Lecturer"].ToString();
                                    events.Add(new Lecture(Id, Name, Recurring, Lecturer, Date));
                                    break;
                                
                                case 3:
                                    string LecturerTut = da["Lecturer"].ToString();
                                    string Lab = da["Lab"].ToString();
                                    events.Add(new Tutorial(Id, Name, Recurring, Lab, LecturerTut, Date));
                                    break;
                            }
                        }
                        da.Close();
                    }
                }
                catch(SqlException ex)
                {
                    throw new DDBBException("ListWeekEvents " + ex.Message);
                }
                finally
                {
                    c.Close();
                }
            });
            try
            {
                t.Wait();
            }
            catch (AggregateException ex)
            {
                throw new DDBBException("ListWeekEvents " + ex.Message);
            }
            events.Sort(EventClass.CompareByDate);
            return events;
        }

        public void ReadEvent(EventClass eventClass)
        {
            string table;
            if (eventClass is Appointment)
                table = "Appointment";
            else if (eventClass is Lecture)
                table = "Lecture";
            else if (eventClass is Tutorial)
                table = "Tutorial";
            else if (eventClass is TaskEvent)
                table = "Task";
            else
                throw new DDBBException("ReadEvent unknown event");
            Task t = Task.Run(() =>
            {
                SqlConnection c = null;
                try
                {
                    c = new SqlConnection(constring);
                    c.Open();

                    SqlCommand com = new SqlCommand("select * from " + table + " where Id=" + eventClass.Id, c);
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        eventClass.Name = dr["Name"].ToString();
                        eventClass.Recurring = Boolean.Parse(dr["Recurring"].ToString());
                        eventClass.Date = DateTime.Parse(dr["Date"].ToString());
                        switch (eventClass)
                        {
                            case Lecture l:
                                ((Lecture)eventClass).Lecturer = dr["Lecturer"].ToString();
                                break;
                            case TaskEvent taskevent:
                                ((TaskEvent)eventClass).Finished = Boolean.Parse(dr["Finished"].ToString());
                                break;
                            case Tutorial tut:
                                ((Tutorial)eventClass).Lecturer = dr["Lecturer"].ToString();
                                ((Tutorial)eventClass).Lab = dr["Lab"].ToString();
                                break;
                        }
                    }
                    dr.Close();
                }
                catch (SqlException ex)
                {
                    throw new DDBBException("ReadEvent " + ex.Message);
                }
                finally
                {
                    c.Close();
                }
            });

            try
            {
                t.Wait();
            }
            catch(AggregateException ex)
            {
                throw new DDBBException("ReadEvent " + ex.Message);
            }
        }
    }
}

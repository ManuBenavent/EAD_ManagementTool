using System;
using System.Configuration;
using System.Collections.Generic;
using library.exceptions;
using System.Data.SqlClient;

namespace library
{
    internal class DAC : ICRUD
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
                    TABLE = "Appointment (Name, Recurring)";
                    VALUES = ap.SQLCreateString;
                    break;
                case Lecture lec:
                    TABLE = "Lecture (Name, Recurring, Lecturer)";
                    VALUES = lec.SQLCreateString;
                    break;
                case Task task:
                    TABLE = "Task (Name, Recurring, Finished)";
                    VALUES = task.SQLCreateString;
                    break;
                case Tutorial tut:
                    TABLE = "Tutorial (Name, Recurring, Lecturer, Lab)";
                    VALUES = tut.SQLCreateString;
                    break;
                default:
                    throw new DDBBException("Create");
            }
            string sql_statement = "INSERT INTO " + TABLE + " VALUES " + VALUES;
            SQLNonQuery(sql_statement);
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
                case Task task:
                    TABLE = task.SQLGetString;
                    break;
                case Tutorial tut:
                    TABLE = tut.SQLGetString;
                    break;
                default:
                    throw new DDBBException("GetId");
            }
            string statement = "SELECT Id FROM " + TABLE;
            int Id=-1;
            Task t = Task.Run( () => {
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
                    //Id = loc.Id;
                    break;
                case Appointment ap:
                    TABLE = "Appointment";
                    //Id = ap.Id;
                    break;
                case Lecture lec:
                    TABLE = "Lecture";
                    //Id = lec.Id;
                    break;
                /*case Task task:
                    TABLE = "Task";
                    break;
                case Tutorial tut:
                    TABLE = "Tutorial";
                    break;*/
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
            switch (obj)
            {
                case Contact cont:
                    TABLE = cont.SQLUpdateString;
                    break;
                case Location loc:
                    TABLE = loc.SQLUpdateString;
                    break;
                case Appointment ap:
                    TABLE = ap.SQLUpdateString;
                    break;
                case Lecture lec:
                    TABLE = lec.SQLUpdateString;
                    break;
                case Task task:
                    TABLE = task.SQLUpdateString;
                    break;
                case Tutorial tut:
                    TABLE = tut.SQLUpdateString;
                    break;
                default:
                    throw new DDBBException("Delete");
            }
            string statement = "Update " + TABLE;
            SQLNonQuery(statement);
        }

        public object Read(int Id)
        {
            throw new NotImplementedException();
        }

        public List<object> Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs a non query SQL statement.
        /// </summary>
        /// <param name="statement">The SQL statement to be performed.</param>
        private void SQLNonQuery (string statement)
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
                          throw new DDBBException("SQLNonQuery");
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
            catch( AggregateException ex)
            {
                throw new DDBBException("SQLNonQuery " + ex.Message);
            }
        }
    }
}

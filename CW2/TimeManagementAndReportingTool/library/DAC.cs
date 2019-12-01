using System;
using System.Configuration;
using System.Collections.Generic;
using library.exceptions;
using System.Data.SqlClient;

namespace library
{
    internal class DAC : ICRUD
    {
        public string constring;
        public DAC()
        {
            constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        public void Create(object obj)
        {
            string TABLE = "";
            string VALUES = "";
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
                    TABLE = "Lecture (Name, Recurring, Lecturer)",
                    VALUES = lec.SQLCreateString;
                    break;
                case Task task:
                    TABLE = "Task (Name, Recurring, Finished)";
                    VALUES = task.SQLCreateString;
                    break;
                case Tutorial tut:
                    TABLE = "Tutorial (Name, Recurring, Lecturer, Lab";
                    VALUES = tut.SQLCreateString;
                    break;
                default:
                    throw new DDBBException("Create");
            }
            string sql_statement = "INSERT INTO " + TABLE + " VALUES " + VALUES;
            SQLNonQuery(sql_statement);
        }

        public int GetId(object obj)
        {
            string TABLE = "";
            switch (obj)
            {
                case Contact cont:
                    TABLE = cont.SQLGetString;
                    break;
                case Location loc:
                    TABLE = "Location (Name, AddrLine1, AddrLine2, City, Postcode, Country)";
                    break;
                case Appointment ap:
                    TABLE = "Appointment (Name, Recurring)";
                    break;
                case Lecture lec:
                    break;
                /*case Task task:
                    break;
                case Tutorial tut:
                    break;*/
                default:
                    throw new DDBBException("GetId");
            }
            string statement = "SELECT Id FROM " + TABLE;
            // TODO DRY + THREADS
            SqlConnection c = null;
            int Id = -1;
            try
            {
                c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand(statement, c);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                    Id = int.Parse(reader["Id"].ToString());
                reader.Close();
                if (Id == -1)
                    throw new DDBBException("GetId: Id not found");
            }catch(SqlException ex)
            {
                throw new DDBBException("GetId: " + ex.Message);
            }
            finally
            {
                c.Close();
            }
            return Id;
        }

        public void Delete(Object obj)
        {
            string TABLE = "";
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

        public void Update(object obj)
        {
            string TABLE;
            switch (obj)
            {
                case Contact cont:
                    TABLE = cont.SQLUpdateString;
                    break;
                case Location loc:
                    TABLE = "Location";
                    break;
                case Appointment ap:
                    TABLE = "Appointment";
                    break;
                case Lecture lec:
                    TABLE = "Lecture";
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

        private void SQLNonQuery (string statement)
        {
            // TODO create thread
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
        }
    }
}

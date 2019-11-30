using System;
using System.Configuration;
using System.Collections.Generic;
using library.exceptions;
using System.Data.SqlClient;

namespace library
{
    internal class DAC /*: ICRUD*/ //TODO uncomment
    {
        public string constring;
        public DAC()
        {
            constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            //constring = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\mbena\Documents\EAD_CW\CW2\TimeManagementAndReportingTool\TimeManagementAndReportingTool\Database.mdf; Integrated Security = True";
        }

        public void Create(object obj)
        {
            string TABLE = "";
            string VALUES = "";
            switch (obj)
            {
                case Contact cont:
                    TABLE = "Contact (FirstName, LastName, Email, Phone)";
                    VALUES = cont.SQLString;
                    break;
                case Location loc:
                    break;
                case Appointment ap:
                    break;
                case Lecture lec:
                    break;
                /*case Task task:
                    break;
                case Tutorial tut:
                    break;*/
                default:
                    throw new DDBBException("Create");
            }

            /*switch(obj){
                case Appointment ap:
                    // give TABLE(cols) SQL statement part
                    // since downcasting has been already perfomerd use getSQLInsertMethod
                    // this way the method is more generic and there is a lot of code reusability
                    break;
                case Contact contact:
            }*/
            string sql_statement = "INSERT INTO " + TABLE + " VALUES " + VALUES;
            SQLNonQuery(sql_statement);
        }

        /*public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }


        public int GetId(object obj)
        {
            throw new NotImplementedException();
        }

        public object Read(int Id)
        {
            throw new NotImplementedException();
        }

        public List<object> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(object obj)
        {
            throw new NotImplementedException();
        }*/

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

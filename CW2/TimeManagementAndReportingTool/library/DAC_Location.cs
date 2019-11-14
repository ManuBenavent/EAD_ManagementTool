using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using library.exceptions;

namespace library
{
    internal class DAC_Location : ICRUD
    {
        SqlConnection connection;

        public DAC_Location()
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ToString());
            }
            catch(SqlException ex)
            {
                throw new DDBBException(ex.Source);
            }
        }

        public bool Create(object obj)
        {
            Location location = (Location)obj;
            try
            {
                connection.Open();
                SqlCommand com = new SqlCommand("Insert into Location (name, adr1, adr2, city, postcode, country) VALUES ('" + 
                location.Name + "','" + location.AddressLine1 + "','" + location.AddressLine2 + "','"  + location.City + "','"
                    + location.PostCode + "','" + location.Country + "')", connection);
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool Delete(Object obj)
        {
            Location location = (Location)obj;

            try
            {
                connection.Open();
                SqlCommand com = new SqlCommand("Delete from Location where name = '" + location.Name + "' and adr1 = '"
                + location.AddressLine1 + "' and adr2 = '" + location.AddressLine2 + "' and city = '" + location.City
                    + "' and postcode = '" + location.PostCode + "' and location.country = '" + location.Country + "'", connection);
                com.ExecuteNonQuery();
            }
            catch(SqlException ex){
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public void Read(Object obj)
        {
            Location loc = (Location)obj;
            try
            {
                connection.Open();
                //TODO implement
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new DDBBException(ex.Source);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Object> Read()
        {
            List<Object> locations = new List<Object>();
            try
            {
                connection.Open();
                //TODO implement (upcasting of locations)
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
            return locations;
        }

        public bool Update(object obj)
        {
            Location location = (Location)obj;

            try
            {
                connection.Open();
                // TODO implement
                SqlCommand com = new SqlCommand("", connection);
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}

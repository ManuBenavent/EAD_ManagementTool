using System;
using System.Collections.Generic;

namespace library
{
    internal class DAC : ICRUD
    {
        public DAC()
        {
        }

        public bool Create(object obj)
        {
            //TODO: Connect to DDBB an create a new Location object
            throw new NotImplementedException();
            
            /*switch(obj){
                case Appointment ap:
                    // give TABLE(cols) SQL statement part
                    // since downcasting has been already perfomerd use getSQLInsertMethod
                    // this way the method is more generic and there is a lot of code reusability
                    break;
                case Contact contact:
            }*/
            
            // insert into "TABLE (cols)" VALUES ("values quoted")
        }

        public bool Delete(int Id)
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
        }
    }
}

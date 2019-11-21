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
            // implement switch depending on the object type (see tutorials) and that would give the TABLE(cols)
            // and the downcasting that needs to be perfomed to obtains the valules quoted (create a toquotedstring funcion in BE)
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

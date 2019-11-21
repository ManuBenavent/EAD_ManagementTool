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

using System;
using System.Collections.Generic;

namespace library
{
    internal interface ICRUD
    {
        /// <summary>
        /// Inserts an instance of the object in the data base
        /// </summary>
        /// <returns>True if succesful. False if not.</returns>
        /// <param name="obj">Object of the table we are trying to insert into</param>
        bool Create(Object obj);

        /// <summary>
        /// Reads the object of the type implemented for the given ID
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="Id">Identifier.</param>
        void Read(Object obj);

        /// <summary>
        /// Gets a list with all the instances stored in the DDBB
        /// </summary>
        /// <returns>List with the objects</returns>
        List<Object> Read();

        /// <summary>
        /// Update the specified obj.
        /// </summary>
        /// <returns>true or false depending on the result of the operation</returns>
        /// <param name="obj">Object.</param>
        bool Update(Object obj);

        /// <summary>
        /// Delete the specified Id.
        /// </summary>
        /// <returns>True or false depending on the result of the operation</returns>
        /// <param name="Id">Identifier.</param>
        bool Delete(Object obj);
    }
}

using System;
using System.Collections.Generic;

namespace library
{
    internal interface ICRUD
    {
        /// <summary>
        /// Create the specified obj.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="obj">Object.</param>
        void Create(Object obj);

        /// <summary>
        /// Read the specified Id.
        /// </summary>
        /// <returns>The read.</returns>
        /// <param name="Id">Identifier.</param>
        Object Read(int Id);

        /// <summary>
        /// Read this instance.
        /// </summary>
        /// <returns>The read.</returns>
        List<Object> Read();

        /// <summary>
        /// Update the specified obj.
        /// </summary>
        /// <param name="obj">Object.</param>
        void Update(Object obj);

        /// <summary>
        /// Delete the specified object.
        /// </summary>
        /// <param name="obj">Object.</param>
        void Delete(Object obj);

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns>The identifier.</returns>
        /// <param name="obj">Object.</param>
        int GetId(Object obj);
    }
}

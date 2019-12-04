using System;
using System.Collections.Generic;

namespace library
{
    internal interface ISQLAccess
    {
        /// <summary>
        /// Date and time of the event.
        /// </summary>
        string SQLCreateString { get; }
        /// <summary>
        /// String used for updating the values of the object in the DDBB.
        /// </summary>
        string SQLUpdateString { get; }
        /// <summary>
        /// String used as getter for the Id in the SQL statements.
        /// </summary>
        string SQLGetString { get; }
        /// <summary>
        /// Create the specified obj.
        /// </summary>
        /// <returns>The create.</returns>
        void Create();
        /// <summary>
        /// Update the specified obj.
        /// </summary>
        void Update();
        /// <summary>
        /// Delete the specified object.
        /// </summary>
        void Delete();
    }
}

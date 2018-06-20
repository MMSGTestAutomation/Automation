using System;

namespace MMSG.Automation.DataTransferObjects
{
    /// <summary>
    /// This is the base entity object.
    /// </summary>
    public class BaseEntityObject : BaseDataTransferObject
    {
        /// <summary>
        /// This is the name.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// This tells if the object is created.
        /// </summary>
        public bool IsCreated { get; set; }
    }
}
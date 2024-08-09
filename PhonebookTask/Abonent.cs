using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookTask
{
    /// <summary>
    /// Абонент.
    /// </summary>
    internal class Abonent
    {
        #region Fields and Properties

        private string name;
        private string phoneNumber;

        /// <summary>
        /// Имя абонента.
        /// </summary>
        public string Name 
        { 
            get 
            { 
                return name; 
            } 
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Номер телефона абонента.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        #endregion
    }
}

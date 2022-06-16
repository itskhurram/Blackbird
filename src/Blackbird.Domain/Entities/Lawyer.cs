using Blackbird.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackbird.Domain.Entities
{
    public class Lawyer : User    
    {
        #region private declarations
        private short practicingSince;
        private string? education;
        private string? postalAddress;
        private string? state;
        private string? city;
        #endregion

        
        public short PracticingSince
        {
            get => practicingSince; set
            {
                practicingSince = value; EntityModified();
            }
        }
        public string Education
        {
            get => education; set
            {
                education = value; EntityModified();
            }
        }
        public string PostalAddress
        {
            get => postalAddress; set
            {
                postalAddress = value; EntityModified();
            }
        }
        public string State
        {
            get => state; set
            {
                state = value; EntityModified();
            }
        }
        public string City
        {
            get => city; set
            {
                city = value; EntityModified();
            }
        }
    }
}

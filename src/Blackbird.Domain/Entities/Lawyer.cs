namespace Blackbird.Domain.Entities
{
    public class Lawyer : User    
    {
        #region private declarations
        private short practicingSince;
        private string? tagLine;
        private string? designation;
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
        public string TagLine
        {
            get => tagLine; set
            {
                tagLine = value; EntityModified();
            }
        }
        public string Designation
        {
            get => designation; set
            {
                designation= value; EntityModified();
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

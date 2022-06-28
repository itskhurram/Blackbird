using Blackbird.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackbird.Domain.Entities
{
    public class LawyerSocialMediaLinks: EntityBase
    {
        #region private declarations
        private long lawyerSocialMediaLinksId;
        
        private string? whatsappNumber;
        private string? facebookLink;
        private string? instagramLink;
        private string? messengerLink;

        private long userId;

        #endregion


        public long LawyerSocialMediaLinksId
        {
            get => lawyerSocialMediaLinksId; set
            {
                lawyerSocialMediaLinksId = value; EntityModified();
            }
        }
        public long UserId
        {
            get => userId; set
            {
                userId = value; EntityModified();
            }
        }
        public string WhatsappNumber
        {
            get => whatsappNumber; set
            {
                whatsappNumber = value; EntityModified();
            }
        }
        public string FacebookLink
        {
            get => facebookLink; set
            {
                facebookLink = value; EntityModified();
            }
        }

        public string InstagramLink
        {
            get => instagramLink; set
            {
                instagramLink = value; EntityModified();
            }
        }

        public string MessengerLink
        {
            get => messengerLink; set
            {
                messengerLink = value; EntityModified();
            }
        }
    }
}

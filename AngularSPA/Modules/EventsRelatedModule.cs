using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularSPA.Modules
{

    public class EventEnqueryRqeuest
    {
        public int EventId { get; set; }
        // public int scannedId { get; set; } = 0;
        public List<int> InvitationIdList { get; set; } // optional params
    }


    public class SendInvitationRqeuest
    {
        public int EventId { get; set; }
        // public int scannedId { get; set; } = 0;
        public int invitationId { get; set; } // optional params
    }



    public class EventData
    {
        public int EventId { get; set; }
        public DateTime CreateTime { get; set; }
        public string StrCreatedTime {
            get
            {
                return this.CreateTime.ToLocalTime().ToLongTimeString();
            }
        }
        public List<Invitation> Invitations { get; set; }
    }


    public class Invitation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Content { get; set; }
        public InvitationStatus Status { get; set; }
        public DateTime CreateTime { get; set; }
        public string StrCreatedTime { get; set; }
        public DateTime? RequestSentTime { get; set; }
        public string StrRequestSentTime { get; set; }
        public DateTime? ResponseTime { get; set; }
        public string StrResponseTime { get; set; }
    }


    public enum InvitationStatus
    {
        Initial = 10,
        Sending = 20,
        Sent = 30,
        Declined = 40,
        Confirmed = 50,
        Expired = 60,
        Others = 100
    }
}

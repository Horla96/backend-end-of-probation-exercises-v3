using customer_support_api.Enums;
using System.Security.Cryptography.X509Certificates;

namespace customer_support_api.Models
{
    public class BugReport : Ticket
    {
        public Priority Priority { get; set; }
        public BugReport(string id, string subject, string description, Priority priority, TicketStatus status) : base( subject, description, TicketStatus.Open)
        { 
            Priority = priority;
        }

        

        
    }

    public class FeatureRequest : Ticket
    {
     
        public FeatureRequest(string id, string subject, string description, Priority priority, TicketStatus status) : base( subject, description, TicketStatus.Open)
        {
        }

    }
}

using customer_support_api.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json.Serialization;

namespace customer_support_api.Models;

public class Ticket
{

    [JsonIgnore]
    public string Id { get; set; } 
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt {get; set; }
    public TicketStatus Status { get; set; }

    [JsonConstructor]
    public Ticket( string subject, string description,  TicketStatus status)
    {
        Id = Guid.NewGuid().ToString();
        Subject = subject;
        Description = description;
        CreatedAt = DateTime.Now;
        Status = status;
    }
}

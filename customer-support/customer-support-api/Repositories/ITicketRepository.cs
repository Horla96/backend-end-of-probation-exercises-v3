using customer_support_api.Enums;
using customer_support_api.Models;

namespace customer_support_api.Repositories
{
    public interface ITicketRepository
    {
        Ticket Add(Ticket ticket);
        Ticket? GetById(string id);
        IEnumerable<Ticket> GetAll();
        IEnumerable<Ticket> FilterTickets(TicketStatus? status, DateTime? startDate, DateTime? endDate);
        Ticket? Update(Ticket ticket);
        bool Delete(string id);
    }
}

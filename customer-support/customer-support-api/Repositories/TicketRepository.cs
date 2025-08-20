using customer_support_api.Enums;
using customer_support_api.Models;

namespace customer_support_api.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        public readonly List<Ticket> _tickets = new();

        public Ticket Add(Ticket ticket)
        {
            _tickets.Add(ticket);
            return ticket;
        }

        public bool Delete(string id)
        {
            var ticket = GetById(id);
            if (ticket != null)
                return false;

            _tickets.Remove(ticket);
            return true;
        }

        public IEnumerable<Ticket> FilterTickets(TicketStatus? status, DateTime? startDate, DateTime? endDate)
        {
            var query = _tickets.AsQueryable();

            if (status.HasValue)
                query = query.Where(t => t.Status == status.Value);

            if (startDate.HasValue)
                query = query.Where(t => t.CreatedAt >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(t => t.CreatedAt >= endDate.Value);

            return query.ToList();


        }

        public IEnumerable<Ticket> GetAll()
        {
            return _tickets;
        }

        public Ticket? GetById(string id)
        {
            if (Guid.TryParse(id, out var ticketId))
            {
                return _tickets.FirstOrDefault(t => t.Id == id);
            }

            return null;
        }

        public Ticket? Update(Ticket ticket)
        {
            var existing = GetById(ticket.Id);
            if (existing == null)
                return null;

            existing.Subject = ticket.Subject;
            existing.Status = ticket.Status;
            existing.Description = ticket.Description;

            return existing;

        }
    }
}

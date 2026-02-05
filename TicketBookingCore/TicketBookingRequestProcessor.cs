namespace TicketBookingCore
{
    public class TicketBookingRequestProcessor
    {
        private readonly ITicketBookingRepository _ticketBookingRepository;

        public TicketBookingRequestProcessor(
            ITicketBookingRepository ticketBookingRepository)
        {
            _ticketBookingRepository = ticketBookingRepository;
        }
    }
}
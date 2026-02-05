namespace TicketBookingCore
{
    public class TicketBookingRequestProcessor
    {
        internal TicketBookingResponse Book(TicketBookingRequest request)
        {
            return new TicketBookingResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
        }
    }
}
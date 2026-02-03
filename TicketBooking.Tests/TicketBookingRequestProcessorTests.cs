namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        public void ShouldReturnTicketBookingResultWithRequestValues()
        {
            var processor = new TicketBookingRequestProcessor();

            var request = new TicketBookingRequest
            {
                FirstName = "Mersiha",
                LastName = "Mesihovic",
                Email = "mersiha.mesihovic@gmail.com"
            };
        }
    }
}
using System;
using Xunit;

namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        [Fact]
        public void ShouldReturnTicketBookingResultWithRequestValues()
        {
            // Arrange
            var processor = new TicketBookingRequestProcessor();
            var request = new TicketBookingRequest
            {
                FirstName = "Mersiha",
                LastName = "Mesihovic",
                Email = "mersiha.mesihovic@gmail.com"
            };

            // Act
            TicketBookingResponse response = processor.Book(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(request.FirstName, response.FirstName);
            Assert.Equal(request.LastName, response.LastName);
            Assert.Equal(request.Email, response.Email);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            // Arrange
            var processor = new TicketBookingRequestProcessor();

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() =>
                processor.Book(null));

            // Assert
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveToDatabase()
        {
            // Arrange
            var processor = new TicketBookingRequestProcessor();

            var request = new TicketBookingRequest
            {
                FirstName = "Mersiha",
                LastName = "Mesihovic",
                Email = "m.mesihovic@@gmail.comcom"
            };

            // Act
            TicketBookingResponse response = processor.Book(request);

            // Assert
            Assert.NotNull(response);
        }
    }
}
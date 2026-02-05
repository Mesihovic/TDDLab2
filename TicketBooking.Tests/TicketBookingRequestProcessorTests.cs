using System;
using Moq;
using Xunit;

namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        private readonly Mock<ITicketBookingRepository> _ticketBookingRepositoryMock;
        private readonly TicketBookingRequestProcessor _processor;
        private readonly TicketBookingRequest _request;

        public TicketBookingRequestProcessorTests()
        {
            _ticketBookingRepositoryMock = new Mock<ITicketBookingRepository>();
            _processor = new TicketBookingRequestProcessor(_ticketBookingRepositoryMock.Object);
            _request = new TicketBookingRequest
            {
                FirstName = "Mersiha",
                LastName = "Mesihovic",
                Email = "mersiha.mesihovic@gmail.com"
            };
        }

        [Fact]
        public void ShouldReturnTicketBookingResultWithRequestValues()
        {
            // Arrange

            // Act
            TicketBookingResponse response = _processor.Book(_request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(_request.FirstName, response.FirstName);
            Assert.Equal(_request.LastName, response.LastName);
            Assert.Equal(_request.Email, response.Email);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            // Arrange
            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.Book(null));

            // Assert
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveToDatabase()
        {
            // Arrange
            TicketBooking savedTicketBooking = null;

            // Setup the Save method to capture the saved ticket booking
            _ticketBookingRepositoryMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
                .Callback<TicketBooking>((ticketBooking) =>
                {
                    savedTicketBooking = ticketBooking;
                });

            var request = new TicketBookingRequest
            {
                FirstName = "Milena",
                LastName = "Avramovic",
                Email = "milenaavramovic@gmail.com"
            };

            // Act
            TicketBookingResponse response = _processor.Book(request);

            // Assert
            Assert.NotNull(savedTicketBooking);
            Assert.Equal(request.FirstName, savedTicketBooking.FirstName);
            Assert.Equal(request.LastName, savedTicketBooking.LastName);
            Assert.Equal(request.Email, savedTicketBooking.Email);
        }
    }
}
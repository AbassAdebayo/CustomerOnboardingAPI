using Application.Identity;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Castle.Core.Logging;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _repositoryMock;
        private readonly Mock<ICustomerService> _serviceMock;
        private readonly ICustomerService _service;
        private readonly Mock<ILogger<CustomerService>> _loggerMock;
        private readonly Mock<IPasswordHasherService> _passwordHasherServiceMock;

        public CustomerServiceTests()
        {
            _repositoryMock = new Mock<ICustomerRepository>();
            _serviceMock = new Mock<ICustomerService>();
            _loggerMock = new Mock<ILogger<CustomerService>>();
            _passwordHasherServiceMock = new Mock<IPasswordHasherService>();

            _service = new CustomerService(_repositoryMock.Object, _loggerMock.Object, _passwordHasherServiceMock.Object);
        }

        [Fact]
        public async Task OnboardCustomerAsync_ShouldReturnCustomer_WhenPhoneNumberIsVerified()
        {
            // Arrange
            var onboardCustomerDTO = new OboardCustomerRequestModel
            {
                PhoneNumber = "08123487093",
                Email = "deji@gmail.com",
                Password = "password",
                StateOfResidence = "Oyo",
                LGA = "Akinyele"
            };
            var hashedPassword = "hashedpassword";
            var customer = new Customer
            {
                PhoneNumber = onboardCustomerDTO.PhoneNumber,
                Email = onboardCustomerDTO.Email,
                Password = hashedPassword,
                StateOfResidence = onboardCustomerDTO.StateOfResidence,
                LGA = onboardCustomerDTO.LGA
            };

            
           
            _serviceMock.Setup(service => service.VerifyOTPAsync(It.IsAny<string>())).ReturnsAsync(true);
            _passwordHasherServiceMock.Setup(ph => ph.HashPassword(It.IsAny<string>())).Returns(hashedPassword);
            _serviceMock.Setup(service => service.OnboardCustomer(It.IsAny<Customer>())).ReturnsAsync(customer);
    
            // Act
            var result = await _service.OnboardCustomer(customer);
                
            // Assert
            Assert.NotNull(result);
            Assert.Equal(onboardCustomerDTO.PhoneNumber, result.PhoneNumber);
            Assert.Equal(onboardCustomerDTO.Email, result.Email);
            Assert.Equal(onboardCustomerDTO, result.Password);
            Assert.Equal(onboardCustomerDTO.StateOfResidence, result.StateOfResidence);
            Assert.Equal(onboardCustomerDTO.LGA, result.LGA);
    
            _serviceMock.Verify(service => service.VerifyOTPAsync(It.IsAny<string>()), Times.Once);
            _serviceMock.Verify(service => service.OnboardCustomer(It.IsAny<Customer>()), Times.Once);
            _passwordHasherServiceMock.Verify(ph => ph.HashPassword(It.IsAny<string>()), Times.Once);
                
            }
        }
}

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
        private readonly ILogger<CustomerServiceTests> _logger;
        private readonly IPasswordHasherService _passwordHasherService;

        public CustomerServiceTests()
        {
            _repositoryMock = new Mock<ICustomerRepository>();
            _serviceMock = new Mock<ICustomerService>();
            _service = new CustomerService(_repositoryMock.Object, ILogger<CustomerServiceTests);
        }

        [Fact]
        public async Task OnboardCustomerAsync_ShouldReturnCustomer_WhenPhoneNumberIsVerified()
        {

            var customer = new Customer { PhoneNumber = "1234567890", Email = "test@example.com", Password = "password", StateOfResidence = "State", LGA = "LGA" };
            await _serviceMock.Setup(service => service.VerifyOTPAsync(It.IsAny<string>())).ReturnsAsync(true);
            _repositoryMock.Setup(repo => repo.AddCustomer(It.IsAny<Customer>())).ReturnsAsync(customer);

            var result = await _service.OnboardCustomer(customer);

            Assert.NotNull(result);
            Assert.True(result.IsVerified);
            _serviceMock.Verify(service => service.VerifyOTPAsync(It.IsAny<string>()), Times.Once);
            _serviceMock.Verify(repo => repo.OnboardCustomer(It.IsAny<Customer>()), Times.Once);
        }
    }
}
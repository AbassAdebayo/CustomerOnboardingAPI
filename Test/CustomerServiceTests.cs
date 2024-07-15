using Application.DTOs;
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
        public async Task OnboardCustomer_ShouldReturnError_WhenFieldsAreEmpty()
        {
            var response = await _service.OnboardCustomerAsync(null);

            Assert.False(response.Status);
            Assert.Equal("Fields cannot be empty!", response.Message);
        }

        [Fact]
        public async Task OnboardCustomer_ShouldReturnError_WhenLgaDoesNotMatchState()
        {
            var request = new OnboardCustomerRequestModel
            {
                PhoneNumber = "1234567890",
                Email = "test@example.com",
                Password = "password",
                StateOfResidence = "InvalidState",
                LGA = "InvalidLGA"
            };

            var existingCustomer = new Customer { PhoneNumber = request.PhoneNumber };

            _repositoryMock.Setup(repo => repo.GetCustomerByPhoneNumber(It.IsAny<string>())).ReturnsAsync(existingCustomer);

            var response = await _service.OnboardCustomerAsync(request);

            Assert.False(response.Status);
            Assert.Equal("LGA does not match the selected state!", response.Message);
        }

        [Fact]
        public async Task OnboardCustomer_ShouldReturnSuccess_WhenCustomerIsCreated()
        {
            var request = new OnboardCustomerRequestModel
            {
                PhoneNumber = "1234567890",
                Email = "test@example.com",
                Password = "password",
                StateOfResidence = "Lagos",
                LGA = "Ikeja"
            };

            var existingCustomer = new Customer { PhoneNumber = request.PhoneNumber };
            var hashedPassword = "hashedpassword";
            var newCustomer = new Customer { PhoneNumber = request.PhoneNumber };

            _repositoryMock.Setup(repo => repo.GetCustomerByPhoneNumber(It.IsAny<string>())).ReturnsAsync(existingCustomer);
            _passwordHasherServiceMock.Setup(ph => ph.HashPassword(It.IsAny<string>())).Returns(hashedPassword);
            _repositoryMock.Setup(repo => repo.AddCustomer(It.IsAny<Customer>())).ReturnsAsync(newCustomer);

            var response = await _service.OnboardCustomerAsync(request);

            Assert.True(response.Status);
            Assert.Equal($"Customer has been created and OTP sent to {request.PhoneNumber} successfully.", response.Message);
            Assert.Equal(newCustomer, response.Data);
        }

        [Fact]
        public async Task VerifyOTP_ShouldReturnError_WhenOTPIsInvalid()
        {
            var request = new VerifyOtpRequestModel { PhoneNumber = "1234567890", OTP = "123456" };
            var customer = new Customer { PhoneNumber = request.PhoneNumber, OTP = "654321" };

            _repositoryMock.Setup(repo => repo.GetCustomerByPhoneNumber(It.IsAny<string>())).ReturnsAsync(customer);

            var response = await _service.VerifyOTPAsync(request);

            Assert.False(response.Status);
            Assert.Equal("Invalid OTP!", response.Message);
        }

        [Fact]
        public async Task VerifyOTP_ShouldReturnError_WhenOTPIsExpired()
        {
            var request = new VerifyOtpRequestModel { PhoneNumber = "1234567890", OTP = "123456" };
            var customer = new Customer { PhoneNumber = request.PhoneNumber, OTP = "123456", OTPExpiration = DateTime.UtcNow.AddMinutes(-5) };

            _repositoryMock.Setup(repo => repo.GetCustomerByPhoneNumber(It.IsAny<string>())).ReturnsAsync(customer);

            var response = await _service.VerifyOTPAsync(request);

            Assert.False(response.Status);
            Assert.Equal("OTP entered has expired!", response.Message);
        }

        [Fact]
        public async Task VerifyOTP_ShouldReturnSuccess_WhenOTPIsVerified()
        {
            var request = new VerifyOtpRequestModel { PhoneNumber = "1234567890", OTP = "123456" };
            var customer = new Customer { PhoneNumber = request.PhoneNumber, OTP = "123456", OTPExpiration = DateTime.UtcNow.AddMinutes(5) };

            _repositoryMock.Setup(repo => repo.GetCustomerByPhoneNumber(It.IsAny<string>())).ReturnsAsync(customer);

            var response = await _service.VerifyOTPAsync(request);

            Assert.True(response.Status);
            Assert.Equal("Phone number verified successfully", response.Message);
        }

        [Fact]
        public async Task GetAllOnboardedCustomersAsync_ShouldReturnError_WhenNoCustomersFound()
        {
            _repositoryMock.Setup(repo => repo.GetAllOnboardedCustomers()).ReturnsAsync((List<Customer>)null);

            var response = await _service.GetAllOnboardedCustomersAsync();

            Assert.False(response.Status);
            Assert.Equal("Customers are empty, or couldn't be fetched", response.Message);
            Assert.Null(response.Data);
        }

        [Fact]
        public async Task GetAllOnboardedCustomersAsync_ShouldReturnSuccess_WhenCustomersAreFound()
        {
            var customers = new List<Customer>
        {
            new Customer { Id = new Guid(), Email = "customer1@example.com", PhoneNumber = "1234567890", LGA = "LGA1", StateOfResidence = "State1", IsVerified = true },
            new Customer { Id = new Guid(), Email = "customer2@example.com", PhoneNumber = "0987654321", LGA = "LGA2", StateOfResidence = "State2", IsVerified = false }
        };

            _repositoryMock.Setup(repo => repo.GetAllOnboardedCustomers()).ReturnsAsync(customers);

            var response = await _service.GetAllOnboardedCustomersAsync();

            Assert.True(response.Status);
            Assert.Equal("Customers fetched successfully", response.Message);
            Assert.NotNull(response.Data);
            Assert.Equal(2, response.Data.Count());

            var customersDto = response.Data.ToList();
            Assert.Equal(customers[0].Id, customersDto[0].Id);
            Assert.Equal(customers[0].Email, customersDto[0].Email);
            Assert.Equal(customers[0].PhoneNumber, customersDto[0].PhoneNumber);
            Assert.Equal(customers[0].LGA, customersDto[0].LGA);
            Assert.Equal(customers[0].StateOfResidence, customersDto[0].StateOfResidence);
            Assert.Equal(customers[0].IsVerified, customersDto[0].IsVerified);

            Assert.Equal(customers[1].Id, customersDto[1].Id);
            Assert.Equal(customers[1].Email, customersDto[1].Email);
            Assert.Equal(customers[1].PhoneNumber, customersDto[1].PhoneNumber);
            Assert.Equal(customers[1].LGA, customersDto[1].LGA);
            Assert.Equal(customers[1].StateOfResidence, customersDto[1].StateOfResidence);
            Assert.Equal(customers[1].IsVerified, customersDto[1].IsVerified);
        }

    }
}
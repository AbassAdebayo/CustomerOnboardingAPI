using Application.DTOs;
using Application.Extensions;
using Application.Identity;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;
        private readonly IPasswordHasherService _passwordHasherService;

        private static StateLgaMapping _stateLgaMapping;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger, 
            IPasswordHasherService passwordHasherService)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _passwordHasherService = passwordHasherService;
        }
        public async Task<BaseResponse<IEnumerable<CustomerDto>>> GetAllOnboardedCustomersAsync()
        {
            var customers = await _customerRepository.GetAllOnboardedCustomers();
            if (customers is null || !customers.Any())
            {
                _logger.LogError("Customers are empty, couldn't be fetched");
                return new BaseResponse<IEnumerable<CustomerDto>>
                {
                    Message = $"Customers are empty, or couldn't be fetched",
                    Status = false,

                };
            }

            var customersDto = customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                LGA = c.LGA,
                StateOfResidence = c.StateOfResidence,
                IsVerified = c.IsVerified,

            }).ToList();

            return new BaseResponse<IEnumerable<CustomerDto>>
            {
                Message = "Customers fetched successfully",
                Status = true,
                Data = customersDto
            };
        }

        public async Task<BaseResponse<Customer>> OnboardCustomerAsync(OnboardCustomerRequestModel request)
        {
            if(request is null)
            {
                _logger.LogError("Fields cannot be empty!");
                return new BaseResponse<Customer>
                {
                    Message = "Fields cannot be empty!",
                    Status = false
                };
            }

            var existingCustomer = await _customerRepository.GetCustomerByPhoneNumber(request.PhoneNumber);

            if(existingCustomer != null)
            {
                _logger.LogError("Customer already exist!");
                return new BaseResponse<Customer>
                {
                    Message = "Customer already exist!",
                    Status = false
                };
            }

            var customerExistsByEmail = await _customerRepository.CustomerExistsByEmail(request.Email);
            if(customerExistsByEmail)
            {
                _logger.LogError("Customer already exist!");
                return new BaseResponse<Customer>
                {
                    Message = "Customer already exist!",
                    Status = false
                };
            }

            ProcessStateAndLga(request.StateOfResidence, request.LGA);

            var hashedPassword = _passwordHasherService.HashPassword(request.Password);

            var customer = new Customer
            {
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = hashedPassword,
                LGA = request.LGA,
                StateOfResidence = request.StateOfResidence
            };
            var newCustomer = await _customerRepository.AddCustomer(customer);
            if(newCustomer is null)
            {
                _logger.LogError("Customer creation couldn't be completed.");
                return new BaseResponse<Customer>
                {
                    Message = "Customer creation couldn't be completed.",
                    Status = false
                };
            }


            newCustomer.OTP = GenerateOTP();
            newCustomer.OTPExpiration = DateTime.UtcNow.AddMinutes(5);

            await _customerRepository.SaveChangesAsync();
            await SendOTPAsync(newCustomer.PhoneNumber);

            _logger.LogError("Customer has been created and OTP sent successfully.");
            return new BaseResponse<Customer>
            {
                Message = $"Customer has been created and OTP sent to {newCustomer.PhoneNumber} successfully.",
                Status = true,
                Data = newCustomer
            };
        }

        public async Task<BaseResponse> SendOTPAsync(string phoneNumber)
        {
            var getCustomer = await _customerRepository.GetCustomerByPhoneNumber(phoneNumber);
            if (getCustomer is null)
            {
                _logger.LogError("Customer does not exist!");
                return new BaseResponse
                {
                    Message = "Customer does not exist!",
                    Status = false
                };
            }

            getCustomer.OTP = GenerateOTP();
            getCustomer.OTPExpiration = DateTime.UtcNow.AddMinutes(5);

            await _customerRepository.SaveChangesAsync();

            return new BaseResponse
            {
                Message = $"Seding OTP to phone number {phoneNumber}",
                Status = true,

            };
        }

        public async Task<BaseResponse> VerifyOTPAsync(VerifyOtpRequestModel request)
        {
            var getCustomer = await _customerRepository.GetCustomerByPhoneNumber(request.PhoneNumber);
            if (getCustomer is null)
            {
                _logger.LogError("Customer does not exist!");
                return new BaseResponse
                {
                    Message = "Customer does not exist!",
                    Status = false
                };
            }

            if(getCustomer.OTP != request.OTP)
            {
                _logger.LogError("Invalid OTP!");
                return new BaseResponse
                {
                    Message = "Invalid OTP!",
                    Status = false
                };
            }

            if(getCustomer.OTPExpiration < DateTime.UtcNow)
            {
                _logger.LogError("OTP entered has expired!");
                return new BaseResponse
                {
                    Message = "OTP entered has expired!",
                    Status = false
                };
            }
            getCustomer.IsVerified = true;
            getCustomer.OTP = null;
            getCustomer.OTPExpiration = null;

            await _customerRepository.SaveChangesAsync();

            return new BaseResponse
            {
                Message = "Phone number verified successfully",
                Status = true
            };
        }

       private string GenerateOTP()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
       }

        private void ProcessStateAndLga(string state, string lga)
        {
            _stateLgaMapping = new StateLgaMapping();

            try
            {
                _stateLgaMapping.ValidateStateAndLga(state, lga);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

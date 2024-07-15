using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task<BaseResponse<Customer>> OnboardCustomer(OnboardCustomerRequestModel request);
        public Task<BaseResponse<IEnumerable<CustomerDto>>> GetAllOnboardedCustomers();
        //public Task<BaseResponse<Customer>> GetCustomerByPhoneNumber(string phoneNumber);
        public Task<BaseResponse> SendOTPAsync(string phoneNumber);
        public Task<BaseResponse> VerifyOTPAsync(VerifyOtpRequestModel request);
    }
}

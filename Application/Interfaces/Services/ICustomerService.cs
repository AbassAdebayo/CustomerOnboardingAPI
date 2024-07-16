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
        public Task<BaseResponse<Customer>> OnboardCustomerAsync(OnboardCustomerRequestModel request);
        public Task<BaseResponse<IEnumerable<CustomerDto>>> GetAllOnboardedCustomersAsync();
        public Task<BaseResponse> SendOTPAsync(string phoneNumber);
        public Task<BaseResponse> VerifyOTPAsync(VerifyOtpRequestModel request);
    }
}

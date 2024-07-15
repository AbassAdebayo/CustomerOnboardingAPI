using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("onboard-customer")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        public async Task<IActionResult> OnboardCustomer([FromBody] OnboardCustomerRequestModel model)
        {
            var response = await _customerService.OnboardCustomerAsync(model);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("get-all-onboarded-customers")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        public async Task<IActionResult> GetAllOnboardedCustomers()
        {
            var response = await _customerService.GetAllOnboardedCustomersAsync();
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPost("send-otp")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        public async Task<IActionResult> SendOTP([FromBody] string phoneNumber)
        {
            var response = await _customerService.SendOTPAsync(phoneNumber);
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPost("verify-otp")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyOtpRequestModel model)
        {
            var response = await _customerService.VerifyOTPAsync(model);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}

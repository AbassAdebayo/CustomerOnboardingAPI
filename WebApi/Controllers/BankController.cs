using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Filters;

namespace WebApi.Controllers
{

    [Route("api/bank")]
    public class BankController : ControllerBase
    {
        private static readonly HttpClient _client = new HttpClient();

        public BankController() { }

        [HttpGet("get-existing-bank")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        public async Task<IActionResult> GetBanks()
        {
            var response = await _client.GetAsync("https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks");
            if (!response.IsSuccessStatusCode)
            {
                
                return BadRequest(new BaseResponse
                {
                    Message = $"Error fetching banks: {response.StatusCode}"
                });
            }

            var contentType = response.Content.Headers.ContentType?.MediaType;
            if (contentType != "application/json")
            {
                
                return BadRequest(new BaseResponse
                {
                    Message = "Unexpected content type"
                });
            }

            var banks = await response.Content.ReadAsStringAsync();
            return Ok(banks);
            
        }
    }
}

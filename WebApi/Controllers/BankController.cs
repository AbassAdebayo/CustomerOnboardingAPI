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
            var response = await _client.GetAsync("https://wema-alatdev-apimgt.developer.azure-api.net/api-details#api=alat-tech-test-api/GetBanks");
            var banks = await response.Content.ReadAsByteArrayAsync();
            return Ok(banks);
        }
    }
}

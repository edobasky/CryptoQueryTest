using CryptoQueryTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoQueryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _service;

        public CryptoController(ICryptoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCrypto()
        {
            var response = await _service.GetAllCrypto();

            return Ok(response);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetCrypto(string Id)
        {
            var response = await _service.GetCryptoById(Id);

            return Ok(response);
        }
    }
}

using DataBaseMicroService.DTO;
using DataBaseMicroService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityController : ControllerBase
    {
        private readonly ElectricityPriceService _electricityPriceService;
        private readonly MyDbContext _myDbContext;
        private ILogger<ElectricityPriceService> _logger;


        public ElectricityController(ElectricityPriceService electricityPriceService, MyDbContext myDbContext, ILogger<ElectricityController> logger)
        {
            _electricityPriceService = electricityPriceService ?? throw new ArgumentNullException(nameof(electricityPriceService));
            _myDbContext = myDbContext ?? throw new ArgumentNullException();
        }

        //[HttpGet("/electricity/price")]
        //public async Task<IActionResult> GetElectricityPrice()
        //{
        //    var electricityPrice = await _electricityPriceService.GetElectricityPriceAsync();
        //    return Ok(electricityPrice);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ElectricityPriceDataDtoIn data)
        {
            if (data == null)
            {
                return BadRequest("Dataa ei vastaanotettu.");
            }

            var success = await _electricityPriceService.SaveAsync(data);

            if (!success)
            {
                _logger.LogError("Virhe tallennettaessa dataa tietokantaan.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Virhe tallennettaessa dataa tietokantaan.");
            }

            return Ok("Data vastaanotettu ja käsitelty.");
        }
    }

  
}

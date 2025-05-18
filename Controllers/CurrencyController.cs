using DbOprationWthEFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DbOprationWthEFCoreApp.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        // ✅ Constructor Fix: Parameter name and assignment
        public CurrencyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // ✅ Return IActionResult and use Ok() properly
        [HttpGet("")]
        public IActionResult GetAllCurrencies()
        {
            var result = _appDbContext.Currencies.ToList();
            return Ok(result);
        }
    }
}
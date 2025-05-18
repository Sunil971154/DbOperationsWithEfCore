using DbOprationWthEFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public  async Task<IActionResult>  GetAllCurrencies()
        {

            // var result = _appDbContext.Currencies.ToList();// tolist method linq ka hi part hai 
            // return Ok(result);

            // Likq ki kisi bhi query ko 2 form me likh sakte  hai 
            // var result = (from currencies in _appDbContext.Currencies
            //              select currencies).ToList();

           // var result = await _appDbContext.Currencies.ToListAsync();

            var result = await (from currencies in _appDbContext.Currencies
                         select currencies).ToListAsync();




            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrenciesByID([FromRoute]  int id  )
        {

            var result = await _appDbContext.Currencies.FindAsync(id);
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrenciesByName([FromRoute] string name)
        {

            var result = await _appDbContext.Currencies.Where(x => x.Title == name).FirstOrDefaultAsync();
            return Ok(result);
        }




    }
}
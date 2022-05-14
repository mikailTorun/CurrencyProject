using Currency.BusinessAPI.CurrencyService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Currency.BusinessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyServices currencyService;
        public CurrencyController(CurrencyServices currencyService)
        {
            this.currencyService = currencyService;
        }
        // GET: api/<CurrencyController>
        [HttpGet]
        public object GetLast2Month([FromHeader] string code)
        {

            return currencyService.getCurrencies(code);
        }
    }
}

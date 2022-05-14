using CRUDService;
using Currency.DataAPI.CurrencyService;
using Currency.DataAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Currency.DataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private string urlPatter = "https://www.tcmb.gov.tr/kurlar/{0}.xml";
        private readonly WebClient client;
        private readonly CurrencyServices currencyService;
        private readonly Crud crud;
        private readonly DataAccess.Entities.Currency currencyDb;

        public CurrencyController(CurrencyServices currencyService, Crud crud, DataAccess.Entities.Currency currencyDb)
        {
            this.currencyDb = currencyDb;
            this.crud = crud;
            this.currencyService = currencyService;
            client = new WebClient
            {
                Encoding = Encoding.UTF8
            };
        }

        [HttpGet("GetList")]
        public string GetList([FromHeader] string code)
        {
            return JsonConvert.SerializeObject(crud.getAll(code).ToList());
            //return crud.getAll(code).ToList();
        }
        // GET: api/<CurrencyController>
        [HttpGet("SaveToDB")]
        public Dictionary<DateTime, Array> SaveToDB()
        {
            Dictionary<DateTime, Array> currencyListwithDate = new();

            for (int i = 1; i <= 31; i++)
            {
                try
                {
                    //currencyListwithDate.Add(currencyService.GetByDate(new DateTime(2022, 3, i)).Item1, currencyService.GetByDate(new DateTime(2022, 3, i)).Item2);

                    currencyDb.Date = new DateTime(2022, 3, i);
                    foreach(var a in currencyService.GetByDate(new DateTime(2022, 3, i)))
                    {
                        currencyDb.Id = 0;
                        currencyDb.BanknoteBuying = a.BanknoteBuying;
                        currencyDb.BanknoteSelling = a.BanknoteSelling;
                        currencyDb.CrossRateUsd = a.CrossRateUsd;
                        currencyDb.CurrencyCode = a.CurrencyCode;
                        currencyDb.ForexBuying = a.ForexBuying;
                        currencyDb.ForexSelling = a.ForexSelling;
                        currencyDb.Name = a.Name;
                        currencyDb.Unit = a.Unit;

                        crud.insert(currencyDb);
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            for (int i = 1; i <= 30; i++)
            {
                try
                {
                    //currencyListwithDate.Add(currencyService.GetByDate(new DateTime(2022, 3, i)).Item1, currencyService.GetByDate(new DateTime(2022, 3, i)).Item2);
                    currencyDb.Date = new DateTime(2022, 4, i);
                    foreach (var a in currencyService.GetByDate(new DateTime(2022, 4, i)))
                    {
                        currencyDb.Id = 0;
                        currencyDb.BanknoteBuying = a.BanknoteBuying;
                        currencyDb.BanknoteSelling = a.BanknoteSelling;
                        currencyDb.CrossRateUsd = a.CrossRateUsd;
                        currencyDb.CurrencyCode = a.CurrencyCode;
                        currencyDb.ForexBuying = a.ForexBuying;
                        currencyDb.ForexSelling = a.ForexSelling;
                        currencyDb.Name = a.Name;
                        currencyDb.Unit = a.Unit;

                        crud.insert(currencyDb);
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return currencyListwithDate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.InjectionTests;
using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Krooze.EntranceTest.WriteHere.Tests.WebTests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Krooze.EntranceTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KroozeController : ControllerBase
    {
        readonly InjectionTest _injectioTest = new InjectionTest();
        readonly SimpleLogicTest _logicTest = new SimpleLogicTest();
        readonly XMLTest _xmlTest = new XMLTest();
        readonly WebTest _webTest = new WebTest();

        // POST api/Krooze/GetCruises
        [HttpPost]
        [Route("GetCruises")]
        public List<CruiseDTO> GetCruises([FromBody]CruiseRequestDTO request)
        {
            return _injectioTest.GetCruises(request);
        }

        // POST api/Krooze/IsThereDiscount
        [HttpPost]
        [Route("IsThereDiscount")]
        //public bool? IsThereDiscount([FromBody]CruiseDTO cruiseDTO)
        public bool? IsThereDiscount([FromBody]CruiseDTO cruiseDTO)
        {
            //string json = jarray.ToString();
            //CruiseDTO cruiseDTO = JsonConvert.DeserializeObject<CruiseDTO>(json);

            return _logicTest.IsThereDiscount(cruiseDTO);
        }

        // GET api/Krooze/GetInstallments/1000
        [HttpGet]
        [Route("GetInstallments/{fullprice}")]
        public int? GetInstallments(string fullPrice)
        {
            return _logicTest.GetInstallments(Decimal.Parse(fullPrice, CultureInfo.InvariantCulture));
        }

        // POST api/Krooze/GetOtherTaxes
        [HttpPost]
        [Route("GetOtherTaxes")]
        public decimal? GetOtherTaxes([FromBody]CruiseDTO cruiseDTO)
        {
            return _logicTest.GetOtherTaxes(cruiseDTO);
        }

        // POST api/Krooze/TranslateXML
        [HttpPost]
        [Route("TranslateXML")]
        public CruiseDTO TranslateXML()
        {
            return _xmlTest.TranslateXML();
        }

        // GET api/Krooze/GetDirector
        [HttpGet]
        [Route("GetDirector")]
        public string GetDirector()
        {
            return _webTest.GetDirector();
        }

        // GET api/Krooze/GetAllMovies
        [HttpGet]
        [Route("GetAllMovies")]
        public JObject GetAllMovies()
        {
            return _webTest.GetAllMovies();
        }
    }
}
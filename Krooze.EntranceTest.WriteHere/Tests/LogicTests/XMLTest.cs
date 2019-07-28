using Krooze.EntranceTest.WriteHere.Structure.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class XMLTest
    {
        public CruiseDTO TranslateXML()
        {
            //TODO: Take the Cruises.xml file, on the Resources folder, and translate it to the CruisesDTO object,
            //you can do it in any way, including intermediary objects

            //TextReader reader = new StreamReader(@"..\..\..\..\Krooze.EntranceTest.WriteHere\Resources\Cruises.xml");
            TextReader reader = new StreamReader(@"..\Krooze.EntranceTest.WriteHere\Resources\Cruises.xml");

            XDocument doc = XDocument.Load(reader);
            string jsonText = JsonConvert.SerializeXNode(doc);
            dynamic expandoObj = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
            CruiseDTO cruiseDTO = new CruiseDTO();
            cruiseDTO.CruiseCode = expandoObj.Cruises.CruiseId;
            cruiseDTO.ShipName = expandoObj.Cruises.ShipName;
            cruiseDTO.CabinValue = Decimal.Parse(expandoObj.Cruises.CabinPrice, CultureInfo.InvariantCulture);
            cruiseDTO.PortCharge = Decimal.Parse(expandoObj.Cruises.PortChargesAmt, CultureInfo.InvariantCulture);
            cruiseDTO.TotalValue = Decimal.Parse(expandoObj.Cruises.TotalCabinPrice, CultureInfo.InvariantCulture);
            var expandoDict1 = expandoObj.Cruises.CategoryPriceDetails.Pax[0] as IDictionary<string, object>;
            var expandoDict2 = expandoObj.Cruises.CategoryPriceDetails.Pax[1] as IDictionary<string, object>;

            List<PassengerCruiseDTO> passengerCruiseDTOs = new List<PassengerCruiseDTO>();
            passengerCruiseDTOs.Add(new PassengerCruiseDTO());
            passengerCruiseDTOs.Add(new PassengerCruiseDTO());
            cruiseDTO.PassengerCruise = passengerCruiseDTOs;

            CruiseDTO passangerCruiseDTO = passengerCruise(cruiseDTO, cruiseDTO.PassengerCruise.Count);
            cruiseDTO.PassengerCruise[0].PassengerCode = expandoDict1["@PaxID"].ToString();
            cruiseDTO.PassengerCruise[0].Cruise = passangerCruiseDTO;
            cruiseDTO.PassengerCruise[1].PassengerCode = expandoDict2["@PaxID"].ToString();
            cruiseDTO.PassengerCruise[1].Cruise = passangerCruiseDTO;

            return cruiseDTO;
        }

        private CruiseDTO passengerCruise(CruiseDTO cruiseDTO, int passengerCount)
        {
            CruiseDTO passengerCruiseDTO = new CruiseDTO();
            passengerCruiseDTO.CabinValue = cruiseDTO.CabinValue / passengerCount;
            passengerCruiseDTO.PortCharge = cruiseDTO.PortCharge / passengerCount;
            passengerCruiseDTO.TotalValue = cruiseDTO.TotalValue / passengerCount;

            return passengerCruiseDTO;
        }
    }
}

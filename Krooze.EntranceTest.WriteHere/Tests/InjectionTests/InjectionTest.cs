using System;
using System.Collections.Generic;
using Krooze.EntranceTest.WriteHere.Structure.Implementations;
using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Structure.Model;

namespace Krooze.EntranceTest.WriteHere.Tests.InjectionTests
{
    public class InjectionTest
    {
        //private IGetCruise _getCruise;

        //public InjectionTest(IGetCruise getCruise)
        //{
        //    _getCruise = getCruise;
        //}

        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            //TODO: This method receives a generic request, that has a cruise company code on it
            //There is an interface (IGetCruise) that is implemented by 3 classes (Company1, Company2 and Company3)
            //Make sure that the correct class is injected based on the CruiseCompanyCode on the request
            //without directly referencing the 3 classes and the method GetCruises of the chosen implementation is called

            var list = new List<CruiseDTO>();

            if (request.CruiseCompanyCode == 1)
            {
                Company1 company1 = new Company1();
                list = company1.GetCruises(request);
            }
            else if (request.CruiseCompanyCode == 2)
            {
                Company2 company2 = new Company2();
                list = company2.GetCruises(request);
            }
            else if (request.CruiseCompanyCode == 3)
            {
                Company3 company3 = new Company3();
                list = company3.GetCruises(request);
            }
            else
            {
                throw new System.Exception("Incorrect company code");
            }

            return list;
        }        
    }
}

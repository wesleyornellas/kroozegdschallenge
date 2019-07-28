using Krooze.EntranceTest.WriteHere.Structure.Model;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class SimpleLogicTest
    {
        public decimal? GetOtherTaxes(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, gets if there is some other tax that not the port charge
            decimal? otherTax = cruise.TotalValue - (cruise.CabinValue + cruise.PortCharge);
            if (otherTax < 0)
                otherTax = 0;
            return otherTax;
        }

        public bool? IsThereDiscount(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, check if the second passenger has some kind of discount, based on the first passenger price
            //Assume there are always 2 passengers on the list
            //cruise.

            if (cruise.PassengerCruise[0].Cruise.CabinValue > cruise.PassengerCruise[1].Cruise.CabinValue)
                return true;
            else
                return false;
        }

        public int? GetInstallments(decimal fullPrice)
        {
            //TODO: Based on the full price, find the max number of installments
            // -The absolute max number is 12
            // -The minimum value of the installment is 200

            int installments = 0;
            decimal installmentValue;

            while (installments < 12)
            {
                installments++;
                installmentValue = fullPrice / installments;

                if (installmentValue >= 200 || (installments == 1 && installmentValue < 200))
                    continue;
                else
                {
                    installments--;
                    break;
                }
            }

            return installments;
        }
    }
}

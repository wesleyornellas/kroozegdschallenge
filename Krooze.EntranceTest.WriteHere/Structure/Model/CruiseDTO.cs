using System.Collections.Generic;

namespace Krooze.EntranceTest.WriteHere.Structure.Model
{
    /// <summary>
    /// Cruise Transfer Object
    /// </summary>
    public class CruiseDTO
    {
        public string CruiseCode { get; set; }
        /// <summary>
        /// Total Value of the Cruise
        /// </summary>
        public decimal TotalValue { get; set; }
        /// <summary>
        /// Total Cabin (CAB) Value
        /// </summary>
        public decimal CabinValue { get; set; }
        /// <summary>
        /// Total Port Charge (PCH) Value
        /// </summary>
        public decimal PortCharge { get; set; }
        /// <summary>
        /// Ship Name
        /// </summary>
        public string ShipName { get; set; }

        public List<PassengerCruiseDTO> PassengerCruise { get; set; }

    }

    public class PassengerCruiseDTO
    {
        public CruiseDTO Cruise { get; set; }
        public string PassengerCode { get; set; }
    }
}

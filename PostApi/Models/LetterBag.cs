using System;
using System.Collections.Generic;

#nullable disable

namespace PostApi.Models
{
    public partial class LetterBag
    {
        public int LbagId { get; set; }
        public string BagNumber { get; set; }
        public int LetterCount { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public int? FkShipmentId { get; set; }

        public virtual Shipment FkShipment { get; set; }
    }
}

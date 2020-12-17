using System;
using System.Collections.Generic;

#nullable disable

namespace PostApi.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            LetterBags = new HashSet<LetterBag>();
            ParcelBags = new HashSet<ParcelBag>();
        }

        public int ShipmentId { get; set; }
        public string ShipmentNumber { get; set; }
        public string Airport { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }

        public virtual ICollection<LetterBag> LetterBags { get; set; }
        public virtual ICollection<ParcelBag> ParcelBags { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace PostApi.Models
{
    public partial class ParcelBag
    {
        public ParcelBag()
        {
            Parcels = new HashSet<Parcel>();
        }

        public int PbagId { get; set; }
        public string BagNumber { get; set; }
        public int? FkShipmentId { get; set; }

        public virtual Shipment FkShipment { get; set; }
        public virtual ICollection<Parcel> Parcels { get; set; }
    }
}

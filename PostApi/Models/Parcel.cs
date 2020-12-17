using System;
using System.Collections.Generic;

#nullable disable

namespace PostApi.Models
{
    public partial class Parcel
    {
        public int ParcelId { get; set; }
        public string ParcelNumber { get; set; }
        public string RecipientName { get; set; }
        public string Destination { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public int? FkPbagId { get; set; }

        public virtual ParcelBag FkPbag { get; set; }
    }
}

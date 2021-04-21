namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Services_TBL
    {
        [Key]
        public int ServiceId { get; set; }

        [StringLength(100)]
        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        [StringLength(100)]
        public string ServiceIcon { get; set; }
    }
}

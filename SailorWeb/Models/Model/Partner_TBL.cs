namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Partner_TBL
    {
        [Key]
        public int PartnerId { get; set; }

        [StringLength(250)]
        public string LogoURL { get; set; }

        [StringLength(250)]
        public string LogoAdress { get; set; }
    }
}

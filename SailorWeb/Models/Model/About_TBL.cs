namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class About_TBL
    {
        [Key]
        public int AboutId { get; set; }

        [StringLength(500)]
        public string AboutHeader { get; set; }

        [StringLength(600)]
        public string AboutShHeader { get; set; }

        public string AboutDescrition { get; set; }
    }
}

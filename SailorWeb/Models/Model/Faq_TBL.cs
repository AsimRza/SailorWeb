namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Faq_TBL
    {
        [Key]
        public int FaqId { get; set; }

        [StringLength(500)]
        public string FaqHeader { get; set; }

        public string FaqDescription { get; set; }
    }
}

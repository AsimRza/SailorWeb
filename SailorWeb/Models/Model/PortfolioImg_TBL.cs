namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PortfolioImg_TBL
    {
        [Key]
        public int ImgId { get; set; }

        public int PortfolioId { get; set; }

        [StringLength(250)]
        public string ImgURL { get; set; }

        public virtual Portfolio_TBL Portfolio_TBL { get; set; }
    }
}

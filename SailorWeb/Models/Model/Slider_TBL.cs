namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slider_TBL
    {
        [Key]
        public int SliderId { get; set; }

        [StringLength(250)]
        public string ImageURL { get; set; }

        [StringLength(300)]
        public string SliderHeader { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string ButtonText { get; set; }

        [StringLength(250)]
        public string ButtonURL { get; set; }
    }
}

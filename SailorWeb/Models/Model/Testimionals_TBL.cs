namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Testimionals_TBL
    {
        [Key]
        public int TestimonialsId { get; set; }

        [StringLength(250)]
        public string ImageURL { get; set; }

        [StringLength(150)]
        public string TestimonialJob { get; set; }

        public string TestimionalDescription { get; set; }

        [StringLength(150)]
        public string NameSurname { get; set; }
    }
}

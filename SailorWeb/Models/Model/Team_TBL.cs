namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Team_TBL
    {
        [Key]
        public int TeamId { get; set; }

        [StringLength(100)]
        public string TeamName { get; set; }

        [StringLength(200)]
        public string TeamPosition { get; set; }
        public string TeamDescription { get; set; }
        [StringLength(150)]
        public string TeamImg { get; set; }
        [StringLength(200)]
        public string Twitter { get; set; }

        [StringLength(200)]
        public string Facebook { get; set; }

        [StringLength(200)]
        public string Instagram { get; set; }

        [StringLength(200)]
        public string Linkedin { get; set; }
    }
}

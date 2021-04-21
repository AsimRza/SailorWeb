namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Skills_TBL
    {
        [Key]
        public int SkillsID { get; set; }

        [StringLength(100)]
        public string SkillsName { get; set; }

        public short? SkillPercent { get; set; }
    }
}

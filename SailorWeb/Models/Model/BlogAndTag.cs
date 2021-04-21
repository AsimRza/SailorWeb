namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlogAndTag")]
    public partial class BlogAndTag
    {
        [Key]
        public int BTId { get; set; }

        public int BlogId { get; set; }

        public int TagId { get; set; }

        public virtual Blog_TBL Blog_TBL { get; set; }

        public virtual Tag_TBL Tag_TBL { get; set; }
    }
}

namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment_TBL
    {
        [Key]
        public int CommentId { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string UserEmail { get; set; }

        public string CommentDescription { get; set; }

        public int BlogId { get; set; }

        public DateTime? WritedDate { get; set; }

        public virtual Blog_TBL Blog_TBL { get; set; }
    }
}

namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Blog_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blog_TBL()
        {
            BlogAndTag = new HashSet<BlogAndTag>();
            Comment_TBL = new HashSet<Comment_TBL>();
        }

        [Key]
        public int BlogId { get; set; }

        [StringLength(500)]
        public string BlogHeader { get; set; }

        public string BlogDescription { get; set; }

        [StringLength(100)]
        public string BlogAuthor { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string BlogImg { get; set; }

        public int CategoryId { get; set; }

        public virtual BlogCategory_TBL BlogCategory_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogAndTag> BlogAndTag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment_TBL> Comment_TBL { get; set; }
    }
}

namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BlogCategory_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BlogCategory_TBL()
        {
            Blog_TBL = new HashSet<Blog_TBL>();
            Status = true;
        }

        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog_TBL> Blog_TBL { get; set; }
    }
}

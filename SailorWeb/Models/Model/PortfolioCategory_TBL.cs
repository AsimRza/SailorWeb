namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PortfolioCategory_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PortfolioCategory_TBL()
        {
            Portfolio_TBL = new HashSet<Portfolio_TBL>();
        }

        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio_TBL> Portfolio_TBL { get; set; }
    }
}

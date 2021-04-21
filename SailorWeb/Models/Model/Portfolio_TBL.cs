namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portfolio_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Portfolio_TBL()
        {
            PortfolioImg_TBL = new HashSet<PortfolioImg_TBL>();
        }

        [Key]
        public int PortfolioId { get; set; }

        [StringLength(250)]
        public string ProjectHeader { get; set; }

        public string ProjectDescription { get; set; }

        [StringLength(250)]
        public string ProjectUrl { get; set; }

        public DateTime? ProjectDate { get; set; }

        [Column(TypeName = "image")]
        public byte[] ClientName { get; set; }

        public int CategoryId { get; set; }

        public virtual PortfolioCategory_TBL PortfolioCategory_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PortfolioImg_TBL> PortfolioImg_TBL { get; set; }
    }
}

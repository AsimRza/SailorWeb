namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PageIdentity_TBL
    {
        [Key]
        public int PId { get; set; }

        [StringLength(100)]
        public string MetaAuthor { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string LogoURL { get; set; }

        [StringLength(250)]
        public string PageTitle { get; set; }
    }
}

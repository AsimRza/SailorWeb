namespace SailorWeb.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact_TBL
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(300)]
        public string Location { get; set; }

        [StringLength(80)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Number { get; set; }

        [StringLength(100)]
        public string Twitter { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        [StringLength(100)]
        public string Instagram { get; set; }

        [StringLength(100)]
        public string Skype { get; set; }

        [StringLength(100)]
        public string Linkedin { get; set; }
    }
}

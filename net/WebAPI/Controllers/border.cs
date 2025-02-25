namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("border")]
    public partial class border
    {
        public int id { get; set; }

        public int? country_id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        public virtual country country { get; set; }
    }
}

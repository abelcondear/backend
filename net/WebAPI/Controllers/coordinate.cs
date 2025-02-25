namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coordinate")]
    public partial class coordinate
    {
        public int id { get; set; }

        public int? country_id { get; set; }

        public long? latitude { get; set; }

        public long? longitude { get; set; }

        public virtual country country { get; set; }
    }
}

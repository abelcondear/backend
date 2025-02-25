namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("country")]
    public partial class country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public country()
        {
            border = new HashSet<border>();
            coordinate = new HashSet<coordinate>();
            language = new HashSet<language>();
            timezone = new HashSet<timezone>();
        }

        public int id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [StringLength(250)]
        public string capital { get; set; }

        [StringLength(50)]
        public string region { get; set; }

        [StringLength(50)]
        public string subregion { get; set; }

        public int? population { get; set; }

        public int? area { get; set; }

        [StringLength(100)]
        public string currency { get; set; }

        [StringLength(250)]
        public string flag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<border> border { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<coordinate> coordinate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<language> language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timezone> timezone { get; set; }
    }
}

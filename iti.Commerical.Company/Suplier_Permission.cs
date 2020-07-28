namespace iti.Commerical.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Suplier_Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Suplier_Permission()
        {
            Suplier_Category = new HashSet<Suplier_Category>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Permission_num { get; set; }

        [Column(TypeName = "date")]
        public DateTime Permission_Date { get; set; }

        public int Suplier_Id { get; set; }

        public int Stored_Id { get; set; }

        public virtual Story Story { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Suplier_Category> Suplier_Category { get; set; }

        public virtual Suplier Suplier { get; set; }
    }
}

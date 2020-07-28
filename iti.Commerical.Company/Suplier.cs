namespace iti.Commerical.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Suplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Suplier()
        {
            Categories = new HashSet<Category>();
            Suplier_Permission = new HashSet<Suplier_Permission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Suplier_Id { get; set; }

        public string Suplier_Name { get; set; }

        [StringLength(50)]
        public string Suplier_Phone { get; set; }

        [StringLength(50)]
        public string Suplier_Fax { get; set; }

        [StringLength(50)]
        public string Suplier_telephone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Suplier_Permission> Suplier_Permission { get; set; }
    }
}

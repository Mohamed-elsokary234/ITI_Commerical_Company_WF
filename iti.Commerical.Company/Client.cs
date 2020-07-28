namespace iti.Commerical.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Clients_Permission = new HashSet<Clients_Permission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client_Id { get; set; }

        public string Client_Name { get; set; }

        [StringLength(50)]
        public string Client_Phone { get; set; }

        public string Client_Address { get; set; }

        [StringLength(50)]
        public string Client_Telephone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clients_Permission> Clients_Permission { get; set; }
    }
}

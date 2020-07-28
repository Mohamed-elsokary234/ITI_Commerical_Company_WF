namespace iti.Commerical.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [Key]
        [StringLength(100)]
        public string Company_Name { get; set; }

        public string Company_Address { get; set; }

        [StringLength(50)]
        public string Company_Phone { get; set; }
    }
}

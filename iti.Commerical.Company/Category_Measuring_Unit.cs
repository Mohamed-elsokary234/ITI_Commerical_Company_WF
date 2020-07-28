namespace iti.Commerical.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category_Measuring_Unit
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int categ_Code_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string categ_measuring_unit { get; set; }

        public virtual Category Category { get; set; }
    }
}

namespace iti.Commerical.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Suplier_Category
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Suplier_category_Code { get; set; }

        [StringLength(50)]
        public string Suplier_category_Name { get; set; }

        public int? Suplier_category_Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Suplier_category_Product_date { get; set; }

        public int? Suplier_category_expiry { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Premission_num { get; set; }

        public virtual Suplier_Permission Suplier_Permission { get; set; }
    }
}

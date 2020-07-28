namespace iti.Commerical.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Category_Code { get; set; }

        [StringLength(50)]
        public string Category_Name { get; set; }

        public int? Category_expiry { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Product_Date { get; set; }

        public int? Category_Amount { get; set; }

        public int? Suplier_Id { get; set; }

        public int? Stored_Id { get; set; }

        public string measure_units { get; set; }

        public virtual Story Story { get; set; }

        public virtual Suplier Suplier { get; set; }
    }
}

namespace iti.Commerical.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clients_Permission_Category
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client_category_Code { get; set; }

        [StringLength(50)]
        public string Client_category_Name { get; set; }

        public int? Client_category_Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Client_category_Product_date { get; set; }

        public int? Client_category_expiry { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client_Premission_num { get; set; }

        public virtual Clients_Permission Clients_Permission { get; set; }
    }
}

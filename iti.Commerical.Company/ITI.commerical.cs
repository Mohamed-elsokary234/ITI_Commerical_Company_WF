namespace iti.Commerical.Company
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ITIcommerical : DbContext
    {
        public ITIcommerical()
            : base("name=ITI_commerical_company")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Category_Measuring_Unit> Category_Measuring_Unit { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Clients_Permission> Clients_Permission { get; set; }
        public virtual DbSet<Clients_Permission_Category> Clients_Permission_Category { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Story> Stories { get; set; }
        //public virtual DbSet<Story> Stories { get; set; }
        //public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<Suplier_Category> Suplier_Category { get; set; }
        public virtual DbSet<Suplier_Permission> Suplier_Permission { get; set; }
        public virtual DbSet<Suplier> Supliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.Category_Measuring_Unit)
            //    .WithRequired(e => e.Category)
            //    .HasForeignKey(e => e.categ_Code_Id)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Clients_Permission)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clients_Permission>()
                .HasMany(e => e.Clients_Permission_Category)
                .WithRequired(e => e.Clients_Permission)
                .HasForeignKey(e => e.Client_Premission_num)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Story>()
                .HasMany(e => e.Clients_Permission)
                .WithRequired(e => e.Story)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Story>()
                .HasMany(e => e.Suplier_Permission)
                .WithRequired(e => e.Story)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Suplier_Permission>()
                .HasMany(e => e.Suplier_Category)
                .WithRequired(e => e.Suplier_Permission)
                .HasForeignKey(e => e.Premission_num)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Suplier>()
                .HasMany(e => e.Suplier_Permission)
                .WithRequired(e => e.Suplier)
                .WillCascadeOnDelete(false);
        }
    }
}

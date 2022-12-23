using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DBAccess.Entities
{
    public partial class AutoShowDb : DbContext
    {
        public AutoShowDb()
            : base("name=DbConnection")
        {
        }

        public virtual DbSet<AdditionalServices> AdditionalServices { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CategoryServices> CategoryServices { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Colour> Colour { get; set; }
        public virtual DbSet<ContractSale> ContractSale { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SaleLines> SaleLines { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transmission> Transmission { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalServices>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AdditionalServices>()
                .HasMany(e => e.SaleLines)
                .WithRequired(e => e.AdditionalServices)
                .HasForeignKey(e => e.additional_services_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdditionalServices>()
                .HasMany(e => e.Model)
                .WithMany(e => e.AdditionalServices)
                .Map(m => m.ToTable("ModelsAdditionaS").MapLeftKey("additional_services_id").MapRightKey("model_id"));

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Model)
                .WithRequired(e => e.Brand)
                .HasForeignKey(e => e.brand_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.ContractSale)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.car_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategoryServices>()
                .HasMany(e => e.AdditionalServices)
                .WithRequired(e => e.CategoryServices)
                .HasForeignKey(e => e.category_services_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.ContractSale)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.client_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Sale)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<Colour>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Colour>()
                .HasMany(e => e.Car)
                .WithRequired(e => e.Colour)
                .HasForeignKey(e => e.colour_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ContractSale)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.employee_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Sale)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.employee_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Engine>()
                .HasMany(e => e.Equipment)
                .WithRequired(e => e.Engine)
                .HasForeignKey(e => e.engine_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.Car)
                .WithRequired(e => e.Equipment)
                .HasForeignKey(e => e.equipment_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.Equipment)
                .WithRequired(e => e.Model)
                .HasForeignKey(e => e.model_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Position)
                .HasForeignKey(e => e.position_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Sale>()
                .HasMany(e => e.SaleLines)
                .WithRequired(e => e.Sale)
                .HasForeignKey(e => e.sale_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transmission>()
                .HasMany(e => e.Equipment)
                .WithRequired(e => e.Transmission)
                .HasForeignKey(e => e.transmission_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Model)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.type_id)
                .WillCascadeOnDelete(false);
        }
    }
}

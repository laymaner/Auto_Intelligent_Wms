using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mask_STK.Core.WebApi.Models
{
    public class Auto_Inteligent_Wms_DbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User_Role_RelationShip> User_Role_RelationShips { get; set; }

        public DbSet<Factory> Factorys { get; set; }

        public DbSet<WareHouse> WareHouses { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Shelf> Shelfs { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<MaterialStock> MaterialStocks { get; set; }

        public DbSet<MaterialStock_History> MaterialStock_Histories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Material_Supplier_RelationShip> Material_Supplier_RelationShips { get; set; }

        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }

        public DbSet<DeliveryOrder_Item> DeliveryOrder_Items { get; set; }

        public DbSet<ReceiptOrder> ReceiptOrders { get; set; }

        public DbSet<ReceiptOrder_Item> ReceiptOrder_Items { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<RelocationOrder> RelocationOrders { get; set; }



        public Auto_Inteligent_Wms_DbContext(DbContextOptions<Auto_Inteligent_Wms_DbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}

using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mask_STK.Core.WebApi.Models
{
    public class Auto_Inteligent_Wms_DbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User_Role_RelationShip> User_Role_RelationShips { get; set; }

        public DbSet<WareHouse> WareHouses { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Shelf> Shelfs { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Material_Supplier_RelationShip> Material_Supplier_RelationShips { get; set; }

        public DbSet<Castle> Castles { get; set; }

        public DbSet<ExpOrder> ExpOrders { get; set; }

        public DbSet<ExpOrder_Items> ExpOrder_Items { get; set; }

        public DbSet<ImpOrder>  ImpOrders { get; set; }

        public DbSet<ImpOrder_Items> ImpOrder_Items { get; set; }

        public DbSet<StockInventory> StockInventories { get; set; }

        public DbSet<StockInventory_History> StockInventory_Histories { get; set; }

        public DbSet<Operate_Log> Operate_Logs { get; set; }

        public DbSet<PassageWay> PassageWays { get; set; }





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

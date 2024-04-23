using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Mask_STK.Core.WebApi.Models
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<Auto_Inteligent_Wms_DbContext>
    {
        public Auto_Inteligent_Wms_DbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<Auto_Inteligent_Wms_DbContext> builder = new DbContextOptionsBuilder<Auto_Inteligent_Wms_DbContext>();
            builder.UseSqlServer("Data Source=localhost;Initial Catalog=Mask_STK_Test;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new Auto_Inteligent_Wms_DbContext(builder.Options);
        }
    }
}

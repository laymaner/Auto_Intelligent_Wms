using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{ 
    public class WareHouseConfig : IEntityTypeConfiguration<WareHouse>
    {
        public void Configure(EntityTypeBuilder<WareHouse> builder)
        {
            builder.ToTable("Mask_STK_WareHouses");
            builder.HasComment("仓库");
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("仓库名称").IsRequired();
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("仓库编码").IsRequired();
            builder.Property(m => m.Type).HasMaxLength(5).HasComment("仓库类型").IsRequired();
            builder.Property(m => m.FactoryId).HasComment("工厂id").IsRequired();
            builder.Property(m => m.FactoryCode).HasMaxLength(20).HasComment("工厂编码").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

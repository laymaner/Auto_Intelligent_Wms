using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class DeliveryOrderConfig : IEntityTypeConfiguration<DeliveryOrder>
    {
        public void Configure(EntityTypeBuilder<DeliveryOrder> builder)
        {
            builder.ToTable("Mask_STK_DeliveryOrders");
            builder.HasComment("出库单主单据");
            builder.Property(m => m.DeliveryOrderCode).HasMaxLength(20).HasComment("出库单编码").IsRequired();
            builder.Property(m => m.DeliveryOrderType).HasMaxLength(5).HasComment("出库单类型").IsRequired();
            builder.Property(m => m.DeliveryOrderTypeDesc).HasComment("出库单类型描述");
            builder.Property(m => m.FactoryCode).HasMaxLength(20).HasComment("出库所选工厂").IsRequired();
            builder.Property(m => m.WareHouseCode).HasMaxLength(20).HasComment("出库所选仓库").IsRequired();
            builder.Property(m => m.Step).HasMaxLength(2).HasDefaultValue(1).HasComment("出库当前步骤：1：待出库 2：已出库").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.DeliveryTime).HasComment("出库时间");
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

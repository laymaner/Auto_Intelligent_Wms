using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class RelocationOrderConfig : IEntityTypeConfiguration<RelocationOrder>
    {
        public void Configure(EntityTypeBuilder<RelocationOrder> builder)
        {
            builder.ToTable("Mask_STK_RelocationOrders");
            builder.HasComment("移库单主单据数据");
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("移库单编码").IsRequired();
            builder.Property(m => m.Type).HasMaxLength(2).HasComment("移库单类型  1：库内移库 2：库间移库 3：工厂间调拨").IsRequired();
            builder.Property(m => m.OriginalFactoryId).HasComment("移库前原工厂id").IsRequired();
            builder.Property(m => m.OriginalFactoryName).HasMaxLength(20).HasComment("移库前原工厂名称").IsRequired();
            builder.Property(m => m.OriginalFactoryCode).HasMaxLength(20).HasComment("移库前原工厂编码").IsRequired();
            builder.Property(m => m.OriginalWareHouseId).HasComment("移库前原仓库id").IsRequired();
            builder.Property(m => m.OriginalWareHouseName).HasMaxLength(20).HasComment("移库前原仓库名称").IsRequired();
            builder.Property(m => m.OriginalWareHouseCode).HasMaxLength(20).HasComment("移库前原仓库编码").IsRequired();
            builder.Property(m => m.OriginalAreaId).HasComment("移库前原库区id").IsRequired();
            builder.Property(m => m.OriginalAreaName).HasMaxLength(20).HasComment("移库前原库区名称").IsRequired();
            builder.Property(m => m.OriginalAreaCode).HasMaxLength(20).HasComment("移库前原库区编码").IsRequired();
            builder.Property(m => m.OriginalLocationId).HasComment("移库前原库位id").IsRequired();
            builder.Property(m => m.OriginalLocationName).HasMaxLength(20).HasComment("移库前原库位名称").IsRequired();
            builder.Property(m => m.OriginalLocationCode).HasMaxLength(20).HasComment("移库前原库位编码").IsRequired();

            builder.Property(m => m.FactoryId).HasComment("移库后现工厂id").IsRequired();
            builder.Property(m => m.FactoryName).HasMaxLength(20).HasComment("移库后现工厂名称").IsRequired();
            builder.Property(m => m.FactoryCode).HasMaxLength(20).HasComment("移库后现工厂编码").IsRequired();
            builder.Property(m => m.WareHouseId).HasComment("移库后现仓库id").IsRequired();
            builder.Property(m => m.WareHouseName).HasMaxLength(20).HasComment("移库后现仓库名称").IsRequired();
            builder.Property(m => m.WareHouseCode).HasMaxLength(20).HasComment("移库后现仓库编码").IsRequired();
            builder.Property(m => m.AreaId).HasComment("移库后现库区id").IsRequired();
            builder.Property(m => m.AreaName).HasMaxLength(20).HasComment("移库后现库区名称").IsRequired();
            builder.Property(m => m.AreaCode).HasMaxLength(20).HasComment("移库后现库区编码").IsRequired();
            builder.Property(m => m.LocationId).HasComment("移库后现库位id").IsRequired();
            builder.Property(m => m.LocationName).HasMaxLength(20).HasComment("移库后现库位名称").IsRequired();
            builder.Property(m => m.LocationCode).HasMaxLength(20).HasComment("移库后现库位编码").IsRequired();

            builder.Property(m => m.Step).HasMaxLength(2).HasDefaultValue(1).HasComment("移库当前步骤：1：待移库 2：已移库").IsRequired();
            builder.Property(m => m.RelocationTime).HasComment("移库时间");
            builder.Property(m => m.MaterialStockIds).HasComment("库存ids").IsRequired();

            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class ReceiptOrder_ItemConfig : IEntityTypeConfiguration<ReceiptOrder_Item>
    {
        public void Configure(EntityTypeBuilder<ReceiptOrder_Item> builder)
        {
            builder.ToTable("Mask_STK_ReceiptOrder_Items");
            builder.HasComment("入库单明细单据数据");
            builder.Property(m => m.ReceiptOrderId).HasComment("入库单id").IsRequired();
            builder.Property(m => m.MaterialId).HasComment("物料id").IsRequired();
            builder.Property(m => m.MaterialCode).HasMaxLength(20).HasComment("物料编码").IsRequired();
            builder.Property(m => m.MaterialName).HasMaxLength(20).HasComment("物料名称").IsRequired();
            builder.Property(m => m.SupplierId).HasComment("供应商id").IsRequired();
            builder.Property(m => m.SupplierCode).HasMaxLength(20).HasComment("供应商编码").IsRequired();
            builder.Property(m => m.SupplierName).HasMaxLength(20).HasComment("供应商名称").IsRequired();
            builder.Property(m => m.AreaId).HasComment("库区id").IsRequired();
            builder.Property(m => m.AreaName).HasMaxLength(20).HasComment("库区名称").IsRequired();
            builder.Property(m => m.AreaCode).HasMaxLength(20).HasComment("库区编码").IsRequired();
            builder.Property(m => m.LocationId).HasComment("库位id").IsRequired();
            builder.Property(m => m.LocationName).HasMaxLength(20).HasComment("库位名称").IsRequired();
            builder.Property(m => m.LocationCode).HasMaxLength(20).HasComment("库位编码").IsRequired();
            builder.Property(m => m.Unit).HasMaxLength(20).HasComment("基本单位").IsRequired();
            builder.Property(m => m.PriceUint).HasMaxLength(20).HasComment("价格单位").IsRequired();
            builder.Property(m => m.Price).HasComment(" 每个/价格").IsRequired();
            builder.Property(m => m.ValidityPeriod).HasComment("有效期").IsRequired();
            builder.Property(m => m.SchemeReceiptQuantity).HasComment(" 计划入库数量").IsRequired();
            builder.Property(m => m.RelReceiptQuantity).HasComment(" 实际入库数量").IsRequired();
            builder.Property(m => m.Step).HasMaxLength(2).HasDefaultValue(1).HasComment("入库当前步骤 1:待入库 2:已入库").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

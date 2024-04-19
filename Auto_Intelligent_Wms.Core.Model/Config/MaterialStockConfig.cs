using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class MaterialStockConfig : IEntityTypeConfiguration<MaterialStock>
    {
        public void Configure(EntityTypeBuilder<MaterialStock> builder)
        {
            builder.ToTable("Mask_STK_MaterialStocks");
            builder.HasComment("库存");
            builder.Property(m => m.MaterialId).HasComment("物料id").IsRequired();
            builder.Property(m => m.MaterialCode).HasMaxLength(20).HasComment("物料编码").IsRequired();
            builder.Property(m => m.MaterialName).HasMaxLength(20).HasComment("物料名称").IsRequired();
            builder.Property(m => m.MaterialType).HasMaxLength(5).HasComment("物料类型").IsRequired();
            builder.Property(m => m.SupplierId).HasComment("供应商id").IsRequired();
            builder.Property(m => m.SupplierCode).HasMaxLength(20).HasComment("供应商编码").IsRequired();
            builder.Property(m => m.SupplierName).HasMaxLength(20).HasComment("供应商名称").IsRequired();
            builder.Property(m => m.FactoryId).HasComment("工厂id").IsRequired();
            builder.Property(m => m.FactoryName).HasMaxLength(20).HasComment("工厂名称").IsRequired();
            builder.Property(m => m.FactoryCode).HasMaxLength(20).HasComment("工厂编码").IsRequired();
            builder.Property(m => m.WareHouseId).HasComment("仓库id").IsRequired();
            builder.Property(m => m.WareHouseName).HasMaxLength(20).HasComment("仓库名称").IsRequired();
            builder.Property(m => m.WareHouseCode).HasMaxLength(20).HasComment("仓库编码").IsRequired();
            builder.Property(m => m.AreaId).HasComment("库区id").IsRequired();
            builder.Property(m => m.AreaName).HasMaxLength(20).HasComment("库区名称").IsRequired();
            builder.Property(m => m.AreaCode).HasMaxLength(20).HasComment("库区编码").IsRequired();
            builder.Property(m => m.LocationId).HasComment("库位id").IsRequired();
            builder.Property(m => m.LocationName).HasMaxLength(20).HasComment("库位名称").IsRequired();
            builder.Property(m => m.LocationCode).HasMaxLength(20).HasComment("库位编码").IsRequired();
            builder.Property(m => m.Quantity).HasComment(" 数量").IsRequired();
            builder.Property(m => m.Unit).HasMaxLength(20).HasComment("基本单位").IsRequired();
            builder.Property(m => m.PriceUint).HasMaxLength(20).HasComment("价格单位").IsRequired();
            builder.Property(m => m.Price).HasComment(" 每个/价格").IsRequired();
            builder.Property(m => m.ValidityPeriod).HasComment("有效期").IsRequired();
            builder.Property(m => m.IsOccupy).HasMaxLength(1).HasComment("是否占用 N/Y");
            builder.Property(m => m.IsLock).HasMaxLength(1).HasComment("是否锁定 N/Y");
            builder.Property(m => m.IsFreeze).HasMaxLength(1).HasComment("是否冻结 N/Y");
            builder.Property(m => m.IsEligibility).HasMaxLength(1).HasComment("是否合格 N/Y");
            builder.Property(m => m.IsScrap).HasMaxLength(1).HasComment("是否报废 N/Y");
            builder.Property(m => m.BatchNo).HasMaxLength(20).HasComment("批次号").IsRequired();
            builder.Property(m => m.TrayNo).HasMaxLength(100).HasComment("托标签").IsRequired();
            builder.Property(m => m.SnTag).HasMaxLength(100).HasComment("SN标签").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");

        }
    }
}

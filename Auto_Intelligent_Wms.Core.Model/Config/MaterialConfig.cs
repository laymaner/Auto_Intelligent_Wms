using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class MaterialConfig : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Mask_STK_Materials");
            builder.HasComment("物料");
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("物料名称").IsRequired();
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("物料编码").IsRequired();
            builder.Property(m => m.Type).HasMaxLength(5).HasComment("物料类型").IsRequired();
            builder.Property(m => m.Description).HasComment("物料描述");
            builder.Property(m => m.FactoryId).HasComment("工厂id").IsRequired();
            builder.Property(m => m.FactoryName).HasMaxLength(20).HasComment("工厂名称").IsRequired();
            builder.Property(m => m.FactoryCode).HasMaxLength(20).HasComment("工厂编码").IsRequired();
            builder.Property(m => m.Unit).HasMaxLength(20).HasComment("基本单位").IsRequired();
            builder.Property(m => m.PriceUint).HasMaxLength(20).HasComment("价格单位").IsRequired();
            builder.Property(m => m.Price).HasComment(" 每个/价格").IsRequired();
            builder.Property(m => m.ValidityPeriod).HasComment("有效期").IsRequired();
            builder.Property(m => m.MinimumPackagingQuantity).HasComment("最小包装数量").IsRequired();
            builder.Property(m => m.Quantity).HasComment("基本计量单位数量").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Version).HasMaxLength(5).HasComment("物料等级").IsRequired();
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

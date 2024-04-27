using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class LabelConfig : IEntityTypeConfiguration<Label>
    {

        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("Mask_STK_Labels");
            builder.HasComment("标签");
            builder.Property(m => m.SnCode).HasMaxLength(100).HasComment("SnCode");
            builder.Property(m => m.CastleCode).HasMaxLength(50).HasComment("Castle编码");
            builder.Property(m => m.CastleType).HasComment("Castle类型");
            builder.Property(m => m.SupplierCode).HasMaxLength(50).HasComment("供应商编码");
            builder.Property(m => m.MaterialCode).HasMaxLength(50).HasComment("物料编码");
            builder.Property(m => m.BatchNo).HasMaxLength(50).HasComment("批次号");
            builder.Property(m => m.Quantity).HasComment("数量");
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

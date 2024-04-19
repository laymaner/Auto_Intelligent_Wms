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
            builder.Property(m => m.BatchNo).HasMaxLength(20).HasComment("批次号").IsRequired();
            builder.Property(m => m.TrayNo).HasMaxLength(100).HasComment("托标签").IsRequired();
            builder.Property(m => m.SnTag).HasMaxLength(100).HasComment("SN标签").IsRequired();
            builder.Property(m => m.Quantity).HasComment("数量").IsRequired();
            builder.Property(m => m.FactoryId).HasComment("工厂id").IsRequired();
            builder.Property(m => m.FactoryName).HasMaxLength(20).HasComment("工厂名称").IsRequired();
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

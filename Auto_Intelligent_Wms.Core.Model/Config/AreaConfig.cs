using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class AreaConfig : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Mask_STK_Area");
            builder.HasComment("库区");
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("库区名称").IsRequired();
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("库区编码").IsRequired();
            builder.Property(m => m.WareHouseId).HasComment("仓库id").IsRequired();
            builder.Property(m => m.WareHouseCode).HasMaxLength(20).HasComment("仓库编码").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class ShelfConfig : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Shelf> builder)
        {
            builder.ToTable("Mask_STK_Shelfs");
            builder.HasComment("货架");
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("货架名称").IsRequired();
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("货架编码").IsRequired();
            builder.Property(m => m.AreaId).HasComment("库区id").IsRequired();
            builder.Property(m => m.AreaCode).HasMaxLength(20).HasComment("库区编码").IsRequired();
            builder.Property(m => m.AreaName).HasMaxLength(20).HasComment("库区名称").IsRequired();
            builder.Property(m => m.RoadWay).HasComment("巷道数").IsRequired();
            builder.Property(m => m.ShelfRows).HasComment("排数").IsRequired();
            builder.Property(m => m.ShelfColumns).HasComment("列数").IsRequired();
            builder.Property(m => m.ShelfLayers).HasComment("层数").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

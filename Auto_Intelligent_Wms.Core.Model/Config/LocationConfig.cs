using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Mask_STK_Locations");
            builder.HasComment("货位");
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("货位名称").IsRequired();
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("货位编码").IsRequired();
            builder.Property(m => m.ShelfId).HasComment("货架id").IsRequired();
            builder.Property(m => m.ShelfCode).HasMaxLength(20).HasComment("货架编码").IsRequired();
            builder.Property(m => m.ShelfName).HasMaxLength(20).HasComment("货架名称").IsRequired();
            builder.Property(m => m.RoadWay).HasComment("巷道").IsRequired();
            builder.Property(m => m.LRow).HasComment("排").IsRequired();
            builder.Property(m => m.LColumn).HasComment("列").IsRequired();
            builder.Property(m => m.Layer).HasComment("层").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

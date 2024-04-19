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
            builder.HasComment("库位");
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("库位名称").IsRequired();
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("库位编码").IsRequired();
            builder.Property(m => m.AreaId).HasComment("库区id").IsRequired();
            builder.Property(m => m.AreaCode).HasMaxLength(20).HasComment("库区编码").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

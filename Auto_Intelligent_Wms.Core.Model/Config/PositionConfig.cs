using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Mask_STK_Positions");
            builder.HasComment("精确存储位置");
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("精确存储位置名称").IsRequired();
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("精确存储位置编码").IsRequired();
            builder.Property(m => m.LocationId).HasComment("货位id").IsRequired();
            builder.Property(m => m.LocationCode).HasMaxLength(20).HasComment("货位编码").IsRequired();
            builder.Property(m => m.LocationName).HasMaxLength(20).HasComment("货位名称").IsRequired();
            builder.Property(m => m.RoadWay).HasComment("巷道").IsRequired();
            builder.Property(m => m.LRow).HasComment("排").IsRequired();
            builder.Property(m => m.LColumn).HasComment("列").IsRequired();
            builder.Property(m => m.Layer).HasComment("层").IsRequired();
            builder.Property(m => m.Lattice).HasComment("第几格").IsRequired();
            builder.Property(m => m.ImpLock).HasComment("入库锁定标识 0：未锁定 1：已锁定").HasDefaultValue(0);
            builder.Property(m => m.ExpLock).HasComment(" 出库锁定标识 0：未锁定 1：已锁定").HasDefaultValue(0);
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

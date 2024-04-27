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
    public class CastleConfig : IEntityTypeConfiguration<Castle>
    {
        public void Configure(EntityTypeBuilder<Castle> builder)
        {
            builder.ToTable("Mask_STK_Castles");
            builder.HasComment("货物装载容器");
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("名称").IsRequired();
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("编码").IsRequired();
            builder.Property(m => m.Type).HasComment("类型 ：1、料箱").IsRequired();
            builder.Property(m => m.AffiliatedUnit).HasMaxLength(50).HasComment("所属单位");
            builder.Property(m => m.OriginalCode).HasComment("清洗前原编码集合 例如 A001,A002,A003 后续叠加 逗号分割");
            builder.Property(m => m.CleanCount).HasComment("清洗次数");
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

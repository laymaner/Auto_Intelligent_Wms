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
    public class PassageWayConfig : IEntityTypeConfiguration<PassageWay>
    {
        public void Configure(EntityTypeBuilder<PassageWay> builder)
        {
            builder.ToTable("Mask_STK_PassageWay");
            builder.HasComment("通道");
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("名称").IsRequired();
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("编码").IsRequired();
            builder.Property(m => m.Type).HasMaxLength(2).HasComment("通道类型 1：入库口 2：出库口");
            builder.Property(m => m.WareHouseId).HasComment("仓库id").IsRequired();
            builder.Property(m => m.WareHouseCode).HasMaxLength(20).HasComment("仓库编码").IsRequired();
            builder.Property(m => m.WareHouseName).HasMaxLength(20).HasComment("仓库名称").IsRequired();
            builder.Property(m => m.FirstLanway).HasMaxLength(2).HasComment("一号巷道");
            builder.Property(m => m.SecondLanway).HasMaxLength(2).HasComment("二号巷道");
            builder.Property(m => m.ThirdtLanway).HasMaxLength(2).HasComment("三号巷道");
            builder.Property(m => m.ForthLanway).HasMaxLength(2).HasComment("四号巷道");
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

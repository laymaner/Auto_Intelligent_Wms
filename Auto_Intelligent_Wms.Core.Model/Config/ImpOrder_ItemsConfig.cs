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
    public class ImpOrder_ItemsConfig : IEntityTypeConfiguration<ImpOrder_Items>
    {
        public void Configure(EntityTypeBuilder<ImpOrder_Items> builder)
        {
            builder.ToTable("Mask_STK_ImpOrder_Items");
            builder.HasComment("入库单明细");
            builder.Property(m => m.ImpOrderId).HasComment("入库单id");
            builder.Property(m => m.CastleCode).HasMaxLength(50).HasComment("Castle编码");
            builder.Property(m => m.CastleType).HasMaxLength(50).HasComment("Castle类型");
            builder.Property(m => m.AreaCode).HasMaxLength(50).HasComment("仓储库区位置");
            builder.Property(m => m.ShelfCode).HasMaxLength(50).HasComment("仓储货架位置");
            builder.Property(m => m.LocationCode).HasMaxLength(50).HasComment("仓储货位位置");
            builder.Property(m => m.MaterialCode).HasMaxLength(50).HasComment("物料编码");
            builder.Property(m => m.BatchNo).HasMaxLength(50).HasComment("批次号");
            builder.Property(m => m.PassageWayCode).HasMaxLength(50).HasComment("入库口编码");
            builder.Property(m => m.PlanImpQuantity).HasComment("计划入库货物数量");
            builder.Property(m => m.ActualImpQuantity).HasComment("实际入库货物数量");
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

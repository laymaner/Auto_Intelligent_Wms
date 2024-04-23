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
    public class StockInventory_HistoryConfig : IEntityTypeConfiguration<StockInventory_History>
    {
        public void Configure(EntityTypeBuilder<StockInventory_History> builder)
        {
            builder.ToTable("Mask_STK_StockInventory_History");
            builder.HasComment("库存明细历史记录");
            builder.Property(m => m.RelatedOrder).HasMaxLength(50).HasComment("关联单号");
            builder.Property(m => m.OrderType).HasMaxLength(5).HasComment("订单类型");
            builder.Property(m => m.WareHouseCode).HasMaxLength(50).HasComment("仓库编码");
            builder.Property(m => m.AreaCode).HasMaxLength(50).HasComment("库区编码");
            builder.Property(m => m.ShelfCode).HasMaxLength(50).HasComment("货架编码");
            builder.Property(m => m.CastleCode).HasMaxLength(50).HasComment("Castle编码");
            builder.Property(m => m.CastleType).HasComment("Castle类型");
            builder.Property(m => m.SupplierCode).HasMaxLength(50).HasComment("供应商编码");
            builder.Property(m => m.MaterialCode).HasMaxLength(50).HasComment("物料编码");
            builder.Property(m => m.Version).HasMaxLength(20).HasComment("物料等级");
            builder.Property(m => m.Unit).HasMaxLength(20).HasComment("基本单位");
            builder.Property(m => m.Price).HasComment("每个/价格");
            builder.Property(m => m.PriceUnit).HasMaxLength(20).HasComment("价格单位");
            builder.Property(m => m.ValidityPeriod).HasComment("有效期");
            builder.Property(m => m.IsLock).HasMaxLength(2).HasComment("是否锁定 N/Y");
            builder.Property(m => m.IsOccupy).HasMaxLength(2).HasComment("是否占用 N/Y");
            builder.Property(m => m.IsScrap).HasMaxLength(2).HasComment("是否报废 N/Y");
            builder.Property(m => m.IsFreeze).HasMaxLength(2).HasComment("是否冻结 N/Y");
            builder.Property(m => m.BatchNo).HasMaxLength(20).HasComment("批次");
            builder.Property(m => m.Quantity).HasComment("库存数量");
            builder.Property(m => m.OperateQuantity).HasComment("操作库存数量");
            builder.Property(m => m.OperateType).HasComment("操作类型");
            builder.Property(m => m.OperateTypeDesc).HasComment("操作类型描述");
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

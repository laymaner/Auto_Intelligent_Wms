﻿using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class ImpOrderConfig : IEntityTypeConfiguration<ImpOrder>
    {
        public void Configure(EntityTypeBuilder<ImpOrder> builder)
        {
            builder.ToTable("Mask_STK_ImpOrder");
            builder.HasComment("入库单");
            builder.Property(m => m.OrderNo).HasMaxLength(50).HasComment("入库单号");
            builder.Property(m => m.OrderType).HasMaxLength(5).HasComment("入库单类型");
            builder.Property(m => m.SupplierCode).HasMaxLength(50).HasComment("供应商编码");
            builder.Property(m => m.WareHouseCode).HasMaxLength(50).HasComment("仓库编码");
            builder.Property(m => m.ImpTime).HasComment("入库时间");
            builder.Property(m => m.Step).HasComment("入库步骤");
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}
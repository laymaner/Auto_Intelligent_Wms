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
    public class Operate_LogConfig : IEntityTypeConfiguration<Operate_Log>
    {
        public void Configure(EntityTypeBuilder<Operate_Log> builder)
        {
            builder.ToTable("Mask_STK_Operate_Log");
            builder.HasComment("操作日志");
            builder.Property(m => m.UserCode).HasMaxLength(50).HasComment("用户编码");
            builder.Property(m => m.UserName).HasMaxLength(50).HasComment("用户名称");
            builder.Property(m => m.IpAddress).HasMaxLength(50).HasComment("ip地址");
            builder.Property(m => m.Title).HasMaxLength(50).HasComment("标题");
            builder.Property(m => m.Method).HasMaxLength(50).HasComment("方法名称");
            builder.Property(m => m.OperateType).HasMaxLength(50).HasComment("操作类型");
            builder.Property(m => m.OperateUrl).HasComment("操作路径");
            builder.Property(m => m.OperateParams).HasComment("参数");
            builder.Property(m => m.OperateStatus).HasComment("操作状态");
            builder.Property(m => m.ErrorMsg).HasComment("错误消息");
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

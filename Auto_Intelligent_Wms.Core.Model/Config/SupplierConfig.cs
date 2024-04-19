using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Mask_STK_Suppliers");
            builder.HasComment("供应商");
            builder.Property(m => m.Code).HasMaxLength(20).HasComment("供应商编码").IsRequired();
            builder.Property(m => m.Name).HasMaxLength(20).HasComment("供应商名称").IsRequired();
            builder.Property(m => m.Email).HasMaxLength(20).HasComment("电子邮件");
            builder.Property(m => m.Telephone).HasMaxLength(20).HasComment("联系电话");
            builder.Property(m => m.Address).HasMaxLength(50).HasComment("居住地址");
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：注销 3.禁用").HasDefaultValue(1).IsRequired();

            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

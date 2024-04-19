using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class Material_Supplier_RelationShipConfig : IEntityTypeConfiguration<Material_Supplier_RelationShip>
    {
        public void Configure(EntityTypeBuilder<Material_Supplier_RelationShip> builder)
        {
            builder.ToTable("Mask_STK_Material_Supplier_RelationShips");
            builder.HasComment("物料供应商关系");
            builder.Property(m => m.MaterialId).HasComment("物料id").IsRequired();
            builder.Property(m => m.MaterialCode).HasMaxLength(20).HasComment("物料编码").IsRequired();
            builder.Property(m => m.SupplierId).HasComment("供应商id").IsRequired();
            builder.Property(m => m.SupplierCode).HasMaxLength(20).HasComment("供应商编码").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

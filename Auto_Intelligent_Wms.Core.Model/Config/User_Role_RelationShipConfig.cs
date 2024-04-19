using Auto_Intelligent_Wms.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auto_Intelligent_Wms.Core.Model.Config
{
    public class User_Role_RelationShipConfig : IEntityTypeConfiguration<User_Role_RelationShip>
    {
        public void Configure(EntityTypeBuilder<User_Role_RelationShip> builder)
        {
            builder.ToTable("Mask_STK_User_Role_RelationShips");
            builder.HasComment("用户角色关系");
            builder.Property(m => m.UserId).HasComment("用户id").IsRequired();
            builder.Property(m => m.UserCode).HasMaxLength(20).HasComment("用户编码").IsRequired();
            builder.Property(m => m.UserName).HasMaxLength(20).HasComment("用户名称").IsRequired();
            builder.Property(m => m.RoleId).HasComment("角色id").IsRequired();
            builder.Property(m => m.RoleCode).HasMaxLength(20).HasComment("角色编码").IsRequired();
            builder.Property(m => m.RoleName).HasMaxLength(20).HasComment("角色名称").IsRequired();
            builder.Property(m => m.Status).HasMaxLength(2).HasComment("状态 1：正常 2：删除").HasDefaultValue(1).IsRequired();
            builder.Property(m => m.Remark).HasComment("备注");
            builder.Property(m => m.Creator).HasComment("创建人").IsRequired();
            builder.Property(m => m.CreateTime).HasComment("创建时间").IsRequired();
            builder.Property(m => m.Updator).HasComment("更新人");
            builder.Property(m => m.UpdateTime).HasComment("更新时间");
        }
    }
}

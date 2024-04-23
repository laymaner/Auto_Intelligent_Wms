using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auto_Intelligent_Wms.Core.Model.Migrations
{
    public partial class initDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mask_STK_Area",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "库区名称"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "库区编码"),
                    WareHouseId = table.Column<long>(type: "bigint", nullable: false, comment: "仓库id"),
                    WareHouseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "仓库编码"),
                    WareHouseName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "仓库名称"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Area", x => x.Id);
                },
                comment: "库区");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Castles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "编码"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名称"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "类型 ：1、料箱"),
                    AffiliatedUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "所属单位"),
                    LocationId = table.Column<long>(type: "bigint", nullable: true, comment: "存储货位id"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "存储货位名称"),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "存储货位编码"),
                    StorageStatus = table.Column<int>(type: "int", nullable: true, comment: "存储状态 不在货位/在货位/任务中"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    HasGoods = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "是否有货 Y/N"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Castles", x => x.Id);
                },
                comment: "货物装载容器");

            migrationBuilder.CreateTable(
                name: "Mask_STK_ExpOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "出库单号"),
                    OrderType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "出库单类型"),
                    SupplierCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "供应商编码"),
                    WareHouseCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓库编码"),
                    ExpTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "出库时间"),
                    Step = table.Column<int>(type: "int", nullable: false, comment: "出库步骤"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_ExpOrder", x => x.Id);
                },
                comment: "出库单");

            migrationBuilder.CreateTable(
                name: "Mask_STK_ExpOrder_Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpOrderId = table.Column<long>(type: "bigint", nullable: false, comment: "出库单id"),
                    CastleCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "Castle编码"),
                    CastleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Castle类型"),
                    AreaCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓储库区位置"),
                    ShelfCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓储货架位置"),
                    LocationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓储货位位置"),
                    MaterialCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "物料编码"),
                    BatchNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "批次号"),
                    PassageWayCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "出库口编码"),
                    PlanExpQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "计划出库货物数量"),
                    ActualExpQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "实际出库货物数量"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_ExpOrder_Items", x => x.Id);
                },
                comment: "出库单明细");

            migrationBuilder.CreateTable(
                name: "Mask_STK_ImpOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "入库单号"),
                    OrderType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "入库单类型"),
                    SupplierCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "供应商编码"),
                    WareHouseCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓库编码"),
                    ImpTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "入库时间"),
                    Step = table.Column<int>(type: "int", nullable: false, comment: "入库步骤"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_ImpOrder", x => x.Id);
                },
                comment: "入库单");

            migrationBuilder.CreateTable(
                name: "Mask_STK_ImpOrder_Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImpOrderId = table.Column<long>(type: "bigint", nullable: false, comment: "入库单id"),
                    CastleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Castle编码"),
                    CastleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Castle类型"),
                    AreaCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓储库区位置"),
                    ShelfCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓储货架位置"),
                    LocationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓储货位位置"),
                    MaterialCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "物料编码"),
                    BatchNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "批次号"),
                    PassageWayCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "入库口编码"),
                    PlanImpQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "计划入库货物数量"),
                    ActualImpQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "实际入库货物数量"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_ImpOrder_Items", x => x.Id);
                },
                comment: "入库单明细");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Locations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "货位名称"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "货位编码"),
                    ShelfId = table.Column<long>(type: "bigint", nullable: false, comment: "货架id"),
                    ShelfCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "货架编码"),
                    ShelfName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "货架名称"),
                    RoadWay = table.Column<int>(type: "int", nullable: false, comment: "巷道"),
                    LRow = table.Column<int>(type: "int", nullable: false, comment: "排"),
                    LColumn = table.Column<int>(type: "int", nullable: false, comment: "列"),
                    Layer = table.Column<int>(type: "int", nullable: false, comment: "层"),
                    ImpLock = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "入库锁定标识 0：未锁定 1：已锁定"),
                    ExpLock = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: " 出库锁定标识 0：未锁定 1：已锁定"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Locations", x => x.Id);
                },
                comment: "货位");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Material_Supplier_RelationShips",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "物料编码"),
                    MaterialId = table.Column<long>(type: "bigint", nullable: false, comment: "物料id"),
                    SupplierCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "供应商编码"),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false, comment: "供应商id"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Material_Supplier_RelationShips", x => x.Id);
                },
                comment: "物料供应商关系");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Materials",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "物料名称"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "物料编码"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "物料描述"),
                    Type = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "物料类型"),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "基本单位"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "基本计量单位数量"),
                    MinimumPackagingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "最小包装数量"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    PriceUint = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "价格单位"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: " 每个/价格"),
                    ValidityPeriod = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "有效期"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    Version = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "物料等级"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Materials", x => x.Id);
                },
                comment: "物料");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Operate_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "用户编码"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "用户名称"),
                    IpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "ip地址"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "标题"),
                    Method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "方法名称"),
                    OperateType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "操作类型"),
                    OperateUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "操作路径"),
                    OperateParams = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "参数"),
                    OperateStatus = table.Column<int>(type: "int", nullable: false, comment: "操作状态"),
                    ErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "错误消息"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Operate_Log", x => x.Id);
                },
                comment: "操作日志");

            migrationBuilder.CreateTable(
                name: "Mask_STK_PassageWay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "编码"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "名称"),
                    Type = table.Column<int>(type: "int", maxLength: 2, nullable: false, comment: "通道类型 1：入库口 2：出库口"),
                    WareHouseId = table.Column<long>(type: "bigint", nullable: false, comment: "仓库id"),
                    WareHouseName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "仓库名称"),
                    WareHouseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "仓库编码"),
                    FirstLanway = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "一号巷道"),
                    SecondLanway = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "二号巷道"),
                    ThirdtLanway = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "三号巷道"),
                    ForthLanway = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "四号巷道"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_PassageWay", x => x.Id);
                },
                comment: "通道");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "角色名称"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "角色编码"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "角色描述"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：注销 3.禁用"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Roles", x => x.Id);
                },
                comment: "角色");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Shelfs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "货架名称"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "货架编码"),
                    AreaId = table.Column<long>(type: "bigint", nullable: false, comment: "库区id"),
                    AreaCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "库区编码"),
                    AreaName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "库区名称"),
                    RoadWay = table.Column<int>(type: "int", nullable: false, comment: "巷道数"),
                    ShelfRows = table.Column<int>(type: "int", nullable: false, comment: "排数"),
                    ShelfColumns = table.Column<int>(type: "int", nullable: false, comment: "列数"),
                    ShelfLayers = table.Column<int>(type: "int", nullable: false, comment: "层数"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Shelfs", x => x.Id);
                },
                comment: "货架");

            migrationBuilder.CreateTable(
                name: "Mask_STK_StockInventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓库编码"),
                    AreaCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "库区编码"),
                    ShelfCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "货架编码"),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CastleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Castle编码"),
                    CastleType = table.Column<int>(type: "int", nullable: false, comment: "Castle类型"),
                    SupplierCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "供应商编码"),
                    MaterialCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "物料编码"),
                    Version = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "物料等级"),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "基本单位"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "每个/价格"),
                    PriceUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "价格单位"),
                    ValidityPeriod = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "有效期"),
                    IsLock = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "是否锁定 N/Y"),
                    IsOccupy = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "是否占用 N/Y"),
                    IsScrap = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "是否报废 N/Y"),
                    IsFreeze = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "是否冻结 N/Y"),
                    BatchNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "批次"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "库存数量"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_StockInventory", x => x.Id);
                },
                comment: "库存明细");

            migrationBuilder.CreateTable(
                name: "Mask_STK_StockInventory_History",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedOrder = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "关联单号"),
                    OrderType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "订单类型"),
                    WareHouseCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "仓库编码"),
                    AreaCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "库区编码"),
                    ShelfCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "货架编码"),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CastleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Castle编码"),
                    CastleType = table.Column<int>(type: "int", nullable: false, comment: "Castle类型"),
                    SupplierCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "供应商编码"),
                    MaterialCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "物料编码"),
                    Version = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "物料等级"),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "基本单位"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "每个/价格"),
                    PriceUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "价格单位"),
                    ValidityPeriod = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "有效期"),
                    IsLock = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "是否锁定 N/Y"),
                    IsOccupy = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "是否占用 N/Y"),
                    IsScrap = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "是否报废 N/Y"),
                    IsFreeze = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "是否冻结 N/Y"),
                    BatchNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "批次"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "库存数量"),
                    OperateQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "操作库存数量"),
                    OperateType = table.Column<int>(type: "int", nullable: false, comment: "操作类型"),
                    OperateTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "操作类型描述"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_StockInventory_History", x => x.Id);
                },
                comment: "库存明细历史记录");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Suppliers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "供应商名称"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "供应商编码"),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "居住地址"),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "联系电话"),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "电子邮件"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：注销 3.禁用"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Suppliers", x => x.Id);
                },
                comment: "供应商");

            migrationBuilder.CreateTable(
                name: "Mask_STK_User_Role_RelationShips",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false, comment: "用户id"),
                    UserCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "用户编码"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "用户名称"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false, comment: "角色id"),
                    RoleCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "角色编码"),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "角色名称"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_User_Role_RelationShips", x => x.Id);
                },
                comment: "用户角色关系");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "用户编码"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "用户姓名"),
                    Age = table.Column<int>(type: "int", nullable: true, comment: "年龄"),
                    Gender = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, comment: "性别(M:男生 W：女生)"),
                    Birth = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "出生年月份"),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "电子邮件"),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "联系电话"),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "居住地址"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "密码"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：注销 3.禁用"),
                    JWTVersion = table.Column<long>(type: "bigint", nullable: true, comment: "自增jwt令牌"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Users", x => x.Id);
                },
                comment: "用户");

            migrationBuilder.CreateTable(
                name: "Mask_STK_WareHouses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "仓库名称"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "仓库编码"),
                    Type = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "仓库类型"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_WareHouses", x => x.Id);
                },
                comment: "仓库");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mask_STK_Area");

            migrationBuilder.DropTable(
                name: "Mask_STK_Castles");

            migrationBuilder.DropTable(
                name: "Mask_STK_ExpOrder");

            migrationBuilder.DropTable(
                name: "Mask_STK_ExpOrder_Items");

            migrationBuilder.DropTable(
                name: "Mask_STK_ImpOrder");

            migrationBuilder.DropTable(
                name: "Mask_STK_ImpOrder_Items");

            migrationBuilder.DropTable(
                name: "Mask_STK_Locations");

            migrationBuilder.DropTable(
                name: "Mask_STK_Material_Supplier_RelationShips");

            migrationBuilder.DropTable(
                name: "Mask_STK_Materials");

            migrationBuilder.DropTable(
                name: "Mask_STK_Operate_Log");

            migrationBuilder.DropTable(
                name: "Mask_STK_PassageWay");

            migrationBuilder.DropTable(
                name: "Mask_STK_Roles");

            migrationBuilder.DropTable(
                name: "Mask_STK_Shelfs");

            migrationBuilder.DropTable(
                name: "Mask_STK_StockInventory");

            migrationBuilder.DropTable(
                name: "Mask_STK_StockInventory_History");

            migrationBuilder.DropTable(
                name: "Mask_STK_Suppliers");

            migrationBuilder.DropTable(
                name: "Mask_STK_User_Role_RelationShips");

            migrationBuilder.DropTable(
                name: "Mask_STK_Users");

            migrationBuilder.DropTable(
                name: "Mask_STK_WareHouses");
        }
    }
}

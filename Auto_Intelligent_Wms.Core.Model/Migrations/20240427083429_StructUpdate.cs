using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auto_Intelligent_Wms.Core.Model.Migrations
{
    public partial class StructUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpLock",
                table: "Mask_STK_Locations");

            migrationBuilder.DropColumn(
                name: "ImpLock",
                table: "Mask_STK_Locations");

            migrationBuilder.DropColumn(
                name: "HasGoods",
                table: "Mask_STK_Castles");

            migrationBuilder.DropColumn(
                name: "LocationCode",
                table: "Mask_STK_Castles");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Mask_STK_Castles");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Mask_STK_Castles");

            migrationBuilder.DropColumn(
                name: "StorageStatus",
                table: "Mask_STK_Castles");

            migrationBuilder.AlterColumn<string>(
                name: "LocationCode",
                table: "Mask_STK_StockInventory_History",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "货位编码",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PositionCode",
                table: "Mask_STK_StockInventory_History",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "精确存储位置编码");

            migrationBuilder.AddColumn<string>(
                name: "SnCode",
                table: "Mask_STK_StockInventory_History",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "SnCode");

            migrationBuilder.AlterColumn<string>(
                name: "LocationCode",
                table: "Mask_STK_StockInventory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "货位编码",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PositionCode",
                table: "Mask_STK_StockInventory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "精确存储位置编码");

            migrationBuilder.AddColumn<string>(
                name: "SnCode",
                table: "Mask_STK_StockInventory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "SnCode");

            migrationBuilder.AddColumn<string>(
                name: "PositionCode",
                table: "Mask_STK_ImpOrder_Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "存放精确位置编码");

            migrationBuilder.AddColumn<string>(
                name: "PositionCode",
                table: "Mask_STK_ExpOrder_Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "存放精确位置编码");

            migrationBuilder.AddColumn<string>(
                name: "SnCode",
                table: "Mask_STK_ExpOrder_Items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "SnCode");

            migrationBuilder.AddColumn<int>(
                name: "CleanCount",
                table: "Mask_STK_Castles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "清洗次数");

            migrationBuilder.AddColumn<string>(
                name: "OriginalCode",
                table: "Mask_STK_Castles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "清洗前原编码集合 例如 A001,A002,A003 后续叠加 逗号分割");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Labels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CastleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Castle编码"),
                    CastleType = table.Column<int>(type: "int", nullable: false, comment: "Castle类型"),
                    SupplierCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "供应商编码"),
                    MaterialCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "物料编码"),
                    SnCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "SnCode"),
                    BatchNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "批次号"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "数量"),
                    Status = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1, comment: "状态 1：正常 2：删除"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    Creator = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间"),
                    Updator = table.Column<long>(type: "bigint", nullable: true, comment: "更新人")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mask_STK_Labels", x => x.Id);
                },
                comment: "标签");

            migrationBuilder.CreateTable(
                name: "Mask_STK_Positions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "精确存储位置名称"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "精确存储位置编码"),
                    LocationId = table.Column<long>(type: "bigint", nullable: false, comment: "货位id"),
                    LocationCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "货位编码"),
                    LocationName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "货位名称"),
                    RoadWay = table.Column<int>(type: "int", nullable: false, comment: "巷道"),
                    LRow = table.Column<int>(type: "int", nullable: false, comment: "排"),
                    LColumn = table.Column<int>(type: "int", nullable: false, comment: "列"),
                    Layer = table.Column<int>(type: "int", nullable: false, comment: "层"),
                    Lattice = table.Column<int>(type: "int", nullable: false, comment: "第几格"),
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
                    table.PrimaryKey("PK_Mask_STK_Positions", x => x.Id);
                },
                comment: "精确存储位置");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mask_STK_Labels");

            migrationBuilder.DropTable(
                name: "Mask_STK_Positions");

            migrationBuilder.DropColumn(
                name: "PositionCode",
                table: "Mask_STK_StockInventory_History");

            migrationBuilder.DropColumn(
                name: "SnCode",
                table: "Mask_STK_StockInventory_History");

            migrationBuilder.DropColumn(
                name: "PositionCode",
                table: "Mask_STK_StockInventory");

            migrationBuilder.DropColumn(
                name: "SnCode",
                table: "Mask_STK_StockInventory");

            migrationBuilder.DropColumn(
                name: "PositionCode",
                table: "Mask_STK_ImpOrder_Items");

            migrationBuilder.DropColumn(
                name: "PositionCode",
                table: "Mask_STK_ExpOrder_Items");

            migrationBuilder.DropColumn(
                name: "SnCode",
                table: "Mask_STK_ExpOrder_Items");

            migrationBuilder.DropColumn(
                name: "CleanCount",
                table: "Mask_STK_Castles");

            migrationBuilder.DropColumn(
                name: "OriginalCode",
                table: "Mask_STK_Castles");

            migrationBuilder.AlterColumn<string>(
                name: "LocationCode",
                table: "Mask_STK_StockInventory_History",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "货位编码");

            migrationBuilder.AlterColumn<string>(
                name: "LocationCode",
                table: "Mask_STK_StockInventory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "货位编码");

            migrationBuilder.AddColumn<int>(
                name: "ExpLock",
                table: "Mask_STK_Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: " 出库锁定标识 0：未锁定 1：已锁定");

            migrationBuilder.AddColumn<int>(
                name: "ImpLock",
                table: "Mask_STK_Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "入库锁定标识 0：未锁定 1：已锁定");

            migrationBuilder.AddColumn<string>(
                name: "HasGoods",
                table: "Mask_STK_Castles",
                type: "nvarchar(max)",
                nullable: true,
                comment: "是否有货 Y/N");

            migrationBuilder.AddColumn<string>(
                name: "LocationCode",
                table: "Mask_STK_Castles",
                type: "nvarchar(max)",
                nullable: true,
                comment: "存储货位编码");

            migrationBuilder.AddColumn<long>(
                name: "LocationId",
                table: "Mask_STK_Castles",
                type: "bigint",
                nullable: true,
                comment: "存储货位id");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Mask_STK_Castles",
                type: "nvarchar(max)",
                nullable: true,
                comment: "存储货位名称");

            migrationBuilder.AddColumn<int>(
                name: "StorageStatus",
                table: "Mask_STK_Castles",
                type: "int",
                nullable: true,
                comment: "存储状态 不在货位/在货位/任务中");
        }
    }
}

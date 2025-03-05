using Microsoft.EntityFrameworkCore.Migrations;
using N5.System.Domain.Entities;
using N5.System.Domain.Enums;

#nullable disable

namespace N5.System.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDataPermissionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: nameof(PermissionType),
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { EnumPermissionType.Create.ToString() },
                });

            migrationBuilder.InsertData(
                table: nameof(PermissionType),
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { EnumPermissionType.Update.ToString() },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

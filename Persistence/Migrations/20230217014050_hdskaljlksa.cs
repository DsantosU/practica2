using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class hdskaljlksa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImmovableOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Codia = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmovableOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImmovableProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImmovableOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Surface = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Region = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmovableProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmovableProperties_ImmovableOwners_ImmovableOwnerId",
                        column: x => x.ImmovableOwnerId,
                        principalTable: "ImmovableOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImmovableProperties_ImmovableOwnerId",
                table: "ImmovableProperties",
                column: "ImmovableOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImmovableProperties");

            migrationBuilder.DropTable(
                name: "ImmovableOwners");
        }
    }
}

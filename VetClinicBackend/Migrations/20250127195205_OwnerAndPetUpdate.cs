using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinicBackend.Migrations
{
    /// <inheritdoc />
    public partial class OwnerAndPetUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerPet");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Pet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_OwnerId",
                table: "Pet",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Owner_OwnerId",
                table: "Pet",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Owner_OwnerId",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_OwnerId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Pet");

            migrationBuilder.CreateTable(
                name: "OwnerPet",
                columns: table => new
                {
                    OwnersId = table.Column<int>(type: "int", nullable: false),
                    PetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerPet", x => new { x.OwnersId, x.PetsId });
                    table.ForeignKey(
                        name: "FK_OwnerPet_Owner_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerPet_Pet_PetsId",
                        column: x => x.PetsId,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnerPet_PetsId",
                table: "OwnerPet",
                column: "PetsId");
        }
    }
}

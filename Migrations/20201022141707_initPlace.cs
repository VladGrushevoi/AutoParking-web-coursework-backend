using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoParking_backend.Migrations
{
    public partial class initPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parkings",
                columns: table => new
                {
                    ParkingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkings", x => x.ParkingId);
                });

            migrationBuilder.CreateTable(
                name: "typeCars",
                columns: table => new
                {
                    TypeCarId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeCarName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeCars", x => x.TypeCarId);
                });

            migrationBuilder.CreateTable(
                name: "typePlaces",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typePlaces", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeId = table.Column<int>(nullable: false),
                    TypeCarId = table.Column<int>(nullable: false),
                    ParkingId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    TypePlaceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_places", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_places_parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "parkings",
                        principalColumn: "ParkingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_places_typeCars_TypeCarId",
                        column: x => x.TypeCarId,
                        principalTable: "typeCars",
                        principalColumn: "TypeCarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_places_typePlaces_TypePlaceTypeId",
                        column: x => x.TypePlaceTypeId,
                        principalTable: "typePlaces",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_places_ParkingId",
                table: "places",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_places_TypeCarId",
                table: "places",
                column: "TypeCarId");

            migrationBuilder.CreateIndex(
                name: "IX_places_TypePlaceTypeId",
                table: "places",
                column: "TypePlaceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "places");

            migrationBuilder.DropTable(
                name: "parkings");

            migrationBuilder.DropTable(
                name: "typeCars");

            migrationBuilder.DropTable(
                name: "typePlaces");
        }
    }
}

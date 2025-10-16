using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TattooApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialTattooShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialtyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpecialtyId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    TattooDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Binders",
                columns: table => new
                {
                    BinderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Binders", x => x.BinderId);
                    table.ForeignKey(
                        name: "FK_Binders_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSpecialty",
                columns: table => new
                {
                    ArtistsArtistId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialtiesSpecialtyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSpecialty", x => new { x.ArtistsArtistId, x.SpecialtiesSpecialtyId });
                    table.ForeignKey(
                        name: "FK_ArtistSpecialty_Artists_ArtistsArtistId",
                        column: x => x.ArtistsArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSpecialty_Specialties_SpecialtiesSpecialtyId",
                        column: x => x.SpecialtiesSpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    FlashCardId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BinderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.FlashCardId);
                    table.ForeignKey(
                        name: "FK_FlashCards_Binders_BinderId",
                        column: x => x.BinderId,
                        principalTable: "Binders",
                        principalColumn: "BinderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ArtistId",
                table: "Appointments",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSpecialty_SpecialtiesSpecialtyId",
                table: "ArtistSpecialty",
                column: "SpecialtiesSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Binders_ArtistId",
                table: "Binders",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_BinderId",
                table: "FlashCards",
                column: "BinderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ArtistSpecialty");

            migrationBuilder.DropTable(
                name: "FlashCards");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Binders");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}

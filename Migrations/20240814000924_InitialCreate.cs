using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CreekRiver.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampsiteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampsiteTypeName = table.Column<string>(type: "text", nullable: false),
                    MaxReservationDays = table.Column<int>(type: "integer", nullable: false),
                    FeePerNight = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campsites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CampsiteTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campsites_CampsiteTypes_CampsiteTypeId",
                        column: x => x.CampsiteTypeId,
                        principalTable: "CampsiteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampsiteId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Campsites_CampsiteId",
                        column: x => x.CampsiteId,
                        principalTable: "Campsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CampsiteTypes",
                columns: new[] { "Id", "CampsiteTypeName", "FeePerNight", "MaxReservationDays" },
                values: new object[,]
                {
                    { 1, "Tent", 15.99m, 7 },
                    { 2, "RV", 26.50m, 14 },
                    { 3, "Primitive", 10.00m, 3 },
                    { 4, "Hammock", 12m, 7 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "washingmachinevictory@gmail.com", "Victoria", "Washington" },
                    { 2, "summercatalog@yahoo.com", "Catalog", "Jenkins" }
                });

            migrationBuilder.InsertData(
                table: "Campsites",
                columns: new[] { "Id", "CampsiteTypeId", "ImageUrl", "Nickname" },
                values: new object[,]
                {
                    { 1, 1, "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg", "Barred Owl" },
                    { 2, 1, "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiLUjCh4wWXqqhXmG7C4cNc7fetwLRnRYkAW9xNg-WC8rHFo2gxTgp1dYNwtmO_uJur3lNjRvIIU0IjjuD6mnVYNMVD01l1dw6QK-jvXpPYxLA5Zkh0IHebAlcMCEUz0OoEEOdHD4A3bpu_/s1600/001.JPG", "Knockturn Alley" },
                    { 3, 3, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/307f17b7-52d4-4f3f-a171-d77fe66dba18/deqlqb-95f9713c-e751-49cf-866c-f4292325dc2d.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzMwN2YxN2I3LTUyZDQtNGYzZi1hMTcxLWQ3N2ZlNjZkYmExOFwvZGVxbHFiLTk1Zjk3MTNjLWU3NTEtNDljZi04NjZjLWY0MjkyMzI1ZGMyZC5qcGcifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6ZmlsZS5kb3dubG9hZCJdfQ.C7hm0-EOyf0gPxPl0MWvzx-xP1B2NUg-4cInu8Yd53Y", "Chimney Falls" },
                    { 4, 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSXRhvLOQifx3Md17B5Mn3xz7QqN1nj7WmJeQ&s", "Scarborough" },
                    { 5, 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2GazB75A_1GYpIjwi9KF_3jijPgWV6935mg&s", "Muddy Landing" },
                    { 6, 4, "https://d9-wret.s3.us-west-2.amazonaws.com/assets/palladium/production/s3fs-public/styles/side_image/public/vhp_img2997.jpg?itok=nXc98AQF", "Haliburton's Coat" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CampsiteId", "CheckinDate", "CheckoutDate", "UserProfileId" },
                values: new object[] { 1, 3, new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Campsites_CampsiteTypeId",
                table: "Campsites",
                column: "CampsiteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CampsiteId",
                table: "Reservations",
                column: "CampsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserProfileId",
                table: "Reservations",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Campsites");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "CampsiteTypes");
        }
    }
}

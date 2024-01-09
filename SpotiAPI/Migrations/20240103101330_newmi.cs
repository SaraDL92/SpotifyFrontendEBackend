using Microsoft.EntityFrameworkCore.Migrations;

namespace SpotiAPI.Migrations
{
    public partial class newmi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id_Artist = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfArtist = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id_Artist);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id_Director = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfDirector = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id_Director);
                });

            migrationBuilder.CreateTable(
                name: "Radios",
                columns: table => new
                {
                    Id_Radio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOfRadio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radios", x => x.Id_Radio);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id_Album = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOfAlbum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Artist = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id_Album);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_Id_Artist",
                        column: x => x.Id_Artist,
                        principalTable: "Artists",
                        principalColumn: "Id_Artist",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id_Movie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOfMovie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Director = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id_Movie);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_Id_Director",
                        column: x => x.Id_Director,
                        principalTable: "Directors",
                        principalColumn: "Id_Director",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id_Song = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOfSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Artist = table.Column<int>(type: "int", nullable: true),
                    Id_Radio = table.Column<int>(type: "int", nullable: true),
                    Id_Album = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id_Song);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_Id_Album",
                        column: x => x.Id_Album,
                        principalTable: "Albums",
                        principalColumn: "Id_Album",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_Id_Artist",
                        column: x => x.Id_Artist,
                        principalTable: "Artists",
                        principalColumn: "Id_Artist",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Songs_Radios_Id_Radio",
                        column: x => x.Id_Radio,
                        principalTable: "Radios",
                        principalColumn: "Id_Radio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Setting = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id_Setting = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LightTheme = table.Column<bool>(type: "bit", nullable: false),
                    GoldPlan = table.Column<bool>(type: "bit", nullable: false),
                    FreePlan = table.Column<bool>(type: "bit", nullable: false),
                    PremiumPlan = table.Column<bool>(type: "bit", nullable: false),
                    Id_User = table.Column<int>(type: "int", nullable: true),
                    SelectedTimeZoneId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id_Setting);
                    table.ForeignKey(
                        name: "FK_Settings_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_Id_Artist",
                table: "Albums",
                column: "Id_Artist");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Id_Director",
                table: "Movies",
                column: "Id_Director");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Id_User",
                table: "Settings",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Id_Album",
                table: "Songs",
                column: "Id_Album");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Id_Artist",
                table: "Songs",
                column: "Id_Artist");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Id_Radio",
                table: "Songs",
                column: "Id_Radio");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Setting",
                table: "Users",
                column: "Id_Setting");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Settings_Id_Setting",
                table: "Users",
                column: "Id_Setting",
                principalTable: "Settings",
                principalColumn: "Id_Setting",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Users_Id_User",
                table: "Settings");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Radios");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "d_Buses",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Years = table.Column<int>(type: "int", nullable: true),
                    Numer = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_d_Transports", x => x.BusID);
                });

            migrationBuilder.CreateTable(
                name: "d_City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Notes = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_d_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "d_Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    Experience = table.Column<decimal>(type: "decimal(12,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_d_Drivers", x => x.DriverID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_TrackingsBus",
                columns: table => new
                {
                    TrackingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusID = table.Column<int>(type: "int", nullable: false),
                    Bdate = table.Column<DateTime>(type: "date", nullable: true),
                    Edate = table.Column<DateTime>(type: "date", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    Notes = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_TrackingsTransports", x => x.TrackingID);
                    table.ForeignKey(
                        name: "FK_Bus",
                        column: x => x.BusID,
                        principalTable: "d_Buses",
                        principalColumn: "BusID");
                });

            migrationBuilder.CreateTable(
                name: "d_Routes",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BCity = table.Column<int>(type: "int", nullable: false),
                    ECity = table.Column<int>(type: "int", nullable: false),
                    RouteLen = table.Column<int>(type: "int", nullable: true),
                    RouteTime = table.Column<int>(type: "int", nullable: true),
                    IsWork = table.Column<bool>(type: "bit", nullable: true),
                    Notes = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_d_Routes", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_BCity",
                        column: x => x.BCity,
                        principalTable: "d_City",
                        principalColumn: "CityID");
                    table.ForeignKey(
                        name: "FK_Ectiy",
                        column: x => x.ECity,
                        principalTable: "d_City",
                        principalColumn: "CityID");
                });

            migrationBuilder.CreateTable(
                name: "t_Flights",
                columns: table => new
                {
                    FlightsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteID = table.Column<int>(type: "int", nullable: false),
                    BusID = table.Column<int>(type: "int", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false),
                    BDateRoute = table.Column<DateTime>(type: "date", nullable: true),
                    BTimeRoute = table.Column<TimeSpan>(type: "time", nullable: true),
                    EDateRoute = table.Column<DateTime>(type: "date", nullable: true),
                    ETimeRoute = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsEnd = table.Column<bool>(type: "bit", nullable: true),
                    IsCanselet = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_flights", x => x.FlightsID);
                    table.ForeignKey(
                        name: "FK_BusFlights",
                        column: x => x.BusID,
                        principalTable: "d_Buses",
                        principalColumn: "BusID");
                    table.ForeignKey(
                        name: "FK_Drivers",
                        column: x => x.DriverID,
                        principalTable: "d_Drivers",
                        principalColumn: "DriverID");
                    table.ForeignKey(
                        name: "FK_Routes",
                        column: x => x.RouteID,
                        principalTable: "d_Routes",
                        principalColumn: "RouteID");
                });

            migrationBuilder.CreateTable(
                name: "t_Bills",
                columns: table => new
                {
                    FlightsID = table.Column<int>(type: "int", nullable: false),
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_Bills", x => x.FlightsID);
                    table.ForeignKey(
                        name: "FK_BillClient",
                        column: x => x.ClientID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillFlights",
                        column: x => x.FlightsID,
                        principalTable: "t_Flights",
                        principalColumn: "FlightsID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_d_Routes_BCity",
                table: "d_Routes",
                column: "BCity");

            migrationBuilder.CreateIndex(
                name: "IX_d_Routes_ECity",
                table: "d_Routes",
                column: "ECity");

            migrationBuilder.CreateIndex(
                name: "IX_t_Bills_ClientID",
                table: "t_Bills",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_t_Flights_BusID",
                table: "t_Flights",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_t_Flights_DriverID",
                table: "t_Flights",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_t_Flights_RouteID",
                table: "t_Flights",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_t_TrackingsBus_BusID",
                table: "t_TrackingsBus",
                column: "BusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "t_Bills");

            migrationBuilder.DropTable(
                name: "t_TrackingsBus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "t_Flights");

            migrationBuilder.DropTable(
                name: "d_Buses");

            migrationBuilder.DropTable(
                name: "d_Drivers");

            migrationBuilder.DropTable(
                name: "d_Routes");

            migrationBuilder.DropTable(
                name: "d_City");
        }
    }
}

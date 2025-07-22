using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchemeServe.Provider.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrganisationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnershipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompaniesHouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddressTownCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddressCounty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uprn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnSpdLatitude = table.Column<double>(type: "float", nullable: true),
                    OnSpdLongitude = table.Column<double>(type: "float", nullable: true),
                    MainPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionDirectorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Constituency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastInspection = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderEntityProviderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Providers_ProviderEntityProviderId",
                        column: x => x.ProviderEntityProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProviderEntityProviderId",
                table: "Locations",
                column: "ProviderEntityProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}

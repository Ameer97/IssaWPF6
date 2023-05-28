using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IssaWPF6.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    FileNo = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Premedication = table.Column<string>(type: "text", nullable: false),
                    Scope = table.Column<string>(type: "text", nullable: false),
                    ReferredDoctor = table.Column<string>(type: "text", nullable: false),
                    ClinicalData = table.Column<string>(type: "text", nullable: false),
                    Preparation = table.Column<string>(type: "text", nullable: false),
                    AnalInspection = table.Column<string>(type: "text", nullable: false),
                    PRExam = table.Column<string>(type: "text", nullable: false),
                    Ileum = table.Column<string>(type: "text", nullable: false),
                    ColonDetails = table.Column<string>(type: "text", nullable: false),
                    Rectum = table.Column<string>(type: "text", nullable: false),
                    Conclusion = table.Column<string>(type: "text", nullable: false),
                    Assistant = table.Column<string>(type: "text", nullable: false),
                    Endoscopist = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stomaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    FileNo = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Premedication = table.Column<string>(type: "text", nullable: false),
                    Scope = table.Column<string>(type: "text", nullable: false),
                    ReferredDoctor = table.Column<string>(type: "text", nullable: false),
                    ClinicalData = table.Column<string>(type: "text", nullable: false),
                    GEJ = table.Column<string>(type: "text", nullable: false),
                    Esophagus = table.Column<string>(type: "text", nullable: false),
                    StomachDetails = table.Column<string>(type: "text", nullable: false),
                    D1 = table.Column<string>(type: "text", nullable: false),
                    D2 = table.Column<string>(type: "text", nullable: false),
                    Conclusion = table.Column<string>(type: "text", nullable: false),
                    Assistant = table.Column<string>(type: "text", nullable: false),
                    Endoscopist = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stomaches", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colons");

            migrationBuilder.DropTable(
                name: "Stomaches");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mechty_learn_backend.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adults3DModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Adults3DIconUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adults3DModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kids3DModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kids3DIconUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kids3DModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonTitle = table.Column<string>(type: "text", nullable: true),
                    LessonDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Adults3DModelId = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Adults3DModels_Adults3DModelId",
                        column: x => x.Adults3DModelId,
                        principalTable: "Adults3DModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    ChapterTitle = table.Column<string>(type: "text", nullable: true),
                    ChapterDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => new { x.Id, x.LessonId });
                    table.ForeignKey(
                        name: "FK_Chapters_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "Kids",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AdultId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    KidProgress = table.Column<int>(type: "integer", nullable: false),
                    Kids3DModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kids", x => new { x.Id, x.AdultId });
                    table.ForeignKey(
                        name: "FK_Kids_AspNetUsers_AdultId",
                        column: x => x.AdultId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kids_Kids3DModels_Kids3DModelId",
                        column: x => x.Kids3DModelId,
                        principalTable: "Kids3DModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChapterPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    ChapterPageTitle = table.Column<string>(type: "text", nullable: true),
                    ChapterPageDescription = table.Column<string>(type: "text", nullable: true),
                    ChapterLessonId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterPages", x => new { x.Id, x.ChapterId });
                    table.ForeignKey(
                        name: "FK_ChapterPages_Chapters_ChapterId_ChapterLessonId",
                        columns: x => new { x.ChapterId, x.ChapterLessonId },
                        principalTable: "Chapters",
                        principalColumns: new[] { "Id", "LessonId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KidId = table.Column<string>(type: "text", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    KidAdultId = table.Column<string>(type: "text", nullable: true),
                    ChapterLessonId = table.Column<int>(type: "integer", nullable: true),
                    Progress = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterProgresses", x => new { x.Id, x.KidId, x.ChapterId });
                    table.ForeignKey(
                        name: "FK_ChapterProgresses_Chapters_ChapterId_ChapterLessonId",
                        columns: x => new { x.ChapterId, x.ChapterLessonId },
                        principalTable: "Chapters",
                        principalColumns: new[] { "Id", "LessonId" });
                    table.ForeignKey(
                        name: "FK_ChapterProgresses_Kids_KidId_KidAdultId",
                        columns: x => new { x.KidId, x.KidAdultId },
                        principalTable: "Kids",
                        principalColumns: new[] { "Id", "AdultId" });
                });

            migrationBuilder.CreateTable(
                name: "LessonProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KidId = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    KidAdultId = table.Column<string>(type: "text", nullable: true),
                    Progress = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonProgresses", x => new { x.Id, x.KidId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_LessonProgresses_Kids_KidId_KidAdultId",
                        columns: x => new { x.KidId, x.KidAdultId },
                        principalTable: "Kids",
                        principalColumns: new[] { "Id", "AdultId" });
                    table.ForeignKey(
                        name: "FK_LessonProgresses_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChapterPage3DModels",
                columns: table => new
                {
                    ChapterPageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChapterPageChapterId = table.Column<int>(type: "integer", nullable: false),
                    ChapterPage3DModelUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterPage3DModels", x => x.ChapterPageId);
                    table.ForeignKey(
                        name: "FK_ChapterPage3DModels_ChapterPages_ChapterPageId_ChapterPageC~",
                        columns: x => new { x.ChapterPageId, x.ChapterPageChapterId },
                        principalTable: "ChapterPages",
                        principalColumns: new[] { "Id", "ChapterId" });
                });

            migrationBuilder.CreateTable(
                name: "ChapterPageSounds",
                columns: table => new
                {
                    ChapterPageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChapterPageChapterId = table.Column<int>(type: "integer", nullable: false),
                    ChapterPageSoundUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterPageSounds", x => x.ChapterPageId);
                    table.ForeignKey(
                        name: "FK_ChapterPageSounds_ChapterPages_ChapterPageId_ChapterPageCha~",
                        columns: x => new { x.ChapterPageId, x.ChapterPageChapterId },
                        principalTable: "ChapterPages",
                        principalColumns: new[] { "Id", "ChapterId" });
                });

            migrationBuilder.CreateTable(
                name: "ChapterPageTexts",
                columns: table => new
                {
                    ChapterPageId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChapterPageChapterId = table.Column<int>(type: "integer", nullable: false),
                    ChapterPageTextUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterPageTexts", x => x.ChapterPageId);
                    table.ForeignKey(
                        name: "FK_ChapterPageTexts_ChapterPages_ChapterPageId_ChapterPageChap~",
                        columns: x => new { x.ChapterPageId, x.ChapterPageChapterId },
                        principalTable: "ChapterPages",
                        principalColumns: new[] { "Id", "ChapterId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_Adults3DModelId",
                table: "AspNetUsers",
                column: "Adults3DModelId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPage3DModels_ChapterPageId_ChapterPageChapterId",
                table: "ChapterPage3DModels",
                columns: new[] { "ChapterPageId", "ChapterPageChapterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPages_ChapterId_ChapterLessonId",
                table: "ChapterPages",
                columns: new[] { "ChapterId", "ChapterLessonId" });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPageSounds_ChapterPageId_ChapterPageChapterId",
                table: "ChapterPageSounds",
                columns: new[] { "ChapterPageId", "ChapterPageChapterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterPageTexts_ChapterPageId_ChapterPageChapterId",
                table: "ChapterPageTexts",
                columns: new[] { "ChapterPageId", "ChapterPageChapterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterProgresses_ChapterId_ChapterLessonId",
                table: "ChapterProgresses",
                columns: new[] { "ChapterId", "ChapterLessonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChapterProgresses_KidId_KidAdultId",
                table: "ChapterProgresses",
                columns: new[] { "KidId", "KidAdultId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_LessonId",
                table: "Chapters",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Kids_AdultId",
                table: "Kids",
                column: "AdultId");

            migrationBuilder.CreateIndex(
                name: "IX_Kids_Kids3DModelId",
                table: "Kids",
                column: "Kids3DModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonProgresses_KidId_KidAdultId",
                table: "LessonProgresses",
                columns: new[] { "KidId", "KidAdultId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonProgresses_LessonId",
                table: "LessonProgresses",
                column: "LessonId",
                unique: true);
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
                name: "ChapterPage3DModels");

            migrationBuilder.DropTable(
                name: "ChapterPageSounds");

            migrationBuilder.DropTable(
                name: "ChapterPageTexts");

            migrationBuilder.DropTable(
                name: "ChapterProgresses");

            migrationBuilder.DropTable(
                name: "LessonProgresses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ChapterPages");

            migrationBuilder.DropTable(
                name: "Kids");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Kids3DModels");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Adults3DModels");
        }
    }
}

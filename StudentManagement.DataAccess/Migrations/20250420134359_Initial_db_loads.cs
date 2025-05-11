using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial_db_loads : Migration
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
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "JWTUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JWTUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subjects = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
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
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_JWTUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "JWTUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeTableEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolClassId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTableEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTableEntries_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTableEntries_SchoolClass_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTableEntries_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTableEntries_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Period",
                columns: new[] { "Id", "EndTime", "PeriodName", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 8, 45, 0, 0), "1st", new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(0, 9, 30, 0, 0), "2nd", new TimeSpan(0, 8, 45, 0, 0) },
                    { 3, new TimeSpan(0, 10, 15, 0, 0), "3rd", new TimeSpan(0, 9, 30, 0, 0) },
                    { 4, new TimeSpan(0, 11, 0, 0, 0), "4th", new TimeSpan(0, 10, 15, 0, 0) },
                    { 5, new TimeSpan(0, 8, 45, 0, 0), "5th", new TimeSpan(0, 8, 0, 0, 0) },
                    { 6, new TimeSpan(0, 8, 45, 0, 0), "6th", new TimeSpan(0, 8, 0, 0, 0) },
                    { 7, new TimeSpan(0, 8, 45, 0, 0), "7th", new TimeSpan(0, 8, 0, 0, 0) },
                    { 8, new TimeSpan(0, 8, 45, 0, 0), "8th", new TimeSpan(0, 8, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "SchoolClass",
                columns: new[] { "Id", "Name", "Section" },
                values: new object[,]
                {
                    { 1, "I", "A" },
                    { 2, "I", "B" },
                    { 3, "I", "C" },
                    { 4, "I", "D" },
                    { 5, "I", "E" },
                    { 6, "I", "F" },
                    { 7, "II", "A" },
                    { 8, "II", "B" },
                    { 9, "II", "C" },
                    { 10, "II", "D" },
                    { 11, "II", "E" },
                    { 12, "II", "F" },
                    { 13, "III", "A" },
                    { 14, "III", "B" },
                    { 15, "III", "C" },
                    { 16, "III", "D" },
                    { 17, "III", "E" },
                    { 18, "III", "F" },
                    { 19, "IV", "A" },
                    { 20, "IV", "B" },
                    { 21, "IV", "C" },
                    { 22, "IV", "D" },
                    { 23, "IV", "E" },
                    { 24, "IV", "F" },
                    { 25, "V", "A" },
                    { 26, "V", "B" },
                    { 27, "V", "C" },
                    { 28, "V", "D" },
                    { 29, "V", "E" },
                    { 30, "V", "F" },
                    { 31, "VI", "A" },
                    { 32, "VI", "B" },
                    { 33, "VI", "C" },
                    { 34, "VI", "D" },
                    { 35, "VI", "E" },
                    { 36, "VI", "F" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "English", "English" },
                    { 2, "Hindi", "Hindi" },
                    { 3, "Sanskrit", "Sanskrit" },
                    { 4, "Mathematics", "English" },
                    { 5, "Social Science", "S. Sc." },
                    { 6, "Science", "EVS" },
                    { 7, "Computer", "Computer" },
                    { 8, "Music", "Music" },
                    { 9, "Library", "Library" },
                    { 10, "Game", "Game" },
                    { 11, "Drawing", "Drawing" },
                    { 12, "Activity", "Activity" },
                    { 13, "General Knowledge", "G. K." },
                    { 14, "Moral Education", "M. Ed." },
                    { 15, "Physical Education", "P. Ed." }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Name", "Qualified", "Subjects" },
                values: new object[,]
                {
                    { 1, "MR. ANUPAM ANURAG", "NA", "HINDI+ M.ED" },
                    { 2, "MR.Dummy ENGLISH Teacher6", "NA", "ENGLISH + SPOKEN ENG" },
                    { 3, "MS.GAYATRI KUMARI", "NA", "MATHEMATICS" },
                    { 4, "MR.MANOJ KUMAR", "NA", "EVS + ACTIVITY" },
                    { 5, "MR.ABHISHEK KR.SINGH", "NA", "S.SC. + ACT+ G.K" },
                    { 6, "MRS.PALLAVI KUMARI", "NA", "GAME" },
                    { 7, "MR.RAUSHAN KUMAR", "NA", "LIBRARY" },
                    { 8, "MRS.RICHA KUMARI", "NA", "MUSIC" },
                    { 9, "MRS.NIDHI", "NA", "COMPUTER" },
                    { 10, "MR.ARUN KUMAR", "NA", "DRAWING" },
                    { 11, "MR.MAHENDRA KUMAR", "NA", "HINDI + M.ED" },
                    { 12, "MS.MUSKAN THAKUR", "NA", "ENGLISH + SPOKEN ENG" },
                    { 13, "MRS.R.K.SAH", "NA", "MUSIC" },
                    { 14, "MRS.SNEHA", "NA", "EVS + ACTIVITY" },
                    { 15, "MRS.RUCHI KUMARI", "NA", "HINDI + M.ED" },
                    { 16, "MR.Dummy ENGLISH Teacher4", "NA", "ENGLISH + SPOKEN ENG" },
                    { 17, "MRS.KATYAYINI", "NA", "MATHEMATICS" },
                    { 18, "MR.AMAN KUMAR", "NA", "S.SC. + ACTIVITY" },
                    { 19, "MRS.PRAKRITI MOHANTI", "NA", "HINDI + M.ED" },
                    { 20, "MR.Dummy ENGLISH Teacher1", "NA", "ENGLISH + SPOKEN ENG" },
                    { 21, "MR.RAJESH KUMAR", "NA", "MATHEMATICS" },
                    { 22, "MR.ABHIJEET KUMAR THAKUR", "NA", "EVS + ACTIVITY" },
                    { 23, "MS.KANCHAN BHARTI", "NA", "ENGLISH + SPOKEN ENG" },
                    { 24, "MR.NADIM QUASMI", "NA", "LIBRARY" },
                    { 25, "MR.SURESH KUMAR", "NA", "MATHEMATICS" },
                    { 26, "MS.AMRITA KUMARI", "NA", "EVS + ACTIVITY" },
                    { 27, "MR.AVINASH KUMAR", "NA", "S.SC. + ACT + G.K." },
                    { 28, "MRS.MEGHA MITI", "NA", "COMPUTER" },
                    { 30, "MR.PRASHANT KUMAR", "NA", "MATHEMATICS" },
                    { 31, "MR.PRABIN RANJAN", "NA", "EVS + ACTIVITY" },
                    { 32, "MR.NIKHIL NISHANT", "NA", "S.SC. + ACTIVITY" },
                    { 33, "MRS.VIJETA KUMARI", "NA", "HINDI + M.ED" }
                });

            migrationBuilder.InsertData(
                table: "TimeTableEntries",
                columns: new[] { "Id", "Day", "PeriodId", "SchoolClassId", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, 1, 13, 2, 1 },
                    { 2, 1, 2, 13, 5, 5 },
                    { 3, 1, 3, 13, 8, 8 },
                    { 4, 1, 4, 13, 4, 3 },
                    { 5, 1, 5, 13, 1, 2 },
                    { 6, 1, 6, 13, 6, 4 },
                    { 7, 2, 1, 13, 2, 1 },
                    { 8, 2, 2, 13, 5, 5 },
                    { 9, 2, 3, 13, 7, 9 },
                    { 10, 2, 4, 13, 4, 3 },
                    { 11, 2, 5, 13, 1, 2 },
                    { 12, 2, 6, 13, 6, 4 },
                    { 13, 3, 1, 13, 2, 1 },
                    { 14, 3, 2, 13, 5, 5 },
                    { 15, 3, 3, 13, 7, 9 },
                    { 16, 3, 4, 13, 4, 3 },
                    { 17, 3, 5, 13, 1, 2 },
                    { 18, 3, 6, 13, 6, 4 },
                    { 19, 4, 1, 13, 2, 1 },
                    { 20, 4, 2, 13, 5, 5 },
                    { 21, 4, 3, 13, 10, 6 },
                    { 22, 4, 4, 13, 4, 3 },
                    { 23, 4, 5, 13, 1, 2 },
                    { 24, 4, 6, 13, 6, 4 },
                    { 25, 5, 1, 13, 2, 1 },
                    { 26, 5, 2, 13, 5, 5 },
                    { 27, 5, 3, 13, 11, 10 },
                    { 28, 5, 4, 13, 4, 3 },
                    { 29, 5, 5, 13, 1, 2 },
                    { 30, 5, 6, 13, 6, 4 },
                    { 31, 6, 1, 13, 2, 1 },
                    { 32, 6, 2, 13, 5, 5 },
                    { 33, 6, 3, 13, 9, 7 },
                    { 34, 6, 4, 13, 4, 3 },
                    { 35, 6, 5, 13, 1, 2 },
                    { 36, 6, 6, 13, 6, 4 }
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
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTableEntries_PeriodId",
                table: "TimeTableEntries",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTableEntries_SchoolClassId",
                table: "TimeTableEntries",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTableEntries_SubjectId",
                table: "TimeTableEntries",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTableEntries_TeacherId",
                table: "TimeTableEntries",
                column: "TeacherId");
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
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "TimeTableEntries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "JWTUsers");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}

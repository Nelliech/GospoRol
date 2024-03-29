﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GospoRol.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgriculturalClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(nullable: true),
                    NameClass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriculturalClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCultivations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCultivations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeFertilizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFertilizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeFertilizers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFertilizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypePesticides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePesticides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeSowings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSowings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTreatment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTreatment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Lands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    PlotNumber = table.Column<string>(nullable: true),
                    Acreage = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AcreageFree = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AcreageOccupied = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lands_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Acreage = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    Acreage = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CultivatedPlant = table.Column<string>(nullable: true),
                    Variety = table.Column<string>(nullable: true),
                    AgriculturalClassId = table.Column<int>(nullable: false),
                    LandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_AgriculturalClasses_AgriculturalClassId",
                        column: x => x.AgriculturalClassId,
                        principalTable: "AgriculturalClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fields_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fields_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fertilizers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    FertilizerComposition = table.Column<string>(nullable: true),
                    Concentration = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Capacity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FertilizerUnit = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    TypeProductId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    TypeFertilizerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fertilizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fertilizers_TypeFertilizers_TypeFertilizerId",
                        column: x => x.TypeFertilizerId,
                        principalTable: "TypeFertilizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fertilizers_TypeProduct_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "TypeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fertilizers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fertilizers_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pesticides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PesticideComposition = table.Column<string>(nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PesticideUnit = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    TypeProductId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    TypePesticideId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesticides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesticides_TypePesticides_TypePesticideId",
                        column: x => x.TypePesticideId,
                        principalTable: "TypePesticides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pesticides_TypeProduct_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "TypeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pesticides_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pesticides_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    NamePlant = table.Column<string>(nullable: true),
                    PlantVariety = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SeedUnit = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    TypeProductId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seeds_TypeProduct_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "TypeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seeds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seeds_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cultivatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DateTreatment = table.Column<DateTime>(nullable: false),
                    CultivatedPlant = table.Column<string>(nullable: true),
                    PlantVariety = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: false),
                    TypeTreatmentId = table.Column<int>(nullable: false),
                    TypeCultivationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cultivatings_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cultivatings_TypeCultivations_TypeCultivationId",
                        column: x => x.TypeCultivationId,
                        principalTable: "TypeCultivations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cultivatings_TypeTreatment_TypeTreatmentId",
                        column: x => x.TypeTreatmentId,
                        principalTable: "TypeTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cultivatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Harvests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DateTreatment = table.Column<DateTime>(nullable: false),
                    CultivatedPlant = table.Column<string>(nullable: true),
                    PlantVariety = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: false),
                    TypeTreatmentId = table.Column<int>(nullable: false),
                    Efficiency = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsPostHarvestResidue = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harvests_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Harvests_TypeTreatment_TypeTreatmentId",
                        column: x => x.TypeTreatmentId,
                        principalTable: "TypeTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Harvests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MechanicalWeedControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DateTreatment = table.Column<DateTime>(nullable: false),
                    CultivatedPlant = table.Column<string>(nullable: true),
                    PlantVariety = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: false),
                    TypeTreatmentId = table.Column<int>(nullable: false),
                    NumberInterRows = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicalWeedControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MechanicalWeedControls_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicalWeedControls_TypeTreatment_TypeTreatmentId",
                        column: x => x.TypeTreatmentId,
                        principalTable: "TypeTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicalWeedControls_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fertilizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DateTreatment = table.Column<DateTime>(nullable: false),
                    CultivatedPlant = table.Column<string>(nullable: true),
                    PlantVariety = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: false),
                    TypeTreatmentId = table.Column<int>(nullable: false),
                    HowManyHa = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FertilizationUnit = table.Column<int>(nullable: false),
                    FertilizerId = table.Column<int>(nullable: false),
                    TypeFertilizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fertilizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fertilizations_Fertilizers_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fertilizations_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fertilizations_TypeFertilizations_TypeFertilizationId",
                        column: x => x.TypeFertilizationId,
                        principalTable: "TypeFertilizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fertilizations_TypeTreatment_TypeTreatmentId",
                        column: x => x.TypeTreatmentId,
                        principalTable: "TypeTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fertilizations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sprayings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DateTreatment = table.Column<DateTime>(nullable: false),
                    CultivatedPlant = table.Column<string>(nullable: true),
                    PlantVariety = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: false),
                    TypeTreatmentId = table.Column<int>(nullable: false),
                    NameProduct = table.Column<string>(nullable: true),
                    Dose = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SprayingUnit = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    PesticideId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprayings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprayings_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sprayings_Pesticides_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Pesticides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sprayings_TypeTreatment_TypeTreatmentId",
                        column: x => x.TypeTreatmentId,
                        principalTable: "TypeTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sprayings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sowings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DateTreatment = table.Column<DateTime>(nullable: false),
                    CultivatedPlant = table.Column<string>(nullable: true),
                    PlantVariety = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: false),
                    TypeTreatmentId = table.Column<int>(nullable: false),
                    WidthBetweenRows = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NumberRows = table.Column<int>(nullable: false),
                    HowManyHa = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SowingUnit = table.Column<int>(nullable: false),
                    DepthSowing = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TypeSowingId = table.Column<int>(nullable: false),
                    SeedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sowings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sowings_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sowings_Seeds_SeedId",
                        column: x => x.SeedId,
                        principalTable: "Seeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sowings_TypeSowings_TypeSowingId",
                        column: x => x.TypeSowingId,
                        principalTable: "TypeSowings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sowings_TypeTreatment_TypeTreatmentId",
                        column: x => x.TypeTreatmentId,
                        principalTable: "TypeTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sowings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    NamePlant = table.Column<string>(nullable: true),
                    PlantVariety = table.Column<string>(nullable: true),
                    Count = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    YieldUnit = table.Column<int>(nullable: false),
                    HarvestRef = table.Column<int>(nullable: true),
                    TypeProductId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yields_Harvests_HarvestRef",
                        column: x => x.HarvestRef,
                        principalTable: "Harvests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yields_TypeProduct_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "TypeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yields_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yields_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AgriculturalClasses",
                columns: new[] { "Id", "Class", "NameClass" },
                values: new object[,]
                {
                    { 1, "I", "Gleby orne najlepsze" },
                    { 2, "II", "Gleby orne bardzo dobre" },
                    { 3, "III a", "Gleby orne dobre" },
                    { 4, "III b", "Gleby orne średnio dobre" },
                    { 5, "IV a", "Gleby orne średniej jakości, lepsze" },
                    { 6, "IV a", "Gleby orne średniej jakości, gorsze" },
                    { 7, "V", "Gleby orne słabe" },
                    { 8, "VI", "Gleby orne najsłabsze" }
                });

            migrationBuilder.InsertData(
                table: "TypeCultivations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Kultywatorowanie" },
                    { 3, "Bronowanie" },
                    { 2, "Orka" },
                    { 1, "Włókowanie" },
                    { 5, "Wałowanie" },
                    { 6, "Gryzowanie" }
                });

            migrationBuilder.InsertData(
                table: "TypeFertilizations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nawożenie Przedsiewne" },
                    { 2, "Nawożenie Siewne" },
                    { 3, "Nawożenie Pogłówne" },
                    { 4, "Nawożenie Dolistne" }
                });

            migrationBuilder.InsertData(
                table: "TypeFertilizers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Mikroelementy" },
                    { 1, "Nawóz Zielony" },
                    { 5, "Fosfor" },
                    { 2, "Nawóz Organiczny" },
                    { 3, "Nawóz Mineralny" },
                    { 4, "Azot" },
                    { 6, "Potas" }
                });

            migrationBuilder.InsertData(
                table: "TypePesticides",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Wirocyd" },
                    { 7, "Zoocyd" },
                    { 6, "Regulator wzrostu owadów" },
                    { 5, "Regulator wzrostu roślin" },
                    { 4, "Herbicyd" },
                    { 3, "Fungicyd" },
                    { 1, "Algicyd" },
                    { 8, "Synergetyk" },
                    { 2, "Bakteriocyd" }
                });

            migrationBuilder.InsertData(
                table: "TypeProduct",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nawozy" },
                    { 3, "Pestycydy" },
                    { 2, "Nasiona" },
                    { 4, "Plony Rolne" }
                });

            migrationBuilder.InsertData(
                table: "TypeSowings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Siew Gwiazdowy" },
                    { 2, "Siew Punktowy" },
                    { 3, "Siew Pasowy" },
                    { 4, "Siew Rzędowy" },
                    { 5, "Siew Rzutowy" }
                });

            migrationBuilder.InsertData(
                table: "TypeTreatment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Odchwaszczanie" },
                    { 1, "Siew" },
                    { 2, "Zbiór" },
                    { 3, "Nawożenie" },
                    { 4, "Oprysk" },
                    { 6, "Zabieg Uprawowy" }
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
                name: "IX_Cultivatings_FieldId",
                table: "Cultivatings",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivatings_TypeCultivationId",
                table: "Cultivatings",
                column: "TypeCultivationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivatings_TypeTreatmentId",
                table: "Cultivatings",
                column: "TypeTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivatings_UserId",
                table: "Cultivatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizations_FertilizerId",
                table: "Fertilizations",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizations_FieldId",
                table: "Fertilizations",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizations_TypeFertilizationId",
                table: "Fertilizations",
                column: "TypeFertilizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizations_TypeTreatmentId",
                table: "Fertilizations",
                column: "TypeTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizations_UserId",
                table: "Fertilizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizers_TypeFertilizerId",
                table: "Fertilizers",
                column: "TypeFertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizers_TypeProductId",
                table: "Fertilizers",
                column: "TypeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizers_UserId",
                table: "Fertilizers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizers_WarehouseId",
                table: "Fertilizers",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_AgriculturalClassId",
                table: "Fields",
                column: "AgriculturalClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_LandId",
                table: "Fields",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_UserId",
                table: "Fields",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_FieldId",
                table: "Harvests",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_TypeTreatmentId",
                table: "Harvests",
                column: "TypeTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_UserId",
                table: "Harvests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_UserId",
                table: "Lands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWeedControls_FieldId",
                table: "MechanicalWeedControls",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWeedControls_TypeTreatmentId",
                table: "MechanicalWeedControls",
                column: "TypeTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWeedControls_UserId",
                table: "MechanicalWeedControls",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesticides_TypePesticideId",
                table: "Pesticides",
                column: "TypePesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesticides_TypeProductId",
                table: "Pesticides",
                column: "TypeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesticides_UserId",
                table: "Pesticides",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesticides_WarehouseId",
                table: "Pesticides",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Seeds_TypeProductId",
                table: "Seeds",
                column: "TypeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Seeds_UserId",
                table: "Seeds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Seeds_WarehouseId",
                table: "Seeds",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sowings_FieldId",
                table: "Sowings",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Sowings_SeedId",
                table: "Sowings",
                column: "SeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Sowings_TypeSowingId",
                table: "Sowings",
                column: "TypeSowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Sowings_TypeTreatmentId",
                table: "Sowings",
                column: "TypeTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sowings_UserId",
                table: "Sowings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprayings_FieldId",
                table: "Sprayings",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprayings_PesticideId",
                table: "Sprayings",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprayings_TypeTreatmentId",
                table: "Sprayings",
                column: "TypeTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprayings_UserId",
                table: "Sprayings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_UserId",
                table: "Warehouses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Yields_HarvestRef",
                table: "Yields",
                column: "HarvestRef",
                unique: true,
                filter: "[HarvestRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Yields_TypeProductId",
                table: "Yields",
                column: "TypeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Yields_UserId",
                table: "Yields",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Yields_WarehouseId",
                table: "Yields",
                column: "WarehouseId");
        }

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
                name: "Cultivatings");

            migrationBuilder.DropTable(
                name: "Fertilizations");

            migrationBuilder.DropTable(
                name: "MechanicalWeedControls");

            migrationBuilder.DropTable(
                name: "Sowings");

            migrationBuilder.DropTable(
                name: "Sprayings");

            migrationBuilder.DropTable(
                name: "Yields");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TypeCultivations");

            migrationBuilder.DropTable(
                name: "Fertilizers");

            migrationBuilder.DropTable(
                name: "TypeFertilizations");

            migrationBuilder.DropTable(
                name: "Seeds");

            migrationBuilder.DropTable(
                name: "TypeSowings");

            migrationBuilder.DropTable(
                name: "Pesticides");

            migrationBuilder.DropTable(
                name: "Harvests");

            migrationBuilder.DropTable(
                name: "TypeFertilizers");

            migrationBuilder.DropTable(
                name: "TypePesticides");

            migrationBuilder.DropTable(
                name: "TypeProduct");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "TypeTreatment");

            migrationBuilder.DropTable(
                name: "AgriculturalClasses");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

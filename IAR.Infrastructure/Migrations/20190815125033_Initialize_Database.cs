using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IAR.Infrastructure.Migrations
{
    public partial class Initialize_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicableRights",
                columns: table => new
                {
                    ApplicableRightId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicableRights", x => x.ApplicableRightId);
                });

            migrationBuilder.CreateTable(
                name: "AssetStatuses",
                columns: table => new
                {
                    AssetStatusId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatuses", x => x.AssetStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AssetValues",
                columns: table => new
                {
                    AssetValueId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetValues", x => x.AssetValueId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DepartmentName = table.Column<string>(nullable: true),
                    DepartmentAbbreviation = table.Column<string>(nullable: true),
                    DPOName = table.Column<string>(nullable: true),
                    DataControllerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentSecurityClassifications",
                columns: table => new
                {
                    GovernmentSecurityClassificationId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentSecurityClassifications", x => x.GovernmentSecurityClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "LawfulProcessingConditions",
                columns: table => new
                {
                    LawfulProcessingConditionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawfulProcessingConditions", x => x.LawfulProcessingConditionId);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationalSecurityMeasures",
                columns: table => new
                {
                    OrganisationalSecurityMeasureId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationalSecurityMeasures", x => x.OrganisationalSecurityMeasureId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDataSources",
                columns: table => new
                {
                    PersonalDataSourceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDataSources", x => x.PersonalDataSourceId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDataSpecialCategories",
                columns: table => new
                {
                    PersonalDataSpecialCategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDataSpecialCategories", x => x.PersonalDataSpecialCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProtectiveMarkingClassifications",
                columns: table => new
                {
                    ProtectiveMarkingClassificationId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ProtectiveMarkingClassificationDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtectiveMarkingClassifications", x => x.ProtectiveMarkingClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "RetentionPeriods",
                columns: table => new
                {
                    RetentionPeriodId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetentionPeriods", x => x.RetentionPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialCategoryLawfulProcessingConditions",
                columns: table => new
                {
                    SpecialCategoryLawfulProcessingConditionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCategoryLawfulProcessingConditions", x => x.SpecialCategoryLawfulProcessingConditionId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DivisionName = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Divisions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessAreas",
                columns: table => new
                {
                    BusinessAreaId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BusinessAreaName = table.Column<string>(nullable: true),
                    ParentDivisionDivisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAreas", x => x.BusinessAreaId);
                    table.ForeignKey(
                        name: "FK_BusinessAreas_Divisions_ParentDivisionDivisionId",
                        column: x => x.ParentDivisionDivisionId,
                        principalTable: "Divisions",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InformationAssetOwners",
                columns: table => new
                {
                    InformationAssetOwnerId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DisplayName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    BusinessAreaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationAssetOwners", x => x.InformationAssetOwnerId);
                    table.ForeignKey(
                        name: "FK_InformationAssetOwners_BusinessAreas_BusinessAreaId",
                        column: x => x.BusinessAreaId,
                        principalTable: "BusinessAreas",
                        principalColumn: "BusinessAreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    WindowsLoginName = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    RoleUserRoleId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    BusinessAreaId = table.Column<int>(nullable: true),
                    IsIAO = table.Column<short>(nullable: false)                  
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_BusinessAreas_BusinessAreaId",
                        column: x => x.BusinessAreaId,
                        principalTable: "BusinessAreas",
                        principalColumn: "BusinessAreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleUserRoleId",
                        column: x => x.RoleUserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DataController = table.Column<string>(nullable: true),
                    AssetName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    InformationAssetOwnerUserId = table.Column<int>(nullable: true),
                    LocalResponsiblePerson = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AssetStatusId = table.Column<int>(nullable: true),
                    RetentionPeriodId = table.Column<int>(nullable: true),
                    RetentionPeriodOther = table.Column<string>(nullable: true),
                    GovernmentSecurityClassificationId = table.Column<int>(nullable: true),
                    AccessToAsset = table.Column<string>(nullable: true),
                    RisksToAsset = table.Column<string>(nullable: true),
                    ValueOfAssetAssetValueId = table.Column<int>(nullable: true),
                    BILConfidentiality = table.Column<int>(nullable: true),
                    BILIntegrity = table.Column<int>(nullable: true),
                    BILAvailability = table.Column<int>(nullable: true),
                    LinkToBIAssessment = table.Column<string>(nullable: true),
                    DSAInPlace = table.Column<short>(nullable: false),
                    LinkToDataSharingAgreement = table.Column<string>(nullable: true),
                    DSAReviewDate = table.Column<DateTime>(nullable: true),
                    HardcopyLocation = table.Column<string>(nullable: true),
                    FileShareLocation = table.Column<string>(nullable: true),
                    AssetInHardCopy = table.Column<short>(nullable: false),
                    AssetInSystem = table.Column<short>(nullable: false),
                    SystemDetails = table.Column<string>(nullable: true),
                    PersonalInformationHeld = table.Column<short>(nullable: true),
                    JointDataController = table.Column<string>(nullable: true),
                    ReasonForProcessing = table.Column<string>(nullable: true),
                    CategoriesOfIndividuals = table.Column<string>(nullable: true),
                    CategoriesOfPersonalData = table.Column<string>(nullable: true),
                    EvidenceOfLC = table.Column<string>(nullable: true),
                    EvidenceOfSCLC = table.Column<string>(nullable: true),
                    CategoriesOfRecipients = table.Column<string>(nullable: true),
                    TransfersToThirdCountries = table.Column<short>(nullable: true),
                    LinkToDocumentation = table.Column<string>(nullable: true),
                    DPIAPerformed = table.Column<short>(nullable: true),
                    LinkToDPIA = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DeptReference = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_AssetStatuses_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatuses",
                        principalColumn: "AssetStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_GSC_GovernmentSecurityClassificationId",
                        column: x => x.GovernmentSecurityClassificationId,
                        principalTable: "GovernmentSecurityClassifications",
                        principalColumn: "GovernmentSecurityClassificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_Users_InformationAssetOwnerUserId",
                        column: x => x.InformationAssetOwnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_RetentionPeriods_RetentionPeriodId",
                        column: x => x.RetentionPeriodId,
                        principalTable: "RetentionPeriods",
                        principalColumn: "RetentionPeriodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assets_AssetValues_ValueOfAssetAssetValueId",
                        column: x => x.ValueOfAssetAssetValueId,
                        principalTable: "AssetValues",
                        principalColumn: "AssetValueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetApplicableRights",
                columns: table => new
                {
                    AssetApplicableRightId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AssetId = table.Column<int>(nullable: true),
                    ApplicableRightId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetApplicableRight", x => x.AssetApplicableRightId);
                    table.ForeignKey(
                        name: "FK_AssetApplicableRight_ApplicableRights_ApplicableRightId",
                        column: x => x.ApplicableRightId,
                        principalTable: "ApplicableRights",
                        principalColumn: "ApplicableRightId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetApplicableRight_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetLawfulProcessingConditions",
                columns: table => new
                {
                    AssetLawfulProcessingConditionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AssetId = table.Column<int>(nullable: true),
                    LawfulProcessingConditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLawfulProcessingCondition", x => x.AssetLawfulProcessingConditionId);
                    table.ForeignKey(
                        name: "FK_AssetLawfulProcessingCondition_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetLPC_LPC_LPCId",
                        column: x => x.LawfulProcessingConditionId,
                        principalTable: "LawfulProcessingConditions",
                        principalColumn: "LawfulProcessingConditionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetOrganisationalSecurityMeasures",
                columns: table => new
                {
                    AssetOrganisationalSecurityMeasureId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AssetId = table.Column<int>(nullable: true),
                    OrganisationalSecurityMeasureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetOrganisationalSecurityMeasure", x => x.AssetOrganisationalSecurityMeasureId);
                    table.ForeignKey(
                        name: "FK_AssetOrganisationalSecurityMeasure_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetOSM_OSM_OSMId",
                        column: x => x.OrganisationalSecurityMeasureId,
                        principalTable: "OrganisationalSecurityMeasures",
                        principalColumn: "OrganisationalSecurityMeasureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetPersonalDataSources",
                columns: table => new
                {
                    AssetPersonalDataSourceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AssetId = table.Column<int>(nullable: true),
                    PersonalDataSourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPersonalDataSource", x => x.AssetPersonalDataSourceId);
                    table.ForeignKey(
                        name: "FK_AssetPersonalDataSource_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetPDS_PDS_PDSId",
                        column: x => x.PersonalDataSourceId,
                        principalTable: "PersonalDataSources",
                        principalColumn: "PersonalDataSourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetPersonalDataSpecialCategories",
                columns: table => new
                {
                    AssetPersonalDataSpecialCategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AssetId = table.Column<int>(nullable: true),
                    PersonalDataSpecialCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPersonalDataSpecialCategory", x => x.AssetPersonalDataSpecialCategoryId);
                    table.ForeignKey(
                        name: "FK_AssetPersonalDataSpecialCategory_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetPDSC_PDSC_PDSCId",
                        column: x => x.PersonalDataSpecialCategoryId,
                        principalTable: "PersonalDataSpecialCategories",
                        principalColumn: "PersonalDataSpecialCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetSpecialCategoryLawfulProcessingConditions",
                columns: table => new
                {
                    AssetSpecialCategoryLawfulProcessingConditionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AssetId = table.Column<int>(nullable: true),
                    SpecialCategoryLawfulProcessingConditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetSpecialCategoryLawfulProcessingCondition", x => x.AssetSpecialCategoryLawfulProcessingConditionId);
                    table.ForeignKey(
                        name: "FK_AssetSpecialCategoryLawfulProcessingCondition_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetSCLP_SCLP_SCLPId",
                        column: x => x.SpecialCategoryLawfulProcessingConditionId,
                        principalTable: "SpecialCategoryLawfulProcessingConditions",
                        principalColumn: "SpecialCategoryLawfulProcessingConditionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLinkedUsers",
                columns: table => new
                {
                    LinkedUserId = table.Column<int>(nullable: false).Annotation("MySQL:AutoIncrement", true),
                    LinkedUser_UserId = table.Column<int>(nullable: false),
                    PrimaryUser_UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLinkedUserId", x => x.LinkedUserId);
                    table.ForeignKey(
                        name: "FK_PrimaryUser_UserId",
                        column: x => x.PrimaryUser_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkedUser_UserId",
                        column: x => x.LinkedUser_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicableRights",
                columns: new[] { "ApplicableRightId", "Description" },
                values: new object[,]
                {
                    { 1, "Right to be informed" },
                    { 2, "Right of access" },
                    { 3, "Right to Rectification" },
                    { 4, "Right to erasure" },
                    { 5, "Right to restrict processing" },
                    { 6, "Right to data portability" },
                    { 7, "Right to object" },
                    { 8, "Rights to automated decision making including profiling" }
                });

            migrationBuilder.InsertData(
                table: "AssetStatuses",
                columns: new[] { "AssetStatusId", "Description" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" },
                    { 3, "Disposed" }
                });

            migrationBuilder.InsertData(
                table: "AssetValues",
                columns: new[] { "AssetValueId", "Description" },
                values: new object[,]
                {
                    { 3, "Low" },
                    { 2, "Medium" },
                    { 1, "High" }
                });

            migrationBuilder.InsertData(
                table: "GovernmentSecurityClassifications",
                columns: new[] { "GovernmentSecurityClassificationId", "Description" },
                values: new object[,]
                {
                    { 1, "Official" },
                    { 2, "Official Sensitive" },
                    { 3, "Secret" },
                    { 4, "Top Secret" }
                });

            migrationBuilder.InsertData(
                table: "LawfulProcessingConditions",
                columns: new[] { "LawfulProcessingConditionId", "Description" },
                values: new object[,]
                {
                    { 1, "Legal obligation" },
                    { 2, "Public task" },
                    { 3, "Consent" },
                    { 4, "Contract" },
                    { 5, "Vital interest" },
                    { 6, "Legitimate interest" }
                });

            migrationBuilder.InsertData(
                table: "OrganisationalSecurityMeasures",
                columns: new[] { "OrganisationalSecurityMeasureId", "Description" },
                values: new object[,]
                {
                    { 5, "Training" },
                    { 4, "Documented processes in place for handling personal data" },
                    { 6, "Business continuity plan" },
                    { 2, "Encrypted transfer" },
                    { 1, "Encrypted storage" },
                    { 3, "Access controls" }
                });

            migrationBuilder.InsertData(
                table: "PersonalDataSources",
                columns: new[] { "PersonalDataSourceId", "Description" },
                values: new object[,]
                {
                    { 1, "Data subject" },
                    { 2, "Data controller" },
                    { 3, "3rd party" }
                });

            migrationBuilder.InsertData(
                table: "PersonalDataSpecialCategories",
                columns: new[] { "PersonalDataSpecialCategoryId", "Description" },
                values: new object[,]
                {
                    { 11, "None" },
                    { 9, "Sex life" },
                    { 8, "Physical and mental health" },
                    { 7, "Biometrics (where used for ID purposes)" },
                    { 6, "Genetics" },
                    { 10, "Sexual orientation" },
                    { 4, "Religious or philosophical beliefs" },
                    { 3, "Political opinion" },
                    { 2, "Ethnic origin" },
                    { 1, "Race" },
                    { 5, "Trade union membership" }
                });

            migrationBuilder.InsertData(
                table: "RetentionPeriods",
                columns: new[] { "RetentionPeriodId", "Description" },
                values: new object[,]
                {
                    { 4, "10 years" },
                    { 3, "2 years" },
                    { 5, "Other - Please specify" },
                    { 1, "Never" },
                    { 2, "1 year" }
                });

            migrationBuilder.InsertData(
                table: "SpecialCategoryLawfulProcessingConditions",
                columns: new[] { "SpecialCategoryLawfulProcessingConditionId", "Description" },
                values: new object[,]
                {
                    { 9, "Legitimate activities" },
                    { 1, "Explicit consent" },
                    { 2, "Employment and Social Security and Social Protection law" },
                    { 3, "Vital interests of data subject" },
                    { 4, "Public health" },
                    { 5, "Made public by the data subject" },
                    { 6, "Substantial public interest" },
                    { 7, "Statistical/Research" },
                    { 8, "Establishment, exercise or defence of legal claims" },
                    { 10, "Employee health and social care" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetApplicableRight_ApplicableRightId",
                table: "AssetApplicableRights",
                column: "ApplicableRightId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetApplicableRight_AssetId",
                table: "AssetApplicableRights",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLawfulProcessingCondition_AssetId",
                table: "assetlawfulprocessingconditions",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLPC_LPCId",
                table: "assetlawfulprocessingconditions",
                column: "LawfulProcessingConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetOSM_AssetId",
                table: "assetorganisationalsecuritymeasures",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetOSM_OrganisationalSecurityMeasureId",
                table: "AssetOrganisationalSecurityMeasures",
                column: "OrganisationalSecurityMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPDS_AssetId",
                table: "AssetPersonalDataSources",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPDS_PersonalDataSourceId",
                table: "AssetPersonalDataSources",
                column: "PersonalDataSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPersonalDataSpecialCategory_AssetId",
                table: "AssetPersonalDataSpecialCategories",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPDSC_PersonalDataSpecialCategoryId",
                table: "AssetPersonalDataSpecialCategories",
                column: "PersonalDataSpecialCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetStatusId",
                table: "Assets",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_GSCId",
                table: "Assets",
                column: "GovernmentSecurityClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_InformationAssetOwnerUserId",
                table: "Assets",
                column: "InformationAssetOwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_RetentionPeriodId",
                table: "Assets",
                column: "RetentionPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ValueOfAssetAssetValueId",
                table: "Assets",
                column: "ValueOfAssetAssetValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetSpecialCategoryLawfulProcessingCondition_AssetId",
                table: "AssetSpecialCategoryLawfulProcessingConditions",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetSCLP_SpecialCategoryLawfulProcessingConditionId",
                table: "AssetSpecialCategoryLawfulProcessingConditions",
                column: "SpecialCategoryLawfulProcessingConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAreas_ParentDivisionDivisionId",
                table: "BusinessAreas",
                column: "ParentDivisionDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_DepartmentId",
                table: "Divisions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationAssetOwners_BusinessAreaId",
                table: "InformationAssetOwners",
                column: "BusinessAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusinessAreaId",
                table: "Users",
                column: "BusinessAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleUserRoleId",
                table: "Users",
                column: "RoleUserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetApplicableRights");

            migrationBuilder.DropTable(
                name: "assetlawfulprocessingconditions");

            migrationBuilder.DropTable(
                name: "assetorganisationalsecuritymeasures");

            migrationBuilder.DropTable(
                name: "AssetPersonalDataSource");

            migrationBuilder.DropTable(
                name: "AssetPersonalDataSpecialCategory");

            migrationBuilder.DropTable(
                name: "AssetSpecialCategoryLawfulProcessingCondition");

            migrationBuilder.DropTable(
                name: "InformationAssetOwners");

            migrationBuilder.DropTable(
                name: "ProtectiveMarkingClassifications");

            migrationBuilder.DropTable(
                name: "ApplicableRights");

            migrationBuilder.DropTable(
                name: "LawfulProcessingConditions");

            migrationBuilder.DropTable(
                name: "OrganisationalSecurityMeasures");

            migrationBuilder.DropTable(
                name: "PersonalDataSources");

            migrationBuilder.DropTable(
                name: "PersonalDataSpecialCategories");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "SpecialCategoryLawfulProcessingConditions");

            migrationBuilder.DropTable(
                name: "AssetStatuses");

            migrationBuilder.DropTable(
                name: "GovernmentSecurityClassifications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RetentionPeriods");

            migrationBuilder.DropTable(
                name: "AssetValues");

            migrationBuilder.DropTable(
                name: "BusinessAreas");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

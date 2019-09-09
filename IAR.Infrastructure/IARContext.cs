using IAR.Domain.Admin;
using IAR.Domain.InformationAssets;
using IAR.Domain.LookupLists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace IAR.Infrastructure
{
    public class IARContext : DbContext
    {
        public IARContext()
        {

        }

        public IARContext(DbContextOptions<IARContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged, and Modified <see cref="User"/> entities in this context.
        /// </summary>
        public DbSet<User> Users { get; set; }


        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged, and Modified <see cref="UserLinkedUser"/> entities in this context.
        /// </summary>
        public DbSet<UserLinkedUser> UserLinkedUsers { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged, and Modified <see cref="UserRole"/> entities in this context.
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="Asset"/> entities in this context.
        /// </summary>
        public DbSet<Asset> Assets { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="AssetApplicableRight"/> entities in this context.
        /// </summary>
        public DbSet<AssetApplicableRight> AssetApplicableRights { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="AssetLawfulProcessingCondition"/> entities in this context.
        /// </summary>
        public DbSet<AssetLawfulProcessingCondition> AssetLawfulProcessingConditions { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="AssetOrganisationalSecurityMeasure"/> entities in this context.
        /// </summary>
        public DbSet<AssetOrganisationalSecurityMeasure> AssetOrganisationalSecurityMeasures { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="AssetPersonalDataSource"/> entities in this context.
        /// </summary>
        public DbSet<AssetPersonalDataSource> AssetPersonalDataSources { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="AssetPersonalDataSpecialCategory"/> entities in this context.
        /// </summary>
        public DbSet<AssetPersonalDataSpecialCategory> AssetPersonalDataSpecialCategories { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="AssetSpecialCategoryLawfulProcessingCondition"/> entities in this context.
        /// </summary>
        public DbSet<AssetSpecialCategoryLawfulProcessingCondition> AssetSpecialCategoryLawfulProcessingConditions { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged, and Modified <see cref="BusinessArea"/> entities in this context.
        /// </summary>
        public DbSet<BusinessArea> BusinessAreas { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged, and Modified <see cref="Department"/> entities in this context.
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged, and Modified <see cref="Division"/> entities in this context.
        /// </summary>
        public DbSet<Division> Divisions { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged, and Modified <see cref="InformationAssetOwner"/> entities in this context.
        /// </summary>
        public DbSet<InformationAssetOwner> InformationAssetOwners { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged, and Modified <see cref="ProtectiveMarkingClassification"/> entities in this context.
        /// </summary>
        public DbSet<ProtectiveMarkingClassification> ProtectiveMarkingClassifications { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="AssetStatus"/> entities in this context.
        /// </summary>
        public DbSet<AssetStatus> AssetStatuses { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="RetentionPeriod"/> entities in this context.
        /// </summary>
        public DbSet<RetentionPeriod> RetentionPeriods { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="GovernmentSecurityClassification"/> entities in this context.
        /// </summary>
        public DbSet<GovernmentSecurityClassification> GovernmentSecurityClassifications { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="AssetValue"/> entities in this context.
        /// </summary>
        public DbSet<AssetValue> AssetValues { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="PersonalDataSource"/> entities in this context.
        /// </summary>
        public DbSet<PersonalDataSource> PersonalDataSources { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="LawfulProcessingCondition"/> entities in this context.
        /// </summary>
        public DbSet<LawfulProcessingCondition> LawfulProcessingConditions { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="PersonalDataSpecialCategory"/> entities in this context.
        /// </summary>
        public DbSet<PersonalDataSpecialCategory> PersonalDataSpecialCategories { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="SpecialCategoryLawfulProcessingCondition"/> entities in this context.
        /// </summary>
        public DbSet<SpecialCategoryLawfulProcessingCondition> SpecialCategoryLawfulProcessingConditions { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="ApplicableRight"/> entities in this context.
        /// </summary>
        public DbSet<ApplicableRight> ApplicableRights { get; set; }

        /// <summary>
        /// Gets or sets a collection of all Added, Unchanged and Modified <see cref="OrganisationalSecurityMeasure"/> entities in this context.
        /// </summary>
        public DbSet<OrganisationalSecurityMeasure> OrganisationalSecurityMeasures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asset>().Property(p => p.PersonalInformationHeld).HasConversion(new BoolToZeroOneConverter<Int16>());
            modelBuilder.Entity<Asset>().Property(p => p.AssetInSystem).HasConversion(new BoolToZeroOneConverter<Int16>());
            modelBuilder.Entity<Asset>().Property(p => p.DPIAPerformed).HasConversion(new BoolToZeroOneConverter<Int16>());
            modelBuilder.Entity<Asset>().Property(p => p.DSAInPlace).HasConversion(new BoolToZeroOneConverter<Int16>());
            modelBuilder.Entity<Asset>().Property(p => p.AssetInHardCopy).HasConversion(new BoolToZeroOneConverter<Int16>());
            modelBuilder.Entity<Asset>().Property(p => p.TransfersToThirdCountries).HasConversion(new BoolToZeroOneConverter<Int16>());
            modelBuilder.Entity<User>().Property(p => p.IsIAO).HasConversion(new BoolToZeroOneConverter<Int16>());
            modelBuilder.Entity<User>().HasMany(u => u.LinkedUsers).WithOne(u => u.PrimaryUser);

            SeedData(modelBuilder);
        }

        void SeedData(ModelBuilder modelBuilder)
        {
            //Seed the lookup list values
            modelBuilder.Entity<AssetStatus>().HasData(
                new AssetStatus() { AssetStatusId = 1, Description = "Active" },
               new AssetStatus() { AssetStatusId = 2, Description = "Inactive" },
               new AssetStatus() { AssetStatusId = 3, Description = "Disposed" });

            modelBuilder.Entity<RetentionPeriod>().HasData(
               new RetentionPeriod() { RetentionPeriodId = 1, Description = "Never" },
               new RetentionPeriod() { RetentionPeriodId = 2, Description = "1 year" },
               new RetentionPeriod() { RetentionPeriodId = 3, Description = "2 years" },
               new RetentionPeriod() { RetentionPeriodId = 4, Description = "10 years" },
               new RetentionPeriod() { RetentionPeriodId = 5, Description = "Other - Please specify" });

            modelBuilder.Entity<GovernmentSecurityClassification>().HasData(
                new GovernmentSecurityClassification() { GovernmentSecurityClassificationId = 1, Description = "Official" },
                new GovernmentSecurityClassification() { GovernmentSecurityClassificationId = 2, Description = "Official Sensitive" },
                new GovernmentSecurityClassification() { GovernmentSecurityClassificationId = 3, Description = "Secret" },
                new GovernmentSecurityClassification() { GovernmentSecurityClassificationId = 4, Description = "Top Secret" });

            modelBuilder.Entity<AssetValue>().HasData(
                new AssetValue() { AssetValueId = 1, Description = "High" },
                new AssetValue() { AssetValueId = 2, Description = "Medium" },
                new AssetValue() { AssetValueId = 3, Description = "Low" });

            modelBuilder.Entity<PersonalDataSource>().HasData(
                new PersonalDataSource() { PersonalDataSourceId = 1, Description = "Data subject" },
                new PersonalDataSource() { PersonalDataSourceId = 2, Description = "Data controller" },
                new PersonalDataSource() { PersonalDataSourceId = 3, Description = "3rd party" });

            modelBuilder.Entity<PersonalDataSpecialCategory>().HasData(
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 1, Description = "Race" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 2, Description = "Ethnic origin" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 3, Description = "Political opinion" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 4, Description = "Religious or philosophical beliefs" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 5, Description = "Trade union membership" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 6, Description = "Genetics" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 7, Description = "Biometrics (where used for ID purposes)" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 8, Description = "Physical and mental health" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 9, Description = "Sex life" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 10, Description = "Sexual orientation" },
                new PersonalDataSpecialCategory() { PersonalDataSpecialCategoryId = 11, Description = "None" });

            modelBuilder.Entity<LawfulProcessingCondition>().HasData(
                new LawfulProcessingCondition() { LawfulProcessingConditionId = 1, Description = "Legal obligation" },
                new LawfulProcessingCondition() { LawfulProcessingConditionId = 2, Description = "Public task" },
                new LawfulProcessingCondition() { LawfulProcessingConditionId = 3, Description = "Consent" },
                new LawfulProcessingCondition() { LawfulProcessingConditionId = 4, Description = "Contract" },
                new LawfulProcessingCondition() { LawfulProcessingConditionId = 5, Description = "Vital interest" },
                new LawfulProcessingCondition() { LawfulProcessingConditionId = 6, Description = "Legitimate interest" });

            modelBuilder.Entity<SpecialCategoryLawfulProcessingCondition>().HasData(
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 1, Description = "Explicit consent" },
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 2, Description = "Employment and Social Security and Social Protection law" },
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 3, Description = "Vital interests of data subject" },
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 4, Description = "Public health" },
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 5, Description = "Made public by the data subject" },
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 6, Description = "Substantial public interest" },
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 7, Description = "Statistical/Research" },
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 8, Description = "Establishment, exercise or defence of legal claims" },
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 9, Description = "Legitimate activities" },
                new SpecialCategoryLawfulProcessingCondition() { SpecialCategoryLawfulProcessingConditionId = 10, Description = "Employee health and social care" });

            modelBuilder.Entity<ApplicableRight>().HasData(
                new ApplicableRight() { ApplicableRightId = 1, Description = "Right to be informed" },
                new ApplicableRight() { ApplicableRightId = 2, Description = "Right of access" },
                new ApplicableRight() { ApplicableRightId = 3, Description = "Right to Rectification" },
                new ApplicableRight() { ApplicableRightId = 4, Description = "Right to erasure" },
                new ApplicableRight() { ApplicableRightId = 5, Description = "Right to restrict processing" },
                new ApplicableRight() { ApplicableRightId = 6, Description = "Right to data portability" },
                new ApplicableRight() { ApplicableRightId = 7, Description = "Right to object" },
                new ApplicableRight() { ApplicableRightId = 8, Description = "Rights to automated decision making including profiling" });

            modelBuilder.Entity<OrganisationalSecurityMeasure>().HasData(
                new OrganisationalSecurityMeasure() { OrganisationalSecurityMeasureId = 1, Description = "Encrypted storage" },
                new OrganisationalSecurityMeasure() { OrganisationalSecurityMeasureId = 2, Description = "Encrypted transfer" },
                new OrganisationalSecurityMeasure() { OrganisationalSecurityMeasureId = 3, Description = "Access controls" },
                new OrganisationalSecurityMeasure() { OrganisationalSecurityMeasureId = 4, Description = "Documented processes in place for handling personal data" },
                new OrganisationalSecurityMeasure() { OrganisationalSecurityMeasureId = 5, Description = "Training" },
                new OrganisationalSecurityMeasure() { OrganisationalSecurityMeasureId = 6, Description = "Business continuity plan" });

            modelBuilder.Entity<Department>().HasData(new Department() { DepartmentId = 1, DataControllerName = "Department of Finance", DPOName = "Jenny Lynn", DepartmentAbbreviation = "DoF", DepartmentName = "Department of Finance" });
        }
    }
}

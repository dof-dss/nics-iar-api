using System;
using System.Collections.Generic;
using IAR.Core.Models.LookupLists;
using IAR.Core.Models.Admin;
using DSS.Architecture.Patterns.DotNet.Clean.Validation;

namespace IAR.Core.Models.InformationAssets
{
    public class AssetDetail : IValidate
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the asset.
        /// </summary>
        public int AssetId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing the name of the Data Controller for the Asset
        /// </summary>
        public string DataController { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains the name of the asset.
        /// </summary>
        public string AssetName { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the asset.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="User"/> which contains details of the IAO.
        /// </summary>
        public virtual User InformationAssetOwner { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains the name of a contact within the branch.
        /// </summary>
        public string LocalResponsiblePerson { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DateTime"/> containing the date the asset entry was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="AssetStatus"/> which contains details of the current asset status.
        /// </summary>
        public virtual AssetStatus AssetStatus { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="RetentionPeriod"/> which contains details of the current retention period.
        /// </summary>
        public virtual RetentionPeriod RetentionPeriod { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains details of the retention period when 'Other' selected
        /// as the retention period.
        /// </summary>
        public string RetentionPeriodOther { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="GovernmentSecurityClassification"/> containing details of the current
        /// government security classification.
        /// </summary>
        public virtual GovernmentSecurityClassification GovernmentSecurityClassification { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing details of who has access to the asset.
        /// </summary>
        public string AccessToAsset { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing details of risks to the asset (inlcuding link to risk register).
        /// </summary>
        public string RisksToAsset { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="AssetValue"/> containing details of the current value of the asset.
        /// </summary>
        public virtual AssetValue ValueOfAsset { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="int"/> which will contain the Business Impact Level for confidentiality.
        /// </summary>
        public int? BILConfidentiality { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="int"/> which will contain the Business Impact Level for integrity.
        /// </summary>
        public int? BILIntegrity { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="int"/> which will contain the Business Impact Level for availability.
        /// </summary>
        public int? BILAvailability { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing a link to the Business Impact assessment.
        /// </summary>
        public string LinkToBIAssessment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether there is a Data Sharing Agreement in place for the Asset.
        /// </summary>
        public bool DSAInPlace { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing a link to the data sharing agreement.
        /// </summary>
        public string LinkToDataSharingAgreement { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="DateTime"/> containing the date the data sharing agreement is to be reviewed.
        /// </summary>
        public DateTime? DSAReviewDate { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="LawfulProcessingCondition"/> containing Asset lawful processing conditions.
        /// </summary>
        public virtual ICollection<LawfulProcessingCondition> LawfulProcessingConditions { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains the location of the hardcopy
        /// </summary>
        public string HardcopyLocation { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains the file share location
        /// </summary>
        public string FileShareLocation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the information asset is held in a hardcopy location
        /// </summary>
        public bool AssetInHardCopy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the information asset is processed in an IT System
        /// </summary>
        public bool AssetInSystem { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing details on the system(s) the information asset is held in
        /// </summary>
        public string SystemDetails { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="PersonalDataSource"/> containing Asset locations where the asset is held.
        /// </summary>
        public virtual ICollection<PersonalDataSource> PersonalDataSources { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> indicating whether or not personal information is held.
        /// </summary>
        public bool? PersonalInformationHeld { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing details of the joint data controller.
        /// </summary>
        public string JointDataController { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing details for the reason / purpose for processing personal data.
        /// </summary>
        public string ReasonForProcessing { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains details about the types of people whose data is processed.
        /// </summary>
        public string CategoriesOfIndividuals { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains details of the types of information that is processed.
        /// </summary>
        public string CategoriesOfPersonalData { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains details of evidence for the lawful conditions for processing.
        /// </summary>
        public string EvidenceOfLC { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="PersonalDataSpecialCategory"/> containing the special types of
        /// information that is processed.
        /// </summary>
        public virtual ICollection<PersonalDataSpecialCategory> PersonalDataSpecialCategories { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="SpecialCategoryLawfulProcessingCondition"/> containing the lawful
        /// conditions for processing special categories.
        /// </summary>
        public virtual ICollection<SpecialCategoryLawfulProcessingCondition> SpecialCategoryLawfulProcessingConditions { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains details of evidence for the lawful conditions for processing special categories.
        /// </summary>
        public string EvidenceOfSCLC { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="ApplicableRight"/> containing details of the applicable rights of the individual
        /// whose personal data is being processed.
        /// </summary>
        public virtual ICollection<ApplicableRight> ApplicableRights { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains details of the categories of recipients.
        /// </summary>
        public string CategoriesOfRecipients { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> which indicates whether or not data is transferred to third countries.
        /// </summary>
        public bool? TransfersToThirdCountries { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing a link to the document in HPRM.
        /// </summary>
        public string LinkToDocumentation { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="OrganisationalSecurityMeasure"/> containing Asset locations where the asset is held.
        /// </summary>
        public virtual ICollection<OrganisationalSecurityMeasure> OrganisationalSecurityMeasures { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> which indicates whether or not a DPIA was carried out.
        /// </summary>
        public bool? DPIAPerformed { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing a link to the data protection impact assessment.
        /// </summary>
        public string LinkToDPIA { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> containing the windows login name of the user
        /// who created the asset.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="int"/> which will contain the unique department reference for the asset.
        /// </summary>
        public int DeptReference { get; set; }

        public ValidationResult Validate()
        {
            ValidationResult validation = new ValidationResult();
            // perform basic domain model validation logic

            if (string.IsNullOrWhiteSpace(AssetName))
            {
                validation.AddError("AssetName", "You must provide an Asset Name value for this Asset");
            }

            if (InformationAssetOwner == null)
            {
                validation.AddError("InformationAssetOwner", "You must specify an Information Asset Owner for this Asset");
            }

            return validation;
        }
    }
}

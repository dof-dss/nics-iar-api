using DSS.Architecture.Patterns.DotNet.Clean.Interactors;
using System;
using System.Collections.Generic;

namespace IAR.Business.SaveInformationAsset
{
    public interface IInformationAsset : IRequestMessage
    {
        int AssetId { get; set; }

        string AssetName { get; set; }

        string Description { get; set; }

        string DataController { get; set; }

        int? InformationAssetOwner { get; set; }

        string LocalResponsiblePerson { get; set; }

        int? AssetStatus { get; set; }

        int? RetentionPeriod { get; set; }

        string RetentionPeriodOther { get; set; }

        int? GovernmentSecurityClassification { get; set; }

        string AccessToAsset { get; set; }

        string RisksToAsset { get; set; }

        string ValueOfAsset { get; set; }

        int? BILConfidentiality { get; set; }

        int? BILIntegrity { get; set; }

        int? BILAvailability { get; set; }

        string LinkToBIAssessment { get; set; }

        bool DSAInPlace { get; set; }

        string LinkToDataSharingAgreement { get; set; }

        DateTime? DSAReviewDate { get; set; }

        string HardcopyLocation { get; set; }

        string FileShareLocation { get; set; }

        bool AssetInHardCopy { get; set; }

        bool AssetInSystem { get; set; }

        string SystemDetails { get; set; }

        bool? PersonalInformationHeld { get; set; }

        string JointDataController { get; set; }

        string ReasonForProcessing { get; set; }

        string CategoriesOfIndividuals { get; set; }

        string CategoriesOfPersonalData { get; set; }

        string EvidenceOfLC { get; set; }

        Dictionary<int, string> PersonalDataSources { get; set; }

        Dictionary<int, string> LawfulProcessingConditions { get; set; }

        Dictionary<int, string> PersonalDataSpecialCategories { get; set; }

        Dictionary<int, string> SpecialCategoryLawfulProcessingConditions { get; set; }

        Dictionary<int, string> ApplicableRights { get; set; }

        Dictionary<int, string> OrganisationalSecurityMeasures { get; set; }

        string EvidenceOfSCLC { get; set; }

        string CategoriesOfRecipients { get; set; }

        bool? TransfersToThirdCountries { get; set; }

        string LinkToDocumentation { get; set; }

        bool? DPIAPerformed { get; set; }

        string LinkToDPIA { get; set; }

        int CreatedByUserId { get; set; }
    }
}

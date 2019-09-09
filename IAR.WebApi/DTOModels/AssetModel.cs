using IAR.Business.SaveInformationAsset;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IAR.WebApi.DTOModels
{
    public class AssetModel : IInformationAsset
    {        
        public int AssetId { get; set; }
        
        public string DataController { get; set; }
        
        [Required(ErrorMessage = "You must provide a name for this Asset")]
        public string AssetName { get; set; }
        
        public string Description { get; set; }
        
        public string InformationAssetOwnerName { get; set; }
        
        public string LocalResponsiblePerson { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public string AssetStatusName { get; set; }
        
        public string RetentionPeriodName { get; set; }
        
        public string RetentionPeriodOther { get; set; }
        
        public string GovernmentSecurityClassificationName { get; set; }
                
        public string AccessToAsset { get; set; }
        
        public string RisksToAsset { get; set; }
        
        public string ValueOfAsset { get; set; }
        
        public int? BILConfidentiality { get; set; }
        
        public int? BILIntegrity { get; set; }
        
        public int? BILAvailability { get; set; }
        
        public string LinkToBIAssessment { get; set; }
        
        public bool DSAInPlace { get; set; }
        
        public string LinkToDataSharingAgreement { get; set; }
        
        public DateTime? DSAReviewDate { get; set; }
        
        public Dictionary<int, string> LawfulProcessingConditions { get; set; }
        
        public string HardcopyLocation { get; set; }
        
        public string FileShareLocation { get; set; }
        
        public bool AssetInHardCopy { get; set; }
        
        public bool AssetInSystem { get; set; }
        
        public string SystemDetails { get; set; }
        
        public Dictionary<int, string> PersonalDataSources { get; set; }
        
        public bool? PersonalInformationHeld { get; set; }
                
        public string JointDataController { get; set; }
        
        public string ReasonForProcessing { get; set; }
        
        public string CategoriesOfIndividuals { get; set; }
        
        public string CategoriesOfPersonalData { get; set; }
        
        public string EvidenceOfLC { get; set; }
        
        public Dictionary<int, string> PersonalDataSpecialCategories { get; set; }
        
        public Dictionary<int, string> SpecialCategoryLawfulProcessingConditions { get; set; }
        
        public string EvidenceOfSCLC { get; set; }
        
        public Dictionary<int, string> ApplicableRights { get; set; }
        
        public string CategoriesOfRecipients { get; set; }
        
        public bool? TransfersToThirdCountries { get; set; }
        
        public string LinkToDocumentation { get; set; }
        
        public Dictionary<int, string> OrganisationalSecurityMeasures { get; set; }
                
        public bool? DPIAPerformed { get; set; }
        
        public string LinkToDPIA { get; set; }
        
        public string CreatedBy { get; set; }
        
        public int DeptReference { get; set; }

        [Required(ErrorMessage = "You must specify the Information Asset Owner for this Asset")]
        public int? InformationAssetOwner { get; set; }

        public int CreatedByUserId { get; set; }

        public int? AssetStatus { get; set; }

        public int? RetentionPeriod { get; set; }

        public int? GovernmentSecurityClassification { get; set; }
    }
}

using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using DSS.Architecture.Patterns.DotNet.Clean.Interactors;
using DSS.Architecture.Patterns.DotNet.Clean.Validation;
using IAR.Domain.Admin;
using IAR.Domain.InformationAssets;
using IAR.Domain.LookupLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR.Business.SaveInformationAsset
{
    public class SaveInformationAssetUsecase : IRequestHandlerAsync<IInformationAsset, SaveInformationAssetResponse>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public SaveInformationAssetUsecase(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveInformationAssetResponse> Handle(IInformationAsset message)
        {
            // Build the Domain.Asset model based on the data supplied
            var newModel = BuildAssetModel(message);

            // Validate the new Asset conforms to the Domain rules
            var validationResult = newModel.Validate();

            // Prep response
            var response = new SaveInformationAssetResponse
            {
                ValidationResult = validationResult
            };

            // If the model is valid then attempt to save it
            if (validationResult.IsValid)
            {
                try
                {
                    var repo = _unitOfWork.GetRepository<Asset>();

                    if (message.AssetId > 0)
                    {
                        await repo.Edit(newModel);
                    }
                    else
                    {
                        await repo.Create(newModel);
                    }
                   
                    await _unitOfWork.Save();

                    response.Asset = newModel;
                }
                catch (Exception ex)
                {
                    // Failed to save the asset so copy error to response so clients can see what has gone wrong.
                    response.InnerException = ex;
                    response.ResponseType = ResponseTypes.Failure;
                    response.OutputMessage = "Failed to save the asset. See exception for details.";                    
                }
            }

            return response;
        }

        private Asset BuildAssetModel(IInformationAsset message)
        {
            Asset newAsset = new Asset
            {
                DateCreated = DateTime.Today
            };

            MapProperties(newAsset, message);
            MapToType<AssetStatus>(message.AssetStatus, newAsset, "AssetStatus");
            MapToType<RetentionPeriod>(message.RetentionPeriod, newAsset, "RetentionPeriod");
            MapToType<AssetValue>(message.RetentionPeriod, newAsset, "RetentionPeriod");
            MapToType<GovernmentSecurityClassification>(message.GovernmentSecurityClassification, newAsset, "GovernmentSecurityClassification");
            MapToType<User>(message.InformationAssetOwner, newAsset, "InformationAssetOwner");
            MapApplicableRights(newAsset, message);
            MapLawfulProcessingConditions(newAsset, message);
            MapOrganisationalSecurityMeasures(newAsset, message);
            MapPersonalDataSources(newAsset, message);
            MapSpecialCategoriesOfLawfulProcessingConditions(newAsset, message);
            MapPersonalDataSpecialCategories(newAsset, message);
            MapCreatedBy(newAsset, message);

            return newAsset;
        }

        private void MapProperties(Asset newAsset, IInformationAsset message)
        {
            var props = newAsset.GetType().GetProperties();
            var requestProperties = message.GetType().GetProperties();

            // map the basic properties
            foreach (var prop in requestProperties)
            {
                try
                {
                    var property = newAsset.GetType().GetProperty(prop.Name);
                    if (property != null)
                    {
                        property.SetValue(newAsset, prop.GetValue(message));
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        private async void MapToType<TEntity>(int? id, Asset newAsset, string propertyName)
            where TEntity : class
        {
            if (id.HasValue)
            {
                var itemsRepo = _unitOfWork.GetRepository<TEntity>();
                var item = await itemsRepo.Get(id.Value);
                newAsset.GetType().GetProperty(propertyName).SetValue(item ?? null, newAsset);
            }
        }

        private async void MapPersonalDataSpecialCategories(Asset newAsset, IInformationAsset message)
        {
            if (message.PersonalDataSpecialCategories != null && message.PersonalDataSpecialCategories.Count > 0)
            {
                var repo = _unitOfWork.GetRepository<PersonalDataSpecialCategory>();
                var allData = await repo.GetAll();
                
                var selected = allData.Where(item => message.PersonalDataSpecialCategories.Any(x => x.Key == item.PersonalDataSpecialCategoryId));
                newAsset.PersonalDataSpecialCategories = new List<AssetPersonalDataSpecialCategory>();

                foreach (var item in selected)
                {
                    newAsset.AddPersonalDataSpecialCategory(item);
                }
            }
        }

        private async void MapSpecialCategoriesOfLawfulProcessingConditions(Asset newAsset, IInformationAsset message)
        {
            if (message.SpecialCategoryLawfulProcessingConditions != null && message.SpecialCategoryLawfulProcessingConditions.Count > 0)
            {
                var repo = _unitOfWork.GetRepository<SpecialCategoryLawfulProcessingCondition>();
                var allData = await repo.GetAll();

                var selected = allData.Where(item => message.SpecialCategoryLawfulProcessingConditions.Any(x => x.Key == item.SpecialCategoryLawfulProcessingConditionId));
                newAsset.SpecialCategoryLawfulProcessingConditions = new List<AssetSpecialCategoryLawfulProcessingCondition>();

                foreach (var item in selected)
                {
                    newAsset.AddSpecialCategoryLawfulProcessingCondition(item);
                }
            }
        }

        private async void MapPersonalDataSources(Asset newAsset, IInformationAsset message)
        {
            if (message.PersonalDataSources != null && message.PersonalDataSources.Count > 0)
            {
                var repo = _unitOfWork.GetRepository<PersonalDataSource>();
                var allData = await repo.GetAll();


                var selected = allData.Where(item => message.PersonalDataSources.Any(x => x.Key == item.PersonalDataSourceId));
                newAsset.PersonalDataSources = new List<AssetPersonalDataSource>();

                foreach (var item in selected)
                {
                    newAsset.AddPersonalDataSource(item);
                }
            }
        }

        private async void MapOrganisationalSecurityMeasures(Asset newAsset, IInformationAsset message)
        {
            if (message.OrganisationalSecurityMeasures != null && message.OrganisationalSecurityMeasures.Count > 0)
            {
                var repo = _unitOfWork.GetRepository<OrganisationalSecurityMeasure>();
                var allData = await repo.GetAll();

                var selected = allData.Where(item => message.OrganisationalSecurityMeasures.Any(x => x.Key == item.OrganisationalSecurityMeasureId));
                newAsset.OrganisationalSecurityMeasures = new List<AssetOrganisationalSecurityMeasure>();

                foreach (var item in selected)
                {
                    newAsset.AddOrganisationalSecurityMeasure(item);
                }
            }
        }

        private async void MapLawfulProcessingConditions(Asset newAsset, IInformationAsset message)
        {
            if (message.LawfulProcessingConditions != null && message.LawfulProcessingConditions.Count > 0)
            {
                var repo = _unitOfWork.GetRepository<LawfulProcessingCondition>();
                var allData = await repo.GetAll();

                var selected = allData.Where(item => message.LawfulProcessingConditions.Any(x => x.Key == item.LawfulProcessingConditionId));
                newAsset.LawfulProcessingConditions = new List<AssetLawfulProcessingCondition>();

                foreach (var item in selected)
                {
                    newAsset.AddLawfulProcessingCondition(item);
                }
            }
        }

        private async void MapApplicableRights(Asset newAsset, IInformationAsset message)
        {
            if (message.ApplicableRights != null && message.ApplicableRights.Count > 0)
            {
                var appRightsRepo = _unitOfWork.GetRepository<ApplicableRight>();
                var allRights = await appRightsRepo.GetAll();


                var selected = allRights.Where(item => message.ApplicableRights.Any(x => x.Key == item.ApplicableRightId));
                newAsset.ApplicableRights = new List<AssetApplicableRight>();

                foreach (var item in selected)
                {
                    newAsset.AddApplicableRight(item);
                }
            }
        }

        private async void MapCreatedBy(Asset newAsset, IInformationAsset message)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = await userRepo.Get(message.CreatedByUserId);
            newAsset.CreatedBy = user == null ? string.Empty : user.DisplayName;
        }
    }

    public class SaveInformationAssetResponse : IResponseMessage
    {
        public SaveInformationAssetResponse(Asset asset)
        {
            Asset = asset;
        }

        public SaveInformationAssetResponse()
        {

        }

        public Asset Asset { get; set; }

        public Exception InnerException { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public ResponseTypes ResponseType { get; set; }

        public string OutputMessage { get; set; }
    }
}

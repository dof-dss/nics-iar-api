using DSS.Architecture.Patterns.DotNet.Clean.Presenters;
using IAR.Domain.InformationAssets;
using IAR.WebApi.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAR.WebApi.Presenters
{
    public class AssetPresenter : IPresenter<Asset, AssetModel>
    {
        /// <inheritdoc/>
        public AssetModel Build(Asset source)
        {
            var vm = new AssetModel
            {
                AssetName = source.AssetName,
                Description = source.Description,
                AccessToAsset = source.AccessToAsset,
                AssetId = source.AssetId,
                AssetInHardCopy = source.AssetInHardCopy,
                AssetInSystem = source.AssetInSystem,
                AssetStatusName = source.AssetStatus != null ? source.AssetStatus.Description : string.Empty,
                RetentionPeriodName = source.RetentionPeriod != null ? source.RetentionPeriod.Description : string.Empty
            };

            return vm;
        }
    }
}

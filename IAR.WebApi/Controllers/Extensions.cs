using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using IAR.Business.GetLookupList;
using IAR.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAR.WebApi.Controllers
{
    public static class Extensions
    {
        public static async Task<List<TOutput>> GetLookupList<TInput, TOutput>(this Controller controller, IUnitOfWorkAsync unitOfWork, List<PropertyMapping> mappings)
            where TInput : class
            where TOutput : class
        {
            return await BuildLookupList(controller, unitOfWork, new LookupListItemPresenter<TInput, TOutput>(mappings));
        }

        private static async Task<List<TOutput>> BuildLookupList<TInput, TOutput>(Controller controller, IUnitOfWorkAsync unitOfWork, LookupListItemPresenter<TInput, TOutput> presenter)
            where TInput : class
            where TOutput : class
        {
            GetLookupListUsecase<TInput> usecase = new GetLookupListUsecase<TInput>(unitOfWork);
            var response = await usecase.Handle();
            List<TOutput> data = new List<TOutput>();

            switch (response.ResponseType)
            {
                case DSS.Architecture.Patterns.DotNet.Clean.Interactors.ResponseTypes.Success:
                    // The usecase executed successfully, meaning it connected to the datastore, however, need to check if data was found...
                    if (response.Data == null || response.Data.Count() == 0)
                    {                          
                        return null;
                    }                             
                    foreach (var item in response.Data)
                    {
                        data.Add(presenter.Build(item));
                    }                  
                    return data;
                default:                
                    return data;
            }
        }

        public static async Task<List<TOutput>> GetLookupList<TInput, TOutput>(this Controller controller, IUnitOfWorkAsync unitOfWork, string keyMapping, string valueMapping)
            where TInput : class
            where TOutput : class
        {
            return await BuildLookupList(controller, unitOfWork, new LookupListItemPresenter<TInput, TOutput>(keyMapping, valueMapping));
        }
    }
}

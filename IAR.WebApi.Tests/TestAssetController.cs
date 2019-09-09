using IAR.WebApi.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using IAR.Infrastructure.Repositories;
using IAR.Infrastructure;
using IAR.WebApi.Controllers.v1;

namespace IAR.WebApi.Tests
{
    public class TestAssetController
    {
        private readonly AssetsController controller;

        public TestAssetController()
        {
            //controller = new AssetsController(new MockUnitOfWorkAsync("AssetId"));
        }

        [Fact]
        public async void GetById_ReturnsHttpNotFound_WhenNoRecordFound()
        {
            //var response = await controller.Get(10);
            //Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async void GetById_ReturnsBadRequest_IdLessThanOrEqualToZero()
        {
            //var response = await controller.Get(-10);
            //Assert.IsType<BadRequestResult>(response.Result);
        }
    }
}

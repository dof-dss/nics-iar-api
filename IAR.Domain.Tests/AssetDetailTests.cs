using DSS.Architecture.Patterns.DotNet.Clean.Validation;
using IAR.Domain.Admin;
using IAR.Domain.InformationAssets;
using System;
using Xunit;

namespace IAR.Domain.Tests
{
    public class AssetDetailTests
    {
        [Fact]
        public void Asset_Should_Be_Invalid_If_No_Asset_Name()
        {
            // Arrange
            var asset = new Asset();

            // Act
            var validate = asset.Validate();

            // Assert
            Assert.False(validate.IsValid);
        }

        [Fact]
        public void Asset_Should_Be_Invalid_If_No_Information_Asset_Owner()
        {
            // Arrange
            var asset = new Asset { AssetName = "Test Asset Name" };

            // Act
            var validate = asset.Validate();

            // Assert
            Assert.False(validate.IsValid);
        }

        [Fact]
        public void Asset_Should_Be_Valid_If_It_Has_An_Asset_Name_And_Information_Asset_Owner()
        {
            // Arrange
            var asset = new Asset { AssetName = "Test Asset", InformationAssetOwner = new User() };

            // Act
            var validate = asset.Validate();

            // Assert
            Assert.True(validate.IsValid);
        }
    }
}

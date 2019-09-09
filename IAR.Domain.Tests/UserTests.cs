using IAR.Domain.Admin;
using IAR.Domain.LookupLists;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IAR.Domain.Tests
{
    public class UserTests
    {
        [Fact]
        public void Users_Should_Be_Invalid_If_No_Windows_Login_Name_Provided()
        {
            var user = new User
            {
                DisplayName = "Test",
                BusinessArea = new BusinessArea()
            };

            var valid = user.Validate();

            Assert.False(valid.IsValid);
        }

        [Fact]
        public void Users_Should_Be_Invalid_If_No_Display_Name_Provided()
        {
            var user = new User
            {
                WindowsLoginName = "Test",
                BusinessArea = new BusinessArea()
            };

            var valid = user.Validate();

            Assert.False(valid.IsValid);
        }

        [Fact]
        public void Users_Should_Be_Invalid_If_No_Business_Area_Provided()
        {
            var user = new User
            {
                DisplayName = "Test",
                WindowsLoginName = "Test",
                BusinessArea = null
            };

            var valid = user.Validate();

            Assert.False(valid.IsValid);
        }

        [Fact]
        public void Users_Should_Be_Valid_If_WindowsLoginName_DisplayName_And_BusinessArea_Provided()
        {
            var user = new User
            {
                DisplayName = "Test",
                WindowsLoginName = "Test",
                BusinessArea = new BusinessArea()
            };

            var valid = user.Validate();

            Assert.True(valid.IsValid);
        }

        [Fact]
        public void Users_Cannot_Be_Linked_If_They_Are_Not_An_IAO()
        {
            var primaryUser = new User
            {
                DisplayName = "Test",
                WindowsLoginName = "Test",
                BusinessArea = new BusinessArea()
            };

            var linkedUser = new User
            {
                DisplayName = "Test",
                WindowsLoginName = "Test",
                BusinessArea = new BusinessArea(),
                IsIAO = false
            };

            primaryUser.LinkedUsers = new List<UserLinkedUser>();

            Assert.Throws<Exception>(() => { primaryUser.AddLinkedUser(linkedUser); });
        }

        public void Users_Cannot_Be_Added_Twice()
        {
            var primaryUser = new User
            {
                DisplayName = "Test",
                WindowsLoginName = "Test",
                BusinessArea = new BusinessArea()
            };

            var linkedUser = new User
            {
                DisplayName = "Test",
                WindowsLoginName = "Test",
                BusinessArea = new BusinessArea(),
                UserId = 1,
                IsIAO = true
            };
            primaryUser.AddLinkedUser(linkedUser);

            var linkedUser2 = new User
            {
                DisplayName = "Test",
                WindowsLoginName = "Test",
                BusinessArea = new BusinessArea(),                
                UserId = 1,
                IsIAO = true
            };

            primaryUser.AddLinkedUser(linkedUser2);

            primaryUser.LinkedUsers = new List<UserLinkedUser>();

            var linkedUserCount = primaryUser.LinkedUsers.Count;
            Assert.True(linkedUserCount == 1);
        }
    }
}

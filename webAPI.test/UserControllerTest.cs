using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

using newWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.test
{
    public class UserControllerTest
    {
        [Fact]
        public void UserGet()
        {
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController = new UserController(apiContext);

            var result = userController.Get();

            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public void UserGetByIdBadRequest()
        {
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController = new UserController(apiContext);

            var result = userController.GetById("");

            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void UserGetById()
        {
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController = new UserController(apiContext);
            var firstId = userController.Get().Value?.ToList()[0].UserId;

            var result = userController.GetById(firstId.ToString());

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
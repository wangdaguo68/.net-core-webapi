using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using WebApiCore.Controllers;
using WebApiCore.Domain.Interface;
using Xunit;

namespace WebApiCore.xUnit
{
    public class UserTest
    {
        Mock<IUserRepository> mockRepo = new Mock<IUserRepository>();
        UserController controller;
        public UserTest()
        {
            mockRepo.Setup(repo => repo.Find()).Returns(GetTestUsers());
            controller = new UserController(mockRepo.Object);
        }
        [Fact]
        public void GetTest()
        {
            var result = controller.Get();
            // Assert
            var viewResult = Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public void InsertTest()
        {
            var user = new User
            {
                ID = Guid.NewGuid(),
                age = 35,
                name = "Alex_Mahone"
            };
            controller.Post(user);
            var users = controller.Get();
        }
        private List<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    ID = Guid.NewGuid(),
                    age = 1,
                    name = "Scofield"
                }
            };
            return users;
        }
    }
}

﻿using API.Controllers;
using Core.Entities;
using Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockData;
using Xunit;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Api
{
    public class UserControllerAPITest
    {
        MoqData _moqdata;
        public UserControllerAPITest()
        {
            _moqdata = new MoqData();
        }
        [Fact]
        public void AddCourseTest()
        {
            //Arrange
            var moq = new Mock<IUserService>();
            UserController apiController = new UserController(moq.Object,null);
            Course course = new Course()
            {
                Id = 4,
                Description = "cccc",
                Name = "course 23",
                Code = "cskd"
            };
            //Act
            var result = apiController.SubscribeCourse(Guid.Empty,course);
            //Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }


        [Theory]
        [InlineData(1, -1)]
        public void DeleteCourse_Test(int ValidId, int inValidId)
        {
            //Arrange
            var moq = new Mock<IUserService>();

            moq.Setup(p => p.RemoveSubscribedCourse(Guid.Empty,ValidId));
            moq.Setup(p => p.GetAllCourses(Guid.Empty))
                .Returns(_moqdata.GetAllUser().Find(x=>x.Id==Guid.Empty).courses);

            UserController apiController = new UserController(moq.Object,null);

            //Act
            var result = apiController.DeleteCourse(Guid.Empty,ValidId);
            var invalidResult = apiController.DeleteCourse(Guid.Empty,inValidId);
            //Assert

            Assert.IsType<OkObjectResult>(result);

            Assert.IsType<NotFoundResult>(invalidResult);
        }


        [Fact]
        public void Test_Behavior_SendMessageWithEmail()
        {

            var moq = new Mock<IMessage>();
            var moqProduct = new Mock<IUserService>();

            UserController controller = new UserController(moqProduct.Object, moq.Object);

            controller.SendMessage("Hi", 1, Messagetype.Email);

            //moq.Verify(p => p.Sms(It.IsAny<string>(), It.IsAny<int>()),"fail in sending message");
            moq.Verify(p => p.Email(It.IsAny<string>(), It.IsAny<int>()));

        }




    }
}

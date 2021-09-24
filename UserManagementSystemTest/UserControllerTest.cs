using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystemApi.Controllers;
using UserManagementSystemApi.Models.Dto;
using UserManagementSystemApi.Services;

namespace UserManagementSystemTest
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public async Task HttpGetTest()
        {
            Mock<IUserServices> mockGet = new Mock<IUserServices>();

            List<UserReadDto> userList = new List<UserReadDto>();

            UserReadDto giftCard = new UserReadDto()
            {
                UserId = 1,
                UserFirstName = "Joe",
                UserLastName = "Smith",
                UserAddress = "XYZ",
                UserContactNumber = "9876543211"
            };

            userList.Add(giftCard);

            mockGet.Setup(p => p.GetAll()).ReturnsAsync(userList);

            UsersController controller = new UsersController(mockGet.Object);

            List<UserReadDto> output = (await controller.GetAll()).ToList();

            Console.WriteLine(output[0].UserFirstName);
            Console.WriteLine(userList[0].UserFirstName);

            Assert.IsTrue(Helper.CheckList(output, userList));
        }

        [TestMethod]
        public async Task HttpPassPostTest()
        {
            Mock<IUserServices> mockPost = new Mock<IUserServices>();

            UserCreateDto user = new UserCreateDto()
            {
                UserFirstName = "Joe",
                UserLastName = "Smith",
                UserAddress = "XYZ",
                UserContactNumber = "9876543211"
            };

            UserReadDto userReadDto = new UserReadDto()
            {
                UserId = 1,
                UserFirstName = "Joe",
                UserLastName = "Smith",
                UserAddress = "XYZ",
                UserContactNumber = "9876543211"
            };

            string passOutput = "User added successfully";

            mockPost.Setup(p => p.Create(user)).ReturnsAsync(userReadDto);

            UsersController controller = new UsersController(mockPost.Object);

            string output = (await controller.Create(user)).ToString();

            Assert.AreEqual(passOutput, output);
        }

        [TestMethod]
        public async Task HttpFailPostTest()
        {
            Mock<IUserServices> mockPost = new Mock<IUserServices>();

            UserCreateDto user = new UserCreateDto();
            UserReadDto failUserRead = null;

            mockPost.Setup(p => p.Create(user)).ReturnsAsync(failUserRead);

            UsersController controller = new UsersController(mockPost.Object);

            string output = (await controller.Create(user)).ToString();
            string failOutput = "User addition unsuccessfull";

            Assert.AreEqual(failOutput, output);
        }
    }
}

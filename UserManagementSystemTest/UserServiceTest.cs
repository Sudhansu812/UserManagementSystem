using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystemApi.CustomExceptions;
using UserManagementSystemApi.Models;
using UserManagementSystemApi.Models.Dto;
using UserManagementSystemApi.Models.Profiles;
using UserManagementSystemApi.Repository;
using UserManagementSystemApi.Services;

namespace UserManagementSystemTest
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public async Task CreateTest()
        {
            Mock<IUserRepo> mockRepo = new Mock<IUserRepo>();

            UserProfiles myProfile = new UserProfiles();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            UserModel user = new UserModel()
            {
                UserId = 1,
                UserFirstName = "Joe",
                UserLastName = "Smith",
                UserAddress = "XYZ",
                UserContactNumber = "9876543211"
            };

            UserCreateDto userCreateDto = new UserCreateDto()
            {
                UserFirstName = "Joe",
                UserLastName = "Smith",
                UserAddress = "XYZ",
                UserContactNumber = "9876543211"
            };

            UserReadDto userReadDto = new UserReadDto()
            {
                UserId = 0,
                UserFirstName = "Joe",
                UserLastName = "Smith",
                UserAddress = "XYZ",
                UserContactNumber = "9876543211"
            };

            mockRepo.Setup(p => p.Create(user));
            mockRepo.Setup(p => p.SaveChanges()).ReturnsAsync(true);

            IUserServices services = new UserServices(mockRepo.Object, mapper);

            UserReadDto output = await services.Create(userCreateDto);

            Assert.IsTrue(Helper.CheckObject(output, userReadDto));
        }

        [TestMethod]
        public async Task GetAllPassTest()
        {
            Mock<IUserRepo> mockRepo = new Mock<IUserRepo>();

            UserProfiles myProfile = new UserProfiles();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            List<UserReadDto> userReadDtos = new List<UserReadDto>();

            UserReadDto userReadDto = new UserReadDto()
            {
                UserId = 1,
                UserFirstName = "Joe",
                UserLastName = "Smith",
                UserAddress = "XYZ",
                UserContactNumber = "9876543211"
            };

            UserModel user = new UserModel()
            {
                UserId = 1,
                UserFirstName = "Joe",
                UserLastName = "Smith",
                UserAddress = "XYZ",
                UserContactNumber = "9876543211"
            };

            List<UserModel> userList = new List<UserModel>();

            userReadDtos.Add(userReadDto);
            userList.Add(user);

            mockRepo.Setup(p => p.GetAll()).ReturnsAsync(userList);

            IUserServices services = new UserServices(mockRepo.Object, mapper);

            List<UserReadDto> output = (await services.GetAll()).ToList();

            Assert.IsTrue(Helper.CheckList(output, userReadDtos));
        }

        [TestMethod]
        public async Task GetAllFailTest()
        {
            Mock<IUserRepo> mockRepo = new Mock<IUserRepo>();

            UserProfiles myProfile = new UserProfiles();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            List<UserModel> giftCardList = new List<UserModel>();

            //mockRepo.Setup(p => p.GetAll()).ThrowsAsync(new NoDataAvailableException("No Data in the Database"));
            mockRepo.Setup(p => p.GetAll()).ReturnsAsync(giftCardList);

            IUserServices services = new UserServices(mockRepo.Object, mapper);

            await Assert.ThrowsExceptionAsync<NoDataAvailableException>(() => services.GetAll());
        }
    }
}

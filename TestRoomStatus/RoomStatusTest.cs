using Elite.AppDbContext;
using Elite.Controllers;
using Elite.DataAccess.Core;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTest
{
    public class RoomStatusTest
    {
        private readonly RoomStatusController _roomStatusController;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

        public RoomStatusTest()
        {
            _roomStatusController = new RoomStatusController(_unitOfWorkMock.Object);
        }

        [Fact]
        public void Test_Index()
        {
            //Arrenge

            var roomStatusList = new List<RoomStatus>
            {
                new RoomStatus
                {
                    Id = 1,
                    Name = "Available",
                },
                new RoomStatus
                {
                    Id = 1,
                    Name = "Pending",
                },
                new RoomStatus
                {
                    Id = 1,
                    Name = "Repaired",
                },
            };

            _unitOfWorkMock.Setup(u => u.RoomStatus.GetAll(null)).Returns(roomStatusList.AsQueryable);

            //Act && Assert

            var resultView = Assert.IsAssignableFrom<ViewResult>(_roomStatusController.Index());
            var dataView = resultView.ViewData.Model;

            //Assert.True(roomStatusEnumerable.Equals(dataView));
            Assert.True("Index" == resultView.ViewName);
        }

        [Fact]
        public void Test_Detail_Existing_Object()
        {
            //Arrange
            var roomStatus = new RoomStatus
            {
                Id = 1,
                Name = "Available",
            };

            _unitOfWorkMock.Setup(u => u.RoomStatus.GetById(1)).Returns(roomStatus);

            //Act
            var resultView = Assert.IsAssignableFrom<ViewResult>(_roomStatusController.Detail(1));
            var returnedObject = Assert.IsAssignableFrom<RoomStatus>(resultView.ViewData.Model);
            Assert.True(returnedObject.Equals(roomStatus));
            Assert.True("Detail" == resultView.ViewName);
        }

        [Fact]
        public void Test_Detail_Not_Existing_Object()
        {
            //Arrange
            RoomStatus roomStatus = null;

            _unitOfWorkMock.Setup(u => u.RoomStatus.GetById(1)).Returns(roomStatus);

            //Act && Assert
            var resultView = Assert.IsAssignableFrom<RedirectToActionResult>(_roomStatusController.Detail(1));

            Assert.True("Index" == resultView.ActionName);
        }

        [Fact]
        public void Test_Delete_Object()
        {
            //Arrange
            var roomStatus = new RoomStatus
            {
                Id = 1,
                Name = "Available",
            };

            _unitOfWorkMock.Setup(u => u.RoomStatus.Any(r => r.Id == 1)).Returns(true);
            _unitOfWorkMock.Setup(u => u.RoomStatus.GetById(1)).Returns(roomStatus);

            //Act && Assert
            var resultView = Assert.IsAssignableFrom<RedirectToActionResult>(_roomStatusController.Delete(1));

            Assert.True("Index" == resultView.ActionName);
        }

        [Fact]
        public void Test_Delete_NotExist_Object()
        {
            //Arrange
            var roomStatus = new RoomStatus
            {
                Id = 1,
                Name = "Available",
            };

            _unitOfWorkMock.Setup(u => u.RoomStatus.Any(r => r.Id == 1)).Returns(false);
            _unitOfWorkMock.Setup(u => u.RoomStatus.GetById(1)).Returns(roomStatus);

            //Act && Assert
            var resultView = Assert.IsAssignableFrom<RedirectToActionResult>(_roomStatusController.Delete(1));

            Assert.True("Index" == resultView.ActionName);
        }
    }
}
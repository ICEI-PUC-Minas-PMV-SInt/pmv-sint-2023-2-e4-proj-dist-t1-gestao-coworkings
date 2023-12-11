using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ItCollabora.Controllers;
using ItCollabora.Models;
using ItCollabora.Repository.Interfaces;

namespace ItCollabora.Tests
{
    [TestClass]
    public class RoomControllerTests
    {
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly RoomController _roomController;

        public RoomControllerTests()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            _roomController = new RoomController(_mockRoomRepository.Object);
        }

        [TestMethod]
        public async Task GetAll_ReturnsOkResult()
        {
            var rooms = new List<RoomModel> {};
            _mockRoomRepository.Setup(repo => repo.GetAll()).ReturnsAsync(rooms);

            var result = await _roomController.GetAll();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetOne_WithValidId_ReturnsOkResult()
        {
            var roomId = Guid.NewGuid();
            var room = new RoomModel { RoomId = roomId };
            _mockRoomRepository.Setup(repo => repo.GetOne(roomId)).ReturnsAsync(room);

            var result = await _roomController.GetOne(roomId);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetOne_WithInvalidId_ReturnsNotFoundResult()
        {

            var roomId = Guid.NewGuid();
            _mockRoomRepository.Setup(repo => repo.GetOne(roomId)).ReturnsAsync((RoomModel)null);

    
            var result = await _roomController.GetOne(roomId);

     
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task CreateRoom_ReturnsOkResult()
        {
            
            var roomToCreate = new RoomModel {};
            _mockRoomRepository.Setup(repo => repo.CreateOne(It.IsAny<RoomModel>())).ReturnsAsync(roomToCreate);

           
            var result = await _roomController.CreateRoom(roomToCreate);

         
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateRoom_WithValidId_ReturnsOkResult()
        {
            
            var roomId = Guid.NewGuid();
            var updatedRoom = new RoomModel { RoomId = roomId };
            _mockRoomRepository.Setup(repo => repo.Modify(It.IsAny<RoomModel>(), roomId)).ReturnsAsync(updatedRoom);

          
            var result = await _roomController.UpdateRoom(roomId, updatedRoom);

            
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateRoom_WithInvalidId_ReturnsNotFoundResult()
        {
        
            var roomId = Guid.NewGuid();
            var updatedRoom = new RoomModel { RoomId = roomId };
            _mockRoomRepository.Setup(repo => repo.Modify(It.IsAny<RoomModel>(), roomId)).ThrowsAsync(new Exception($"Sala com o Id {roomId} não foi encontrado"));

       
            var result = await _roomController.UpdateRoom(roomId, updatedRoom);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task DeleteRoom_WithValidId_ReturnsNoContentResult()
        {
            
            var roomId = Guid.NewGuid();
            var existingRoom = new RoomModel { RoomId = roomId };
            _mockRoomRepository.Setup(repo => repo.GetOne(roomId)).ReturnsAsync(existingRoom);

         
            var result = await _roomController.DeleteRoom(roomId);

           
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteRoom_WithInvalidId_ReturnsNotFoundResult()
        {
            var roomId = Guid.NewGuid();
            _mockRoomRepository.Setup(repo => repo.GetOne(roomId)).ReturnsAsync((RoomModel)null);

            
            var result = await _roomController.DeleteRoom(roomId);

           
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
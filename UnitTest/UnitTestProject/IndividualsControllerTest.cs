using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JediAcademy.Back.Api.Controllers;
using JediAcademy.Back.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MediatR;
using System.Threading;
using JediAcademy.Back.Domain.Entities;

namespace UnitTestProject
{
    public class IndividualsControllerTest
    {
        [Fact]
        public async void GetStudents_ReturnsOkResult()
        {
            //Setup
            var sampleJediStudent = new JediStudent();
            sampleJediStudent.Id = 1;
            sampleJediStudent.Name = "Luke Skywalker";
            sampleJediStudent.Height = "172";
            sampleJediStudent.Mass = "77";
            sampleJediStudent.Species = "0";
            sampleJediStudent.Planet = "0";
            var jediStudents = new List<JediStudent>();
            jediStudents.Add(sampleJediStudent);

            var mediator = new Mock<IMediator>();
            mediator.Setup(x => x.Send(It.IsAny<GetStudents.Query>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => (true, jediStudents, null));

            // Initiate
            var controller = new IndividualsController(mediator.Object);

            // Result
            var resultObj = await controller.Get(); 
            var okResult = resultObj as OkObjectResult;

            // Test
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(jediStudents, okResult.Value);
        }

        [Fact]
        public async void GetStudents_ReturnsNotFoundResult()
        {
            // Setup
            var jediStudents = new List<JediStudent>();

            var mediator = new Mock<IMediator>();
            mediator.Setup(x => x.Send(It.IsAny<GetStudents.Query>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => (false, jediStudents, "No Jedi Students found"));

            // Initiate
            var controller = new IndividualsController(mediator.Object);

            // Result
            var resultObj = await controller.Get();
            var notFoundResult = resultObj as NotFoundObjectResult;

            // Test
            Assert.NotNull(notFoundResult);
            Assert.Equal(404, notFoundResult.StatusCode);
            Assert.Equal("No Jedi Students found", notFoundResult.Value);
        }

        [Fact]
        public async void AddStudent_ReturnsOkResult()
        {
            //Setup
            var sampleJediStudent = new JediStudent();
            sampleJediStudent.Id = 1;
            sampleJediStudent.Name = "Luke Skywalker";
            sampleJediStudent.Height = "172";
            sampleJediStudent.Mass = "77";
            sampleJediStudent.Species = "0";
            sampleJediStudent.Planet = "0";

            var mediator = new Mock<IMediator>();
            mediator.Setup(x => x.Send(It.IsAny<AddStudent.CreateRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => (true, sampleJediStudent, null));

            // Initiate
            var controller = new IndividualsController(mediator.Object);
            var request = new AddStudent.CreateRequest();

            // Result
            var resultObj = await controller.CreateStudent(request);
            var okResult = resultObj.Result as OkObjectResult;

            // Test
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sampleJediStudent, okResult.Value);
        }

        [Fact]
        public async void AddStudent_ReturnsErrorResult()
        {
            // Setup
            var mediator = new Mock<IMediator>();
            mediator.Setup(x => x.Send(It.IsAny<AddStudent.CreateRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => (false, null, "Database error"));

            // Initiate
            var controller = new IndividualsController(mediator.Object);
            var request = new AddStudent.CreateRequest();

            // Result
            var resultObj = await controller.CreateStudent(request);
            var errorResult = resultObj.Result as ObjectResult;

            // Test
            Assert.NotNull(errorResult);
            Assert.Equal(500, errorResult.StatusCode);
            Assert.Equal("Database error", errorResult.Value);
        }
    }
}

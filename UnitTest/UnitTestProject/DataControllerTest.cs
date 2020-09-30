using StarWars.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace UnitTestProject
{
    public class DataControllerTest
    {
        DataController _controller;

        public DataControllerTest()
        {
            _controller = new DataController();
        }

        [Fact]
        public void GetSpecies_ReturnsOkResult()
        {
            var result = _controller.GetSpecies();
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void GetPlanets_ReturnsOkResult()
        {
            var result = _controller.GetPlanets();
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}

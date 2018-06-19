using HockeyPoolWebApi.API;
using HockeyPoolWebApi.Controllers;
using Xunit;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HockeyPoolWebApi.Tests
{
    public class PlayoffControllerTest
    {
        private PlayoffController _playoffController;

        Mock<INHLApiClient> _api;

        public PlayoffControllerTest()
        {
            _api = new Mock<INHLApiClient>();
            _playoffController = new PlayoffController(_api.Object);
        }

        [Fact]
        public void Get_Series_ShouldReturnApiResult()
        {
            //Arrange
            _api.Setup(a => a.GetPlayoff($"{DateTime.Now.AddYears(-1).Year}" + $"{DateTime.Now.Year}")).Returns(Task.FromResult("test"));

            //Act
            JsonResult actual = _playoffController.Get();

            //Asserts
            actual.Value.Should().Be("test");
        }
    }
}

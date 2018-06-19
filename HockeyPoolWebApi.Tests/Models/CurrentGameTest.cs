using Xunit;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HockeyPoolWebApi.Models;

namespace HockeyPoolWebApi.Tests.Models
{
    public class CurrentGameTest
    {
        [Fact]
        public void CouldBeInProgress_GameDayDifferent_ShouldReturnFalse()
        {
            //Given
            var currentGame = new CurrentGame() { SeriesSummary = new SerieSummary() };

            //When
            currentGame.SeriesSummary.GameTime = "2018-05-06T23:30:00Z";

            //Then
            currentGame.CouldBeInProgess().Should().BeFalse();
        }


        [Fact]
        public void CouldBeInProgress_GameDayIsTheSameButTimeNotPassedYet_ShouldReturnFalse()
        {
            //Given
            var currentGame = new CurrentGame() { SeriesSummary = new SerieSummary() };

            //When
            currentGame.SeriesSummary.GameTime = DateTime.Now.AddMinutes(5).ToString();

            //Then
            currentGame.CouldBeInProgess().Should().BeFalse();
        }

        [Fact]
        public void CouldBeInProgress_GameDayIsTheSameAndTimeHasArrived_ShouldReturnTrue()
        {
            //Given
            var currentGame = new CurrentGame() { SeriesSummary = new SerieSummary() };

            //When
            currentGame.SeriesSummary.GameTime = DateTime.Now.AddMinutes(-5).ToString();

            //Then
            currentGame.CouldBeInProgess().Should().BeTrue();
        }

    }
}
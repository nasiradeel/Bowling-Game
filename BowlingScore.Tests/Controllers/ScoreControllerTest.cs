using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using FluentAssertions;
using BowlingScore.BusinessLogic;
using Moq;
using BowlingScore.Controllers;
using System.Web.Http.Results;

namespace BowlingScore.Tests.Controllers
{
    /// <summary>
    /// Summary description for ScoreController
    /// </summary>
    [TestClass]
    public class ScoreControllerTest
    {
        

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [Fact]
        [TestMethod]
        public void CalculateOpenScore()
        {
            // Arrange
            Score score = new Score();
            var frames = new List<Frame>
            {
                new Frame { FirstRoll = 3, SecondRoll = 6 },
                new Frame { FirstRoll = 4, SecondRoll = 5 },
            };
            var gameManagerMock = new Mock<IGameManager>();
            gameManagerMock.Setup(m => m.CalculateScore(frames)).Returns(score);

            var scoreController = new ScoreController(gameManagerMock.Object);

            // Act
            var actionResult = scoreController.CalculateScore(frames);

            // Assert
            var contentResult = Xunit.Assert.IsType<OkNegotiatedContentResult<Score>>(actionResult);

            contentResult.Content.Should().Equals(18);
            
        }

        [Fact]
        [TestMethod]
        public void CalculateStrike()
        {
            // Arrange
            Score score = new Score();
            var frames = new List<Frame>
            {
                new Frame { FirstRoll = 10, SecondRoll = 0 },
                new Frame { FirstRoll = 6, SecondRoll = 1 },
            };
            var gameManagerMock = new Mock<IGameManager>();
            gameManagerMock.Setup(m => m.CalculateScore(frames)).Returns(score);

            var scoreController = new ScoreController(gameManagerMock.Object);

            // Act
            var actionResult = scoreController.CalculateScore(frames);

            // Assert
            var contentResult = Xunit.Assert.IsType<OkNegotiatedContentResult<Score>>(actionResult);

            contentResult.Content.Should().Equals(24);

        }

        [Fact]
        [TestMethod]
        public void CalculateSpare()
        {
            // Arrange
            Score score = new Score();
            var frames = new List<Frame>
            {
                new Frame { FirstRoll = 8, SecondRoll = 2 },
                new Frame { FirstRoll = 6, SecondRoll = 3 },
            };
            var gameManagerMock = new Mock<IGameManager>();
            gameManagerMock.Setup(m => m.CalculateScore(frames)).Returns(score);

            var scoreController = new ScoreController(gameManagerMock.Object);

            // Act
            var actionResult = scoreController.CalculateScore(frames);

            // Assert
            var contentResult = Xunit.Assert.IsType<OkNegotiatedContentResult<Score>>(actionResult);

            contentResult.Content.Should().Equals(25);

        }
    }
}

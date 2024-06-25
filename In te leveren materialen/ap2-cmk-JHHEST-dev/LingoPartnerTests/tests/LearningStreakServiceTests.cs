using System;
using System.Collections.Generic;
using System.Net.Mail;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Interfaces.Strategies;
using LingoPartnerDomain.Services;
using LingoPartnerDomain.Strategies;
using LingoPartnerDomain.Strategies.Scoring;
using Moq;
using Xunit;

namespace LingoPartnerTests.LearningStreakServiceTests
{
  public class LearningStreakServiceTests
  {
    private readonly Mock<IProgressService> _mockProgressService;
    private readonly Mock<IAuthenticationService> _mockAuthenticationService;
    private readonly Mock<ILearningStreakStrategy> _mockLearningStreakStrategy;
    private readonly LearningStreakService _learningStreakService;
    private readonly int _userId;

    public LearningStreakServiceTests()
    {
      _mockProgressService = new Mock<IProgressService>();
      _mockAuthenticationService = new Mock<IAuthenticationService>();
      _mockLearningStreakStrategy = new Mock<ILearningStreakStrategy>();

      _userId = 1;
      var user = new User(_userId, "John", "", "Doe", new DateTime(1990, 1, 1), new MailAddress("john@doe.nl"), "start1234!", "johndoe", UserRole.ADMIN);

      _mockAuthenticationService.Setup(a => a.CurrentUser).Returns(user);
      ILearningStreakStrategy learningStreakStrategy = new ConsecutiveDaysStrategy();
      ILearningStreakScoringStrategy scoringStrategy = new SimpleScoringStrategy();
      _learningStreakService = new LearningStreakService(
        _mockProgressService.Object,
        _mockAuthenticationService.Object,
        learningStreakStrategy,
        scoringStrategy
      );
    }

    [Fact]
    public void CalculateTotalScore_UsingSimpleScoringStrategy_ReturnsCorrectScore()
    {
      // Arrange
      ILearningStreakScoringStrategy scoringStrategy = new SimpleScoringStrategy();
      var progressItems = new List<Progress>
            {
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details1", _userId, 1, DateTime.Now.AddDays(-5)),
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details2", _userId, 1, DateTime.Now.AddDays(-4)),
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details3", _userId, 1, DateTime.Now.AddDays(-3)),
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details4", _userId, 1, DateTime.Now.AddDays(-2)),
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details5", _userId, 1, DateTime.Now.AddDays(-1)),
            };

      var learningStreaks = new List<LearningStreak>
            {
                new LearningStreak(new List<DateTime> { DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-4) }, scoringStrategy),
                new LearningStreak(new List<DateTime> { DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1) }, scoringStrategy)
            };

      _mockProgressService.Setup(p => p.GetProgressByUserId(It.IsAny<int>())).Returns(progressItems);

      // Act
      int simpleScore = _learningStreakService.CalculateTotalScore(scoringStrategy);

      // Assert
      Assert.Equal(5, simpleScore);
    }

    [Fact]
    public void CalculateTotalScore_UsingBonusScoringStrategy_ReturnsCorrectScore()
    {
      // Arrange
      ILearningStreakScoringStrategy scoringStrategy = new BonusScoringStrategy();
      var progressItems = new List<Progress>
            {
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details1", _userId, 1, DateTime.Now.AddDays(-5)),
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details2", _userId, 1, DateTime.Now.AddDays(-4)),
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details3", _userId, 1, DateTime.Now.AddDays(-3)),
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details4", _userId, 1, DateTime.Now.AddDays(-2)),
                new Progress(ProgressType.LEARNING_ACTIVITY, ProgressStatus.COMPLETED, "Details5", _userId, 1, DateTime.Now.AddDays(-1)),
            };

      var learningStreaks = new List<LearningStreak>
            {
                new LearningStreak(new List<DateTime> { DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-4) }, scoringStrategy),
                new LearningStreak(new List<DateTime> { DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1) }, scoringStrategy)
            };

      _mockProgressService.Setup(p => p.GetProgressByUserId(It.IsAny<int>())).Returns(progressItems);

      // Act

      int bonusScore = _learningStreakService.CalculateTotalScore(scoringStrategy);

      // Assert
      Assert.Equal(10, bonusScore);
    }
  }
}

using System;
using System.Collections.Generic;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Strategies;
using Moq;
using Xunit;

namespace LingoPartnerTests.learningStreak
{
  public class LearningStreakTests
  {
    private readonly Mock<ILearningStreakScoringStrategy> _mockScoringStrategy;
    private readonly LearningStreak _learningStreak;

    public LearningStreakTests()
    {
      _mockScoringStrategy = new Mock<ILearningStreakScoringStrategy>();
      _learningStreak = new LearningStreak(_mockScoringStrategy.Object);
    }

    [Fact]
    public void AddActivityDate_AddsNewDate_ReturnsTrue()
    {
      // Arrange
      var date = DateTime.Now;

      // Act
      var result = _learningStreak.AddActivityDate(date);

      // Assert
      Assert.True(result);
      Assert.Contains(date, _learningStreak.ActivityDates);
      Assert.Equal(date, _learningStreak.StartDate);
      Assert.Equal(date, _learningStreak.EndDate);
    }

    [Fact]
    public void AddActivityDate_DuplicateDate_ReturnsFalse()
    {
      // Arrange
      var date = DateTime.Now;
      _learningStreak.AddActivityDate(date);

      // Act
      var result = _learningStreak.AddActivityDate(date);

      // Assert
      Assert.False(result);
      Assert.Single(_learningStreak.ActivityDates);
    }

    [Fact]
    public void GetLength_ReturnsCorrectLength()
    {
      // Arrange
      var dates = new List<DateTime> { DateTime.Now, DateTime.Now.AddDays(-1) };
      foreach (var date in dates)
      {
        _learningStreak.AddActivityDate(date);
      }

      // Act
      var length = _learningStreak.Length;

      // Assert
      Assert.Equal(dates.Count, length);
    }

    [Fact]
    public void GetScore_ReturnsCorrectScore()
    {
      // Arrange
      _mockScoringStrategy.Setup(s => s.CalculateScore(It.IsAny<LearningStreak>())).Returns(10);

      // Act
      var score = _learningStreak.Score;

      // Assert
      Assert.Equal(10, score);
    }

    [Fact]
    public void MeetCriteria_LengthLessThanTwo_ReturnsFalse()
    {
      // Arrange
      _learningStreak.AddActivityDate(DateTime.Now);

      // Act
      var meetsCriteria = _learningStreak.MeetCriteria();

      // Assert
      Assert.False(meetsCriteria);
    }

    [Fact]
    public void MeetCriteria_LengthGreaterThanOrEqualToTwo_ReturnsTrue()
    {
      // Arrange
      _learningStreak.AddActivityDate(DateTime.Now);
      _learningStreak.AddActivityDate(DateTime.Now.AddDays(-1));

      // Act
      var meetsCriteria = _learningStreak.MeetCriteria();

      // Assert
      Assert.True(meetsCriteria);
    }

    [Fact]
    public void AddActivityDate_UpdatesStartDateAndEndDate_Correctly()
    {
      // Arrange
      var firstDate = DateTime.Now.AddDays(-5);
      var secondDate = DateTime.Now.AddDays(-1);

      // Act
      _learningStreak.AddActivityDate(firstDate);
      _learningStreak.AddActivityDate(secondDate);

      // Assert
      Assert.Equal(firstDate, _learningStreak.StartDate);
      Assert.Equal(secondDate, _learningStreak.EndDate);
    }

    [Fact]
    public void AddActivityDate_WithUnorderedDates_UpdatesStartDateAndEndDate_Correctly()
    {
      // Arrange
      var dates = new List<DateTime>
        {
            DateTime.Now,
            DateTime.Now.AddDays(-3),
            DateTime.Now.AddDays(-1),
            DateTime.Now.AddDays(-2)
        };

      // Act
      foreach (var date in dates)
      {
        _learningStreak.AddActivityDate(date);
      }

      // Assert
      Assert.Equal(dates.Min(), _learningStreak.StartDate);
      Assert.Equal(dates.Max(), _learningStreak.EndDate);
    }
  }
}

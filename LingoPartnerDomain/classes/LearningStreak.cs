using System.Collections.ObjectModel;
using System.Collections.Generic;
using LingoPartnerDomain.Interfaces.Strategies;

namespace LingoPartnerDomain.Classes
{
  public class LearningStreak
  {
    private readonly ILearningStreakScoringStrategy _scoringStrategy;
    private List<DateTime> _dates = [];
    // private DateTime? _startDate;
    // private DateTime? _endDate;
    public ReadOnlyCollection<DateTime> ActivityDates => _dates.AsReadOnly();
    // public DateTime? StartDate => _startDate;
    // public DateTime? EndDate => _endDate;
    // public int Length => _startDate.HasValue && _endDate.HasValue ? (_endDate.Value - _startDate.Value).Days + 1 : 0;
    public int Length => _dates.Count;
    public DateTime? StartDate => _dates.Count != 0 ? _dates.Min() : null;
    public DateTime? EndDate => _dates.Count != 0 ? _dates.Max() : null;
    public int Score => _scoringStrategy.CalculateScore(this);

    public LearningStreak(ILearningStreakScoringStrategy scoringStrategy)
    {
      _scoringStrategy = scoringStrategy;
    }
    public LearningStreak(List<DateTime> activityDates, ILearningStreakScoringStrategy scoringStrategy) : this(scoringStrategy)
    {
      if (activityDates != null && activityDates.Count != 0)
      {
        _dates = activityDates.Distinct().ToList();
        // UpdateDateRange();
      }
    }
    public bool AddActivityDate(DateTime date)
    {
      if (!_dates.Contains(date))
      {
        _dates.Add(date);
        // UpdateDateRange();
        return true;
      }
      return false;
    }
    // private void UpdateDateRange()
    // {
    //   _startDate = _dates.Count != 0 ? _dates.Min() : null;
    //   _endDate = _dates.Count != 0 ? _dates.Max() : null;
    // }
    public bool MeetCriteria()
    {
      return Length >= 2;
    }
  }
}
using System.Collections.ObjectModel;

namespace LingoPartnerDomain.Classes
{
  /// <summary>
  /// Represents a learning streak with activity dates.
  /// </summary>
  public class LearningStreak
  {
    private List<DateTime> _dates = new List<DateTime>();
    private DateTime? _startDate;
    private DateTime? _endDate;
    /// <summary>
    /// Gets a read-only list of activity dates.
    /// </summary>
    public ReadOnlyCollection<DateTime> ActivityDates => _dates.AsReadOnly();
    /// <summary>
    /// Gets the start date of the learning streak.
    /// </summary>
    public DateTime? StartDate => _startDate;
    /// <summary>
    /// Gets the end date of the learning streak.
    /// </summary>
    public DateTime? EndDate => _endDate;
    /// <summary>
    /// Gets the length of the learning streak in days.
    /// </summary>
    public int Length => _startDate.HasValue && _endDate.HasValue ? (_endDate.Value - _startDate.Value).Days + 1 : 0;

    /// <summary>
    /// Gets the score based on the length of the streak.
    /// </summary>
    public int Score => Length * 10; // Example scoring: 10 points per day

    /// <summary>
    /// Initializes a new instance of the <see cref="LearningStreak"/> class.
    /// </summary>
    public LearningStreak() { }
    /// <summary>
    /// Initializes a new instance of the <see cref="LearningStreak"/> class with a list of unique activity dates.
    /// </summary>
    /// <param name="activityDates">A list of unique activity dates.</param>
    public LearningStreak(List<DateTime> activityDates)
    {
      if (activityDates != null && activityDates.Any())
      {
        _dates = activityDates.Distinct().ToList();
        UpdateDateRange();
      }
    }
    /// <summary>
    /// Adds a unique activity date to the list.
    /// </summary>
    /// <param name="date">The date to add.</param>
    /// <returns>True if the date was added; otherwise, false.</returns>
    public bool AddActivityDate(DateTime date)
    {
      if (!_dates.Contains(date))
      {
        _dates.Add(date);
        UpdateDateRange();
        return true;
      }
      return false;
    }
    /// <summary>
    /// Updates the start and end dates based on the current list of activity dates.
    /// </summary>
    private void UpdateDateRange()
    {
      _startDate = _dates.Any() ? (DateTime?)_dates.Min() : null;
      _endDate = _dates.Any() ? (DateTime?)_dates.Max() : null;
    }
  }
}
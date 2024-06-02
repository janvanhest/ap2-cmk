namespace LingoPartnerDomain.Classes
{
  public class LearningStreak
  {
    public int UserId { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public int Length { get; }
    public int Points { get; }

    public LearningStreak(int userId, DateTime startDate, DateTime endDate, int length, int points)
    {
      UserId = userId;
      StartDate = startDate;
      EndDate = endDate;
      Length = length;
      Points = points;
    }
  }
}
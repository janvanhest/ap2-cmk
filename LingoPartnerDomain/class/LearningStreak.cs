namespace LingoPartnerDomain.classes
{
  public class LearningStreak
  {
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int Length => (EndDate - StartDate).Days + 1;

    public LearningStreak(DateTime startDate, DateTime endDate)
    {
      StartDate = startDate;
      EndDate = endDate;
    }
  }
}
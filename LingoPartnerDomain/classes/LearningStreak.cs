namespace LingoPartnerDomain.Classes
{
  public class LearningStreak
  {
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<DateTime> ActivityDates { get; set; } = new List<DateTime>();
    public int Length => (EndDate - StartDate).Days + 1;
    public int Score => Length * 10; // Example scoring: 10 points per day
  }
}
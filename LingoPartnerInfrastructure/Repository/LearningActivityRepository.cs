using LingoPartnerDomain;
using LingoPartnerDomain.classes;
using LingoPartnerInfrastructure.Helpers;

namespace LingoPartnerInfrastructure
{
  public class LearningActivityRepository : ILearningActivityRepository
  {
    private readonly string _connectionString;
    public LearningActivityRepository(string? connectionString = null)
    {
      _connectionString = connectionString ?? InfrastructureHelper.CreateConnectionString();
      // FIXME: is a guard clause really necessary here?
      if (string.IsNullOrEmpty(_connectionString))
      { throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty."); }
    }

    public LearningActivity? AddLearningActivity(LearningActivity activity)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<LearningActivity> GetAllLearningActivities()
    {
      throw new NotImplementedException();
    }

    public LearningActivity? GetLearningActivityById(int activityId)
    {
      throw new NotImplementedException();
    }

    public void RemoveLearningActivity(int activityId)
    {
      throw new NotImplementedException();
    }

    public LearningActivity? UpdateLearningActivity(LearningActivity activity)
    {
      throw new NotImplementedException();
    }
  }
}
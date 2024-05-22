using LingoPartnerDomain.classes;
using LingoPartnerDomain.interfaces;
using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure.Repository
{
  public class ProgressRepository : IProgressRepository
  {
    public Progress? AddProgress(Progress progress)
    {
      //  TODO: Implement AddProgress
      throw new NotImplementedException();
    }
    // TODO: Implement GetProgressByUserId
    public IEnumerable<Progress> GetProgressByUserId(int userId)
    {
      // TODO: Implement GetProgressByUserId
      throw new NotImplementedException();
    }
    // TODO: Implement UpdateProgress
    public Progress? UpdateProgress(Progress updateProgress)
    {
      throw new NotImplementedException();
    }
  }
}
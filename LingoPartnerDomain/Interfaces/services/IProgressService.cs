using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface IProgressService
  {
    Progress? AddProgress(Progress progress);
    Progress? UpdateProgress(Progress progress);
    IEnumerable<Progress> GetAllProgress();
    IEnumerable<Progress> GetProgressByUserId(int userId);
    IEnumerable<DateTime> GetUniqueDatesByUserId(int userId);
  }
}
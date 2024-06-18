using System;
using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Repositories
{
  public interface IProgressRepository
  {
    Progress? AddProgress(Progress progress);
    Progress? UpdateProgress(Progress updateProgress);
    IEnumerable<Progress> GetAllProgress();
    IEnumerable<Progress> GetProgressByUserId(int userId);

    IEnumerable<DateTime> GetUniqueDatesByUserId(int userId);
  }
}
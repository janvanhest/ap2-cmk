using System;
using LingoPartnerDomain.classes;

namespace LingoPartnerDomain.interfaces
{
  public interface IProgressRepository
  {
    Progress? AddProgress(Progress progress);
    Progress? UpdateProgress(Progress updateProgress);
    // void DeleteProgress(int progressId);
    // Progress GetProgressById(int progressId);
    IEnumerable<Progress> GetAllProgress();
    IEnumerable<Progress> GetProgressByUserId(int userId);

  }
}
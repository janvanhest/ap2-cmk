using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerDomain.Services
{
  public class ProgressService : IProgressService
  {
    private readonly IProgressRepository _progressRepository;

    public ProgressService(IProgressRepository progressRepository)
    {
      _progressRepository = progressRepository ?? throw new ArgumentNullException(nameof(progressRepository));
    }

    public Progress? AddProgress(Progress progress)
    {
      return _progressRepository.AddProgress(progress);
    }

    public Progress? UpdateProgress(Progress progress)
    {
      return _progressRepository.UpdateProgress(progress);
    }

    public IEnumerable<Progress> GetAllProgress()
    {
      return _progressRepository.GetAllProgress();
    }

    public IEnumerable<Progress> GetProgressByUserId(int userId)
    {
      return _progressRepository.GetProgressByUserId(userId);
    }

    public IEnumerable<DateTime> GetUniqueDatesByUserId(int userId)
    {
      return _progressRepository.GetUniqueDatesByUserId(userId);
    }
  }
}

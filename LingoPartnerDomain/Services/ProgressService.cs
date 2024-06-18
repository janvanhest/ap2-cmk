﻿using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerInfrastructure.Services;
using LingoPartnerShared.Helpers;

namespace LingoPartnerDomain.Services
{
  public class ProgressService : IProgressService
  {
    private readonly IProgressRepository _progressRepository;
    private readonly ILearningActivityService _learningActivityService;

    public ProgressService(
      IProgressRepository progressRepository,
      ILearningActivityService learningActivityService
      )
    {
      _progressRepository = progressRepository;
      _learningActivityService = learningActivityService;
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

    public double GetModuleCompletionPercentage(int moduleId, User? user)
    {

      User? currentUser = user ?? throw new ArgumentNullException(nameof(user));
      int? userId = currentUser.Id ?? throw new ArgumentNullException(nameof(user.Id));
      IEnumerable<LearningActivity> activitiesByLearningModuleId = _learningActivityService.GetLearningActivitiesByModuleId(moduleId).ToArray();
      if (activitiesByLearningModuleId.Count() == 0) return 0;

      var completedActivities = _progressRepository
          .GetProgressByUserId(userId.Value)
          .Where(p => p.Status == ProgressStatus.COMPLETED && activitiesByLearningModuleId.Any(la => la.Id == p.LearningActivityId))
          .Count();

      return completedActivities * 100.0 / activitiesByLearningModuleId.Count();
    }
  }
}

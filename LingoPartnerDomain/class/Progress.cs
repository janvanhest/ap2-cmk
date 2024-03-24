namespace LingoPartnerDomain.classes;


using System;
using LingoPartnerDomain.enums;

public class Progress
{
  public Guid Id { get; private set; }
  public Guid UserId { get; private set; }
  public Guid LearningEntityId { get; private set; } // ID for LearningModule or LearningActivity

  public Guid RewardId { get; private set; } // ID for Reward
  public ProgressType Type { get; private set; }
  public ProgressStatus Status { get; private set; }
  public string ProgressDetails { get; private set; }

  // Constructor to initialize a new Progress
  public Progress(Guid userId, Guid learningEntityId, ProgressType type)
  {
    Id = Guid.NewGuid(); // Unique identifier for each progress record
    UserId = userId;
    LearningEntityId = learningEntityId;
    Type = type;
    Status = ProgressStatus.NOT_STARTED; // Default status
    ProgressDetails = string.Empty;
  }

  // Method to update the status and details of the progress
  public void UpdateProgress(ProgressStatus newStatus, string newDetails)
  {
    Status = newStatus;
    ProgressDetails = newDetails ?? throw new ArgumentNullException(nameof(newDetails));
  }
}


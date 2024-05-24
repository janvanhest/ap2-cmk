namespace LingoPartnerDomain.classes;

using System;
using LingoPartnerDomain.enums;

public class Progress
{
  public int? Id { get; private set; }  // Private setter
  public ProgressType Type { get; private set; }  // Private setter
  public ProgressStatus Status { get; private set; }  // Private setter
  public string Details { get; private set; }  // Private setter
  public int UserId { get; private set; }  // Private setter
  public int LearningActivityId { get; private set; }  // Private setter

  public Progress(int id, ProgressType type, ProgressStatus status, string details, int userId, int learningActivityId)
  {
    Id = id;
    Type = type;
    Status = status;
    Details = details;
    UserId = userId;
    LearningActivityId = learningActivityId;
  }

  public Progress(ProgressType type, ProgressStatus status, string details, int userId, int learningActivityId)
  {
    Type = type;
    Status = status;
    Details = details;
    UserId = userId;
    LearningActivityId = learningActivityId;
  }

  public string ShowDetails()
  {
    return $"Progress ID: {Id}, Type: {Type}, Status: {Status}, Details: {Details}, User ID: {UserId}, Learning Activity ID: {LearningActivityId}";
  }

  public void UpdateProgress(ProgressStatus newStatus, string newDetails)
  {
    Status = newStatus;
    Details = newDetails;
  }
}

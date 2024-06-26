﻿using LingoPartnerDomain.enums;

namespace LingoPartnerDomain.Classes
{
  public class Progress
  {
    public int? Id { get; private set; }  // Private setter
    public ProgressType Type { get; private set; }  // Private setter
    public ProgressStatus Status { get; private set; }  // Private setter
    public string Details { get; private set; }  // Private setter
    public int UserId { get; private set; }  // Private setter
    public int LearningActivityId { get; private set; }  // Private setter
    public DateTime Date { get; private set; }  // New date property with private setter

    public Progress(
        ProgressType type,
        ProgressStatus status,
        string details,
        int userId,
        int learningActivityId,
        DateTime date) : this(null, type, status, details, userId, learningActivityId, date) { }
    public Progress(
        int? id,
        ProgressType type,
        ProgressStatus status,
        string details,
        int userId,
        int learningActivityId,
        DateTime date)
    {
      Id = id;
      Type = type;
      Status = status;
      Details = details;
      UserId = userId;
      LearningActivityId = learningActivityId;
      Date = date;
    }
    public string GetProgressDescription()
    {
      return $"Progress ID: {Id}, Type: {Type}, Status: {Status}, Details: {Details}, User ID: {UserId}, Learning Activity ID: {LearningActivityId}, Date: {Date}";
    }

    public void UpdateProgress(ProgressStatus newStatus, string newDetails)
    {
      Status = newStatus;
      Details = newDetails;
    }
  }
}
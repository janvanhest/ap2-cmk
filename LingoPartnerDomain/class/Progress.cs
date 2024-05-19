namespace LingoPartnerDomain.classes;

using System;
using LingoPartnerDomain.enums;
public class Progress
{
  public int Id { get; private set; }  // Private setter
  public ProgressType Type { get; private set; }  // Private setter
  public ProgressStatus Status { get; private set; }  // Private setter
  public string Details { get; private set; }  // Private setter

  public Progress(int id, ProgressType type, ProgressStatus status, string details)
  {
    Id = id;
    Type = type;
    Status = status;
    Details = details;
  }

  public string ShowDetails()
  {
    return $"Progress ID: {Id}, Type: {Type}, Status: {Status}, Details: {Details}";
  }

  public void UpdateProgress(ProgressStatus newStatus, string newDetails)
  {
    Status = newStatus;
    Details = newDetails;
  }
}

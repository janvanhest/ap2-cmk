namespace LingoPartnerDomain.enums;
using System.ComponentModel;
public enum ProgressType
{
  [Description("Learning Activity")]
  LEARNING_ACTIVITY,
  [Description("Assessment")]
  ASSESSMENT,
  [Description("Module")]
  MODULE,
  [Description("Project")]
  PROJECT
}

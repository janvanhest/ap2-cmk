namespace LingoPartnerDomain.ENUM;
using System.ComponentModel;
public enum LearningActivityType
{
  [Description("Multiple Choice")]
  MULTIPLE_CHOICE,
  [Description("Fill in the Blank")]
  FILL_IN_THE_BLANK,
  [Description("True or False")]
  TRUE_FALSE,
  [Description("Matching")]
  MATCHING,
  [Description("Instructional Text")]
  INSTRUCTIONAL_TEXT,
  [Description("Quiz")]
  QUIZ

}

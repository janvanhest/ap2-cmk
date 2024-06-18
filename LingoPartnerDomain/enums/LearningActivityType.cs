namespace LingoPartnerDomain.enums;
using System.ComponentModel;
public enum LearningActivityType
{
  [Description("Multiple Choice")]
  MULTIPLECHOICE,
  [Description("Fill in the Blank")]
  FILLINTHEBLANK,
  [Description("True or False")]
  TRUEFALSE,
  [Description("Matching")]
  MATCHING,
  [Description("Instructional Text")]
  INSTRUCTION,
  [Description("Quiz")]
  QUIZ

}

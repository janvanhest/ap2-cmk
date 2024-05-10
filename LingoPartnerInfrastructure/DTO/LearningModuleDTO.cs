using System;

namespace LingoPartnerInfrastructure.DTO
{
  public class LearningModuleDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<LearningActivityDTO> LearningActivities { get; set; }

    public LearningModuleDTO(int id, string name, string description, List<LearningActivityDTO> learningActivities)
    {
      Id = id;
      Name = name;
      Description = description;
      LearningActivities = learningActivities;
    }

    // public static LearningModuleDTO FromEntity(LearningModule module)
    // {
    //   var activityDTOs = module.ShowLearningActivities()
    //                            .Select(LearningActivityDTO.FromEntity)
    //                            .ToList();

    //   return new LearningModuleDTO(
    //       module.Id,
    //       module.Name,
    //       module.Description,
    //       activityDTOs
    //   );
    // }
  }
}
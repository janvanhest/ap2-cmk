namespace LingoPartnerInfrastructure
{
  public class LearningActivityDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }

    public LearningActivityDTO(int id, string name, string description, string type)
    {
      Id = id;
      Name = name;
      Description = description;
      Type = type;
    }

    // public static LearningActivityDTO FromEntity(LearningActivity activity)
    // {
    //   return new LearningActivityDTO(
    //       activity.Id,
    //       activity.Name,
    //       activity.Description,
    //       activity.Type.ToString()
    //   );
    // }
  }
}
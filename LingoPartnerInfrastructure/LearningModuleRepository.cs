namespace LingoPartnerInfrastructure
{

  public class LearningModuleRepository
  {
    private string ConnectionString;
    public LearningModuleRepository()
    {
      ConnectionString = new InfrastructureHelper().CreateConnectionString();
    }

  }
}
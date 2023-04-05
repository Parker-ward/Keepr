namespace Keepr.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Account> FindProfile()
    {
      throw new Exception("Unimplemented method");
    }
  }
}
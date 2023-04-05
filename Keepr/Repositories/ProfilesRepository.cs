namespace Keepr.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Account FindProfile(string id)
    {
      string sql = @"
      SELECT
      *
      FROM accounts
      WHERE id = @id;
      ";
      Account account = _db.Query<Account>(sql, new { id }).FirstOrDefault();
      return account;
    }
  }
}
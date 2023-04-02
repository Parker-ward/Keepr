namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Keep CreateKeep(Keep keepData)
    {
      string sql = @"
      INSERT INTO keep
      (name, description, img, creatorId)
      VALUES
      (@name, @description, @img, @creatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, keepData);
      keepData.Id = id;
      return keepData;
    }

    internal List<Keep> GetKeeps()
    {
      string sql = @"
      SELECT
      k.*,
      acct.*
      FROM keep k
      JOIN accounts acct ON k.creatorId = acct.id
      ";
      List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }).ToList();
      return keeps;
    }

    internal Keep GetOne(int id)
    {
      string sql = @"
      SELECT
      k.*,
      acct.*
      FROM keep k
      JOIN accounts acct ON k.creatorId = acct.id
      WHERE k.id = @id;
      ";
      Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { id }).FirstOrDefault();
      return keep;
    }

    internal int UpdateKeep(Keep origianl)
    {
      string sql = @"
        UPDATE keep
        SET
        name = @name,
        description = @description,
        img = @img
        WHERE id = @id;
        ";
      int rows = _db.Execute(sql, origianl);
      return rows;
    }

    internal bool DeleteKeep(int id)
    {
      string sql = @"
    DELETE FROM keep WHERE id = @id;
    ";
      int rows = _db.Execute(sql, new { id });
      return rows == 1;
    }

    internal List<Keep> FindByVault(int vaultId)
    {
      string sql = @"
      SELECT 
      vk.*, 
      v.*,
      creator.*
      FROM vaultKeeps vk
      JOIN vault v ON vk.vaultId = v.id
      JOIN accounts creator ON vk.creatorId = creator.id
      WHERE
      vk.creatorId = @creatorId;
      ";
      List<KeepInVault> vaultsKeeps = _db.Query<KeepInVault, Vault, Profile, KeepInVault>(sql, (vk, v, profile) =>
      {
        vk.CreatorId = v.Id;
        vk.Creator = profile;
        return vk;
      }, new { creatorId }).ToList();
      return vaultsKeeps;
    }
  }
}
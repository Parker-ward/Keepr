namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault CreateVault(Vault vaultData)
    {
      string sql = @"
     INSERT INTO vault
     (name, description, img, creatorId)
     VALUES
     (@name, @description, @img, @creatorId);
     SELECT LAST_INSERT_ID();
     ";
      int id = _db.ExecuteScalar<int>(sql, vaultData);
      vaultData.Id = id;
      return vaultData;
    }

    internal Vault GetOne(int id)
    {
      string sql = @"
     SELECT
     v.*,
    acct.*
    FROM vault v
    JOIN accounts acct ON v.creatorId = acct.id
    WHERE v.id = @id;
     ";
      Vault vault = _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { id }).FirstOrDefault();
      return vault;
    }

    internal int UpdateVault(Vault original)
    {
      string sql = @"
      UPDATE vault
      SET
      name = @name,
      description = @description,
      img = @img,
      isPrivate = @isPrivate
      WHERE id = @id;
      ";
      int rows = _db.Execute(sql, original);
      return rows;
    }

    internal bool DeleteVault(int id)
    {
      string sql = @"
     DELETE FROM vault WHERE id = @id;
     ";
      int rows = _db.Execute(sql, new { id });
      return rows == 1;
    }

    internal List<Vault> GetUserVaults(string id)
    {
      string sql = @"
      SELECT
      v.*,
      creator.*
      FROM vault v
      JOIN accounts creator ON v.creatorId = creator.id
      WHERE v.creatorId = @id;
      ";

      List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, (v, prof) =>
      {
        v.Creator = prof;
        return v;
      }, new { id }).ToList();
      return vaults;
    }


  }
}
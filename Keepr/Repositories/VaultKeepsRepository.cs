namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
      string sql = @"
      INSERT INTO vaultKeeps
      (creatorId, vaultId, keepId)
      VALUES
      (@creatorId, @vaultId, @keepId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
      vaultKeepData.Id = id;
      return vaultKeepData;
    }

    internal bool DeleteVautKeep(int id)
    {
      string sql = @"
      DELETE FROM vaultKeeps WHERE id = @id;
      ";
      int rows = _db.Execute(sql, new { id });
      return rows == 1;
    }

    internal VaultKeep FindVaultKeep(VaultKeep vaultKeepData)
    {
      string sql = @"
      SELECT
      *
      FROM vaultKeeps
      WHERE creatorId = creatorId AND vaultId = @vaultId AND keepId = @keepId;
      ";
      VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).FirstOrDefault();
      return vaultKeep;
    }

    internal VaultKeep GetOne(int id)
    {
      string sql = @"
      SELECT
      vk.*,
      acct.*
      FROM vaultKeeps vk
      JOIN accounts acct ON vk.creatorId = acct.id
      WHERE vk.id = @id;
      ";
      VaultKeep vaultKeep = _db.Query<VaultKeep, Profile, VaultKeep>(sql, (vaultKeep, profile) =>
      {
        vaultKeep.Creator = profile;
        return vaultKeep;
      }, new { id }).FirstOrDefault();
      return vaultKeep;
    }
  }
}
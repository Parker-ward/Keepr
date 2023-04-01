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
  }
}
namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
      VaultKeep foundVaultKeep = _repo.FindVaultKeep(vaultKeepData);
      if (foundVaultKeep != null) throw new Exception("You already have this vaultkeep");
      VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
      return vaultKeep;
    }
  }
}
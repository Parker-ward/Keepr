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
      // TODO find the vault that I am creating this keep for
      // TODO if the user did not create that vault, they shouldn't be able to create a vaultkeep
      VaultKeep foundVaultKeep = _repo.FindVaultKeep(vaultKeepData);
      if (foundVaultKeep != null) throw new Exception("You already have this vaultkeep");

      VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
      return vaultKeep;
    }
  }
}
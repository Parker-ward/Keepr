namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    private readonly VaultsService _vaultsService;
    public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService)
    {
      _repo = repo;
      _vaultsService = vaultsService;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, int id, int vaultId)
    {
      // TODO find the vault that I am creating this keep for
      // TODO if the user did not create that vault, they shouldn't be able to create a vaultkeep
      Vault vault = _vaultsService.Find(vaultId);
      if (Vault.CreatorId != userId) throw new Exception("Not your Vault bruh");
      VaultKeep foundVaultKeep = _repo.FindVaultKeep(vaultKeepData);
      if (foundVaultKeep != null) throw new Exception("You already have this vaultkeep");

      VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
      if (foundVaultKeep.CreatorId != userInfo.id) throw new Exception("Not your Vault bruh");
      return vaultKeep;
    }

    internal VaultKeep Find(int id, string userId)
    {
      VaultKeep vaultKeep = _repo.GetOne(id);
      if (vaultKeep == null) throw new Exception("no vaultkeep at that id");
      return vaultKeep;
    }

    internal string DeleteVaultKeep(int id, Account userInfo)
    {
      VaultKeep vaultKeep = this.Find(id, userInfo.Id);
      if (vaultKeep.CreatorId != userInfo.Id) throw new Exception("Not your Vault Keep bruh");
      bool result = _repo.DeleteVautKeep(id);
      if (!result) throw new Exception("Something went wrong when trying to delete vault keep");
      return "vault deleted";
    }


  }
}
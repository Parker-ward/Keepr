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

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
    {

      Vault vault = _vaultsService.Find(vaultKeepData.VaultId, userId);
      if (vault.CreatorId != userId) throw new Exception("Can't create vaultkeep for other people bruh");
      // VaultKeep foundVaultKeep = _repo.FindVaultKeep(vaultKeepData);
      // if (foundVaultKeep != null) throw new Exception("You already have this vaultkeep");

      VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
      if (vaultKeep.CreatorId != userId) throw new Exception("Not your Vault bruh");
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
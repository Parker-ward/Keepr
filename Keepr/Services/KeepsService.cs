namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    private readonly VaultsService _vaultsService;

    public KeepsService(KeepsRepository repo, VaultsService vaultsService)
    {
      _repo = repo;
      _vaultsService = vaultsService;
    }

    internal List<Keep> GetKeeps(string id)
    {
      List<Keep> allKeeps = _repo.GetKeeps();
      return allKeeps;
    }

    internal Keep CreateKeep(Keep keepData)
    {
      Keep keep = _repo.CreateKeep(keepData);
      return keep;
    }

    internal Keep EditKeep(int id, Keep keepData, Account userInfo)
    {
      Keep original = this.Find(id, userInfo.Id);
      if (original.CreatorId != userInfo.Id) throw new Exception("Not your Vault bruh");
      // TODO check to make sure that the user is allowed to edit this...throw an error if not

      original.Name = keepData.Name != null ? keepData.Name : original.Name;
      original.Description = keepData.Description != null ? keepData.Description : original.Description;
      original.Img = keepData.Img != null ? keepData.Img : original.Img;
      original.Kept = keepData.Kept != null ? keepData.Kept : original.Kept;
      original.Views = keepData.Views != null ? keepData.Views : original.Views;
      int rowsAffected = _repo.UpdateKeep(original);
      if (rowsAffected == 0) throw new Exception("Could not modify");
      if (rowsAffected > 1) throw new Exception("Something went wrong");
      return original;
    }
    internal Keep Find(int id, string userId)
    {
      Keep keep = _repo.GetOne(id);
      if (keep == null) throw new Exception("Nope");
      if (keep.CreatorId != userId)
        keep.Views++;
      _repo.UpdateKeep(keep);
      return keep;
    }

    internal string DeleteKeep(int id, Account userInfo)
    {
      // TODO check to make sure user has the right to delete this...throw an error if not
      Keep keep = this.Find(id, userInfo.Id);
      if (keep.CreatorId != userInfo.Id) throw new Exception("Not your Vault bruh");
      bool result = _repo.DeleteKeep(id);
      if (!result) throw new Exception("something went wrong when trying to delete");
      return "deleted";
    }

    internal List<KeepInVault> GetKeepsInVault(int vaultId, string userId)
    {
      Vault vault = _vaultsService.Find(vaultId, userId);

      if (vault.isPrivate == true)
      {
        if (vault.CreatorId != userId) throw new Exception("that is not your vault...");
      }
      List<KeepInVault> keepsInVaults = _repo.GetKeepsInVault(vaultId);

      // TODO check to see if the user has access to the private vault, if they do return everything, if they don't filter out the private

      return keepsInVaults;
    }

    internal List<Keep> GetUserKeeps(string id)
    {

      List<Keep> keeps = _repo.GetUserKeeps(id);
      return keeps;
    }
  }
}
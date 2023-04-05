namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
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
      // TODO check to make sure that the user is allowed to edit this...throw an error if not
      Keep original = this.Find(id);
      original.Name = keepData.Name != null ? keepData.Name : original.Name;
      original.Description = keepData.Description != null ? keepData.Description : original.Description;
      original.Img = keepData.Img != null ? keepData.Img : original.Img;
      int rowsAffected = _repo.UpdateKeep(original);
      if (rowsAffected == 0) throw new Exception("Could not modify");
      if (rowsAffected > 1) throw new Exception("Something went wrong");
      return original;
    }
    internal Keep Find(int id)
    {
      Keep keep = _repo.GetOne(id);
      if (keep == null) throw new Exception("Nope");
      return keep;
    }

    internal string DeleteKeep(int id, Account userInfo)
    {
      // TODO check to make sure user has the right to delete this...throw an error if not
      Keep keep = this.Find(id);
      bool result = _repo.DeleteKeep(id);
      if (!result) throw new Exception("something went wrong when trying to delete");
      return "deleted";
    }

    internal List<KeepInVault> GetKeepsInVault(int vaultId)
    {
      // TODO if the user does not have access to the private vaults, throw a Exception/Bad Request
      List<KeepInVault> keepsInVaults = _repo.GetKeepsInVault(vaultId);

      // TODO check to see if the user has access to the private vault, if they do return everything, if they don't filter out the private

      return keepsInVaults;
    }
  }
}
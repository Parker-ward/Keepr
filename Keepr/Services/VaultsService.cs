namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal Vault CreateVault(Vault vaultData)
    {
      Vault vault = _repo.CreateVault(vaultData);
      return vault;
    }

    // internal Vault Get(int id, string userId)
    // {

    // }



    internal Vault EditVault(int id, Vault vaultData, Account userInfo)
    {

      Vault original = this.Find(id, userInfo.Id);
      if (original.CreatorId != userInfo.Id) throw new Exception("not your vault to edit");
      // TODO check to see if user has rights to edit this vault...if not throw an error
      original.Name = vaultData.Name != null ? vaultData.Name : original.Name;
      original.Description = vaultData.Description != null ? vaultData.Description : original.Description;
      original.Img = vaultData.Img != null ? vaultData.Img : original.Img;
      original.isPrivate = vaultData.isPrivate != null ? vaultData.isPrivate : original.isPrivate;
      int rowsAffected = _repo.UpdateVault(original);
      if (rowsAffected == 0) throw new Exception("could not modify");
      if (rowsAffected > 1) throw new Exception("Something went wrong");
      return original;
    }

    internal Vault Find(int id, string userId)
    {

      Vault vault = _repo.GetOne(id);


      if (vault == null) throw new Exception("no vault at that id");
      if (vault.CreatorId != userId && vault.isPrivate == true) throw new Exception("that is private");
      // NOTE keeps IN vault
      // if(vault.CreatorId != userId)
      // vault.keeps++;
      // _repo.EditVault(vault)
      // TODO does the user have access to this vault if its private?... if not, throw an error
      return vault;
    }

    internal string DeleteVault(int id, Account userInfo)
    {
      Vault vault = this.Find(id, userInfo.Id);
      if (vault.CreatorId != userInfo.Id) throw new Exception("Not your Vault bruh");

      // TODO check to see if user has rights to delete, if not throw an error
      bool result = _repo.DeleteVault(id);
      if (!result) throw new Exception("something went wrong when trying to delete vault");
      return "vault deleted";
    }

    internal List<Vault> GetUserVaults(string id)
    {
      List<Vault> vaults = _repo.GetUserVaults(id);
      // List<Vault> vaults = privateVault.Find(v => v.creatorId == userId || v.isPrivate == false);
      return vaults;
    }


  }
}
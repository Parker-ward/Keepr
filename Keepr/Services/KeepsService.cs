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
      Keep original = this.Find(id, userInfo.Id);
      original.Name = keepData.Name != null ? keepData.Name : original.Name;
      original.Description = keepData.Description != null ? keepData.Description : original.Description;
      original.Img = keepData.Img != null ? keepData.Img : original.Img;
      int rowsAffected = _repo.UpdateKeep(original);
      if (rowsAffected == 0) throw new Exception("Could not modify");
      if (rowsAffected > 1) throw new Exception("Something went wrong");
      return original;
    }
    internal Keep Find(int id, string userId)
    {
      Keep keep = _repo.GetOne(id);
      if (keep == null) throw new Exception("Nope");
      return keep;
    }

    internal string DeleteKeep(int id, Account userInfo)
    {
      Keep keep = this.Find(id, userInfo.Id);
      bool result = _repo.DeleteKeep(id);
      if (!result) throw new Exception("something went wrong when trying to delete");
      return "deleted";
    }
  }

}
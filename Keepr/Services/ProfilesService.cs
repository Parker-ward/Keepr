namespace Keepr.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal List<Account> FindProfile(int id, Account userInfo)
    {
      List<Account> profiles = _repo.FindProfile();
      return profiles;
    }
  }
}
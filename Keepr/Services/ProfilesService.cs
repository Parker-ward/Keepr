namespace Keepr.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal Account FindProfile(string id)
    {
      Account profile = _repo.FindProfile(id);
      return profile;
    }
  }
}
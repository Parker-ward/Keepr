namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly Auth0Provider _auth;
    private readonly ProfilesService _profilesService;

    public ProfilesController(Auth0Provider auth, ProfilesService profilesService)
    {
      _auth = auth;
      _profilesService = profilesService;
    }

    [HttpGet("{id}")]
    [Authorize]
    async public Task<ActionResult<Account>> FindProfile(string id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Account accounts = _profilesService.FindProfile(id);
        return Ok(accounts);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
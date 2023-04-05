namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly Auth0Provider _auth;
    private readonly ProfilesService _profilesService;
    private readonly KeepsService _keepsService;

    public ProfilesController(Auth0Provider auth, ProfilesService profilesService, KeepsService keepsService)
    {
      _auth = auth;
      _profilesService = profilesService;
      _keepsService = keepsService;
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

    [HttpGet("{id}/keeps")]
    [Authorize]
    async public Task<ActionResult<Account>> GetUserKeeps(int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        List<Keep> keeps = _keepsService.GetUserKeeps(id);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
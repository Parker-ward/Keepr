namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _keepsService;
    private readonly Auth0Provider _auth;

    public KeepsController(KeepsService keepsService, Auth0Provider auth)
    {
      _keepsService = keepsService;
      _auth = auth;
    }

    [HttpGet]
    public async Task<ActionResult<List<Keep>>> GetKeeps()
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        List<Keep> keeps = _keepsService.GetKeeps(userInfo?.Id);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        keepData.CreatorId = userInfo.Id;
        Keep keep = _keepsService.CreateKeep(keepData);
        keep.Creator = userInfo;
        return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Keep>> FindAsync(int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Keep keep = _keepsService.Find(id, userInfo.Id);
        return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> EditKeep([FromBody] Keep keepData, int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        keepData.CreatorId = userInfo.Id;
        keepData.Id = id;
        Keep keep = _keepsService.EditKeep(id, keepData, userInfo);
        return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    async public Task<ActionResult<string>> DeleteKeep(int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        string message = _keepsService.DeleteKeep(id, userInfo);
        return Ok(message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
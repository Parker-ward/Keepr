namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vaultKeepsService;
    private readonly Auth0Provider _auth;

    public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth)
    {
      _vaultKeepsService = vaultKeepsService;
      _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        vaultKeepData.CreatorId = userInfo.Id;
        VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(vaultKeepData);
        return Ok(vaultKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> DeleteVaultKeep(int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        string message = _vaultKeepsService.DeleteVaultKeep(id, userInfo);
        return Ok(message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // TODO write method for deleting vaultkeep...don't overthink this
    // TODO in the service, make sure you are perform a check to see if the user has the rights to delete, if not throw an errror

  }
}
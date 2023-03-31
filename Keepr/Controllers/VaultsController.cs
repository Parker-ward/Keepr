namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly Auth0Provider _auth;
    private readonly VaultsService _vaultsService;

    public VaultsController(Auth0Provider auth, VaultsService vaultsService)
    {
      _auth = auth;
      _vaultsService = vaultsService;
    }

    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        vaultData.CreatorId = userInfo.Id;
        Vault vault = _vaultsService.CreateVault(vaultData);
        vault.Creator = userInfo;
        // wgers the creator?
        return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
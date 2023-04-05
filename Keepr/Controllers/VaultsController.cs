namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly Auth0Provider _auth;
    private readonly VaultsService _vaultsService;
    private readonly KeepsService _keepsService;

    public VaultsController(Auth0Provider auth, VaultsService vaultsService, KeepsService keepsService)
    {
      _auth = auth;
      _vaultsService = vaultsService;
      _keepsService = keepsService;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> Find(int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Vault vault = _vaultsService.Find(id, userInfo?.Id);
        return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> EditVault([FromBody] Vault vaultData, int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        vaultData.CreatorId = userInfo.Id;
        vaultData.Id = id;
        Vault vault = _vaultsService.EditVault(id, vaultData, userInfo);
        return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    async public Task<ActionResult<string>> DeleteVault(int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        string message = _vaultsService.DeleteVault(id, userInfo);
        return Ok(message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/keeps")]


    public async Task<ActionResult<List<KeepInVault>>> GetKeepsInVault(int id)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        List<KeepInVault> keepsInVaults = _keepsService.GetKeepsInVault(id, userInfo?.Id);
        return Ok(keepsInVaults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
import { AppState } from "../AppState.js"

class VaultsService {

  async getVaults() {
    const res = await api.get(`api/vaults${vaultId}`)
    logger.log('[Getting vaults]', res.data)
    AppState.vaults = res.data
  }
}

export const vaultsService = new VaultsService()
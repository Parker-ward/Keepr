import { AppState } from "../AppState.js"

class VaultsService {

  async getVaults() {
    const res = await api.get(`api/vaults${vaultId}`)
    logger.log('[Getting vaults]', res.data)
    AppState.vaults = res.data
  }

  async deleteVault(vaultId) {
    const res = await api.delete(`api/vaults${vaultId}`)
    logger.log('[That vault has been delete}', res.data)
    let deleteIndex = AppState.vaults.findIndex.apply(v => v.id == vaultId)
    AppState.vaults.splice(deleteIndex, 1)
  }
}

export const vaultsService = new VaultsService()
import { AppState } from "../AppState.js"

class VaultsService {

  async getVaults() {
    const res = await api.get(`api/vaults${vaultId}`)
    logger.log('[Getting vaults]', res.data)
    AppState.vaults = res.data
  }

  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log('vault created', res.data)
    AppState.vaults.push(res.data)
    return res.data
  }

  async deleteVault(vaultId) {
    const res = await api.delete(`api/vaults${vaultId}`)
    logger.log('[That vault has been delete}', res.data)
    let deleteIndex = AppState.vaults.findIndex.apply(v => v.id == vaultId)
    AppState.vaults.splice(deleteIndex, 1)
  }
}

export const vaultsService = new VaultsService()
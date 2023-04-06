import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async getAccountVaults() {
    const res = await api.get('account/vaults')
    logger.log('[Getting Account Vaults]', res.data)
    AppState.accountVaults = res.data
  }


  async getVaultsById(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    logger.log('[Getting vaults]', res.data)
    AppState.profileVaults = res.data
  }

  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log('vault created', res.data)
    AppState.accountVaults.push(res.data)
    return res.data
  }

  async deleteVault(vaultId) {
    const res = await api.delete(`api/vaults${vaultId}`)
    logger.log('[That vault has been delete}', res.data)
    let deleteIndex = AppState.accountVaults.findIndex.apply(v => v.id == vaultId)
    AppState.accountVaults.splice(deleteIndex, 1)
  }

  async makePrivate(vaultId) {
    const res = await api.delete('api/vaults' + vaultId)
    let i = AppState.accountVaults.findIndex(v => v.id == vaultId)
    if (i != -1) {
      AppState.accountVaults.splice(i, 1, res.data)
    }
  }
}

export const vaultsService = new VaultsService()
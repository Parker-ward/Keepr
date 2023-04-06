import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {

  async addKeepToVault(vaultId, keepId) {
    const res = await api.post('api/vaultkeeps', { vaultId, keepId })
    logger.log(res.data)
  }

  // TODO delete vaultkeep..make sure to look at postmans
  async deleteKeepInVault(Id) {
    const res = await api.delete(`api/vaultkeeps/${Id}`)
    logger.log('{That keep in vault has been deleted]', res.data)
    let deleteIndex = AppState.keepsInVault.findIndex(vk => vk.id == keepsInVault)
    AppState.keepsInVault.splice(deleteIndex, 1)
  }
}

export const vaultKeepsService = new VaultKeepsService()
import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getKeeps() {
    const res = await api.get('api/keeps')
    logger.log('[Gettin keeps]', res.data)
    AppState.keeps = res.data
  }

  async getKeepsInVault(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log('[Keeps in vault]', res.data)
    AppState.keepsInVault = res.data
  }
  async getProfileKeeps(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    logger.log('[Get profile keep]', res.data)
    AppState.profileKeeps = res.data
  }

  async getAccountKeeps(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    logger.log('[Get account keep]', res.data)
    AppState.accountKeeps = res.data
  }
  // async getAccountKeeps() {
  //   const res = await api.get('account/keeps')
  //   logger.log('[Getting Account keeps]', res.data)
  //   AppState.accountKeeps = res.data
  // }

  async GetActiveKeep(keep) {
    const res = await api.get(`api/keeps/${keep.id}`)
    logger.log('[Get one keep]', res.data)
    AppState.activeKeep = res.data
  }
  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log("created keep", res.data)
    AppState.keeps.push(res.data)
    return res.data
  }

  async deleteKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    logger.log('[That keep has been deleted]', res.data)
    let deleteIndex = AppState.keeps.findIndex(k => k.id == keepId)
    AppState.keeps.splice(deleteIndex, 1)
  }

}

export const keepsService = new KeepsService()
import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getKeeps() {
    const res = await api.get('api/keeps')
    logger.log('[Gettin keeps]', res.data)
    AppState.keeps = res.data
  }

  async GetActiveKeep(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
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
    logger.log('[Deleted keep]', res.data)
    let deleteIndex = AppState.keeps.findIndex(k => k.id == keepId)
    AppState.keeps.splice(deleteIndex, 1)
  }

}

export const keepsService = new KeepsService()
import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getKeeps() {
    const res = await api.get('api/keeps')
    logger.log('[Gettin keeps]', res.data)
    AppState.keeps = res.data
  }

  async getActiveKeep(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
    logger.log('[Get one keep]', res.data)
    AppState.activeKeep = res.data
  }

}

export const keepsService = new KeepsService()
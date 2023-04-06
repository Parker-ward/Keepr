import { AppState } from "../AppState"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class ProfilesService {

  async getUserProfile(profileId) {
    AppState.profile = null
    const res = await api.get(`api/profiles/${profileId}`)
    logger.log('getting profile data', res.data)
    AppState.profile = res.data
  }
}

export const profilesService = new ProfilesService()
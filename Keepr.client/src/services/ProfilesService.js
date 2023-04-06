import { AppState } from "../AppState"


class ProfilesService {

  async getUserProfile(profileId) {
    AppState.profile = null
    const res = await api.get(`api/profiles/${id}`)
    logger.log('getting profile data', res.data)
    AppState.profile = res.data
  }
}

export const profilesService = new ProfilesService()
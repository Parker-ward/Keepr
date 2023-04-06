import { api } from "./AxiosService.js"

class VaultKeepsService {

  async addKeepToVault(vaultId, keepId) {
    const res = await api.post('api/vaultkeeps', { vaultId, keepId })
    logger.log(res.data)
  }
}

export const vaultKeepsService = new VaultKeepsService()
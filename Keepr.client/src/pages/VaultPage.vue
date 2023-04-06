<template></template>


<script>
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
export default {
  setup() {

    const route = useRoute()
    onMounted(() => {
      getVaultsById()
      getKeepsInVault()
    })

    async function getKeepsInVault() {
      try {
        await keepsService.getKeepsInVault(route.params.vaultId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)

      }
    }

    async function getVaultsById() {
      try {
        await vaultsService.getVaultsById(route.params.vaultId);
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    // TODO get keeps in this vault
    // TODO get this vault
    return {}

  }
}
</script>


<style lang="scss" scoped></style>
<template>
  <div class="rounded-circle delete-btn">
    <div v-if="account.id == vault?.creatorId" title="Delete Vault??">
      <button @click="deleteVault" class="btn btn-danger pt-1 pb-2 rounded delete">Delete</button>
    </div>
    <router-link :to="{ name: 'Vaults', params: { vaultId: vault?.id } }">
      <img class="img-fluid rounded" :src="vault?.img" alt="">
    </router-link>
    <span class="pt-2 d-flex rounded justify-content-between text-light  p-3 name"><b>{{ vault?.name
    }}</b>
      <router-link :to="{ name: 'Profile', params: { profileId: vault?.creatorId } }">
        <img class="rounded-circle p-2 creator-img" :src="vault?.creator.picture" alt="">
      </router-link>
    </span>


  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { vaultsService } from '../services/VaultsService.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';

export default {
  props: { vault: { type: Object, required: true } },
  setup(props) {
    return {
      account: computed(() => AppState.account),

      async getVaults(vault) {
        try {
          await vaultsService.getVaultsById(vault)
        } catch (error) {
          logger.log('[get vault]')
          Pop.error(error)
        }
      },

      async deleteVault() {
        try {
          if (await Pop.confirm('Are you sure?')) {
            await vaultsService.deleteVault(props.vault.id)
            Pop.toast('success, vault has been deleted')
          }
        } catch (error) {
          logger.error
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.creator-img {
  height: 50px;
  transform: translateY(30%);
}

.name {
  transform: translateY(-100%);
  backdrop-filter: blur(5px);
}

.delete {
  transform: translateY(85%);
  height: 33px;
}
</style>
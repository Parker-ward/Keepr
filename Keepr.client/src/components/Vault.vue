<template>
  <img :src="vault.img" alt="">
  {{ vault.name }}
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

      async deleteKeep() {
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


<style lang="scss" scoped></style>
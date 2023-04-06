<template>
  <div>
    <div v-for="vk in keepsinvault" class="col-md-3">
      <KeepCard :keep="vk" />

    </div>



  </div>
</template>


<script>
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { vaultsService } from '../services/VaultsService.js';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import KeepCard from '../components/KeepCard.vue';
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { router } from '../router.js';
import { vaultKeepsService } from '../services/VaultKeepsService.js';
export default {
  props: { keep: { type: Object, required: true } },
  setup() {
    const route = useRoute();
    onMounted(() => {
      getVaultById();
      getKeepsInVault();

    });
    async function getKeepsInVault() {
      try {
        await keepsService.getKeepsInVault(route.params.vaultId);
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    async function getVaultById() {
      try {
        await vaultsService.getVaultById(route.params.vaultId);
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
        router.push({ name: 'Home' })
      }
    }

    return {

      account: computed(() => AppState.account),
      keepsinvault: computed(() => AppState.keepsInVault),

      // async deleteKeepInVault() {
      //   try {
      //     if (await Pop.confirm('Are you sure??')) {
      //       await vaultKeepsService.deleteKeepInVault(Id)
      //       Pop.toast('success, keep in vault has been deleted')
      //     }
      //   } catch (error) {
      //     logger.error
      //     Pop.error(error)
      //   }
      // }
    };
  },
  components: { KeepCard }
}
</script>


<style lang="scss" scoped></style>
<template>
  <div>
    <div class="text-center mt-2">
      <h1> Vault: {{ vault?.name }}</h1>
      <img class="rounded" :src="vault?.img" alt="">

      <p class="fs-3"><u>Keeps:</u>{{ count }}</p>
    </div>
    <div class="container-fluid">
      <div class="row">
        <div v-for="vk in keepsinvault" class="col-md-3 mt-3">
          <KeepCard :keep="vk" />

        </div>
      </div>

    </div>



  </div>
</template>


<script>
import { onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { vaultsService } from '../services/VaultsService.js';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import KeepCard from '../components/KeepCard.vue';
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';

export default {
  props: { keep: { type: Object, required: true } },

  setup() {
    const route = useRoute();
    const router = useRouter();
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
        router.push({ path: '/' })
      }
    }

    return {
      vault: computed(() => AppState.vault),
      count: computed(() => AppState.keepsInVault.length),
      vaults: computed(() => AppState.vault),
      account: computed(() => AppState.account),
      keepsinvault: computed(() => AppState.keepsInVault),

      async makeVaultPrivate() {
        try {
          AppState.vault.isPrivate = !AppState.vault.isPrivate
          await vaultsService.editVault(AppState.vault)
        } catch (error) {
          logger.error
          Pop.error(error.message)
        }
      }
    };
  },
  components: { KeepCard }
}
</script>


<style lang="scss" scoped></style>
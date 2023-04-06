<template>
  <KeepCard />
  <Vault />
</template>


<script>
import { onMounted } from 'vue';
import { keepsService } from '../services/KeepsService.js';
import Vault from '../components/Vault.vue'
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import KeepCard from '../components/KeepCard.vue';
import { profilesService } from '../services/ProfilesService.js'
import { useRoute } from 'vue-router'
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';

export default {
  setup() {
    const route = useRoute()

    onMounted(() => {
      getKeepsById();
      getVaultsById();
      getUserProfile()
    });

    async function getUserProfile() {
      try {
        const profileId = route.params.profileId
        await profilesService.getUserProfile(id)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }

    }


    async function getKeepsById() {
      try {
        await keepsService.getKeepsById(route.params.keepid);
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
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
    // TODO get the profile id from the route at profile page
    // SECTION network requests
    // TODO get the profile based off of the route profileId 
    // TODO get the keeps based off of route profileId
    // TODO get the vaults based off of route profileId
    // in service
    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    };
  },
  components: { KeepCard, Vault }

}
</script>


<style lang="scss" scoped></style>
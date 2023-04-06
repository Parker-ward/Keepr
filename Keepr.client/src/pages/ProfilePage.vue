<template>
  <div>
    <h1>Hello profile page </h1>

    <div> profile: {{ profile?.name }} </div>
    <div> profile:
      <img :src="profile?.picture" alt="">
    </div>
    <div class="container">
      <div class="row">
        <div class="col-md-8">
          <h1><b>Vaults</b></h1>
        </div>
      </div>
    </div>
    <div class="container">
      <div class="row">
        <div v-for="v in vaults" class="col-md-3">
          <!-- <div v-if="account.id == keep.creatorId"> -->
          <Vault :vault="v" />
        </div>
      </div>
    </div>

    <div class="container">
      <div class="row">
        <div class="col-md-8">
          <h1><b>Keeps</b></h1>
        </div>
      </div>
    </div>
    <div class="container">
      <div class="row">
        <div v-for="k in keeps" class="col-md-3">
          <!-- <div v-if="account.id == keep.creatorId"> -->
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </div>
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
import { vaultsService } from '../services/VaultsService.js';

export default {
  setup() {
    const route = useRoute()

    onMounted(() => {
      getKeepsByProfileId();
      getVaultsByProfileId();
      getUserProfile()
    });

    async function getUserProfile() {
      try {
        const profileId = route.params.profileId
        await profilesService.getUserProfile(profileId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }

    async function getKeepsByProfileId() {
      try {
        await keepsService.getProfileKeeps(route.params.profileId);
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    async function getVaultsByProfileId() {
      try {
        await vaultsService.getVaultsByProfileId(route.params.profileId);
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
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.profileKeeps),
      vaults: computed(() => AppState.profileVaults)
    };
  },
  components: { KeepCard, Vault }

}
</script>


<style lang="scss" scoped></style>
<template>
  <div class="rounded-circle delete-btn">
    <div v-if="account.id == keep?.creatorId && route.path == '/'" title="Delete Keep??">
      <button @click="deleteKeep" class="btn btn-danger pt-1 pb-2 rounded delete">Delete</button>
      <!-- TODO this button should only show up if its a vaultkeep and its my vault-->
    </div>
    <button v-if="route.path != '/'" @click="deleteKeepInVault(keep.vaultKeepId)" class="btn btn-info">Delete Vault
      Keep</button>
    <div @click="GetActiveKeep(keep)" data-bs-toggle="modal" data-bs-target="#keepDetails">
      <img class="img-fluid rounded" :src="keep?.img" alt="">
    </div>


    <span class="pt-2 d-flex rounded justify-content-between text-light  p-3 name"><b>{{ keep?.name
    }}</b>
      <router-link :to="{ name: 'Profile', params: { profileId: keep?.creatorId } }">
        <img class="rounded-circle p-2 creator-img" :src="keep?.creator.picture" alt="">
      </router-link>
    </span>


  </div>
</template>


<script>

import { reactive, computed } from 'vue';
import { AppState } from '../AppState.js';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { vaultKeepsService } from '../services/VaultKeepsService.js';
import { useRoute } from 'vue-router';



export default {

  props: { keep: { type: Object, required: true } },
  setup(props) {
    const route = useRoute()
    return {
      route,
      account: computed(() => AppState.account),

      async GetActiveKeep(keep) {
        try {
          await keepsService.GetActiveKeep(keep);
          await keepsService.getKeeps(keep);
        }
        catch (error) {
          logger.log("[get active keep]");
          Pop.error(error);
        }
      },

      async deleteKeep() {
        try {
          if (await Pop.confirm('Are you sure?')) {
            await keepsService.deleteKeep(props.keep.id)
            Pop.toast('success, keep is deleted')
          }
        } catch (error) {
          logger.error
          Pop.error(error)
        }
      },

      async deleteKeepInVault(Id) {
        try {
          if (await Pop.confirm('Are you sure??')) {
            await vaultKeepsService.deleteKeepInVault(Id)
            Pop.toast('success, keep in vault has been deleted')
          }
        } catch (error) {
          logger.error
          Pop.error(error)
        }
      }
    };
  },

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
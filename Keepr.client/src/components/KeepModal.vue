<template>
  <!-- TODO after moving modal here, make sure I still import this component -->

  <div class="modal" tabindex="-1" id="keepDetails">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">{{ keep?.name }}</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
              <h3 class="d-flex justify-content-center"><i class="mdi mdi-eye">{{ keep?.views }}</i>
                <i class="mdi mdi-alpha-k-box-outline">{{
                  keep?.kept }}</i>
              </h3>

            </div>
          </div>
          <div class="container-fluid">
            <div class="row">
              <div class="col-md-6 ">
                <img class="img-fluid pb-2" :src="keep?.img" alt="">
              </div>
              <div class="col-md-6">
                {{ keep?.description }}
              </div>
            </div>
            <div v-if="account.id" class="d-flex justify-content-between">

              <div class="my-2">
                <div>
                  <form v-if="account.id" @submit.prevent="addKeepToVault(keep.id)" class="d-flex">
                    <button @click.stop type="submit" class="btn btn-outline-dark rounded-left d-flex flex-wrap m-auto">
                      Add To Vault
                    </button>
                    <select placeholder="select a deck" @click.stop v-model="editable.vaultId"
                      class="form-select rounded-right w-75 m-auto " aria-label="Default select example">
                      <option v-for="vault in vaults" :value="vault.id" selected>{{
                        vault.name }}</option>
                    </select>
                  </form>
                </div>
              </div>





              <!-- original -->
              <!-- <div class="dropdown">
                <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown"
                  aria-expanded="false">
                  Add to Vault
                </button>
                <button @click.stop type="submit" class="btn btn-outline-dark rounded-left d-flex flex-wrap m-auto">
                  Add To Vault
                </button>
                <ul class="dropdown-menu">
                  <select placeholder="select a deck" @click.stop v-model="editable.value"
                    class="form-select rounded-right w-75 m-auto " aria-label="Default select example">
                    <option v-for="vault in vaults" :value="vault.id" selected>{{
                      vault.name }}</option>
                  </select>
                </ul> -->

              <!-- <select>
                  <li class="selectable p-1" v-for="vault in vaults" :value="vault.id"
                    @click.stop="addKeepToVault(editable.vault, keep.id)">{{
                      vault.name }}</li>
                </select> -->
              <!-- </div> -->


              <router-link v-if="keep?.creatorId" :to="{ name: 'Profile', params: { profileId: keep?.creatorId } }">
                <img data-bs-dismiss="modal" data-bs-target="#keepDetails" class="rounded-circle creator-img"
                  :src="keep?.creator.picture" alt="">
              </router-link>

            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<!-- NOTE bootstrap works in modals!! to get side:side use a col-6 -->

<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { ref } from 'vue';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { vaultKeepsService } from '../services/VaultKeepsService.js';



export default {


  setup() {
    const editable = ref({})
    return {
      editable,
      account: computed(() => AppState.account),
      keep: computed(() => AppState.activeKeep),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.accountVaults),

      async addKeepToVault(keepId) {
        try {

          const vaultId = editable.value
          const body = {
            ...vaultId,
            keepId: keepId
          }
          logger.log('[vaultId]', body)
          if (!vaultId) { Pop.error("select a vault") }
          else {
            await vaultKeepsService.addKeepToVault(body)
            Pop.success("Keep has been added to your vault")
          }
        } catch (error) {
          logger.error(error)
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
}
</style>
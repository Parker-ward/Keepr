<template>
  <div class=" container-fluid bg">
    <div class="container-fluid bg mt-3">
      <div class="row mt-3 me-2">
        <div class="col-md-12 d-flex justify-content-end mt-3 ms-2">
          <button data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-primary">Edit Account</button>
        </div>
      </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Edit Account</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <EditAccount />
          </div>
        </div>
      </div>
    </div>
    <div class="about text-center">
      <!-- NOTE for background img -->
      <img class="img-fluid rounded pt-2 cover-img" :src="account.coverImg" alt="">
      <!-- NOTE ^^^ for backgroung img -->
      <div class="row justify-content-center">
        <div class="col-md-12">
          <img class="rounded-circle prof-img" :src="account.picture" alt="" />
        </div>
      </div>
      <p class="fs-1">{{ account.name }}</p>
      <div class="text-center">
        <p class="fs-4"><u>Keeps:</u>{{ keepCount }}</p>
        <p class="fs-4"><u>Vaults:</u>{{ vaultCount }}</p>
      </div>
    </div>

    <h1 class="text-center mb-5"><b><u>Vaults</u></b></h1>
    <div class="container">
      <div class="row">
        <div class="col-md-8">
        </div>
      </div>
    </div>
    <div class="container-fluid">
      <div class="row">
        <div v-for="v in vaults" class="col-md-3">
          <Vault :vault="v" />
        </div>
      </div>
    </div>
    <h1 class="text-center mb-5"><b><u>Keeps</u></b></h1>
    <div class="container">
      <div class="row">
        <div class="col-md-8">
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
    <!-- </div> -->
  </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue'
import { AppState } from '../AppState'
import EditAccount from '../components/EditAccount.vue';
import KeepCard from '../components/KeepCard.vue';
import Vault from '../components/Vault.vue'
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { useRoute } from 'vue-router';
import { keepsService } from '../services/KeepsService.js';
import { vaultsService } from '../services/VaultsService.js';

export default {
  props: { keep: { type: Object, requried: true } },
  props: { vaults: { type: Object, requried: true } },
  setup() {
    const editable = ref({})
    const route = useRoute()
    // TODO get the profile id from the route

    // SECTION network requests
    // TODO get the profile based off of the route profileId 
    // TODO get the keeps based off of route profileId
    // TODO get the vaults based off of route profileId

    onMounted(() => {

      // getKeepsById()
      getVaultsByProfileId()
      getAccountVaults()
      getAccountKeeps()
    })
    async function getAccountKeeps() {
      try {
        await keepsService.getAccountKeeps(AppState.account.id)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }

    async function getAccountVaults() {
      try {
        await vaultsService.getAccountVaults()
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }

    async function getVaultsByProfileId() {
      try {
        await vaultsService.getVaultsByProfileId(route.params.vaultId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }


    return {
      editable,
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.accountKeeps),
      vaults: computed(() => AppState.accountVaults),
      keepCount: computed(() => AppState.accountKeeps.length),
      vaultCount: computed(() => AppState.accountVaults.length),

    };
  },
  components: { EditAccount },
  components: { KeepCard },
  components: { Vault },
}
</script>

<style scoped>
.bg {
  background-color: #fef6f0;
}

.prof-img {
  height: 200px;
  width: 200px;
  transform: translateY(-30%);
}

.cover-img {}
</style>

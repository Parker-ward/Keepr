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
      <img src="" alt="">
      <!-- NOTE ^^^ for backgroung img -->
      <img class="rounded-circle p-2" :src="account.picture" alt="" />
      <h1>Welcome {{ account.name }}</h1>
      <p>{{ account.name }}</p>
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
    <!-- </div> -->
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import EditAccount from '../components/EditAccount.vue';
import KeepCard from '../components/KeepCard.vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js';

export default {
  props: { keep: { type: Object, requried: true } },
  setup() {
    onMounted(() => {
      getKeeps()
    })
    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        logger.error(error)
        Pop.error(error)

      }
    }
    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { EditAccount },
  components: { KeepCard },
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.bg {
  background-color: #fef6f0;
}
</style>

<template>
  <div class="rounded-circle delete-btn">
    <button v-if="account.id == keep.creatorId" class="btn btn-danger pb-2 rounded delete">Delete</button>
    <div data-bs-toggle="collapse" data-bs-target="#navbarText" @click="GetActiveKeep(keep)">
      <img class="img-fluid rounded" :src="keep.img" alt="">
    </div>
    <span class="pt-2 d-flex justify-content-between text-light elevation-2 py-3 name"><b>{{ keep.name }}</b><img
        class="rounded-circle creator-img" :src="keep.creator.picture" alt=""></span>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
  props: { keep: { type: Object, required: true } },
  setup() {
    return {
      account: computed(() => AppState.account),
      async GetActiveKeep(keep) {
        try {
          await keepsService.GetActiveKeep(keep)
          await keepsService.getKeeps(keep)
        } catch (error) {
          logger.log('[get active keep]')
          Pop.error(error)
        }

      }

    }
  }
}
</script>


<style lang="scss" scoped>
.creator-img {
  height: 40px;
  transform: translateY(30%);
}

.name {
  transform: translateY(-100%)
}

.delete {
  transform: translateY(100%);
  height: 33px;
}
</style>
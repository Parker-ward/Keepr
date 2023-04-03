<template>
  <div class="rounded delete-btn">
    <button v-if="account.id == keep.creatorId" class="btn btn-danger rounded-circle delete"><i
        class="mdi mdi-delete-forever delete-icon "></i></button>
    <div @click="">
      <img class="img-fluid rounded" :src="keep.img" alt="">
      <span class="pt-2 d-flex justify-content-between text-light elevation-2 py-3 name"><b>{{ keep.name }}</b><img
          class="rounded-circle creator-img" :src="keep.creator.picture" alt=""></span>

    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';

export default {
  props: { keep: { type: Object, required: true } },
  setup() {
    return {
      account: computed(() => AppState.account),
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
  height: 30px;
}
</style>
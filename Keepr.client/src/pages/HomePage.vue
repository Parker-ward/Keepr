<template>
  <div class="container-fluid sticky-top">
    <div class="row">
      <div class=" text-center col-md-12 mt-3 fs-4">
        <h1>
          <b>Keepr</b>
        </h1>
      </div>
    </div>
  </div>
  <div class="container-fluid bg">
    <section class="bricks">
      <div v-for="k in keeps" class="">
        <KeepCard :keep="k" />
      </div>
    </section>
  </div>
</template>

<script>
import { onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js'
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue'

export default {
  setup() {
    onMounted(() => {
      getKeeps()
    })
    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    return {
      keeps: computed(() => AppState.keeps)
    }
  },
  components: { KeepCard }
}
</script>

<style scoped lang="scss">
$gap: 5em;

.bricks {
  columns: 300px;
  column-gap: $gap;

  &>div {

    margin-top: $gap;
    display: inline-block;
  }
}

.bg {
  background-color: #fef6f0;

}
</style>

<template>
  <div>{{ keep.img }}</div>
  <!-- TODO move modal from AppVue to here -->
  <!-- TODO after moving modal here, make sure I still import this component -->
</template>


<!-- NOTE bootstrap works in modals!! to get side:side use a col-6 -->

<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';



export default {

  setup() {
    return {
      keep: computed(() => AppState.activeKeep)
    };
  },

}
</script>


<style lang="scss" scoped></style>
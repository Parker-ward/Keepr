<template>
  <div class="about text-center">
    <img class="rounded-circle elevation-3" :src="account.picture" alt="" />
    <h1>Welcome {{ account.name }}</h1>
    <p>{{ account.email }}</p>
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
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>

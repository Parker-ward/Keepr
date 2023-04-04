<template>
  <nav class="navbar navbar-expand-lg navbar-dark elevation-3 bg px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img class="rounded-circle elevation-3" alt=""
          src="https://images.unsplash.com/photo-1560777553-c973b1b7a3c5?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8a2VlcHxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"
          height="45" />
      </div>
      <h1 class="btn btn selectable text-dark"><b>Home</b></h1>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>
          <router-link :to="{ name: 'About' }" class="btn  lighten-30 selectable ">
            <b>About</b>
          </router-link>
        </li>
        <!-- FIXME Figure out why disabled doesn't work -->

        <div class="dropdown">
          <button class="btn btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
            <b>Create</b>
          </button>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#"><button data-bs-toggle="modal" data-bs-target="#createKeepForm"
                  class="btn btn">Create
                  Keep</button></a></li>

            <li><a class="dropdown-item" href="#"><button data-bs-toggle="modal" data-bs-target="#createVaultForm"
                  class="btn btn">Create
                  Vault</button></a></li>
          </ul>
        </div>

      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>

import { computed } from '@vue/reactivity';
import Login from './Login.vue'
import { AppState } from '../AppState.js';
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}

.bg {
  background-color: #fef6f0;
}
</style>

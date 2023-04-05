<template>
  <header class="sticky-top">
    <Navbar />
  </header>
  <main class="bg">
    <router-view />
  </main>
  <footer>
  </footer>
  <!-- NOTE Creat Keep Modal -->
  <div class="modal" tabindex="-1" id="createKeepForm">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Modal title</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <CreateKeep />
        </div>
      </div>
    </div>
  </div>
  <!-- NOTE Create Vault Modal -->
  <div class="modal" tabindex="-1" id="createVaultForm">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Modal title</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <CreateVault />
        </div>
      </div>
    </div>
  </div>
  <!-- NOTE KeepCard Modal -->
  <div class="modal" tabindex="-1" id="keepDetails">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Modal title</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">

        </div>
      </div>
    </div>
  </div>

  <!-- TODO after copy/pasting ^^^^ into the KeepModal component, bring it in here -->
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import CreateKeep from './components/CreateKeep.vue'
import CreateVault from './components/CreateVault.vue'

export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, CreateKeep, CreateVault }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

.bg {
  background-color: #fef6f0;

}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>

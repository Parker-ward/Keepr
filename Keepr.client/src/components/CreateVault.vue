<template>
  <form @submit.prevent="handleSubmit">
    <div class="mb-3">
      <label for="Title" class="form-label">Title</label>
      <textarea required type="text" class="form-control" name="Title" v-model="editable.name" id="title"
        rows="1"></textarea>
    </div>
    <div class="mb-3">
      <label for="img" class="form-label">Img</label>
      <textarea required type="text" class="form-control" name="Img" v-model="editable.img" id="img" rows="1"></textarea>
    </div>
    <div class="mb-3">
      <label for="description" class="form-label">Description</label>
      <textarea required type="text" class="form-control" name="description" v-model="editable.description"
        id="description" rows="4"></textarea>
    </div>
    <div class="text-end">
      <span>Private Vaults can only be seen by you</span>
    </div>
    <div class="d-flex justify-content-end">
      <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
        <label class="form-check-label" for="flexCheckDefault">
          <p>Make Vault Private?</p>
        </label>
      </div>
    </div>
    <div class="text-end">
      <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">
        {{ editable.id ? 'Save Changes' : 'Create Vault' }}
      </button>
    </div>
  </form>
</template>


<script>
import { ref } from 'vue';
import { router } from '../router.js';
import Pop from '../utils/Pop.js';
import { vaultsService } from '../services/VaultsService.js';

export default {
  vault: { type: Object, required: true },

  setup(props) {
    const editable = ref({})
    return {
      editable,
      async handleSubmit() {
        try {
          const vault = await vaultsService.createVault(editable.value)
          editable.value = {}
          if (vault?.id) {
            router.push({ name: 'Vaults', params: { vaultId: vault.id } })
          }
        } catch (error) {
          Pop.error(error, '[submit vault]')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>
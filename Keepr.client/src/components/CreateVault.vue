<template>
  <form @submit.prevent="handleSubmit">
    <div class="mb-3">
      <label for="Title" class="form-label">Title</label>
      <textarea required type="text" class="form-control" name="Title" v-model="editable.title" id="title"
        rows="1"></textarea>
    </div>
    <div class="mb-3">
      <label for="img" class="form-label">Img</label>
      <textarea required type="text" class="form-control" name="Img" v-model="editable.img" id="img" rows="1"></textarea>
    </div>
  </form>
</template>


<script>
import { router } from '../router.js';
import Pop from '../utils/Pop.js';

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
            router.push({ name: 'VaultPage', params: { vaultId: vault.id } })
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
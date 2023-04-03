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
    <div class="mb-3">
      <label for="description" class="form-label">Description</label>
      <textarea required type="text" class="form-control" name="description" v-model="editable.description"
        id="description" rows="4"></textarea>
    </div>
    <div class="text-end">
      <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">
        {{ editable.id ? 'Save Changes' : 'Create Keep' }}
      </button>
    </div>
  </form>
</template>


<script>
import { ref } from 'vue';
import { keepsService } from '../services/KeepsService.js';
import { router } from '../router.js';
import Pop from '../utils/Pop.js';

export default {
  props: {
    keep: { type: Object, required: true }
  },
  setup(props) {
    const editable = ref({})
    return {
      editable,
      async handleSubmit() {
        try {
          const keep = await keepsService.createKeep(editable.value)
          editable.value = {}
          if (keep?.id) {
            router.push({ name: 'Home', params: { home: '/' } })
          }
        } catch (error) {
          Pop.error(error, '[cant submit keep]')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>
<template>
  <div class="card">
    <!-- <div class="containter rounded elevation-1"> -->
    <!-- <router-link :to="{ name: 'RecipeDetails', params: { keepId: keep.id } }"> -->
    <img class="img-fluid rounded" :src="keep.img" alt="">
    <span class="pt-2 d-flex justify-content-between circle text-dark text-center">{{ keep.name }} <img
        :src="keep.creator.picture" alt=""></span>
    <div class=""><span> {{ keep.category }}</span>
    </div>
    <!-- </router-link> -->
  </div>
  <!-- </div> -->
</template>


<script>
export default {
  props: { keep: { type: Object, required: true } },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped></style>
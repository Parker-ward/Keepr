<template>
  <img :src="vault.img" alt="">
  {{ vault.name }}
</template>


<script>
export default {
  props: { vault: { type: Object, required: true } },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped></style>
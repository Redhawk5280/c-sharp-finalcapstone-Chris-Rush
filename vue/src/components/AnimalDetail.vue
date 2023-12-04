<template>
  <div class="details">
    <h1>Animal Details</h1>
    <img :src="animal.photoSrc" alt="">
    <p>ID: {{ animal.id }}</p>
    <p>Name: {{ animal.name }}</p>
  </div>
</template>

<script>
export default {
  props: ['animal'],

}
</script>

<style scoped>
  .details{
    text-align: center;
  }

</style>
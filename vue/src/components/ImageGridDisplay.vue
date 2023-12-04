<template>
    <div class="grid">
      <img v-for="image in this.images" :key="image.imageId" :src="image.imageString">
    </div>
  </template>
  
  <script>
    export default {
      props: {
        images: {
          type: Array,
          required: true
        }
      }
    }
  </script>
  
  <style scoped>
  
  img {
    max-width: 250px;
  }
  
  </style>
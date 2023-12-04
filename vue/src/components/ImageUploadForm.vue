<template>
    <form @submit.prevent="onSubmit">
      <p>Select an image to upload. {{ this.x }}</p>
      <img class="image-preview" v-bind:src="image"/>
      <div>
        <input v-on:change="loadImage" type="file" accept="image/*">
      </div>
      <div>
        <button type="submit">Upload</button>
      </div>
    </form>
  </template>
  
  <script>
  import imageService from '@/services/ImageService.js'
  
  export default {
    data() {
      return {
        image: null,
        imageFile: null,
      }
    },
    methods: {
      loadImage(e) {
        this.imageFile = e.target.files[0];
        const reader = new FileReader();
        reader.onload = (evt) => {
          this.image = evt.target.result;
        };
        reader.readAsDataURL(this.imageFile);
      },
  
      onSubmit() {
        imageService.uploadImage({ imageString: this.image }).then(res => {
          console.log(this.image);
          this.image = null;
          this.imageFile = null;
          this.$router.go();
        });
      }
  
    }
  }
  </script>
  
  
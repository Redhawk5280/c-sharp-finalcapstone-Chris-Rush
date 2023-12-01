<template>
  <div class="imagePreviewWrapper">
    <img v-bind:src="image" />
    <input type="file" v-on:change="loadImage" />
    <button v-on:click="saveImage">Save</button>
  </div>
</template>

<script>
import imageService from "../services/ImageService.js";

export default {
  data() {
    return {
      image: null,
      imageFile: null,
    };
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
    saveImage() {
        imageService.addImage(this.imageFile).catch((err) => {
        console.error(err);
      });
    },
  },
};
</script>

<style scoped>
.imagePreviewWrapper {
  display: flex;
  flex-direction: column;
}
.imagePreviewWrapper img {
  height: 20em;
  width: 20em;
}
.imagePreviewWrapper button {
  width: 20em;
}
</style>
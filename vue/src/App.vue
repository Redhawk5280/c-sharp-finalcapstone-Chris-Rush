<template>
  <div id="capstone-app">
    <header-component />
    <router-view />
  </div>
</template>

<script>
import animalService from "./services/AnimalService";
import HeaderComponent from "./components/Header.vue";

export default {
  mounted() {
    animalService.getAnimals().then(response => {
      this.animals = response.data;
      this.$store.commit('SET_ANIMALS', response.data);
    }).catch(error => {
      console.log("There was an error");
    });
  },
  components: {
    HeaderComponent
  }
};




</script>

<style scoped>

  
</style>



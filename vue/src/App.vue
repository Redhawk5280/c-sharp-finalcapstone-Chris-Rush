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
      this.$store.state.animals = response.data;
      //this.animals = result.data;
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



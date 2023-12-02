<template>
  <div class="home">
    <h1>Welcome to Paw Prints Pet Rescue</h1>
    <animal-list 
      v-bind:animals="animals"
    />
  </div>
</template>

<script>
import AnimalList from "../components/AnimalList.vue";
import animalServices from "../services/AnimalService"

export default {
  components: {
    AnimalList,
  },
  data() { 
    return {
      animals: {},
      isLoading: true,
    }
  },
  methods: {
    // getAnimals() { 
    //   animalServices.getAnimals()
    //     .then(response => { 
    //       this.animals = response.data;
    //       this.isLoading = false;
    //     })

    // }
  },
  // created() { 
  //   this.retrieveBoards();
  // }
};
</script>

<style scoped>
  .home {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
  }
</style>

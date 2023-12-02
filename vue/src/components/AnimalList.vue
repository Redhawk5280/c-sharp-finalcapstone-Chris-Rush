<template>
  <div class="animalList">
    <animal-card 
      v-for="animal in animals" 
      v-bind:key="animal.id"
      v-bind:animal="animal" 
      v-on:click="goToDetails(animal.id)"
      class="animalCard"
    />
  </div>
</template>

<script>

  import AnimalCard from "../components/AnimalCard.vue"
import animalService from "../services/AnimalService";
export default {
    components: {
      AnimalCard,
    },
    data() { 
      return {
        animals: [
          {id: 1, name: "animal 1"},
          {id: 2, name: "animal 2"}
        ],
        isLoading: false,
      }
  },
  methods: {
    goToDetails(id) { 
      this.$router.push({ name: 'animalDetails', params: {id: id} })
    }
  },
    created() { 
      // TODO: uncomment this eventually
        // this.isLoading = true;
        // animalService.getAnimals()
        //   .then(response => { 
        //     this.animals = response.data;
        //     this.isLoading = false;
        //   })
        //   .catch(error => {
        //     console.error("Error fetching animals:", error);
        //     this.isLoading = false;
        //   });
    }
  }
</script>

<style scoped>
  .animalList {
    height: 100%;
    width: 100%;
    display: grid;
    grid-template-columns: repeat(5, 1fr);
    grid-gap: 1.25rem;
  }

  .animalList .animalCard{
  }

  @media only screen and (max-width: 639px) {
    .animalList {
      grid-template-columns: 1fr;
    }
  }

  @media only screen and (min-width: 640px) and (max-width: 1023px) {
    /* Styles for landscape smartphones and tablets in portrait mode */
    .animalList {
      grid-template-columns: repeat(3, 1fr);
    }
  }

  @media only screen and (min-width: 1024px) and (max-width: 1439px) {
    /* Styles for larger devices like tablets in landscape and smaller desktops */
    .animalList {
      grid-template-columns: repeat(5, 1fr);
    }
  }

  @media only screen and (min-width: 1440px) {
    /* Styles for extra large devices like large desktops and TVs */
    .animalList {
      grid-template-columns: repeat(6, 1fr);
    }
  }

</style>
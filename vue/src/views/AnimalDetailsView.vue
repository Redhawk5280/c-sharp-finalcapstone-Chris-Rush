<template>
  <button v-on:click="goToHome">Home</button>
  <h1>Details</h1>
  <animal-details v-bind:animal="animal"/>
</template>

<script>
import animalDetails from "../components/AnimalDetail.vue"

export default {
  components: {
    animalDetails,
  },
  data() { 
    return {
      animal: null
    }
  },
  created() { 
    this.fetchAnimalDetails();
  },
  methods: {
    fetchAnimalDetails() { 
      const id = this.$route.params.id;
      // TODO: Uncomment and use when API is ready
      // animalService.getAnimal(id)
      //   .then(response => {
      //     this.animal = response.data;
      //   })
      //   .catch(error => {
      //     console.error('Error fetching animal details:', error);
      //   });

      //mock data for testing
      this.animal = {id: id, name: "Test Animal"}
    },
    goToHome() { 
      this.$router.push({ name: 'home' });
    }
  }
}
</script>

<style scoped>

</style>
<template>
  <section id="detailsView">
    <h1>Details</h1>
    <animal-details v-bind:animal="animal"/>
  </section>
</template>

<script>
import AnimalDetails from "../components/AnimalDetail.vue";
import animalService from "../services/AnimalService"; // Ensure this import is correct

export default {
  components: {
    AnimalDetails,
  },
  data() {
    return {
      animal: null,
    };
  },
  created() {
    this.fetchAnimalDetails();
  },
  methods: {
    fetchAnimalDetails() {
      const id = parseInt(this.$route.params.id);
      // First, try to get the animal from the Vuex store
      const animalFromStore = this.$store.state.animals.find(a => a.id === id);
      if (animalFromStore) {
        this.animal = animalFromStore;
      } else {
        // If not in store, fetch from the API
        animalService.getAnimal(id)
          .then(response => {
            this.animal = response.data;
          })
          .catch(error => {
            console.error('Error fetching animal details:', error);
          });
      }
    },
    goToHome() {
      this.$router.push({ name: 'home' });
    }
  }
};
</script>

<style scoped>
  #detailsView {
    display: flex;
    flex-direction: column;
    align-items:center;
    justify-content: center;
  }
</style>

<template>
  <section id="detailsView">
    <h1>Hello new friend!</h1>
    <animal-details v-bind:animal="animal" v-if="isLoading == false"/>
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
      isLoading: true,
      animal: null,
    };
  },
  created() {
    animalService.getAnimal(this.$route.params.id).then(response => {
      this.animal = response.data;
      this.isLoading = false;
      console.log(this.$route.params.id);
    }).catch(error => {
      console.log("There was an error");
    });
  },
  methods: {
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
    font-family: var(--card-body-font);
  }
  
</style>
